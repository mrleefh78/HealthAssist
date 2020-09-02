using System;
using System.Collections.Generic;
using System.Web;
using HealthAssist.AppCommon;
using HealthAssist.AppClass;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace HealthAssist.AppDal
{
    class LookUpDAL
    {
        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;
        private string strSql;
        private string strSql1;
    
        public LookUpDAL()
        {
            oConnection = new DALConnectionClass();
        }
        
        public DataSet Select()
        {
            DataSet myDataset = new DataSet();

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(strSql, myCon);
                    myDataAdapter.Fill(myDataset);
                    return myDataset;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                myDataAdapter = null;
            }
        }
   
        #region Position

        private static string TABLE_POSITION = "lkpposition";
        private static string COLUMN_ID = "id";
       // private static string COLUMN_CODE = "code";
        private static string COLUMN_SNAME = "dname";
        private static string COLUMN_NOTES = "notes";
             
        public DataSet SelectAllPosition()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_POSITION + " ";

            return Select();
        }

        public DataSet GetPositionID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_POSITION + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByPositionID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_POSITION + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID   + "' ";

            return Select();
        }

        public DataSet SelectByPositionName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_POSITION + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertPosition(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_POSITION + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";
                  
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePosition(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_POSITION + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePosition(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_POSITION + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Department

        private static string TABLE_DEPARTMENT = "lkpdepartment";
       
        public DataSet SelectAllDept()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_DEPARTMENT + " ";

            return Select();
        }

        public DataSet GetDeptID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_DEPARTMENT + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByDeptID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_DEPARTMENT + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByDeptName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_DEPARTMENT + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertDept(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_DEPARTMENT + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateDept(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_DEPARTMENT + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteDept(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_DEPARTMENT + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Facility

        private static string TABLE_LOCATION = "lkpfacility";
        private static string COLUMN_FACILITY_TYPE = "facility_type";

        private static string COLUMN_DATE_ACC = "date_accredit";
        private static string COLUMN_DATE_EXPIRE = "date_expire";
        private static string COLUMN_PROVINCE = "province";
        private static string COLUMN_CASH_BOND = "cash_bond";
        private static string COLUMN_STATUS = "status_id";
        private static string COLUMN_POSITION = "position";

        public DataSet SelectAllLocation()
        {

            strSql = "SELECT a.*, b.dname as status " +
                     "FROM " + TABLE_LOCATION + " a left outer join " + TABLE_STATUS_NETWORK + " b " +
                     " on a.status_id =  b.id ";

            return Select();
        }

        public DataSet SelectAllLocationCombo()
        {

            strSql = "SELECT id, dname " +
                     "FROM " + TABLE_LOCATION + " union Select null, '-SELECT-'  order by dname asc ";

            return Select();
        }

        public DataSet GetLocIDs(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_LOCATION + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByLocID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_LOCATION + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByLocName(LookUpClass oClass)
        {
            strSql = "SELECT a.*, b.dname as status " +
                     "FROM " + TABLE_LOCATION + " a left outer join " + TABLE_STATUS_NETWORK + " b " +
                     " on a.status_id =  b.id " +
                     "WHERE a." + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' "+
                     "OR a." + COLUMN_PROVINCE + " LIKE '%" + oClass.Desc + "%' "+
                     "OR a." + COLUMN_FACILITY_TYPE + " LIKE '%" + oClass.Desc + "%' "+
                     "OR a." + COLUMN_ADDRESS + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public DataSet SelectByLocType(LookUpClass oClass)
        {
            strSql = "SELECT a.*, b.dname as status " +
                     "FROM " + TABLE_LOCATION + " a left outer join " + TABLE_STATUS_NETWORK + " b " +
                     " on a.status_id =  b.id " +
                     "WHERE a." + COLUMN_FACILITY_TYPE + " LIKE '%" + oClass.Specialty + "%' ";

            return Select();
        }

        public DataSet SelectByLocProvince(LookUpClass oClass)
        {
            strSql = "SELECT a.*, b.dname as status " +
                     "FROM " + TABLE_LOCATION + " a left outer join " + TABLE_STATUS_NETWORK + " b " +
                     " on a.status_id =  b.id " +
                     "WHERE a." + COLUMN_PROVINCE + " LIKE '%" + oClass.Province + "%' ";

            return Select();
        }

        public void InsertLoc(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_LOCATION + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateLoc(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_LOCATION + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertLocation(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_LOCATION + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                         COLUMN_POSITION + ", " +
                        COLUMN_FACILITY_TYPE + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_DATE_ACC + ", " +
                        COLUMN_DATE_EXPIRE + ", " +
                        COLUMN_PROVINCE + ", " +
                        COLUMN_CASH_BOND + ", " +
                        COLUMN_STATUS + ", " +
                        COLUMN_NOTES + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                    oClass.ContactPerson.Replace("'", "") + "', '" +
                    oClass.Position.Replace("'", "") + "', '" +
                    oClass.Specialty + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email + "', '" +
                    oClass.DateAcc.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Province  + "', '" +
                    oClass.CashBond + "', '" +
                    oClass.Status + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateLocation(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_LOCATION + " SET " +
                 COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
                 COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson.Replace("'", "''") + "', " +
                 COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                  COLUMN_POSITION + " = '" + oClass.Position.Replace("'", "''") + "', " +
                 COLUMN_FACILITY_TYPE + " = '" + oClass.Specialty  + "', " +
                 COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                 COLUMN_EMAIL + " = '" + oClass.Email + "', " +
                 COLUMN_PROVINCE + " = '" + oClass.Province  + "', " +
                 COLUMN_CASH_BOND + " = '" + oClass.CashBond  + "', " +
                 COLUMN_DATE_ACC + " = '" + oClass.DateAcc.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                   COLUMN_DATE_EXPIRE + " = '" + oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_STATUS + " = '" + oClass.Status + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteLoc(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_LOCATION + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Country

        private static string TABLE_COUNTRY = "country";
        private static string COLUMN_CODE = "code";

        private static string TABLE_PROVINCE = "lkpprovinces";

        public DataSet SelectAllCountry()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_COUNTRY + " ";

            return Select();
        }

        public DataSet SelectAllCountryCombo()
        {

            strSql = "SELECT code, name " +
                     "FROM " + TABLE_LOCATION + " union Select null, '-SELECT-'  order by name asc ";

            return Select();
        }

        public DataSet SelectAllProvinceCombo()
        {

            strSql = "SELECT id, dname " +
                     "FROM " + TABLE_PROVINCE + " union Select null, '-SELECT-'  order by dname asc ";

            return Select();
        }

        public DataSet GetCountryID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_COUNTRY + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByCountryID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_COUNTRY + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByCountryName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_COUNTRY + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertCountry(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_COUNTRY + " (" +
                        COLUMN_ID + ", " +
                         COLUMN_CODE + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateCountry(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_COUNTRY + " SET " +
                 COLUMN_CODE + " = '" + oClass.Code.Replace("'", "''") + "', " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteCountry(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_COUNTRY + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Status

        private static string TABLE_STATUS = "lkpstatus";

        public DataSet SelectAllStatus()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllStatusCombo()
        {

            strSql = "SELECT id, concat(sname, ' (', id,')') " +
                     "FROM " + TABLE_STATUS + " order by dname asc ";

            return Select();
        }

       
        public DataSet GetStatusID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_STATUS + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByStatusID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByStatusName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertStatus(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_STATUS + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateStatus(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_STATUS + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteStatus(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_STATUS + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Status Bill

        private static string TABLE_STATUS_BILL = "lkpstatusbill";

        public DataSet SelectAllStatusBill()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_BILL + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllStatusBillCombo()
        {

            strSql = "SELECT id, concat(sname, ' (', id,')') " +
                     "FROM " + TABLE_STATUS_BILL + " order by dname asc ";

            return Select();
        }


        public DataSet GetStatusBillID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_STATUS_BILL + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByStatusBillID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_BILL + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByStatusBillName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_BILL + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertStatusBill(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_STATUS_BILL + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateStatusBill(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_STATUS_BILL + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteStatusBill(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_STATUS_BILL + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Status Network

        private static string TABLE_STATUS_NETWORK = "lkpstatusnetwork";

        public DataSet SelectAllStatusNet()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_NETWORK + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllStatusNetCombo()
        {

            strSql = "SELECT id, concat(sname, ' (', id,')') " +
                     "FROM " + TABLE_STATUS_NETWORK + " order by dname asc ";

            return Select();
        }

        public DataSet GetStatusNetID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_STATUS_NETWORK + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByStatusNetID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_NETWORK + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByStatusNetName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_STATUS_NETWORK + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertStatusNet(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_STATUS_NETWORK + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateStatusNet(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_STATUS_NETWORK + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteStatusNet(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_STATUS_NETWORK + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Services

        private static string TABLE_SERVICES = "lkpservices";

        public DataSet SelectAllServices()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_SERVICES + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllServicesCombo()
        {

            strSql = "SELECT id, dname " +
                     "FROM " + TABLE_SERVICES + " union Select null, '-SELECT-' order by dname asc ";

            return Select();
        }


        public DataSet GetServicesID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_SERVICES + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByServicesID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_SERVICES + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByServicesName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_SERVICES + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertServices(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_SERVICES + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateServices(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_SERVICES + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteServices(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_SERVICES + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Specialty

        private static string TABLE_SPECIALTY = "lkpspecialty";

        public DataSet SelectAllSpecialty()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_SPECIALTY + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllSpecialtyCombo()
        {

            strSql = "SELECT id, dname " +
                     "FROM " + TABLE_SPECIALTY + " order by dname asc ";

            return Select();
        }

        public DataSet GetSpecialtyID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_SPECIALTY + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectBySpecialtyID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_SPECIALTY + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectBySpecialtyName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_SPECIALTY + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertSpecialty(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_SPECIALTY + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateSpecialty(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_SPECIALTY + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteSpecialty(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_SPECIALTY + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Ambulance

        private static string TABLE_AMBU = "lkpAmbulance";

        public DataSet SelectAllAmbu()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_AMBU + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllAmbuCombo()
        {

            strSql = "SELECT id, concat(sname, ' (', id,')') " +
                     "FROM " + TABLE_AMBU + " order by dname asc ";

            return Select();
        }
        
        public DataSet GetAmbuID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_AMBU + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByAmbuID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_AMBU + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByAmbuName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_AMBU + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertAmbu(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_AMBU + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateAmbu(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_AMBU + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteAmbu(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_AMBU + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Diagnosis

        private static string TABLE_DIAGNOSIS = "lkpdiagnosis";

        public DataSet SelectAllDiagnosis()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_DIAGNOSIS + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllDiagnosisCombo()
        {

            strSql = "SELECT id, concat(dname, ' (', id,')') " +
                     "FROM " + TABLE_DIAGNOSIS + " order by dname asc ";

            return Select();
        }


        public DataSet GetDiagnosisID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_DIAGNOSIS + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByDiagnosisID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByDiagnosisName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertDiagnosis(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_DIAGNOSIS + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateDiagnosis(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_DIAGNOSIS + " SET " +
                COLUMN_CODE + " = '" + oClass.Code.Replace("'", "''") + "', " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteDiagnosis(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_DIAGNOSIS + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region CPT

        private static string TABLE_CPT = "lkpcpt";

        public DataSet SelectAllCPT()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_CPT + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllCPTCombo()
        {

            strSql = "SELECT id, concat(dname, ' (', id,')') " +
                     "FROM " + TABLE_CPT + " order by dname asc ";

            return Select();
        }
        
        public DataSet GetCptID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_CPT + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByCptID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_CPT + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByCptName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_CPT + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertCpt(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_CPT + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateCpt(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_CPT + " SET " +
                COLUMN_CODE + " = '" + oClass.Code.Replace("'", "''") + "', " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteCpt(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_CPT + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Allergy

        private static string TABLE_ALLERGY = "lkpallergy";

        public DataSet SelectAllAllergy()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_ALLERGY + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllAllergyCombo()
        {

            strSql = "SELECT id, concat(dname, ' (', id,')') " +
                     "FROM " + TABLE_ALLERGY + " order by dname asc ";

            return Select();
        }


        public DataSet GetAllergyID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_ALLERGY + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByAllergyID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_ALLERGY + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByAllergyName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_ALLERGY + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertAllergy(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_ALLERGY + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateAllergy(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_ALLERGY + " SET " +
                COLUMN_CODE + " = '" + oClass.Code.Replace("'", "''") + "', " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteAllergy(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_ALLERGY + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Medication List

        private static string TABLE_MEDS = "lkpmedlist";

        public DataSet SelectAllMeds()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_MEDS + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllMedsCombo()
        {

            strSql = "SELECT id, concat(dname, ' (', id,')') " +
                     "FROM " + TABLE_MEDS + " order by dname asc ";

            return Select();
        }


        public DataSet GetMedsID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_MEDS + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByMedsID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_MEDS + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByMedsName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_MEDS + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertMeds(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_MEDS + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateMeds(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_MEDS + " SET " +
                COLUMN_CODE + " = '" + oClass.Code.Replace("'", "''") + "', " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteMeds(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_MEDS + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region CommonComplaint

        private static string TABLE_CC = "lkpcc";

        public DataSet SelectAllCC()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_CC + " order by dname asc ";

            return Select();
        }

        public DataSet SelectAllCCCombo()
        {

            strSql = "SELECT id, concat(dname, ' (', id,')') " +
                     "FROM " + TABLE_CC + " order by dname asc ";

            return Select();
        }


        public DataSet GetCCID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_CC + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByCCID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_CC + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByCCName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_CC + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertCC(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_CC + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateCC(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_CC + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteCC(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_CC + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Patient List

        private static string TABLE_PATIENT = "patientregistration";
        private static string COLUMN_PATIENT_ID = "id";
        private static string COLUMN_PATIENT_NO = "patient_no";
        private static string COLUMN_DATE_REG = "date_reg";
        private static string COLUMN_LASTNAME = "last_name";
        private static string COLUMN_FIRSTNAME = "first_name";
        private static string COLUMN_DOB = "dob";
        private static string COLUMN_GENDER = "gender";
        private static string COLUMN_PHONE = "phone";
        private static string COLUMN_MOBILE = "mobile";
        private static string COLUMN_EMAIL = "email";
        private static string COLUMN_ADDRESS = "address";
        private static string COLUMN_CITY= "city";
        private static string COLUMN_STATE = "state";

        private static string COLUMN_STREET = "street";
        private static string COLUMN_ZIP = "zip";
        private static string COLUMN_RACE = "race";
        private static string COLUMN_PHYSICIAN = "physician_id";
        private static string COLUMN_ISINACTIVE = "isdeleted";
        private static string COLUMN_PICTURE = "picture";
        private static string COLUMN_MEDICARENO = "medicare_no";
        private static string COLUMN_INSURANCEID = "insurance_id";
        private static string COLUMN_MEDICAIDNO = "medicaid_no";
        private static string COLUMN_POLICYNO = "policy_no";
        private static string COLUMN_GROUPNO = "group_no";

        private static string TABLE_PATIENT_DIAGNOSIS = "patient_diagnosis";
        private static string TABLE_PATIENT_CPT = "patient_cpt";
        private static string TABLE_PATIENT_ALLERGY = "patient_allergy";
        private static string TABLE_PATIENT_MEDS = "patient_meds";

        private static string COLUMN_P_ID = "patient_id";
        private static string COLUMN_TXN_NO = "txn_no";
        private static string COLUMN_FREQUENCY = "dosage";
        private static string COLUMN_DESCRIPTION = "description";
        private static string COLUMN_START_DATE = "start_date";
        private static string COLUMN_END_DATE = "end_date";

        public DataSet SelectAllPatient()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT + " ";

            return Select();
        }

        public DataSet SelectSeachPatient(string fname, string lname, string patientNo)
        {

            strSql = "SELECT *  " +
                     "FROM " + TABLE_PATIENT + " Where 1=1 ";

            if (fname != "")
            {
                strSql = strSql + "AND first_name like '%" + fname+ "%' ";
            }
            if (lname != "")
            {
                strSql = strSql + "AND last_name like '%" + lname + "%' ";
            }
            if (patientNo != "")
            {
                strSql = strSql + "AND ID = '" + patientNo + "' ";
            }

            return Select();
        }

        public DataSet SelectAllPatientCombo()
        {

            strSql = "SELECT id, Concat(last_name, ', ', first_name) as patient_name " +
                     "FROM " + TABLE_PATIENT + " ";

            return Select();
        }
        
        public DataSet SelectCountAllPatient()
        {

            strSql = "SELECT count(patient_id), year(date_reg) as date " +
                     "FROM " + TABLE_PATIENT + " group by year(date_reg) ";

            return Select();
        }

        public DataSet SelectByPatientID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectByPatientCriteria(string sLName, string sFName)
        {
            strSql = "SELECT last_name, first_name, patient_id " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE 1=1 ";

            if (sLName != "")
            {
                strSql = strSql + " AND last_name like '%" + sLName + "%' ";
            }

            if (sFName != "")
            {
                strSql = strSql + " AND first_name like '%" + sFName + "%' ";
            }

            return Select();
        }

        public DataSet GetPatientID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_PATIENT_ID + ",4) " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE left(" + COLUMN_PATIENT_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_PATIENT_ID + ",4) desc ";

            return Select();
        }

        public DataSet GetPatientNo(string FirstNo)
        {
            strSql = "SELECT left(" + COLUMN_PATIENT_NO + ",3) " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE right(" + COLUMN_PATIENT_NO + ",10) = '" + FirstNo + "' " +
                     "ORDER BY left(" + COLUMN_PATIENT_NO + ",3) desc ";

            return Select();
        }

        public DataSet SelectByPatientSSN(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE " + COLUMN_PATIENT_NO + " = '" + oClass.SSN + "' ";

            return Select();
        }

        public DataSet SelectByPatientLName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE " + COLUMN_LASTNAME + " LIKE '%" + oClass.LName + "%' ";

            return Select();
        }

        public DataSet SelectByPatientFName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT + " " +
                     "WHERE " + COLUMN_FIRSTNAME + " LIKE '%" + oClass.FName + "%' ";

            return Select();
        }

        public DataSet SelectByPatientDiagnosis(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectByPatientDiagnosisTxn(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                     "AND " + COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "' ";

            return Select();
        }

        public DataSet SelectByPatientCPT(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_CPT + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet SelectByPatientCPTTxn(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_CPT + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                       "AND " + COLUMN_TXN_NO + " = '" + oClass.TxnNo + "' ";

            return Select();
        }

        public DataSet CheckByPatientDiagnosis(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                      "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis  + "' ";

            return Select();
        }

        public DataSet CheckByPatientDiagnosisTxn(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                      "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis + "' " +
                       "AND " + COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "' ";

            return Select();
        }

        public DataSet CheckByPatientCPT(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_CPT + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                      "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis + "' ";

            return Select();
        }

        public DataSet CheckByPatientCPTTxn(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_CPT + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                      "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis + "' " +
                       "AND " + COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "' ";

            return Select();
        }


        public DataSet SelectByPatientAllergy(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_ALLERGY + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet CheckByPatientAllergy(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_ALLERGY + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                       "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Allergy  + "' ";

            return Select();
        }

        public DataSet SelectByPatientMeds(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_MEDS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            return Select();
        }

        public DataSet CheckByPatientMeds(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PATIENT_MEDS + " " +
                     "WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' " +
                     "AND " + COLUMN_DESCRIPTION + " = '" + oClass.Meds + "' ";

            return Select();
        }
        
        public void InsertPatient(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT + " (" +
                        COLUMN_PATIENT_ID + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE_REG + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_DOB + ", " +
                        COLUMN_GENDER + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_MOBILE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_CITY + ", " +
                        COLUMN_STATE + ", " +
                        COLUMN_ZIP + ", " +
                        COLUMN_RACE + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                        COLUMN_PHYSICIAN + ", " +
                         COLUMN_NOTES + ", " +
                        COLUMN_MEDICARENO + ", " +
                        COLUMN_INSURANCEID + ", " +
                        COLUMN_MEDICAIDNO + ", " +
                        COLUMN_POLICYNO + ", " +
                        COLUMN_GROUPNO + ", " +
                        COLUMN_PICTURE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                    oClass.SSN + "', '" +
                    oClass.RegDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.LName.Replace("'", "") + "', '" +
                    oClass.FName + "', '" +
                    oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Gender + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Mobile + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.City.Replace("'", "") + "', '" +
                    oClass.State + "', '" +
                    oClass.Zip + "', '" +
                    oClass.Race + "', '" +
                    oClass.ContactPerson + "', '" +
                    oClass.PhysicianID + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                    oClass.MedicareNo + "', '" +
                    oClass.InsuranceID + "', '" +
                    oClass.MedicaidNo + "', '" +
                    oClass.PolicyNo + "', '" +
                    oClass.GroupNo + "', " +
                     "@image" + ", '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;


                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.Picture;

                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertPatientBasic(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT + " (" +
                        COLUMN_PATIENT_ID + ", " +
                        COLUMN_PATIENT_NO + ", " +
                        COLUMN_DATE_REG + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_DOB + ", " +
                        COLUMN_GENDER + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_MOBILE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_CITY + ", " +
                         COLUMN_STATE + ", " +
                        COLUMN_ZIP + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                    oClass.SSN + "', '" +
                    oClass.RegDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.LName.Replace("'", "") + "', '" +
                    oClass.FName + "', '" +
                    oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Gender + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Mobile + "', '" +
                    oClass.Email.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.City.Replace("'", "") + "', '" +
                      oClass.State  + "', '" +
                    oClass.Zip + "', '" +
                    oClass.ContactPerson + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;


                  
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatient(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.SSN + "', " +
                COLUMN_DATE_REG + " = '" + oClass.RegDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_LASTNAME + " = '" + oClass.LName.Replace("'", "''") + "', " +
                COLUMN_FIRSTNAME + " = '" + oClass.FName + "', " +
                COLUMN_DOB + " = '" + oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_GENDER + " = '" + oClass.Gender + "', " +
                COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_MOBILE + " = '" + oClass.Mobile + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "''") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                COLUMN_CITY + " = '" + oClass.City.Replace("'", "''") + "', " +
                COLUMN_STATE + " = '" + oClass.State + "', " +
                COLUMN_ZIP + " = '" + oClass.Zip + "', " +
                COLUMN_RACE + " = '" + oClass.Race + "', " +
                COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson + "', " +
                COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "', " +
                COLUMN_MEDICARENO + " = '" + oClass.MedicareNo + "', " +
                COLUMN_INSURANCEID + " = '" + oClass.InsuranceID + "', " +
                COLUMN_MEDICAIDNO + " = '" + oClass.MedicareNo + "', " +
                COLUMN_POLICYNO + " = '" + oClass.PolicyNo + "', " +
                COLUMN_GROUPNO + " = '" + oClass.GroupNo + "', " +
                COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
                COLUMN_PICTURE + " = @image, " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.Picture;

                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientEMS(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT + " SET " +
                COLUMN_PATIENT_NO + " = '" + oClass.SSN + "', " +
                COLUMN_LASTNAME + " = '" + oClass.LName.Replace("'", "''") + "', " +
                COLUMN_FIRSTNAME + " = '" + oClass.FName + "', " +
                COLUMN_DOB + " = '" + oClass.DOB.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_GENDER + " = '" + oClass.Gender + "', " +
                COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_MOBILE + " = '" + oClass.Mobile + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email.Replace("'", "''") + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                COLUMN_CITY + " = '" + oClass.City.Replace("'", "''") + "', " +
                COLUMN_STATE + " = '" + oClass.State + "', " +
                COLUMN_ZIP + " = '" + oClass.Zip + "', " +
                COLUMN_RACE + " = '" + oClass.Race + "', " +
                COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson + "', " +
                COLUMN_PHYSICIAN + " = '" + oClass.PhysicianID + "', " +
                 COLUMN_MEDICARENO + " = '" + oClass.MedicareNo + "', " +
                COLUMN_INSURANCEID + " = '" + oClass.InsuranceID + "', " +
                COLUMN_MEDICAIDNO + " = '" + oClass.MedicareNo + "', " +
                COLUMN_POLICYNO + " = '" + oClass.PolicyNo + "', " +
                COLUMN_GROUPNO + " = '" + oClass.GroupNo + "', " +
                COLUMN_PICTURE + " = @image, " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.Picture;

                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientInactive(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT + " SET " +
                COLUMN_ISINACTIVE + " = " + oClass.IsInactive + ", " +
                " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.Blob);
                    param.Value = oClass.Picture;

                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatient(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            //strSql = "DELETE  FROM " + TABLE_PATIENT + " " +
            //        " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";
            strSql = "Update  " + TABLE_PATIENT + " " +
                    "SET isDeleted = " + oClass.IsDeleted + " deleteReason = '" + oClass.ReasonDelete + "' " +
                    " WHERE " + COLUMN_PATIENT_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertPatientDiagnosis(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT_DIAGNOSIS + " (" +
                        COLUMN_P_ID + ", " +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_START_DATE + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_DESCRIPTION + ", " +
                        COLUMN_NOTES + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                      oClass.TxnNo  + "', '" +
                    oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DiagnosisCode + "', '" +
                    oClass.Diagnosis.Replace("'", "") + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                     currUser + "', " +
                     "CurDate(), '" +
                      currUser + "', " +
                      "CurDate() " +
                      ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientDiagnosis(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT_DIAGNOSIS + " SET " +
                COLUMN_P_ID + " = '" + oClass.PatientID + "', " +
                  COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "', " +
                COLUMN_START_DATE + " = '" + oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_CODE + " = '" + oClass.DiagnosisCode + "', " +
                COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis.Replace("'", "''") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertPatientCPT(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT_CPT + " (" +
                        COLUMN_P_ID + ", " +
                        COLUMN_TXN_NO + ", " +
                        COLUMN_START_DATE + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_DESCRIPTION + ", " +
                        COLUMN_NOTES + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                      oClass.TxnNo + "', '" +
                    oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DiagnosisCode + "', '" +
                    oClass.Diagnosis.Replace("'", "") + "', '" +
                    oClass.Notes.Replace("'", "") + "', '" +
                     currUser + "', " +
                     "CurDate(), '" +
                      currUser + "', " +
                      "CurDate() " +
                      ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientCPT(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT_CPT + " SET " +
                COLUMN_P_ID + " = '" + oClass.PatientID + "', " +
                  COLUMN_TXN_NO + " = '" + oClass.TxnNo + "', " +
                COLUMN_START_DATE + " = '" + oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                COLUMN_CODE + " = '" + oClass.DiagnosisCode + "', " +
                COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis.Replace("'", "''") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientDiagnosis(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientDiagnosisByID(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                    " WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientDiagnosisByTxnNo(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_DIAGNOSIS + " " +
                    " WHERE " + COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientCPT(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_CPT + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientCPTByID(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_CPT + " " +
                    " WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientCPTByTxnNo(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_CPT + " " +
                    " WHERE " + COLUMN_TXN_NO + " = '" + oClass.TxnNo  + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertPatientAllergy(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT_ALLERGY + " (" +
                        COLUMN_P_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_DESCRIPTION + ", " +
                        COLUMN_NOTES + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                    oClass.DiagnosisCode + "', '" +
                    oClass.Diagnosis.Replace("'", "") + "', '" +
                    oClass.Notes + "', '" +
                     currUser + "', " +
                     "CurDate(), '" +
                      currUser + "', " +
                      "CurDate() " +
                      ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientAllergy(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT_ALLERGY + " SET " +
                COLUMN_P_ID + " = '" + oClass.PatientID + "', " +
                COLUMN_CODE + " = '" + oClass.DiagnosisCode + "', " +
                COLUMN_DESCRIPTION + " = '" + oClass.Diagnosis.Replace("'", "''") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientAllergy(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_ALLERGY + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientAllergyByID(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_ALLERGY + " " +
                    " WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void InsertPatientMeds(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PATIENT_MEDS + " (" +
                        COLUMN_P_ID + ", " +
                        COLUMN_CODE + ", " +
                        COLUMN_DESCRIPTION + ", " +
                        COLUMN_FREQUENCY + ", " +
                        COLUMN_START_DATE + ", " +
                         COLUMN_NOTES + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.PatientID + "', '" +
                    oClass.MedsCode + "', '" +
                    oClass.Meds + "', '" +
                    oClass.MedsDose + "', '" +
                    oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.Notes + "', '" +
                     currUser + "', " +
                     "CurDate(), '" +
                      currUser + "', " +
                      "CurDate() " +
                      ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePatientMeds(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PATIENT_MEDS + " SET " +
                COLUMN_P_ID + " = '" + oClass.PatientID + "', " +
                COLUMN_CODE + " = '" + oClass.MedsCode + "', " +
                COLUMN_DESCRIPTION + " = '" + oClass.Meds + "', " +
                COLUMN_FREQUENCY + " = '" + oClass.MedsDose + "', " +
                COLUMN_START_DATE + " = '" + oClass.StartDate.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_NOTES + " = '" + oClass.Notes.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientMeds(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_MEDS + " " +
                    " WHERE id = " + oClass.ID + " ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePatientMedsByID(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PATIENT_MEDS + " " +
                    " WHERE " + COLUMN_P_ID + " = '" + oClass.PatientID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }


        #endregion

        #region Insurance

        private static string TABLE_INSURANCE = "lkpinsurance";
        private static string COLUMN_INSURANCE_ID = "insurance_id";
        private static string COLUMN_COMPANY = "company";
        private static string COLUMN_CONTACT_PERSON = "contact_person";

        public DataSet SelectAllInsurance()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_INSURANCE + " order by company asc ";

            return Select();
        }

        public DataSet SelectAllInsuranceCombo()
        {

            strSql = "SELECT insurance_id, Concat(code, ' - ', company) as company " +
                     "FROM " + TABLE_INSURANCE + " union Select null, '-SELECT-'  order by company asc ";

            return Select();
        }

        public DataSet GetInsuranceID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_INSURANCE_ID + ",4) " +
                     "FROM " + TABLE_INSURANCE + " " +
                     "WHERE left(" + COLUMN_INSURANCE_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_INSURANCE_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByInsuranceID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_INSURANCE + " " +
                     "WHERE " + COLUMN_INSURANCE_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByInsuranceName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_INSURANCE + " " +
                     "WHERE " + COLUMN_COMPANY + " LIKE '%" + oClass.Company + "%' ";

            return Select();
        }

        public void InsertInsurance(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_INSURANCE + " (" +
                        COLUMN_INSURANCE_ID + ", " +
                         COLUMN_CODE + ", " +
                        COLUMN_COMPANY + ", " +
                        COLUMN_CONTACT_PERSON + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_DATE_ACC + ", " +
                        COLUMN_DATE_EXPIRE + ", " +
                          "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Code  + "', '" +
                    oClass.Company.Replace("'", "") + "', '" +
                    oClass.ContactPerson.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email + "', '" +
                    oClass.DateAcc.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                    oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateInsurance(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_INSURANCE + " SET " +
                 COLUMN_COMPANY + " = '" + oClass.Company.Replace("'", "''") + "', " +
                 COLUMN_CONTACT_PERSON + " = '" + oClass.ContactPerson.Replace("'", "''") + "', " +
                 COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                 COLUMN_CODE + " = '" + oClass.Code  + "', " +
                 COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                 COLUMN_EMAIL + " = '" + oClass.Email + "', " +
                 COLUMN_DATE_ACC + " = '" + oClass.DateAcc.ToString("yyyy-MM-d HH:MM:ss") + "', " +
                 COLUMN_DATE_EXPIRE + " = '" + oClass.DateExpire.ToString("yyyy-MM-d HH:MM:ss") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_INSURANCE_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteInsurance(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_INSURANCE + " " +
                  " WHERE " + COLUMN_INSURANCE_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Physician

        private static string TABLE_PHYSICIAN = "lkpdoctor";
        private static string COLUMN_PHYSICIAN_ID = "physician_id";
        private static string COLUMN_SPECIALTY = "specialty";
     
        public DataSet SelectAllPhysician()
        {

            strSql = "SELECT a.physician_id, a.last_name, a.first_name, a.address, a.email, a.phone, b.dname as specialty " +
                     "FROM " + TABLE_PHYSICIAN + " a " +
                     "Left outer join " + TABLE_SPECIALTY + " b on a.specialty = b.id " +
                     " order by last_name asc ";

            return Select();
        }

        public DataSet SelectAllPhysicianCombo()
        {

            strSql = "SELECT physician_id, Concat(last_name, ', ', first_name) as physician_name " +
                     "FROM " + TABLE_PHYSICIAN + " union Select null, '-SELECT-' order by physician_name asc";

            return Select();
        }

        public DataSet GetPhysicianID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_PHYSICIAN_ID + ",4) " +
                     "FROM " + TABLE_PHYSICIAN + " " +
                     "WHERE left(" + COLUMN_PHYSICIAN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_PHYSICIAN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByPhysicianID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PHYSICIAN + " " +
                     "WHERE " + COLUMN_PHYSICIAN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByPhysicianLName(LookUpClass oClass)
        {
            //strSql = "SELECT * " +
            //         "FROM " + TABLE_PHYSICIAN + " " +
            //         "WHERE " + COLUMN_LASTNAME + " LIKE '%" + oClass.LName + "%' ";

            strSql = "SELECT * " +
                    "FROM " + TABLE_PHYSICIAN + " " +
                    "WHERE 1=1 ";

            if (oClass.LName != "")
            {
                strSql = strSql + "AND " + COLUMN_LASTNAME + " LIKE '%" + oClass.LName + "%' ";
            }
            if (oClass.FName != "")
            {
                strSql = strSql + "AND " + COLUMN_FIRSTNAME + " LIKE '%" + oClass.FName + "%' ";
            }

            return Select();
        }

        public void InsertPhysician(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PHYSICIAN + " (" +
                        COLUMN_PHYSICIAN_ID + ", " +
                        COLUMN_LASTNAME + ", " +
                        COLUMN_FIRSTNAME + ", " +
                        COLUMN_SPECIALTY + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_EMAIL + ", " +
                        COLUMN_PHONE + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.LName + "', '" +
                    oClass.FName + "', '" +
                    oClass.Specialty.Replace("'", "") + "', '" +
                    oClass.Address.Replace("'", "") + "', '" +
                    oClass.Email + "', '" +
                    oClass.Phone + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdatePhysician(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PHYSICIAN + " SET " +
                 COLUMN_LASTNAME + " = '" + oClass.LName + "', " +
                 COLUMN_FIRSTNAME + " = '" + oClass.FName + "', " +
                 COLUMN_ADDRESS + " = '" + oClass.Address.Replace("'", "''") + "', " +
                 COLUMN_SPECIALTY + " = '" + oClass.Specialty.Replace("'", "''") + "', " +
                 COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                 COLUMN_EMAIL + " = '" + oClass.Email + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_PHYSICIAN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeletePhysician(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PHYSICIAN + " " +
                  " WHERE " + COLUMN_PHYSICIAN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Types

        private static string TABLE_TYPE = "lkptype";
        //private static string COLUMN_CODE = "code";

     
        public DataSet SelectAllType()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_TYPE + " ";

            return Select();
        }

        public DataSet SelectAllTypeCombo()
        {

            strSql = "SELECT id, dname " +
                     "FROM " + TABLE_TYPE + " union Select null, '-SELECT-'  order by dname asc ";

            return Select();
        }

    
        public DataSet GetTypeID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_TYPE + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByTypeID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_TYPE + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByTypeName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_TYPE + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertType(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_TYPE + " (" +
                        COLUMN_ID + ", " +
                        COLUMN_SNAME + ", " +
                         "created_by, created_date, updated_by, updated_date) ";
            strSql = strSql + "values ('" +
                    oClass.ID + "', '" +
                    oClass.Desc.Replace("'", "") + "', '" +
                     currUser + "', " +
                    "CurDate(), '" +
                    currUser + "', " +
                    "CurDate() " +
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateType(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_TYPE + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "', " +
               " updated_by = '" + user + "', " +
                " updated_date = '" + DateTime.Now.ToString("yyyy-MM-d HH:MM:ss") + "' " +
                " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteType(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_TYPE + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region Province

      // private static string TABLE_PROVINCE = "lkpprovinces";
        //private static string COLUMN_CODE = "code";


        public DataSet SelectAllProvince()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_PROVINCE + " ";

            return Select();
        }

        //public DataSet SelectAllProvinceCombo()
        //{

        //    strSql = "SELECT id, name " +
        //             "FROM " + TABLE_PROVINCE + " union Select null, '-SELECT-'  order by name asc ";

        //    return Select();
        //}


        public DataSet GetProvinceID(string FirstNo)
        {
            strSql = "SELECT right(" + COLUMN_ID + ",4) " +
                     "FROM " + TABLE_PROVINCE + " " +
                     "WHERE left(" + COLUMN_ID + ",8) = '" + FirstNo + "' " +
                     "ORDER BY right(" + COLUMN_ID + ",4) desc ";

            return Select();
        }

        public DataSet SelectByProvinceID(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PROVINCE + " " +
                     "WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            return Select();
        }

        public DataSet SelectByProvinceName(LookUpClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_PROVINCE + " " +
                     "WHERE " + COLUMN_SNAME + " LIKE '%" + oClass.Desc + "%' ";

            return Select();
        }

        public void InsertProvince(string currUser, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "INSERT INTO " + TABLE_PROVINCE + " (" +
                       COLUMN_SNAME + " " +
                         ") ";
            strSql = strSql + "values ('" +
                    oClass.Desc.Replace("'", "") + "'" +                
                    ") ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void UpdateProvince(string user, LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "UPDATE " + TABLE_PROVINCE + " SET " +
                COLUMN_SNAME + " = '" + oClass.Desc.Replace("'", "''") + "' " +
                 " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void DeleteProvince(LookUpClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();

            strSql = "DELETE  FROM " + TABLE_PROVINCE + " " +
                  " WHERE " + COLUMN_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        #endregion


        
            
    }
}