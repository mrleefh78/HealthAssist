using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class InvoiceDAL : BaseDAL 
    {
        public InvoiceDAL()
        {

        }
        private static string TABLE_NAME = ConstantConfiguration.TABLE_INVOICE;

        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_INVOICE_NO = ConstantConfiguration.COLUMN_INVOICE_NO;
        private static string COLUMN_CASE_NO = ConstantConfiguration.COLUMN_CASE_NO;
        private static string COLUMN_PATIENT_NO = ConstantConfiguration.COLUMN_PATIENT_NO;
        private static string COLUMN_INSURANCE = ConstantConfiguration.COLUMN_INSURANCE;
        private static string COLUMN_DATE = ConstantConfiguration.COLUMN_INVOICE_DATE;
        private static string COLUMN_MEDEX = ConstantConfiguration.COLUMN_MEDEX;
        private static string COLUMN_CASE_FEE = ConstantConfiguration.COLUMN_CASE_FEE;
       
        private static string COLUMN_TOTAL_BILLED = ConstantConfiguration.COLUMN_TOTAL_BILLED;
        private static string COLUMN_DATE_BILLED = ConstantConfiguration.COLUMN_DATE_BILLED;
        private static string COLUMN_DATE_PAID = ConstantConfiguration.COLUMN_DATE_PAID;
        private static string COLUMN_STATUS = ConstantConfiguration.COLUMN_STATUS;
        private static string COLUMN_REMARKS = ConstantConfiguration.COLUMN_REMARKS;

        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob,  " +
                     " E.CompanyName, F.dname as Status " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INVOICE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A.IsDeleted = 0";

            return Select(strSql);
        }
        public DataSet SelectByID(InvoiceModel oClass)
        {
            strSql = "SELECT A.*, B.PatientNo, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, " +
                     " E.CompanyName, F.dname as Status " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INVOICE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A." + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SelectByCaseNo(InvoiceModel oClass)
        {
            strSql = "SELECT A.*, Concat(B.LastName, ', ',B.FirstName) as PatientName, B.dob, Concat(C.LastName, ', ',C.FirstName) as PhysicianName, " +
                     " d.FacilityName, E.CompanyName, F.dname as Status " +
                     "FROM " + TABLE_NAME + " A Inner Join  " + ConstantConfiguration.TABLE_PATIENT + " B ON A." +
                     COLUMN_PATIENT_NO + " = B." + COLUMN_PATIENT_NO + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INSURANCE + " E ON E.ID = A." + COLUMN_INSURANCE + " Left Outer Join " +
                     ConstantConfiguration.TABLE_INVOICE_STATUS + " F ON F.ID = A." + COLUMN_STATUS +
                     " WHERE A." + COLUMN_CASE_NO + " = '" + oClass.CaseNo + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string fname, string lname, string patientNo, string caseNo)
        {

            strSql = "SELECT A.*, Concat(B.FirstName, ' ', B.LastName) as PatientName  " +
                     "FROM " + ConstantConfiguration.TABLE_PATIENT_ENCOUNTER + " A INNER JOIN " + ConstantConfiguration.TABLE_PATIENT + " B on A.PatientNo = B.PatientNo  Where 1=1 and A.IsDeleted = 0 ";

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
        public void InsertData(string currUser, InvoiceModel oClass)
        {
          
            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_INVOICE_NO + ", " +
                        COLUMN_CASE_NO + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE + ", " +
                        COLUMN_INSURANCE + ", " +
                        COLUMN_MEDEX + ", " +
                        COLUMN_CASE_FEE + ", " +
                        COLUMN_TOTAL_BILLED + ", " +
                        COLUMN_DATE_BILLED + ", " +
                        COLUMN_DATE_PAID + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_REMARKS + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.InvoiceNo + "', '" +
                    oClass.CaseNo + "', '" +
                    oClass.PatientNo + "', '" +
                    oClass.InvoiceDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.InsuranceCompanyID + "', '" +
                    oClass.Medex + "', '" +
                    oClass.CaseFee + "', '" +
                    oClass.TotalBilled + "', '" +
                    oClass.DateBilled.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DatePaid.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.StatusID + "', '" +
                    oClass.Remarks.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, InvoiceModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_DATE + " = '" + oClass.InvoiceDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_INSURANCE + " = '" + oClass.InsuranceCompanyID + "', " +
                 COLUMN_INVOICE_NO + " = '" + oClass.InvoiceNo + "', " +
                COLUMN_MEDEX + " = '" + oClass.Medex + "', " +
                COLUMN_CASE_FEE + " = '" + oClass.CaseFee + "', " +
                COLUMN_TOTAL_BILLED + " = '" + oClass.TotalBilled + "', " +
                COLUMN_DATE_BILLED + " = '" + oClass.DateBilled.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_DATE_PAID + " = '" + oClass.DatePaid.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_STATUS + " = '" + oClass.StatusID + "', " +
                COLUMN_REMARKS + " = '" + oClass.Remarks.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, InvoiceModel oClass)
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