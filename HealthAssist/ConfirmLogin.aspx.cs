using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthAssist
{
    public partial class ConfirmLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (Session["UserLoginCode"] == null) Response.Redirect("~/login.aspx");
            }
        }

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["UserLoginCode"].ToString() == txbCode.Text)
            {
                if (Session["UserType"].ToString() == "Admin")
                {

                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Dashboard.aspx");

                }
            }
            else
            {
                //Label lb = LoginUser.FindControl("lblError") as Label;
                string script = "<script type=\"text/javascript\">alert('Invalid Code');</script>";
                Response.Write(script);
                // Response.Write("<script>alert('Invalid User');</script>");

            }

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}