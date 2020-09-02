using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthAssist.AppCommon;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;


namespace HealthAssist.AppClass
{
    class rptClass
    {

        private DALConnectionClass oConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;
        private string strSql;

        public rptClass()
        {
            oConnection = new DALConnectionClass();
        }

        public void ShowReport(CrystalDecisions.Windows.Forms.CrystalReportViewer obj, string sql, string repname)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument objReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
            try
            {
                objReport.Load(repname);


                foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in objReport.Database.Tables)
                {
                    ConInfo = tbCurrent.LogOnInfo;
                    ConInfo.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["ReportProvider"];
                    ConInfo.ConnectionInfo.UserID = ConfigurationManager.AppSettings["User ID"];
                    ConInfo.ConnectionInfo.Password = ConfigurationManager.AppSettings["Password"];
                    ConInfo.ConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["Database Name"];

                    tbCurrent.ApplyLogOnInfo(ConInfo);


                }

                DataSet objds = Select(sql);
                objReport.SetDataSource(objds.Tables[0]);
                obj.ReportSource = objReport;

            }
            catch
            {
                //return null;
            }
            finally
            {


            }
        }

        public DataSet Select(string ReportSql)
        {
            DataSet myDataset = new DataSet();
            myCon = new MySqlConnection();
            try
            {
                if (oConnection.OpenConnection())
                {
                    myCon = oConnection.ConnectionObject;
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(ReportSql, myCon);
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

        //public DataSet SelectPatients()
        //{
        //    strSql = "SELECT * " +
        //            "FROM patientregistry ";

        //    return Select();
        //}

    }

     
}