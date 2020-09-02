using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientAppointmentDAL : BaseDAL
    {
        public PatientAppointmentDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PATIENT_APPOINTMENT;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_APPOINTMENT_DATE;
        private static string COLUMN_APPOINTMENT_TYPE = ConstantConfiguration.COLUMN_APPOINTMENT_TYPE;
        private static string COLUMN_PHYSICIAN_ID = ConstantConfiguration.COLUMN_PHYSICIAN_ID;
        private static string COLUMN_HOSPITAL_ID = ConstantConfiguration.COLUMN_FACILITY_ID;
        private static string COLUMN_STATUS_ID = ConstantConfiguration.COLUMN_STATUS_ID;
        private static string COLUMN_REMARKS = ConstantConfiguration.COLUMN_REMARKS;

        private static string TABLE_PATIENT = ConstantConfiguration.TABLE_PATIENT;
        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;

        private static string TABLE_FACILITY = ConstantConfiguration.TABLE_FACILITY;
        private static string COLUMN_FACILITY_NAME = ConstantConfiguration.COLUMN_FACILITY_NAME;

        private static string TABLE_PHYSICIAN = ConstantConfiguration.TABLE_PHYSICIAN;
        private static string TABLE_STATUS = ConstantConfiguration.TABLE_CASE_STATUS;

        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName, C.FacilityName, Concat(D.FirstName, ' ', D.LastName) as PhysicianName, E.dname as Status " +
                    "FROM " + TABLE_NAME + " A INNER JOIN " + TABLE_PATIENT + " B on A.PatientNo = B.PatientNo " +
                    " LEFT OUTER JOIN " + TABLE_FACILITY + " C ON C.ID = A." + COLUMN_HOSPITAL_ID +
                    " LEFT OUTER JOIN " + TABLE_PHYSICIAN + " D ON D.ID = A." + COLUMN_PHYSICIAN_ID +
                    " LEFT OUTER JOIN " + TABLE_STATUS + " E ON E.ID = A." + COLUMN_STATUS_ID +
                    " WHERE A.IsDeleted = 0 ";

            return Select(strSql);
        }
        public DataSet SelectByID(PatientAppointmentModel oClass)
        {
            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName, B.dob, C.FacilityName, Concat(D.FirstName, ' ', D.LastName) as PhysicianName, E.dname as Status " +
                     "FROM " + TABLE_NAME + " A INNER JOIN " + TABLE_PATIENT + " B on A.PatientNo = B.PatientNo " +
                     " LEFT OUTER JOIN "  + TABLE_FACILITY + " C ON C.ID = A." + COLUMN_HOSPITAL_ID +
                     " LEFT OUTER JOIN " + TABLE_PHYSICIAN + " D ON D.ID = A." + COLUMN_PHYSICIAN_ID +
                     " LEFT OUTER JOIN " + TABLE_STATUS + " E ON E.ID = A." + COLUMN_STATUS_ID +
                     " WHERE A." + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string fname, string lname, string patientNo, string caseNo)
        {

            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName, C.FacilityName, Concat(D.FirstName, ' ', D.LastName) as PhysicianName, E.dname as Status " +
                    "FROM " + TABLE_NAME + " A INNER JOIN " + TABLE_PATIENT + " B on A.PatientNo = B.PatientNo " +
                    " LEFT OUTER JOIN " + TABLE_FACILITY + " C ON C.ID = A." + COLUMN_HOSPITAL_ID +
                    " LEFT OUTER JOIN " + TABLE_PHYSICIAN + " D ON D.ID = A." + COLUMN_PHYSICIAN_ID +
                    " LEFT OUTER JOIN " + TABLE_STATUS + " E ON E.ID = A." + COLUMN_STATUS_ID +
                    " Where 1=1 and A.IsDeleted = 0 ";

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
                strSql = strSql + "AND B." + COLUMN_PATIENT_NO + " = '" + patientNo + "' ";
            }
            if (caseNo != "")
            {
                strSql = strSql + "AND A." + COLUMN_CASE_NO + " like '%" + caseNo + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PatientAppointmentModel oClass)
        {
           
            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_APPOINTMENT_TYPE + ", " +
                        COLUMN_PHYSICIAN_ID + ", " +
                         COLUMN_STATUS_ID + ", " +
                        COLUMN_REMARKS + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.CaseNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.AppointmentDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                     oClass.AppointmentType + "', '" +
                    oClass.PhysicianID + "', '" +
                       oClass.StatusID + "', '" +
                    oClass.Remarks.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PatientAppointmentModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_CASE_NO + " = '" + oClass.CaseNo + "', " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "', " +
                COLUMN_DATE + " = '" + oClass.AppointmentDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                   COLUMN_APPOINTMENT_TYPE + " = '" + oClass.AppointmentType + "', " +
                COLUMN_PHYSICIAN_ID + " = '" + oClass.PhysicianID + "', " +
                COLUMN_HOSPITAL_ID + " = '" + oClass.HospitalID + "', " +
                COLUMN_REMARKS + " = '" + oClass.Remarks.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PatientAppointmentModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                " isDeeleted = 1, " +
                " ReasonDelete = '" + oClass.ReasonDelete.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
    }
}