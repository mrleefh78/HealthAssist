using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PhysicianPrescriptionTemplateDAL : BaseDAL
    {
        public PhysicianPrescriptionTemplateDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PHYSICIAN_PRESCRIPTION_TEMPLATE;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_PHYSICIAN_ID = ConstantConfiguration.COLUMN_PHYSICIAN_ID;
        private static string COLUMN_DOSAGE = ConstantConfiguration.COLUMN_DOSAGE;
      
        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " Where IsDeleted = 0 ";

            return Select(strSql);
        }
        public DataSet SelectByID(PhysicianPrescriptionTemplateModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByPhysicianID(PhysicianPrescriptionTemplateModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_PHYSICIAN_ID + " = '" + oClass.PhysicianID + "' ";

            return Select(strSql);
        }


        public DataSet SeachData(PhysicianPrescriptionTemplateModel oClass)
        {
            string dosage = oClass.Dosage;

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            if (dosage != "")
            {
                strSql = strSql + "AND B" + COLUMN_DOSAGE + " like '%" + dosage + "%' ";
            }
          

            return Select(strSql);
        }
        public void InsertData(string currUser, PhysicianPrescriptionTemplateModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                 COLUMN_PHYSICIAN_ID + ", " +
                        COLUMN_DOSAGE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.PhysicianID + "', '" +
                    oClass.Dosage.Replace("'", "") + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PhysicianPrescriptionTemplateModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                 COLUMN_DOSAGE + " = '" + oClass.Dosage.Replace("'", "") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PhysicianPrescriptionTemplateModel oClass)
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