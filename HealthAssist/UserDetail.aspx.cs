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

namespace HealthAssist
{
    public partial class UserDetail : System.Web.UI.Page
    {
        private UsersDAL oDAL;
        private UserModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
               
                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));

                }

                string physicianID = Request.QueryString["physicianID"].ToString();

               if (physicianID!="")
                {
                    LoadPhyscianData(Convert.ToInt16(physicianID));
                }


            }
        }

        private void LoadPhyscianData(int id)
        {
            PhysicianDAL physicianDAL = new PhysicianDAL();
            PhysicianModel physicianClass = new PhysicianModel();
            oDs = new DataSet();

            physicianClass.ID = id;

            oDs = physicianDAL.SelectByID(physicianClass);
            //PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            LastName.Value = oDs.Tables[0].Rows[0]["LastName"].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0]["FirstName"].ToString();
           // Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
            //  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0][4].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0]["address"].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0]["email"].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0]["phone"].ToString();

            if (oDs.Tables[0].Rows[0]["UserID"].ToString() !="")
            {
                var userid = oDs.Tables[0].Rows[0]["UserID"].ToString();
                PopulateData(Convert.ToInt16(userid));
            }

        }

        //private void LoadCountry()
        //{
        //    CountryDAL countryDAL = new CountryDAL();

        //    ddlCountryCode.DataSource = countryDAL.SelectAll();
        //    ddlCountryCode.DataTextField = "Name";
        //    ddlCountryCode.DataValueField = "Code";
        //    ddlCountryCode.DataBind();
        //}
        private void PopulateData(int id)
        {
            oDAL = new UsersDAL();
            oClass = new UserModel();
            oDs = new DataSet();

            oClass.ID = id;
            
            oDs = oDAL.SelectByID(oClass);
            UserID.Value = oDs.Tables[0].Rows[0][0].ToString();
            //UserName.Value = oDs.Tables[0].Rows[0][1].ToString();
            UserName.Value = oDs.Tables[0].Rows[0][2].ToString();
            UserPassword.Value = EncryptDecryptProvider.DecryptString("b14ca5898a4e4133bbce2ea2315a1916", oDs.Tables[0].Rows[0][3].ToString());
            LastName.Value = oDs.Tables[0].Rows[0][4].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0][5].ToString();
            AccountType.Value = oDs.Tables[0].Rows[0][6].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][9].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0][10].ToString();

        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Users.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new UsersDAL();
            oClass = new UserModel();


            oClass.UserName = UserName.Value;
            oClass.UserPassword = EncryptDecryptProvider.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", UserPassword.Value);
            oClass.LastName = LastName.Value;
            oClass.FirstName = FirstName.Value;
            oClass.AccountType = AccountType.Value;
            oClass.Address = txtAddress.InnerText;
            oClass.Phone = txtContact.Value;
            oClass.Email = txtEmail.Value;

            string id = UserID.Value;
            if (id == "")
            {
                oDAL.InsertData(sUserName, oClass);
                //lblMsg.Text = "New Record has been saved";
            }
            else
            {
                oClass.ID = Convert.ToInt16(id);
                oDAL.UpdateData(sUserName, oClass);
                // lblMsg.Text = "Record has been updated";

            }
        }
    }
}