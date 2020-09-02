using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PatientInsuranceDAL : BaseDAL
    {
        public PatientInsuranceDAL()
        {

        }

        private static string TABLE_PATIENT = ConstantConfiguration.TABLE_PATIENT;
        private static string TABLE_PATIENT_INSURANCE = ConstantConfiguration.TABLE_PATIENT_INSURANCE;

        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_INSURANCE_ID = ConstantConfiguration.COLUMN_INSURANCE_ID;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_START_DATE = ConstantConfiguration.COLUMN_START_DATE;
        private static string COLUMN_EXPIRATION_DATE = ConstantConfiguration.COLUMN_EXPIRATION_DATE;
        private static string COLUMN_POLICY_NO = ConstantConfiguration.COLUMN_POLICY_NO;
        private static string COLUMN_MEMBERSHIP_TYPE = ConstantConfiguration.COLUMN_MEMBERSHIP_TYPE;
        private static string COLUMN_PRINCIPAL_PATIENT_NO = ConstantConfiguration.COLUMN_PRINCIPAL_PATIENT_NO;
        private static string COLUMN_EMPLOYEE_NO = ConstantConfiguration.COLUMN_EMPLOYEE_NO;
        private static string COLUMN_COMPANY = ConstantConfiguration.COLUMN_COMPANY;
        private static string COLUMN_NOTES = ConstantConfiguration.COLUMN_NOTES;
     
        private string strSql;

        public DataSet SelectAllPatientInsurance()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_INSURANCE + "  WHERE IFnull(IsDeleted,0) = 0 ";

            return Select(strSql);
        }
        public DataSet SelectByPatientInsuranceID(PatientInsuranceModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_INSURANCE + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' AND IsDeleted <> 1 ";

            return Select(strSql);
        }
        public DataSet SelectByPatientNo(PatientInsuranceModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_INSURANCE + " " +
                     "WHERE " + COLUMN_PATIENT_NO + " = '" + oClass.PatientNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachPatient(string keyword)
        {

            strSql = "SELECT *  " +
                     "FROM " + TABLE_PATIENT_INSURANCE + " Where 1=1 and IsDeleted = 0 ";

            if (keyword != "")
            {
                strSql = strSql + "AND (" + COLUMN_POLICY_NO + " like '%" + keyword + "%' OR  " +
                    "" + COLUMN_COMPANY + " like '%" + keyword + "%' OR " +
                    "" + COLUMN_PATIENT_NO + " = '" + keyword + "') ";
            }


            return Select(strSql);
        }
        public void InsertPatientInsurance(string currUser, PatientInsuranceModel oClass)
        {
           
            strSql = strSql + "INSERT INTO " + TABLE_PATIENT_INSURANCE + " (" +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_INSURANCE_ID + ", " +
                        COLUMN_START_DATE + ", " +
                        COLUMN_EXPIRATION_DATE + ", " +
                        COLUMN_POLICY_NO + ", " +
                        COLUMN_MEMBERSHIP_TYPE + ", " +
                        COLUMN_PRINCIPAL_PATIENT_NO + ", " +
                        COLUMN_EMPLOYEE_NO + ", " +
                        COLUMN_COMPANY + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.PatientNo + "', '" +
                    oClass.InsuranceID + "', '" +
                    oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.ExpirationDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.PolicyNo + "', '" +
                    oClass.MembershipType.Replace("'", "") + "', '" +
                    oClass.PrincipalPatientNo + "', '" +
                    oClass.EmployeeNo + "', '" +
                    oClass.Company.Replace("'", "") + "', '" +
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

            strSql = strSql + "INSERT INTO " + TABLE_PATIENT_INSURANCE + " (" +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_INSURANCE_ID + ", " +
                        COLUMN_START_DATE + ", " +
                        COLUMN_EXPIRATION_DATE + ", " +
                        COLUMN_POLICY_NO + ", " +
                        COLUMN_MEMBERSHIP_TYPE + ", " +
                        COLUMN_PRINCIPAL_PATIENT_NO + ", " +
                        COLUMN_EMPLOYEE_NO + ", " +
                        COLUMN_COMPANY + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            return strSql;


        }
        public void UpdatePatient(string user, PatientInsuranceModel oClass)
        {

            strSql = "UPDATE " + TABLE_PATIENT_INSURANCE + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.PatientNo.Replace("'", "''") + "', " +
                COLUMN_INSURANCE_ID + " = '" + oClass.InsuranceID + "', " +
                COLUMN_START_DATE + " = '" + oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_EXPIRATION_DATE + " = '" + oClass.ExpirationDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_POLICY_NO + " = '" + oClass.PolicyNo  + "', " +
                COLUMN_MEMBERSHIP_TYPE + " = '" + oClass.MembershipType + "', " +
                COLUMN_PRINCIPAL_PATIENT_NO + " = '" + oClass.PrincipalPatientNo + "', " +
                COLUMN_EMPLOYEE_NO + " = '" + oClass.EmployeeNo + "', " +
                COLUMN_COMPANY + " = '" + oClass.Company.Replace("'", "''") + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeletePatient(string user, PatientInsuranceModel oClass)
        {

            strSql = "UPDATE " + TABLE_PATIENT_INSURANCE + " SET " +
                " isDeleted = 1, " +
                " ReasonDelete = '" + oClass.ReasonDelete.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
    }
}