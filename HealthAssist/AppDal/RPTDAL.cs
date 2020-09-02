using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using EvoCMS.AppCommon;
using EvoCMS.AppClass;
using System.Configuration;

namespace EvoCMS.AppDal
{
    class RPTDAL
    {
        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;
        private string strSql;

        public RPTDAL()
        {
            oConnection = new DALConnectionClass();
        }

        public DataSet Select(string str)
        {
            DataSet myDataset = new DataSet();
            myCon = new MySqlConnection();
            try
            {
                if (oConnection.OpenConnection())
                {
                    strSql = str;
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

      
    }
}
