using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Odbc;

namespace HealthAssist.AppCommon
{
    public class DALConnectionClass
    {
        private MySqlConnection mycon;
        private OdbcConnection mc;

        public MySqlConnection ConnectionObject
        {
            get
            {
                return mycon;
            }
            set
            {
                mycon = value;
            }
        }

        public OdbcConnection ConnectionObjectOdbc
        {
            get
            {
                return mc;
            }
            set
            {
                mc = value;
            }
        }

        public bool OpenConnection()
        {
            //var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //ConfigurationManager.RefreshSection("AppSettings");
            string connection_str = "server=" + ConfigurationManager.AppSettings["Server"] + ";uid=" +
                                            ConfigurationManager.AppSettings["User ID"] + ";pwd=" +
                                            ConfigurationManager.AppSettings["Password"] + ";database=" +
                                            ConfigurationManager.AppSettings["Database Name"];


           // var connection_str = ConfigurationManager.AppSettings["ConnectionStringMy"];//appConfig.AppSettings.Settings["EvoCMS.Properties.Settings.ConnectionString"].Value + appConfig.AppSettings.Settings["DataSource"].Value + appConfig.AppSettings.Settings["PersistSecurity"].Value;
            MySqlConnection mycon = new MySqlConnection(connection_str + "; Allow User Variables=True");
           
            mycon.Open();
            ConnectionObject = mycon;
            return true;
        }

        public bool OpenConnectionOdbc()
        {
            //var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //ConfigurationManager.RefreshSection("AppSettings");
            //string connection_str = "server=" + ConfigurationManager.AppSettings["Server"] + ";uid=" +
            //                                ConfigurationManager.AppSettings["User ID"] + ";pwd=" +
            //                                ConfigurationManager.AppSettings["Password"] + ";database=" +
            //                                ConfigurationManager.AppSettings["Database Name"];


            var connection_str = ConfigurationManager.AppSettings["ConnectionStringOdbc"];//appConfig.AppSettings.Settings["EvoCMS.Properties.Settings.ConnectionString"].Value + appConfig.AppSettings.Settings["DataSource"].Value + appConfig.AppSettings.Settings["PersistSecurity"].Value;
            mc = new OdbcConnection(connection_str);
            mc.Open();
            ConnectionObjectOdbc = mc;
            return true;
        }

        public Boolean CloseConnection()
        {
            mycon.Close();
            ConnectionObject = mycon;
            return true;
        }       
    }
}