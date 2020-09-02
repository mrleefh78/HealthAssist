using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientVitalsDAL: BaseDAL
    {
        public PatientVitalsDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_VITALS;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_ENCOUNTER_NO = ConstantConfiguration.COLUMN_ENCOUNTER_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_TEMPERATURE = ConstantConfiguration.COLUMN_TEMPERATURE;
        private static string COLUMN_SYSTOLIC = ConstantConfiguration.COLUMN_SYSTOLIC;
        private static string COLUMN_DIASTOLIC = ConstantConfiguration.COLUMN_DIASTOLIC;
        private static string COLUMN_PULSE_RATE = ConstantConfiguration.COLUMN_PULSE_RATE;
        private static string COLUMN_HEIGHT = ConstantConfiguration.COLUMN_HEIGHT;
        private static string COLUMN_WEIGHT = ConstantConfiguration.COLUMN_WEIGHT;
        private static string COLUMN_BLOOD_SUGAR = ConstantConfiguration.COLUMN_BLOOD_SUGAR;
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
        public DataSet SelectByID(PatientVitalsModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByEncounterNo(PatientVitalsModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(PatientVitalsModel oClass)
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
        public void InsertData(string currUser, PatientVitalsModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_TEMPERATURE + ", " +
                        COLUMN_SYSTOLIC + ", " +
                        COLUMN_DIASTOLIC + ", " +
                        COLUMN_PULSE_RATE + ", " +
                        COLUMN_HEIGHT + ", " +
                        COLUMN_WEIGHT + ", " +
                        COLUMN_BLOOD_SUGAR + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.EncounterNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.Temperature + "', '" +
                    oClass.Systolic + "', '" +
                    oClass.Diastolic + "', '" +
                    oClass.PulseRate + "', '" +
                    oClass.Height + "', '" +
                    oClass.Weight + "', '" +
                    oClass.BloodSugar + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
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
                        COLUMN_TEMPERATURE + ", " +
                        COLUMN_SYSTOLIC + ", " +
                        COLUMN_DIASTOLIC + ", " +
                        COLUMN_PULSE_RATE + ", " +
                        COLUMN_HEIGHT + ", " +
                        COLUMN_WEIGHT + ", " +
                        COLUMN_BLOOD_SUGAR + ", " +
                         COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
         
            return strSql;


        }

        public void UpdateData(string user, PatientVitalsModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "', " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_TEMPERATURE + " = '" + oClass.Temperature+ "', " +
                COLUMN_SYSTOLIC + " = '" + oClass.Systolic + "', " +
                COLUMN_DIASTOLIC + " = '" + oClass.Diastolic + "', " +
                COLUMN_PULSE_RATE + " = '" + oClass.PulseRate + "', " +
                COLUMN_HEIGHT + " = '" + oClass.Height + "', " +
                COLUMN_WEIGHT + " = '" + oClass.Weight + "', " +
                COLUMN_BLOOD_SUGAR + " = '" + oClass.BloodSugar + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }

        public void UpdateDataByEncounter(string user, PatientVitalsModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_TEMPERATURE + " = '" + oClass.Temperature + "', " +
                COLUMN_SYSTOLIC + " = '" + oClass.Systolic + "', " +
                COLUMN_DIASTOLIC + " = '" + oClass.Diastolic + "', " +
                COLUMN_PULSE_RATE + " = '" + oClass.PulseRate + "', " +
                COLUMN_HEIGHT + " = '" + oClass.Height + "', " +
                COLUMN_WEIGHT + " = '" + oClass.Weight + "', " +
                COLUMN_BLOOD_SUGAR + " = '" + oClass.BloodSugar + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientVitalsModel oClass)
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