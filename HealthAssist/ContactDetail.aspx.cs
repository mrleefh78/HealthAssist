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
    public partial class ContactDetail : System.Web.UI.Page
    {
        private FacilityDAL oDAL;
        private FacilityModel oClass;
        private DataSet oDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                LoadProvince();
                LoadStatus();
                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));
                }


            }
        }
        private void LoadProvince()
        {
            ProvinceDAL provinceDAL = new ProvinceDAL();

            ddlProvince.DataSource = provinceDAL.SelectAll();
            ddlProvince.DataTextField = "dName";
            ddlProvince.DataValueField = "dName";
            ddlProvince.DataBind();
        }

        private void LoadStatus()
        {
            PatientCaseStatusDAL caseStatus = new PatientCaseStatusDAL();

            ddlStatus.DataSource = caseStatus.SelectAll();
            ddlStatus.DataTextField = "dname";
            ddlStatus.DataValueField = "id";
            ddlStatus.DataBind();
        }
        private void PopulateData(int id)
        {
            oDAL = new FacilityDAL();
            oClass = new FacilityModel();
            oDs = new DataSet();

            oClass.ID = id;

            oDs = oDAL.SelectByID(oClass);
            FacilityID.Value = oDs.Tables[0].Rows[0][0].ToString();
            FacilityName.Value = oDs.Tables[0].Rows[0][1].ToString();
            ContactPerson.Value = oDs.Tables[0].Rows[0][2].ToString();
            ddlFacilityType.SelectedValue = oDs.Tables[0].Rows[0][3].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0][4].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][5].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0][6].ToString();
            Accreditation.Value = oDs.Tables[0].Rows[0][7].ToString();
            Expiration.Value = oDs.Tables[0].Rows[0][8].ToString();
            ddlProvince.SelectedValue = oDs.Tables[0].Rows[0][9].ToString();
            CashBond.Value = oDs.Tables[0].Rows[0][10].ToString();
            ddlStatus.SelectedValue = oDs.Tables[0].Rows[0][11].ToString();
            txtNote.Value = oDs.Tables[0].Rows[0][12].ToString();
            Designation.Value = oDs.Tables[0].Rows[0][13].ToString();
         
        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Contacts.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("Contacts.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new FacilityDAL();
            oClass = new FacilityModel();

            oClass.FacilityName = FacilityName.Value;
            oClass.ContactPerson = ContactPerson.Value;
            oClass.Designation = Designation.Value;
            oClass.FacilityType = ddlFacilityType.SelectedValue;
            oClass.Province = ddlProvince.SelectedValue;
            oClass.Address = txtAddress.InnerText;
            oClass.Phone = txtContact.Value;
            oClass.Email = txtEmail.Value;
            oClass.StatusID = ddlStatus.SelectedValue;
            if (Accreditation.Value == "")
                Accreditation.Value = DateTime.Today.ToShortDateString();
            oClass.DateAccredit = Convert.ToDateTime(Accreditation.Value); 

            if (Expiration.Value =="")
                Expiration.Value = DateTime.Today.AddYears(1).ToShortDateString();
            oClass.DateExpire = Convert.ToDateTime(Expiration.Value);

            if (CashBond.Value == "")
                CashBond.Value = "0";

            oClass.CashBond = Convert.ToDouble(CashBond.Value);
            oClass.Notes = txtNote.Value;

          
         string id = FacilityID.Value;
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