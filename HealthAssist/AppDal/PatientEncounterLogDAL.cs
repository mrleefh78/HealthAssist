using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientEncounterLogDAL : BaseDAL
    {
        public PatientEncounterLogDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATENT_ENCOUNTER_LOG;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_ENCOUNTER_NO = ConstantConfiguration.COLUMN_ENCOUNTER_NO;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_LOG_DATE;
        private static string COLUMN_STATUS_ID = ConstantConfiguration.COLUMN_STATUS_ID;

        private static string TABLE_STATUS = ConstantConfiguration.TABLE_CASE_STATUS;
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
        public DataSet SelectByID(PatientEncounterLogModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByEncounterNo(PatientEncounterLogModel oClass)
        {
            strSql = "SELECT A.*, B.dname as Status " +
                     "FROM " + TABLE_NAME + " A left outer Join "  + TABLE_STATUS + " B " +
                     "ON A.StatusID = B.ID " +
                     "WHERE " + COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(PatientEncounterLogModel oClass)
        {
            string fname = "";
            string lname = "";
            string patientNo = oClass.PatientNo;
            string encounterNo = oClass.EncounterNo;

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
            if (encounterNo != "")
            {
                strSql = strSql + "AND A." + COLUMN_ENCOUNTER_NO + " like '%" + encounterNo + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PatientEncounterLogModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_ENCOUNTER_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_STATUS_ID + ", " +
                             "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.EncounterNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.LogDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.StatusID + "', '" +
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
                        COLUMN_DATE + ", " +
                        COLUMN_STATUS_ID + ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            return strSql;


        }
        public void UpdateData(string user, PatientEncounterLogModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_ENCOUNTER_NO + " = '" + oClass.EncounterNo + "', " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_DATE + " = '" + oClass.LogDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_STATUS_ID + " = '" + oClass.StatusID + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientEncounterLogModel oClass)
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