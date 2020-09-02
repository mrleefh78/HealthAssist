using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthAssist.AppClass;
using System.Data;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class InvoiceStatusDAL: BaseDAL
    {
        public InvoiceStatusDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_INVOICE_STATUS;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_NAME = ConstantConfiguration.COLUMN_REF_NAME;

        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " ";

            return Select(strSql);
        }
        public DataSet SelectByID(StatusModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }
        public DataSet SeachData(string name)
        {

            strSql = "SELECT *  " +
                     "FROM " + TABLE_NAME + " Where 1=1 and A.IsDeleted = 0 ";


            if (name != "")
            {
                strSql = strSql + "AND " + COLUMN_NAME + " like '%" + name + "%' ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, StatusModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_NAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.StatusName.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, StatusModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_NAME + " = '" + oClass.StatusName.Replace("'", "") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, StatusModel oClass)
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