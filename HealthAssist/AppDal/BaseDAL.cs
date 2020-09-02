using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthAssist.AppCommon;
using HealthAssist.AppClass;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace HealthAssist.AppDal
{
    public class BaseDAL
    {
        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;
       
        public BaseDAL()
        {
            oConnection = new DALConnectionClass();
        }

        public DataSet Select(string strSql)
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

        public void SaveData(string strSql)
        {
            MySqlCommand cmd = new MySqlCommand();

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

        public int SaveDataReturn(string strSql)
        {
            MySqlCommand cmd = new MySqlCommand();
            int returnValue = 0;
            try
            {
                if (oConnection.OpenConnection())
                {
                    //MySqlParameter returnParameter = cmd.Parameters.AddWithValue("RetVal", SqlDbType.Int);
                    //returnParameter.Direction = ParameterDirection.ReturnValue;

                    myCon = oConnection.ConnectionObject;

                    cmd.Connection = myCon;
                    cmd.CommandText = strSql + " SELECT LAST_INSERT_ID(); ";
                   cmd.ExecuteNonQuery();
                    returnValue = (int)cmd.LastInsertedId;
                   // returnValue = (int)returnParameter.Value;
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

            return returnValue;
        }
    }
}