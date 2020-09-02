using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using HealthAssist.AppClass;
using HealthAssist.AppCommon;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Odbc;

namespace HealthAssist.AppDal
{
    #region UserProfile
    public class UserDAL
    {
        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        private OdbcConnection mc;
        public MySqlDataAdapter myDataAdapter;
        private string strSql;
     
        private static string TABLE_NAME = "users";
        private static string COLUMN_USER_ID = "user_id";
        private static string COLUMN_LAST_NAME = "last_name";
        private static string COLUMN_FIRST_NAME = "first_name";
        private static string COLUMN_USER_NAME = "user_name";
        private static string COLUMN_USER_PASSWORD = "user_password";
        private static string COLUMN_ACCOUNT_TYPE = "account_type";
        private static string COLUMN_POSITION = "position_id";
        private static string COLUMN_IS_ACTIVE = "is_active";
        private static string COLUMN_SIGN = "signature";

        private static string COLUMN_EMPNO = "employee_id";
        
        public UserDAL()
        {
            oConnection = new DALConnectionClass();
        }

        public DataSet Select()
        {
            DataSet myDataset = new DataSet();
            myCon = new MySqlConnection();
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

        public DataSet SelectAllUsers()
        {
            strSql = "SELECT a.*, b.dname as position " +
                     "FROM " + TABLE_NAME + " a left outer join lkpposition b on a.position_id = b.id " +
                     "ORDER By " + COLUMN_USER_ID + " asc ";

            return Select();
        }

        public DataSet SelectUsers()
        {
            strSql = "SELECT user_id, employee_id, last_name, first_name, user_name, account_type " +
                     "FROM " + TABLE_NAME + "  " +
                     "ORDER By " + COLUMN_USER_ID + " asc ";

            return Select();
        }

        public DataSet SelectSeachUsers(string fname, string lname, string empid)
        {

            strSql = "SELECT user_id, employee_id, lastname, firstname, user_name, account_type  " +
                     "FROM " + TABLE_NAME + " Where 1=1 ";

            if (fname != "")
            {
                strSql = strSql + "AND first_name like '%" + fname + "%' ";
            }
            if (lname != "")
            {
                strSql = strSql + "AND last_name like '%" + lname + "%' ";
            }
            {
                strSql = strSql + "AND employee_id = '" + empid + "' ";
            }
          

            return Select();
        }

        public DataSet SelectUserID(string FirstNo)
        {
            string strSql;
            strSql = "SELECT right(user_id,4) " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE left(user_id,8) = '" + FirstNo + "' " +
                     "ORDER BY right(user_id,4) desc ";

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

        public DataSet LoadUserByID(UserClass oClass)
        {
            string strSql;
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_ID + " = '" + oClass.UserID + "' ";

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

        public DataSet LoadUserByPosition(UserClass oClass)
        {
            string strSql;
            strSql = "SELECT a.user_id, Concat(a.last_name, ', ', a.first_name) as uname  " +
                     "FROM " + TABLE_NAME + " A left outer join lkpposition b on b.id = a.position_id ";
                     //"WHERE b.dname = '" + oClass.PositionID + "' ";

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

        public DataSet LoadByUserName(UserClass oClass)
        {
            strSql = "SELECT *, Concat(firstname, ' ', lastname) as Fullname " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_NAME + " = '" + oClass.UserName + "' ";

            return Select();
        }

        public DataSet CheckUserName(UserClass oClass)
        {
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_NAME + " = '" + oClass.UserName + "' ";

            return Select();
        }

        public DataSet CheckUserNamePassword(UserClass oClass)
        {
            string strSql;
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_NAME + " = '" + oClass.UserName + "' " +
                     "AND " + COLUMN_USER_PASSWORD + " = '" + oClass.Password  + "' ";

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

        public void Insert(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_USER_ID + ", " +
                        COLUMN_LAST_NAME + ", " +
                        COLUMN_FIRST_NAME + ", " +
                        COLUMN_USER_NAME + ", " +
                        COLUMN_USER_PASSWORD + ", " +
                        COLUMN_ACCOUNT_TYPE + ", " +
                          COLUMN_EMPNO + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.UserID + "', '" +
                    oClass.LastName + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.UserName + "', '" +
                    oClass.Password + "', '" +
                    oClass.AccountType + "', '" +
                    oClass.PositionID  + "', '" +
                    currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
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

        public void Insert2(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_USER_ID + ", " +
                        COLUMN_LAST_NAME + ", " +
                        COLUMN_FIRST_NAME + ", " +
                        COLUMN_USER_NAME + ", " +
                        COLUMN_USER_PASSWORD + ", " +
                        COLUMN_ACCOUNT_TYPE + ", " +
                        COLUMN_POSITION + ", " +
                         COLUMN_SIGN + ", " +
                        "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                    oClass.UserID + "', '" +
                    oClass.LastName + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.UserName + "', '" +
                    oClass.Password + "', '" +
                    oClass.AccountType + "', '" +
                    oClass.PositionID + "', " +
                       "@image" + ", '" +
                    currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                    ") ";
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    myCon = oConnection.ConnectionObject;
                   MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    param.Value = oClass.Sign;
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

        public void Update(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_LAST_NAME + " = '" + oClass.LastName + "', " +
                COLUMN_FIRST_NAME + " = '" + oClass.FirstName + "', " +
                COLUMN_USER_NAME + " = '" + oClass.UserName + "', " +
                COLUMN_USER_PASSWORD + " = '" + oClass.Password + "', " +
                COLUMN_ACCOUNT_TYPE + " = '" + oClass.AccountType + "', " +
                  COLUMN_EMPNO + " = '" + oClass.PositionID  + "', " +
                "updated_by" + " = '" + currUser + "', " +
                "updated_date" + " = '" + DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                " WHERE " + COLUMN_USER_ID + " = '" + oClass.UserID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_ID, oClass.UserID);
                    //cmd.Parameters.AddWithValue(@COLUMN_LAST_NAME, oClass.LastName);
                    //cmd.Parameters.AddWithValue(@COLUMN_FIRST_NAME, oClass.FirstName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_NAME, oClass.UserName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_PASSWORD, oClass.Password);
                    //cmd.Parameters.AddWithValue(@COLUMN_ACCOUNT_TYPE, oClass.AccountType);
                    //cmd.Parameters.AddWithValue(@COLUMN_IS_ACTIVE, oClass.IsActive);
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

        public void Update2(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_LAST_NAME + " = '" + oClass.LastName + "', " +
                COLUMN_FIRST_NAME + " = '" + oClass.FirstName + "', " +
                COLUMN_USER_NAME + " = '" + oClass.UserName + "', " +
                COLUMN_USER_PASSWORD + " = '" + oClass.Password + "', " +
                COLUMN_ACCOUNT_TYPE + " = '" + oClass.AccountType + "', " +
                  COLUMN_POSITION + " = '" + oClass.PositionID + "', " +
               COLUMN_SIGN + " = @image, " +
                "updated_by" + " = '" + currUser + "', " +
                "updated_date" + " = '" + DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                " WHERE " + COLUMN_USER_ID + " = '" + oClass.UserID + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    MySqlParameter param = cmd.Parameters.Add("@image", MySqlDbType.LongBlob);
                    param.Value = oClass.Sign;
                    cmd.CommandText = strSql;
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_ID, oClass.UserID);
                    //cmd.Parameters.AddWithValue(@COLUMN_LAST_NAME, oClass.LastName);
                    //cmd.Parameters.AddWithValue(@COLUMN_FIRST_NAME, oClass.FirstName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_NAME, oClass.UserName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_PASSWORD, oClass.Password);
                    //cmd.Parameters.AddWithValue(@COLUMN_ACCOUNT_TYPE, oClass.AccountType);
                    //cmd.Parameters.AddWithValue(@COLUMN_IS_ACTIVE, oClass.IsActive);
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

        public void UpdatePassword(UserClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "UPDATE " + TABLE_NAME + " SET " +
               COLUMN_USER_PASSWORD + " = '" + oClass.Password + "' " +
                 " WHERE " + COLUMN_USER_NAME + " = '" + oClass.UserName + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_ID, oClass.UserID);
                    //cmd.Parameters.AddWithValue(@COLUMN_LAST_NAME, oClass.LastName);
                    //cmd.Parameters.AddWithValue(@COLUMN_FIRST_NAME, oClass.FirstName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_NAME, oClass.UserName);
                    //cmd.Parameters.AddWithValue(@COLUMN_USER_PASSWORD, oClass.Password);
                    //cmd.Parameters.AddWithValue(@COLUMN_ACCOUNT_TYPE, oClass.AccountType);
                    //cmd.Parameters.AddWithValue(@COLUMN_IS_ACTIVE, oClass.IsActive);
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

        public void Delete(UserClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "DELETE  FROM " + TABLE_NAME + " " +
                    " WHERE " + COLUMN_USER_ID + " = '" + oClass.UserID  + "' ";

            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                   // cmd.Parameters.AddWithValue(@COLUMN_USER_ID, oClass.UserID );
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

    }
    #endregion
}
