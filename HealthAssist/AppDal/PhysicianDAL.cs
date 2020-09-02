using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class PhysicianDAL: BaseDAL
    {
        public PhysicianDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PHYSICIAN;
        private static string TABLE_PHYSICIAN_FACILITY = ConstantConfiguration.TABLE_PHYSICIAN_FACILITY;
        private static string TABLE_FACILITY_NAME = ConstantConfiguration.TABLE_FACILITY;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_NAME_TITLE = ConstantConfiguration.COLUMN_NAME_TITLE;
        private static string COLUMN_LASTNAME = ConstantConfiguration.COLUMN_LASTNAME;
        private static string COLUMN_FIRSTNAME = ConstantConfiguration.COLUMN_FIRSTNAME;
        private static string COLUMN_SUFFIX = ConstantConfiguration.COLUMN_SUFFIX;
        private static string COLUMN_SPECIALTY = ConstantConfiguration.COLUMN_SPECIALTY;
        private static string COLUMN_LICENSE_NO = ConstantConfiguration.COLUMN_LICENSE_NO;
        private static string COLUMN_ADDRESS = ConstantConfiguration.COLUMN_ADDRESS;
        private static string COLUMN_EMAIL = ConstantConfiguration.COLUMN_EMAIL ;
        private static string COLUMN_PHONE = ConstantConfiguration.COLUMN_PHONE;
        private static string COLUMN_HOSPITAL = ConstantConfiguration.COLUMN_FACILITY_ID;
        private static string COLUMN_USER_ID = ConstantConfiguration.COLUMN_USER_ID;
        private static string COLUMN_RATE = ConstantConfiguration.COLUMN_RATE;


        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT A.*, B.* " +
                     "FROM " + TABLE_NAME + " A Left outer join " + TABLE_FACILITY_NAME + 
                     " B On A." + COLUMN_HOSPITAL + " = B." + COLUMN_ID +
                     " WHERE A.IsDeleted = 0";

            return Select(strSql);
        }
        public DataSet SelectAllCombo()
        {

            strSql = "SELECT " + COLUMN_ID + ", Concat(" + COLUMN_LASTNAME + ", ' ', " + COLUMN_FIRSTNAME + ") as Fullname " +
                     "FROM " + TABLE_NAME + " order by id desc ";

            return Select(strSql);
        }
        public DataSet SelectByID(PhysicianModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select(strSql);
        }

        public DataSet SelectByUserID(PhysicianModel oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_ID + " = '" + oClass.UserID + "' ";

            return Select(strSql);
        }

        public DataSet SelectPhysicianFacilityByID(PhysicianModel oClass)
        {
            strSql = "SELECT A.id, C.id as FacilityID, C.FacilityName  " +
                     "FROM " + TABLE_PHYSICIAN_FACILITY + " A Left Outer Join " + TABLE_NAME + " B ON A.PhysicianID = B.ID " +
                     " INNER JOIN " + TABLE_FACILITY_NAME + " C ON C.ID = A.FacilityID " +
                     "WHERE B." + COLUMN_ID + " = '" + oClass.ID + "' and A.IsDeleted = 0 ";

            return Select(strSql);
        }
        public DataSet SeachData(string keyWord)
        {

            strSql = "SELECT A.*, B.* " +
                     "FROM " + TABLE_NAME + " A Left outer join " + TABLE_FACILITY_NAME +
                     " B On A." + COLUMN_HOSPITAL + " = B." + COLUMN_ID + " Where 1=1 and A.IsDeleted = 0 ";
           
            if (keyWord != "")
            {
                strSql = strSql + "AND (A." + COLUMN_FIRSTNAME + " like '%" + keyWord + "%' OR  " +
                    "A." + COLUMN_LASTNAME + " like '%" + keyWord + "%' OR " +
                    "A." + COLUMN_SPECIALTY + " = '" + keyWord + "') ";
            }

            return Select(strSql);
        }
        public void InsertData(string currUser, PhysicianModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_NAME + " (" +
                 COLUMN_NAME_TITLE + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_SUFFIX + ", " +
                        COLUMN_SPECIALTY + ", " +
                         COLUMN_LICENSE_NO + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_HOSPITAL + ", " +
                        COLUMN_RATE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.Title + "', '" +
                      oClass.LastName + "', '" +
                    oClass.FirstName + "', '" +
                      oClass.Suffix + "', '" +
                    oClass.Specialty.Replace("'", "")  + "', '" +
                      oClass.LicenseNo + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +                 
                    oClass.HospitalID + "', '" +
                    oClass.Rate + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PhysicianModel oClass)
        {

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_NAME_TITLE + " = '" + oClass.Title + "', " +
                COLUMN_LASTNAME + " = '" + oClass.LastName + "', " +
                COLUMN_FIRSTNAME + " = '" + oClass.FirstName + "', " +
                COLUMN_SUFFIX + " = '" + oClass.Suffix + "', " +
                COLUMN_SPECIALTY + " = '" + oClass.Specialty.Replace("'", "") + "', " +
                COLUMN_LICENSE_NO + " = '" + oClass.LicenseNo.Replace("'", "") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "") + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "") + "', " +
                 COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_HOSPITAL + " = '" + oClass.HospitalID + "', " +
                  COLUMN_RATE + " = '" + oClass.Rate + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PhysicianModel oClass)
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

    public class PhysicianFacilityDAL: BaseDAL
    {
        public PhysicianFacilityDAL()
        {
        }

        private static string TABLE_PHYSICIAN_FACILITY = ConstantConfiguration.TABLE_PHYSICIAN_FACILITY;
        private static string COLUMN_ID = ConstantConfiguration.COLUMN_ID;
        private static string COLUMN_PHYSICIAN_ID = ConstantConfiguration.COLUMN_PHYSICIAN_ID;
        private static string COLUMN_HOSPITAL_ID = ConstantConfiguration.COLUMN_FACILITY_ID;
        private string strSql;

        public void InsertData(string currUser, PhysicianFacilityModel oClass)
        {

            strSql = strSql + "INSERT INTO " + TABLE_PHYSICIAN_FACILITY + " (" +
                        COLUMN_PHYSICIAN_ID + ", " +
                        COLUMN_HOSPITAL_ID + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.PhysicianID + "', '" +
                    oClass.HospitalID + "', '" +
                    currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            SaveData(strSql);


        }
        public void UpdateData(string user, PhysicianFacilityModel oClass)
        {

            strSql = "UPDATE " + TABLE_PHYSICIAN_FACILITY + " SET " +
                COLUMN_PHYSICIAN_ID + " = '" + oClass.PhysicianID + "', " +
                COLUMN_HOSPITAL_ID + " = '" + oClass.HospitalID + "', " +
                   " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }
        public void DeleteData(string user, PhysicianFacilityModel oClass)
        {

            strSql = "UPDATE " + TABLE_PHYSICIAN_FACILITY + " SET " +
                " isDeleted = 1, " +
                " ReasonDelete = '" + oClass.ReasonDelete.Replace("'", "''") + "', " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            SaveData(strSql);
        }

    }
}