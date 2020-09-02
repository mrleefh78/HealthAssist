using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientAssessmentDAL: BaseDAL 
    {
        public PatientAssessmentDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_ASSESSMENT;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_ENCOUNTER_NO = ConstantConfiguration.COLUMN_ENCOUNTER_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_CHIEF_COMPLAINT = ConstantConfiguration.COLUMN_CHIEF_COMPLAINT;
        private static string COLUMN_HPI = ConstantConfiguration.COLUMN_HPI;
        private static string COLUMN_ROS = ConstantConfiguration.COLUMN_ROS;
        private static string COLUMN_PFSH = ConstantConfiguration.COLUMN_PFSH;
        private static string COLUMN_PHYSICAL_EXAM = ConstantConfiguration.COLUMN_PHYSICAL_EXAM;
        private static string COLUMN_PHYSICIAN_NOTE = ConstantConfiguration.COLUMN_PHYSICIAN_NOTE;
      
        private static string TABLE_PATIENT = ConstantConfiguration.TABLE_PATIENT;
        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;

        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " Where IsDeleted = 0 ";

            return Select(strSql);
        }
        public DataSet SelectByID(PatientAssessmentModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByEncounterNo(PatientAssessmentModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo  + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(PatientAssessmentModel oClass)
        {
            string fname = "";
            string lname = "";
            string patientNo = oClass.PatientNo;
            string caseNo = oClass.EncounterNo;

            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName  " +
                     "FROM " + TABLE_NAME + " A INNER JOIN " + TABLE_PATIENT + " B on A.PatientNo = B.PatientNo  Where 1=1 and A.IsDeleted = 0 ";

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
                strSql = strSql + "AND A." + COLUMN_PATIENT_NO + " = '" + patientNo + "' ";
            }
            if (caseNo != "")
            {
                strSql = strSql + "AND A." + COLUMN_ENCOUNTER_NO + " like '%" + caseNo + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PatientAssessmentModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_CHIEF_COMPLAINT + ", " +
                        COLUMN_HPI + ", " +
                        COLUMN_ROS + ", " +
                        COLUMN_PFSH + ", " +
                        COLUMN_PHYSICAL_EXAM + ", " +
                        COLUMN_PHYSICIAN_NOTE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.EncounterNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.ChiefComplaint.Replace("'", "") + "', '" +
                    oClass.HPI.Replace("'", "") + "', '" +
                    oClass.ROS.Replace("'", "") + "', '" +
                    oClass.PFSC.Replace("'", "") + "', '" +
                    oClass.PhysicalExam.Replace("'", "") + "', '" +
                    oClass.PhysicianNote.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }

        public string InsertData()
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_CHIEF_COMPLAINT + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
          
            return strSql;


        }
        public void UpdateData(string user, PatientAssessmentModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "', " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_CHIEF_COMPLAINT + " = '" + oClass.ChiefComplaint + "', " +
                COLUMN_HPI + " = '" + oClass.HPI.Replace("'", "''") + "', " +
                COLUMN_ROS + " = '" + oClass.ROS.Replace("'", "''") + "', " +
                COLUMN_PFSH + " = '" + oClass.PFSC.Replace("'", "''") + "', " +
                COLUMN_PHYSICAL_EXAM + " = '" + oClass.PhysicalExam.Replace("'", "''") + "', " +
                COLUMN_PHYSICIAN_NOTE + " = '" + oClass.PhysicianNote.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }

        public void UpdateDataByEncounter(string user, PatientAssessmentModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_CHIEF_COMPLAINT + " = '" + oClass.ChiefComplaint + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientAssessmentModel oClass)
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