using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class UsersDAL : BaseDAL
    {
        public UsersDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_USERS;
       
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;
        private static string COLUMN_USER_NAME = ConstantConfiguration.COLUMN_USER_NAME;
        private static string COLUMN_USER_PASSWORD = ConstantConfiguration.COLUMN_USER_PASSWORD;
        private static string COLUMN_EMAIL = ConstantConfiguration.COLUMN_EMAIL;
        private static string COLUMN_PHONE = ConstantConfiguration.COLUMN_PHONE;
        private static string COLUMN_ACCOUNT_TYPE = ConstantConfiguration.COLUMN_ACCOUNT_TYPE;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + 
                     " WHERE IsDeleted = 0";

            return Select(strSql);
        }
        public DataSet SelectAllCombo()
        {

            strSql = "SELECT " + COLUMN_ID + ", Concat(" + COLUMN_LASTNAME + ", ' ', " + COLUMN_FIRSTNAME + ") as Fullname " +
                     "FROM " + TABLE_NAME + " ";

            return Select(strSql);
        }
        public DataSet SelectByID(UserModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
       
        public DataSet SeachData(string keyWord)
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + 
                     " Where IsDeleted = 0 ";

            if (keyWord != "")
            {
                strSql = strSql + "AND (" + COLUMN_FIRSTNAME + " like '%" + keyWord + "%' OR  " +
                    "" + COLUMN_LASTNAME + " like '%" + keyWord + "%' OR " +
                    "" + COLUMN_USER_NAME + " = '" + keyWord + "') ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, UserModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_USER_NAME + ", " +
                        COLUMN_USER_PASSWORD + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_ACCOUNT_TYPE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.LastName + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.UserName.Replace("'", "") + "', '" +
                    oClass.UserPassword.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.AccountType + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, UserModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_LASTNAME + " = '" + oClass.LastName + "', " +
                COLUMN_FIRSTNAME + " = '" + oClass.FirstName + "', " +
                COLUMN_USER_NAME + " = '" + oClass.UserName.Replace("'", "") + "', " +
                COLUMN_USER_PASSWORD + " = '" + oClass.UserPassword.Replace("'", "") + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "") + "', " +
                 COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_ACCOUNT_TYPE + " = '" + oClass.AccountType + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, UserModel oClass)
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