using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientFileDAL :BaseDAL
    {

        public PatientFileDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_DIAGNOSIS;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_ENCOUNTER_NO = ConstantConfiguration.COLUMN_ENCOUNTER_NO;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_START_DATE;
        private static string COLUMN_CODE = ConstantConfiguration.COLUMN_CODE;
        private static string COLUMN_DESCRIPTION = ConstantConfiguration.COLUMN_DESCRIPTION;
        private static string COLUMN_NOTES = ConstantConfiguration.COLUMN_NOTES;

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
        public DataSet SelectByID(PatientDiagnosisModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByEncounterNo(PatientDiagnosisModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(PatientDiagnosisModel oClass)
        {
            string fname = "";
            string lname = "";
            string patientNo = oClass.PatientNo;
            string caseNo = oClass.CaseNo;

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
                strSql = strSql + "AND A." + COLUMN_CASE_NO + " like '%" + caseNo + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PatientDiagnosisModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                        COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_DESCRIPTION + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.EncounterNo + "', '" +
                     oClass.CaseNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Code + "', '" +
                    oClass.Description + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PatientDiagnosisModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "', " +
                COLUMN_CASE_NO + " = '" + oClass.CaseNo + "', " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_DATE + " = '" + oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_CODE + " = '" + oClass.Code + "', " +
                COLUMN_DESCRIPTION + " = '" + oClass.Description + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientDiagnosisModel oClass)
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