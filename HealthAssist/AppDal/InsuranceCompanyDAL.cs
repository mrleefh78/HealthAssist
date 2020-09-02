using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class InsuranceCompanyDAL: BaseDAL
    {
        public InsuranceCompanyDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_INSURANCE;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_CODE = ConstantConfiguration.COLUMN_CODE;
        private static string COLUMN_COMPANY_NAME = ConstantConfiguration.COLUMN_COMPANY_NAME;
        private static string COLUMN_CONTACT_PERSON = ConstantConfiguration.COLUMN_CONTACT_PERSON;
        private static string COLUMN_ADDRESS = ConstantConfiguration.COLUMN_ADDRESS;
        private static string COLUMN_EMAIL = ConstantConfiguration.COLUMN_EMAIL;
        private static string COLUMN_PHONE = ConstantConfiguration.COLUMN_PHONE;
        private static string COLUMN_COUNTRY_CODE = ConstantConfiguration.COLUMN_COUNTRY_CODE;
        private static string COLUMN_DATE_ACCREDIT = ConstantConfiguration.COLUMN_DATE_ACCREDIT;
        private static string COLUMN_DATE_EXPIRE = ConstantConfiguration.COLUMN_DATE_EXPIRE;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, B.Name as CountryName " +
                     "FROM " + TABLE_NAME + " A Left Outer Join Country B On A." + COLUMN_COUNTRY_CODE + " = B.Code" +
                     " WHERE A.IsDeleted = 0 ";

            return Select(strSql);
        }

        public DataSet SelectByCountryCode(InsuranceCompanyModel oClass)
        {

            strSql = "SELECT A.*, B.Name as CountryName " +
                     "FROM " + TABLE_NAME + " A Left Outer Join Country B On A." + COLUMN_COUNTRY_CODE + " = B.Code " +
                     "WHERE A." + COLUMN_COUNTRY_CODE + " = '" + oClass.CountryCode + "' ";

            return Select(strSql);
        }


        public DataSet SelectByID(InsuranceCompanyModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string keyWord)
        {

            strSql = "SELECT A.*, B.Name as CountryName " +
                    "FROM " + TABLE_NAME + " A Left Outer Join Country B On A." + COLUMN_COUNTRY_CODE + " = B.Code" +
                    " WHERE A.IsDeleted = 0 ";

            if (keyWord != "")
            {
                strSql = strSql + "AND (A." + COLUMN_CODE + " like '%" + keyWord + "%' OR  " +
                    "A." + COLUMN_COMPANY_NAME + " like '%" + keyWord + "%' OR " +
                    "A." + COLUMN_ID + " = '" + keyWord + "') ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, InsuranceCompanyModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_CODE + ", " +
                        COLUMN_COMPANY_NAME + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_COUNTRY_CODE + ", " +
                        COLUMN_DATE_ACCREDIT + ", " +
                        COLUMN_DATE_EXPIRE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.Code + "', '" +
                    oClass.CompanyName.Replace("'", "") + "', '" +
                    oClass.ContactPerson.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.CountryCode.Replace("'", "") + "', '" +
                    oClass.DateAccredit.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, InsuranceCompanyModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_CODE + " = '" + oClass.Code + "', " +
                COLUMN_COMPANY_NAME + " = '" + oClass.CompanyName.Replace("'", "") + "', " +
                COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson.Replace("'", "") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "") + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "") + "', " +
                COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_COUNTRY_CODE + " = '" + oClass.CountryCode + "', " +
                COLUMN_DATE_ACCREDIT + " = '" + oClass.DateAccredit.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_DATE_EXPIRE + " = '" + oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, InsuranceCompanyModel oClass)
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