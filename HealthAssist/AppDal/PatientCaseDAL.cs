using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientCaseDAL : BaseDAL
    {
        public PatientCaseDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_CASE;

        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_CASE_DATE;
        private static string COLUMN_TYPE = ConstantConfiguration.COLUMN_TYPE;
        private static string COLUMN_INSURANCE = ConstantConfiguration.COLUMN_INSURANCE;
        private static string COLUMN_INSURANCE_NO = ConstantConfiguration.COLUMN_INSURANCE_NO;
        private static string COLUMN_START_DATE = ConstantConfiguration.COLUMN_START_DATE;
        private static string COLUMN_END_DATE = ConstantConfiguration.COLUMN_END_DATE;
        private static string COLUMN_PHYSICIAN = ConstantConfiguration.COLUMN_PHYSICIAN_ID;
        private static string COLUMN_HOSPITAL = ConstantConfiguration.COLUMN_FACILITY_ID;
        private static string COLUMN_STATUS = ConstantConfiguration.COLUMN_STATUS;
         private static string COLUMN_REMARKS = ConstantConfiguration.COLUMN_REMARKS;

        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;

     
        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     " d.FacilityName, E.CompanyName, F.dname as Status " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." + 
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_PHYSICIAN + " C ON C.ID = A." + COLUMN_PHYSICIAN + " Left Outer Join " +
                     ConstantConfiguration.TABLE_FACILITY + " D ON D.ID = A." + COLUMN_HOSPITAL + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_CASE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A.IsDeleted = 0";

            return Select(strSql);
        }

      
        public DataSet SelectByID(PatientCaseModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SelectByCaseNo(PatientCaseModel oClass)
        {
            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     " d.FacilityName, E.CompanyName, F.dname as Status " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_PHYSICIAN + " C ON C.ID = A." + COLUMN_PHYSICIAN + " Left Outer Join " +
                     ConstantConfiguration.TABLE_FACILITY + " D ON D.ID = A." + COLUMN_HOSPITAL + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_CASE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A." + COLUMN_CASE_NO + " = '" + oClass.CaseNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string fname, string lname, string patientNo, string caseNo)
        {

            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName  " +
                     "FROM " + TABLE_NAME + " A INNER JOIN " + ConstantConfiguration.TABLE_PATIENT + " B on A.PatientNo = B.PatientNo  Where 1=1 and A.IsDeleted = 0 ";

            if (fname != "")
            {
                strSql = strSql + "AND B." + COLUMN_FIRSTNAME + " like '%" + fname + "%' ";
            }
            if (lname != "")
            {
                strSql = strSql + "AND B." + COLUMN_LASTNAME + " like '%" + lname + "%' ";
            }
            if (patientNo != "")
            {
                strSql = strSql + "AND " + COLUMN_PATIENT_NO + " = '" + patientNo + "' ";
            }
            if (caseNo != "")
            {
                strSql = strSql + "AND A." + COLUMN_CASE_NO + " like '%" + caseNo + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PatientCaseModel oClass)
        {
            strSql = "Set @CaseNo = (SELECT Concat(CAST(DATE_FORMAT(curdate(),'%Y') AS CHAR(4)),'-', '0001','0',CAST(DATE_FORMAT(curdate(),'%d') AS CHAR(2)),'0', CAST(DATE_FORMAT(curdate(),'%m') AS CHAR(2))));  " +
                     "Set @LastCaseNo = (SELECT Concat(CAST(DATE_FORMAT(curdate(),'%Y') AS CHAR(4)),'-',Left(Right(CaseNo,10),4) + 1, '0',CAST(DATE_FORMAT(curdate(),'%d') AS CHAR(2)),'0', CAST(DATE_FORMAT(curdate(),'%m') AS CHAR(2))) FROM " + ConstantConfiguration.TABLE_PATIENT_CASE + " " +
                     "where  CAST(left(CaseNo,4) as CHAR (4)) =  CAST(Year(curdate()) as CHAR(4)) " +
                     "and Left(Right(CaseNo,5),2) = DATE_FORMAT(curdate(),'%d') " +
                     "and Right(CaseNo,2) = DATE_FORMAT(curdate(),'%m') order by id desc Limit 1); " +
                     "Set @CaseNo = IF (@LastCaseNo <> '',  @LastCaseNo,  @CaseNo); ";

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_TYPE + ", " +
                        COLUMN_INSURANCE + ", " +
                        COLUMN_INSURANCE_NO + ", " +
                        COLUMN_START_DATE + ", " +
                        COLUMN_END_DATE + ", " +
                        COLUMN_PHYSICIAN + ", " +
                        COLUMN_HOSPITAL + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_REMARKS + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values (@CaseNo,'" +
                    oClass.PatientNo+ "', '" +
                    oClass.CaseDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.ServiceType + "', '" +
                    oClass.InsuranceCompanyID + "', '" +
                    oClass.InsuranceNo.Replace("'", "") + "', '" +
                    oClass.StartDate + "', '" +
                    oClass.EndDate + "', '" +
                    oClass.PhysicianID + "', '" +
                    oClass.HospitalID + "', '" +
                    oClass.StatusID + "', '" +
                    oClass.Remarks.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PatientCaseModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_DATE + " = '" + oClass.CaseDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_TYPE + " = '" + oClass.ServiceType + "', " +
                COLUMN_INSURANCE + " = '" + oClass.InsuranceCompanyID + "', " +
                COLUMN_INSURANCE_NO + " = '" + oClass.InsuranceNo.Replace("'", "''") + "', " +
                COLUMN_START_DATE + " = '" + oClass.StartDate + "', " +
                COLUMN_END_DATE + " = '" + oClass.EndDate + "', " +
                COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "', " +
                COLUMN_HOSPITAL + " = '" + oClass.HospitalID + "', " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                COLUMN_REMARKS + " = '" + oClass.Remarks.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientCaseModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                " isDeleted = 1, " +
                " ReasonDelete = '" + oClass.ReasonDelete.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
    }
}