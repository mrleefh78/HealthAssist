using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using HealthAssist.AppCommon;
using System.Data;
using System.Net.Mail;

namespace HealthAssist
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                Session["UserType"] = "";
                Session["UserID"] = "";
                Session["User"] = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            HealthAssistLogin();
        }

        private void HealthAssistLogin()
        {
            UserClass oClass = new UserClass();
            UserDAL oDal = new UserDAL();
            DataSet oDS = new DataSet();

            // oClass.UserID = UserName.text; 
            //TextBox un =   LoginUser.FindControl("UserName") as TextBox;
            oClass.UserName = txbUsername.Text;
            oDS = oDal.CheckUserName(oClass);

            if (oDS != null)
            {
                if (oDS.Tables[0].Rows.Count > 0)
                {
                    oClass = new UserClass();
                    oDal = new UserDAL();

                    DataSet oDSPwd = new DataSet();

                    //TextBox un1 = UserName.Text;//LoginUser.FindControl("UserName") as TextBox;
                    //TextBox pwd = LoginUser.FindControl("Password") as TextBox;
                    oClass.UserName = txbUsername.Text;
                    oClass.Password = EncryptDecryptProvider.EncryptString("b14ca5898a4e4133bbce2ea2315a1916",txbPassword.Text);
                    oDSPwd = oDal.CheckUserNamePassword(oClass);

                    if (oDSPwd.Tables[0].Rows.Count > 0)
                    {
                        //Response.Redirect("WebFormClientList.aspx");

                        Session["UserType"] = oDSPwd.Tables[0].Rows[0]["account_type"].ToString();
                        Session["UserID"] = oDSPwd.Tables[0].Rows[0][0].ToString();
                        Session["User"] = txbUsername.Text;

                        
                        //Session["UserLoginCode"] = GenerateRandomNumber(1000,9999);
                        //SendEmail(oDSPwd.Tables[0].Rows[0]["email"].ToString());
                        //Response.Redirect("ConfirmLogin.aspx");

                        //Response.Redirect("Dashboard.aspx");
                        if (Session["UserType"].ToString() == "Admin")
                        {

                            Response.Redirect("Dashboard.aspx");
                        }

                        else if (Session["UserType"].ToString() == "Staff")
                        {
                            Response.Redirect("Patient.aspx");

                        }
                        else if (Session["UserType"].ToString() == "Physician")
                        {
                            Response.Redirect("Physician/EncounterList.aspx?View=Pending");

                         }

                        }
                    else
                    {
                        //Label lb = LoginUser.FindControl("lblError") as Label;
                        string script = "<script type=\"text/javascript\">alert('Please check your password');</script>";
                        Response.Write(script);

                    }

                }

                else
                {
                    //Label lb = LoginUser.FindControl("lblError") as Label;
                    string script = "<script type=\"text/javascript\">alert('Invalid User');</script>";
                    Response.Write(script);
                    // Response.Write("<script>alert('Invalid User');</script>");

                }
            }
        }

        public int GenerateRandomNumber(int min, int max)
        {
             Random random = new Random();           
            return random.Next(min, max);
        }

        private void SendEmail(string emailReceiver)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential("fernand.h.lee@gmail.com", "@priL102010");
                // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("fernand.h.lee@gmail.com");
                mail.To.Add(new MailAddress(emailReceiver));

                mail.Subject = "Health Assist Login Code";
                mail.Body = "Your login Code is <h3><b>" + Session["UserLoginCode"].ToString() + "</b></h3>";
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);

                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("ws9securemail.win.arvixe.com");

                //mail.From = new MailAddress("fernan.lee@brightcare-assist.com");
                //mail.To.Add(emailReceiver);
                //mail.Subject = "Health Assist Login Code";
                //mail.Body = "Your login Code is <b>" + Session["UserLoginCode"].ToString();

                //SmtpServer.Port = 465;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("fernan.lee@brightcare-assist.com", "@priL102010");
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}