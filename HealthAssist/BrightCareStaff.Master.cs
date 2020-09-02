using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using System.Data;

namespace HealthAssist
{
    public partial class BrightCareStaff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("~/login.aspx");
            if (!(IsPostBack))
            {
                if (Session["User"] == null) Response.Redirect("~/login.aspx");
                else
                    PopulateUser();
                
            }
        }

        private void PopulateUser()
        {
            UserClass oClass = new UserClass();
            UserDAL oDal = new UserDAL();
            DataSet oDS = new DataSet();

            oClass.UserName = Session["User"].ToString();
            oDS = oDal.LoadByUserName(oClass);

            if (oDS != null)
            {
                currentUserLabel.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
                UserLabelLeft.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
                UserLabelProfile.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
            }

        }
    }
}