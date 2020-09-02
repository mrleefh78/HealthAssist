using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class CPTDAL: BaseDAL
    {
        public CPTDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_CPT;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_ITEM_NAME = ConstantConfiguration.COLUMN_REF_NAME;
        private static string COLUMN_ITEM_CODE = ConstantConfiguration.COLUMN_ITEM_CODE;

        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " limit 1000 ";

            return Select(strSql);
        }
        public DataSet SelectByID(MedicineModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }


        public DataSet SeachData(MedicineModel oClass)
        {
            string med = oClass.ItemName;

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            if (med != "")
            {
                strSql = strSql + "AND " + COLUMN_ITEM_NAME + " like '%" + med + "%' ";
            }


            return Select(strSql);
        }
        public void InsertData(string currUser, MedicineModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                COLUMN_ITEM_CODE + ", " +
                 COLUMN_ITEM_NAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ItemCode.Replace("'", "") + "', '" +
                     oClass.ItemName.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, MedicineModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                 COLUMN_ITEM_CODE + " = '" + oClass.ItemCode.Replace("'", "") + "', " +
                  COLUMN_ITEM_NAME + " = '" + oClass.ItemName.Replace("'", "") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, MedicineModel oClass)
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