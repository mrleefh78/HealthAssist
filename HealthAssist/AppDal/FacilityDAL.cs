using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthAssist.AppClass;
using System.Data;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class FacilityDAL : BaseDAL
    {
        public FacilityDAL() 
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_FACILITY;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_NAME = ConstantConfiguration.COLUMN_FACILITY_NAME;
        private static string COLUMN_CONTACT_PERSON = ConstantConfiguration.COLUMN_CONTACT_PERSON;
        private static string COLUMN_DESIGNATION = ConstantConfiguration.COLUMN_DESIGNATION;
        private static string COLUMN_TYPE = ConstantConfiguration.COLUMN_FACILITY_TYPE;
        private static string COLUMN_ADDRESS = ConstantConfiguration.COLUMN_ADDRESS;
        private static string COLUMN_EMAIL = ConstantConfiguration.COLUMN_EMAIL;
        private static string COLUMN_PHONE = ConstantConfiguration.COLUMN_PHONE;
        private static string COLUMN_DATE_ACCREDIT = ConstantConfiguration.COLUMN_DATE_ACCREDIT;
        private static string COLUMN_DATE_EXPIRE = ConstantConfiguration.COLUMN_DATE_EXPIRE;
        private static string COLUMN_PROVINCE = ConstantConfiguration.COLUMN_PROVINCE;
        private static string COLUMN_CASH_BOND = ConstantConfiguration.COLUMN_CASH_BOND;
        private static string COLUMN_STATUS_ID = ConstantConfiguration.COLUMN_STATUS_ID;
        private static string COLUMN_NOTES = ConstantConfiguration.COLUMN_NOTES;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " ";

            return Select(strSql);
        }

        public DataSet SelectAllHealthCare()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + 
                      " WHERE " + COLUMN_TYPE + " = 'Clinic' or " + COLUMN_TYPE + " = 'Hospital' ";

            return Select(strSql);
        }

        public DataSet SelectAllContacts()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME +
                      " WHERE " + COLUMN_TYPE + " <> 'Clinic' AND " + COLUMN_TYPE + " <> 'Hospital' ";

            return Select(strSql);
        }

        public DataSet SelectByID(FacilityModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string faciltiyName)
        {

            strSql = "SELECT *  " +
                     "FROM " + TABLE_NAME + "  Where 1=1 and IsDeleted = 0 ";

          
            if (faciltiyName != "")
            {
                strSql = strSql + "AND " + COLUMN_NAME + " like '%" + faciltiyName + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, FacilityModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_NAME + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                        COLUMN_DESIGNATION + ", " +
                        COLUMN_TYPE + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_DATE_ACCREDIT + ", " +
                        COLUMN_DATE_EXPIRE + ", " +
                        COLUMN_PROVINCE + ", " +
                        COLUMN_CASH_BOND + ", " +
                        COLUMN_STATUS_ID + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.FacilityName.Replace("'", "") + "', '" +
                    oClass.ContactPerson.Replace("'", "") + "', '" +
                    oClass.Designation.Replace("'", "") + "', '" +
                    oClass.FacilityType.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.DateAccredit.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Province.Replace("'", "") + "', '" +
                    oClass.CashBond + "', '" +
                     oClass.StatusID + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, FacilityModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_NAME + " = '" + oClass.FacilityName.Replace("'", "") + "', " +
                COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson.Replace("'", "") + "', " +
                COLUMN_DESIGNATION + " = '" + oClass.Designation.Replace("'", "") + "', " +
                COLUMN_TYPE + " = '" + oClass.FacilityType.Replace("'", "") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "") + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "") + "', " +
                COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_DATE_ACCREDIT + " = '" + oClass.DateAccredit.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_DATE_EXPIRE + " = '" + oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_PROVINCE + " = '" + oClass.Province.Replace("'", "") + "', " +
                COLUMN_CASH_BOND + " = '" + oClass.CashBond + "', " +
                COLUMN_STATUS_ID + " = '" + oClass.StatusID + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, FacilityModel oClass)
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