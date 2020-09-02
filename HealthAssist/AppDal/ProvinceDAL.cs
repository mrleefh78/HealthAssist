using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HealthAssist.AppCommon;

namespace HealthAssist.AppDal
{
    public class ProvinceDAL : BaseDAL
    {
        public ProvinceDAL()
        {

        }

        private static string TABLE_NAME = ConstantConfiguration.TABLE_PROVINCE;
        private string strSql;
        public DataSet SelectAll()
        {

            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " ";

            return Select(strSql);
        }
    }
}