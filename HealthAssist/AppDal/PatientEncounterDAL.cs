using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientEncounterDAL : BaseDAL
    {

        public PatientEncounterDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_ENCOUNTER;

        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_ENCOUNTER_DATE;
        private static string COLUMN_ENCOUNTER_NO = ConstantConfiguration.COLUMN_ENCOUNTER_NO;
        private static string COLUMN_TYPE = ConstantConfiguration.COLUMN_ENCOUNTER_TYPE;
        private static string COLUMN_INSURANCE = ConstantConfiguration.COLUMN_INSURANCE;
        private static string COLUMN_INSURANCE_NO = ConstantConfiguration.COLUMN_INSURANCE_NO;
        private static string COLUMN_PHYSICIAN = ConstantConfiguration.COLUMN_PHYSICIAN_ID;
        private static string COLUMN_HOSPITAL = ConstantConfiguration.COLUMN_FACILITY_ID;
        private static string COLUMN_STATUS = ConstantConfiguration.COLUMN_STATUS;
        private static string COLUMN_DISPOSITION_ID = ConstantConfiguration.COLUMN_DISPOSITION_ID;
        private static string COLUMN_REST_DAYS = ConstantConfiguration.COLUMN_REST_DAYS;
        private static string COLUMN_FOLLOW_UP_DATE = ConstantConfiguration.COLUMN_FOLLOW_UP_DATE;
        private static string COLUMN_WORK_RESTRICTION = ConstantConfiguration.COLUMN_WORK_RESTRICTION;
        private static string COLUMN_REMARKS = ConstantConfiguration.COLUMN_REMARKS;     

        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     " d.FacilityName, E.CompanyName, F.dname as Status, C.Rate " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_PHYSICIAN + " C ON C.ID = A." + COLUMN_PHYSICIAN + " Left Outer Join " +
                     ConstantConfiguration.TABLE_FACILITY + " D ON D.ID = A." + COLUMN_HOSPITAL + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_CASE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A.IsDeleted = 0 order by F.dname desc";

            return Select(strSql);
        }


        public DataSet SelectByID(PatientCaseModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByPhysician(PatientEncounterModel oClass)
        {
            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     " d.FacilityName, E.CompanyName, F.dname as Status, Ins.CompanyName as Employer " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_PHYSICIAN + " C ON C.ID = A." + COLUMN_PHYSICIAN + " Left Outer Join " +
                     ConstantConfiguration.TABLE_FACILITY + " D ON D.ID = A." + COLUMN_HOSPITAL + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                      ConstantConfiguration.TABLE_PATIENT_INSURANCE + " Ins ON Ins.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_CASE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A." + COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "' ";

            return Select(strSql);
        }
        public DataSet SelectByCaseNo(PatientEncounterModel oClass)
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

        public DataSet SelectByEncounterNo(PatientEncounterModel oClass)
        {
            strSql = "SELECT A.*, Concat(B.FirstName, ' ',B.LastName) as PatientName, B.dob, b.gender, b.address, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     "c.licenseNo, d.FacilityName, E.CompanyName, F.dname as Status, G.dname as Disposition " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_PHYSICIAN + " C ON C.ID = A." + COLUMN_PHYSICIAN + " Left Outer Join " +
                     ConstantConfiguration.TABLE_FACILITY + " D ON D.ID = A." + COLUMN_HOSPITAL + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_CASE_STATUS + " F ON F.ID = A." + COLUMN_STATUS + " Left Outer Join " +
                      ConstantConfiguration.TABLE_DISPOSITION + " G ON G.ID = A." + COLUMN_DISPOSITION_ID +
                     " WHERE A." + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

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
        public void InsertData(string currUser, PatientEncounterModel oClass)
        {
            strSql = "Set @EncounterNo = (SELECT Concat('EN',CAST(DATE_FORMAT(curdate(),'%Y%m') AS CHAR(6)), '0001')); " +
                      "Set @LastNo = (SELECT Concat('EN', Cast(right(EncounterNo,10) + 1 AS CHAR(10))) From " + TABLE_NAME + " " +
                      "where  CAST(left(right(" + COLUMN_ENCOUNTER_NO + ",10) ,6) as CHAR (4)) =  CAST(Year(curdate()) as CHAR(4)) " +
                      "and right(left(right(" + COLUMN_ENCOUNTER_NO + ",10) ,6), 2)  =  DATE_FORMAT(curdate(),'%m') " +
                      "order by id desc Limit 1);" +
                      "Set @EncounterNo = IF (@LastNo <> '',  @LastNo,  @EncounterNo); ";

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                         COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_TYPE + ", " +
                        COLUMN_INSURANCE + ", " +
                        COLUMN_INSURANCE_NO + ", " +
                        COLUMN_PHYSICIAN + ", " +
                        COLUMN_HOSPITAL + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_REMARKS + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values (@EncounterNo,'" +
                    oClass.CaseNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.EncounterDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.EncounterType + "', '" +
                    oClass.InsuranceCompanyID + "', '" +
                    oClass.InsuranceNo.Replace("'", "") + "', '" +
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

        public void InsertNewEncounterData(string currUser, PatientEncounterModel oClass, PatientAssessmentModel assessmentModel, PatientVitalsModel vitalsModel)
        {
            strSql = "Set @EncounterNo = (SELECT Concat('EN',CAST(DATE_FORMAT(curdate(),'%Y%m') AS CHAR(6)), '0001')); " +
                      "Set @LastNo = (SELECT Concat('EN', Cast(right(EncounterNo,10) + 1 AS CHAR(10))) From " + TABLE_NAME + " " +
                      "where  CAST(left(right(" + COLUMN_ENCOUNTER_NO + ",10) ,6) as CHAR (4)) =  CAST(Year(curdate()) as CHAR(4)) " +
                      "and right(left(right(" + COLUMN_ENCOUNTER_NO + ",10) ,6), 2)  =  DATE_FORMAT(curdate(),'%m') " +
                      "order by id desc Limit 1);" +
                      "Set @EncounterNo = IF (@LastNo <> '',  @LastNo,  @EncounterNo); ";

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                         COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_TYPE + ", " +
                        COLUMN_INSURANCE + ", " +
                        COLUMN_INSURANCE_NO + ", " +
                        COLUMN_PHYSICIAN + ", " +
                        COLUMN_HOSPITAL + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_REMARKS + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values (@EncounterNo,'" +
                    oClass.CaseNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.EncounterDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.EncounterType + "', '" +
                    oClass.InsuranceCompanyID + "', '" +
                    oClass.InsuranceNo.Replace("'", "") + "', '" +
                    oClass.PhysicianID + "', '" +
                    oClass.HospitalID + "', '" +
                    oClass.StatusID + "', '" +
                    oClass.Remarks.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    "); ";

            var patientVitalDAL = new PatientVitalsDAL();

            strSql = strSql + patientVitalDAL.InsertData();

            strSql = strSql + "values (@EncounterNo,'" +
                    vitalsModel.PatientNo + "', '" +
                    vitalsModel.Temperature + "', '" +
                    vitalsModel.Systolic + "', '" +
                    vitalsModel.Diastolic + "', '" +
                    vitalsModel.PulseRate + "', '" +
                   vitalsModel.Height + "', '" +
                    vitalsModel.Weight + "', '" +
                   vitalsModel.BloodSugar + "', '" +
                   vitalsModel.Notes.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    "); ";

            var patientAssessmentDAL = new PatientAssessmentDAL();

            strSql = strSql + patientAssessmentDAL.InsertData();

            strSql = strSql + "values (@EncounterNo,'" +
                    assessmentModel.PatientNo + "', '" +
                    assessmentModel.ChiefComplaint.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    "); ";

            var logModel = new PatientEncounterLogModel();
            var logDal = new PatientEncounterLogDAL();

            strSql = strSql + logDal.InsertData();

            strSql = strSql + "values (@EncounterNo,'" +
                   oClass.PatientNo + "', '" +
                   DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.StatusID + "', '" +
                   currUser + "', " +
                   "CurDate(), '" +
                   currUser + "', " +
                   "CurDate() " +
                   "); ";

          
            SaveData(strSql);


        }
        public void UpdateData(string user, PatientEncounterModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_DATE + " = '" + oClass.EncounterDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_TYPE + " = '" + oClass.EncounterType + "', " +
                COLUMN_INSURANCE + " = '" + oClass.InsuranceCompanyID + "', " +
                COLUMN_INSURANCE_NO + " = '" + oClass.InsuranceNo.Replace("'", "''") + "', " +
                COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "', " +
                COLUMN_HOSPITAL + " = '" + oClass.HospitalID + "', " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                COLUMN_REMARKS + " = '" + oClass.Remarks.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }

        public void UpdateDataStatus(string user, PatientEncounterModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            SaveData(strSql);
        }

        public void UpdateEncounterDoctorData(string user, PatientEncounterModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                COLUMN_DISPOSITION_ID + " = '" + oClass.DispositionID + "', " +
                COLUMN_REST_DAYS + " = '" + oClass.NoOfDays + "', " +
                COLUMN_FOLLOW_UP_DATE + " = '" + oClass.FollowUpDate + "', " +
                COLUMN_WORK_RESTRICTION + " = '" + oClass.WorkRestriction.Replace("'", "''").Replace("\r\n", "</br>") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }


        public void UpdateEncounterData(string currUser, PatientEncounterModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_DATE + " = '" + oClass.EncounterDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_TYPE + " = '" + oClass.EncounterType + "', " +
                COLUMN_INSURANCE + " = '" + oClass.InsuranceCompanyID + "', " +
                COLUMN_INSURANCE_NO + " = '" + oClass.InsuranceNo.Replace("'", "''") + "', " +
                COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "', " +
                COLUMN_HOSPITAL + " = '" + oClass.HospitalID + "', " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                COLUMN_REMARKS + " = '" + oClass.Remarks.Replace("'", "''") + "', " +
                " updated_by = '" + currUser + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo  + "'; ";


            SaveData(strSql);
        }
        public void DeleteData(string user, PatientEncounterModel oClass)
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