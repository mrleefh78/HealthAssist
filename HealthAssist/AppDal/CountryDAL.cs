using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class CountryDAL : BaseDAL
    {
        public CountryDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_COUNTRY;
        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " ";

            return Select(strSql);
        }
    }
}