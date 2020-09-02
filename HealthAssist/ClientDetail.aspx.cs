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
    public partial class ClientDetail : System.Web.UI.Page
    {
        private InsuranceCompanyDAL oDAL;
        private InsuranceCompanyModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                LoadCountry();
                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));
                }


            }
        }
        private void LoadCountry()
        {
            CountryDAL countryDAL = new CountryDAL();

            ddlCountryCode.DataSource = countryDAL.SelectAll();
            ddlCountryCode.DataTextField = "Name";
            ddlCountryCode.DataValueField = "Code";
            ddlCountryCode.DataBind();
        }
        private void PopulateData(int id)
        {
            oDAL = new InsuranceCompanyDAL();
            oClass = new InsuranceCompanyModel();
            oDs = new DataSet();

            oClass.ID = id;

            oDs = oDAL.SelectByID(oClass);
            ClientID.Value = oDs.Tables[0].Rows[0][0].ToString();
            Code.Value = oDs.Tables[0].Rows[0][1].ToString();
            CompanyName.Value = oDs.Tables[0].Rows[0][2].ToString();
            ContactPerson.Value = oDs.Tables[0].Rows[0][3].ToString();
            ddlCountryCode.SelectedValue = oDs.Tables[0].Rows[0][4].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0][5].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][6].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0][7].ToString();

        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Clients.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("Clients.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new InsuranceCompanyDAL();
            oClass = new InsuranceCompanyModel();


            oClass.Code = Code.Value;
            oClass.CompanyName = CompanyName.Value;
            oClass.ContactPerson = ContactPerson.Value;
            oClass.CountryCode = ddlCountryCode.SelectedValue;
            oClass.Address = txtAddress.InnerText;
            oClass.Phone = txtContact.Value;
            oClass.Email = txtEmail.Value;

            string id = ClientID.Value;
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