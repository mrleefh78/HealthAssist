using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PrincipalDependentDAL : BaseDAL 
    {
        public PrincipalDependentDAL()
        {

        }

        private static string TABLE_PATIENT_DEPENDENT = ConstantConfiguration.TABLE_PATIENT_DEPENDENT;
        private static string COLUMN_PATIENT_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_PRINCIPAL_PATIENT_NO = ConstantConfiguration.COLUMN_PRINCIPAL_PATIENT_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE_REG = ConstantConfiguration.COLUMN_DATE_REG;
        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;
        private static string COLUMN_MIDDLENAME = ConstantConfiguration.COLUMN_MIDDLENAME;
        private static string COLUMN_DOB = ConstantConfiguration.COLUMN_DOB;
        private static string COLUMN_GENDER = ConstantConfiguration.COLUMN_GENDER;
        private static string COLUMN_PHONE = ConstantConfiguration.COLUMN_PHONE;
        private static string COLUMN_MOBILE = ConstantConfiguration.COLUMN_MOBILE;
        private static string COLUMN_EMAIL = ConstantConfiguration.COLUMN_EMAIL;
        private static string COLUMN_ADDRESS = ConstantConfiguration.COLUMN_ADDRESS;
        private static string COLUMN_NATIONALITY = ConstantConfiguration.COLUMN_NATIONALITY;

        private string strSql;
        public DataSet SelectAllPatient()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DEPENDENT + "  WHERE IFnull(IsDeleted,0) = 0 ";

            return Select(strSql);
        }
        public DataSet SelectByPatientID(PatientModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DEPENDENT + " " +
                     "WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.ID + "' AND IsDeleted <> 1 ";

            return Select(strSql);
        }
        public DataSet SelectByPatientNo(PatientModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DEPENDENT + " " +
                     "WHERE " + COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachPatient(string keyword)
        {

            strSql = "SELECT *  " +
                     "FROM " + TABLE_PATIENT_DEPENDENT + " Where 1=1 and IsDeleted = 0 ";

            if (keyword != "")
            {
                strSql = strSql + "AND (" + COLUMN_FIRSTNAME + " like '%" + keyword + "%' OR  " +
                    "" + COLUMN_LASTNAME + " like '%" + keyword + "%' OR " +
                    "" + COLUMN_PATIENT_NO + " = '" + keyword + "') ";
            }


            return Select(strSql);
        }
        public void InsertPatient(string currUser, PatientModel oClass)
        {
            strSql = "Set @PatientNo = (SELECT Concat('PT',CAST(DATE_FORMAT(curdate(),'%Y%m') AS CHAR(6)), '0001')); " +
                     "Set @LastPatientNo = (SELECT Concat('PT', Cast(right(PatientNo,10) + 1 AS CHAR(10))) From " + TABLE_PATIENT_DEPENDENT + " " +
                     "where  CAST(left(right(" + COLUMN_PATIENT_NO + ",10) ,6) as CHAR (4)) =  CAST(Year(curdate()) as CHAR(4)) " +
                     "and right(left(right(" + COLUMN_PATIENT_NO + ",10) ,6), 2)  =  DATE_FORMAT(curdate(),'%m') " +
                     "order by id desc Limit 1);" +
                     "Set @PatientNo = IF (@LastPatientNo <> '',  @LastPatientNo,  @PatientNo); ";

            strSql = strSql + "INSERT INTO " + TABLE_PATIENT_DEPENDENT + " (" +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE_REG + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_MIDDLENAME + ", " +
                        COLUMN_DOB + ", " +
                        COLUMN_GENDER + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_NATIONALITY + ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values (@PatientNo,'" +
                    oClass.DateRegister.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.LastName.Replace("'", "") + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.MiddleName.Replace("'", "") + "', '" +
                    oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Gender + "', '" +
                    oClass.ContactNo + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Nationality.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }

        public int InsertNewPatient(string currUser, PatientModel oClass)
        {
            strSql = "Set @PatientNo = (SELECT Concat('PT',CAST(DATE_FORMAT(curdate(),'%Y%m') AS CHAR(6)), '0001')); " +
                     "Set @LastPatientNo = (SELECT Concat('PT', Cast(right(PatientNo,10) + 1 AS CHAR(10))) From " + TABLE_PATIENT_DEPENDENT + " " +
                     "where  CAST(left(right(" + COLUMN_PATIENT_NO + ",10) ,6) as CHAR (4)) =  CAST(Year(curdate()) as CHAR(4)) " +
                     "and right(left(right(" + COLUMN_PATIENT_NO + ",10) ,6), 2)  =  DATE_FORMAT(curdate(),'%m') " +
                     "order by id desc Limit 1);" +
                     "Set @PatientNo = IF (@LastPatientNo <> '',  @LastPatientNo,  @PatientNo); ";

            strSql = strSql + "INSERT INTO " + TABLE_PATIENT_DEPENDENT + " (" +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE_REG + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_MIDDLENAME + ", " +
                        COLUMN_DOB + ", " +
                        COLUMN_GENDER + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_NATIONALITY + ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values (@PatientNo,'" +
                    oClass.DateRegister.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.LastName.Replace("'", "") + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.MiddleName.Replace("'", "") + "', '" +
                    oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Gender + "', '" +
                    oClass.ContactNo + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Nationality.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    "); ";


            return SaveDataReturn(strSql);


        }
        public void UpdatePatient(string user, PatientModel oClass)
        {

            strSql = "UPDATE " + TABLE_PATIENT_DEPENDENT + " SET " +
                COLUMN_LASTNAME + " = '" + oClass.LastName.Replace("'", "''") + "', " +
                COLUMN_FIRSTNAME + " = '" + oClass.FirstName + "', " +
                COLUMN_MIDDLENAME + " = '" + oClass.MiddleName + "', " +
                COLUMN_DOB + " = '" + oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_GENDER + " = '" + oClass.Gender + "', " +
                COLUMN_PHONE + " = '" + oClass.ContactNo + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "''") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                COLUMN_NATIONALITY + " = '" + oClass.Nationality.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeletePatient(string user, PatientModel oClass)
        {

            strSql = "UPDATE " + TABLE_PATIENT_DEPENDENT + " SET " +
                " isDeleted = 1, " +
                " ReasonDelete = '" + oClass.ReasonDelete.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
    }
}