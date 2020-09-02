using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthAssist
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("~/login.aspx");
            if (!(IsPostBack))
            {
                if (Session["User"] == null) Response.Redirect("~/login.aspx");

                //lblUser1.Text = Session["User"].ToString();
            }
        }
    }
}