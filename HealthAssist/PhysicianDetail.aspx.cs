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
    public partial class PhysicianDetail : System.Web.UI.Page
    {
        private PhysicianDAL oDAL;
        private PhysicianModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                 LoadHospital();
              
                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));
                    PopulatePhysicianFacility(Convert.ToInt16(id));
                }
               

            }
        }
        private void LoadHospital()
        {
            FacilityDAL facilityDAL = new FacilityDAL();

            ddlHospitalName.DataSource = facilityDAL.SelectAllHealthCare();
            ddlHospitalName.DataTextField = "FacilityName";
            ddlHospitalName.DataValueField = "id";
            ddlHospitalName.DataBind();
        }
        private void PopulateData(int id)
        {
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();
            oDs = new DataSet();

            oClass.ID = id;

            oDs = oDAL.SelectByID(oClass);
            PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            NameTitle.Value = oDs.Tables[0].Rows[0][1].ToString();
            LastName.Value = oDs.Tables[0].Rows[0][2].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0][3].ToString();
            SuffixName.Value = oDs.Tables[0].Rows[0][4].ToString();
            PhysicianSpecialty.Value = oDs.Tables[0].Rows[0][5].ToString();
            LicenseNo.Value = oDs.Tables[0].Rows[0][7].ToString();
            //  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0][4].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0][9].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][8].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0][10].ToString();
            txtRate.Value = oDs.Tables[0].Rows[0][12].ToString();

        }

        private void PopulatePhysicianFacility(int id)
        {
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();
            oClass.ID = id;

            gvFacility.DataSource = oDAL.SelectPhysicianFacilityByID(oClass);
            gvFacility.DataBind();

            gvFacility.Visible = false;
        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Physician.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("Physician.aspx");
        }

        protected void CreateUser(object sender, EventArgs e)
        {

           // Response.Redirect("UserDetail.aspx?id=");
            Response.Redirect(String.Format("UserDetail.aspx?id={0}&physicianID={1}", "", PhysicianID.Value));
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();

            oClass.Title = NameTitle.Value;
            oClass.LastName = LastName.Value;
            oClass.FirstName = FirstName.Value;
            oClass.Suffix = SuffixName.Value;
            oClass.Specialty = PhysicianSpecialty.Value;
            oClass.LicenseNo = LicenseNo.Value;
           // oClass.HospitalID = Convert.ToInt32(ddlHospitalName.SelectedValue);
            oClass.Address = txtAddress.InnerText;
            oClass.Phone = txtContact.Value;
            oClass.Email = txtEmail.Value;
            if (txtRate.Value =="")
            {
                txtRate.Value = "0";
            }
            oClass.Rate = Convert.ToDouble(txtRate.Value);

            string id = PhysicianID.Value;
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

        protected void AddPhysicianFacility_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PhysicianFacilityDAL oPhysicianFacilityDAL = new PhysicianFacilityDAL();
            PhysicianFacilityModel oPhysicianFacilityClass = new PhysicianFacilityModel();

            oPhysicianFacilityClass.PhysicianID = Convert.ToInt32(PhysicianID.Value);
            oPhysicianFacilityClass.HospitalID = Convert.ToInt32(ddlHospitalName.SelectedValue);
               oPhysicianFacilityDAL.InsertData(sUserName, oPhysicianFacilityClass);

            PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
        }

        protected void DeletePhysicianFacility_ServerClick(object sender, EventArgs e)
        {
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldPhysicianFacility.Value);

            PhysicianFacilityDAL oPhysicianFacilityDAL = new PhysicianFacilityDAL();
            PhysicianFacilityModel oPhysicianFacilityClass = new PhysicianFacilityModel();

            oPhysicianFacilityClass.IsDeleted = true;
            oPhysicianFacilityClass.ReasonDelete = deletePhysicianFacilityReason.InnerText;
            string lbl = lblPhysicianFacility.Text;
            oPhysicianFacilityClass.ID = ID;
            oPhysicianFacilityDAL.DeleteData(UserName, oPhysicianFacilityClass);

            PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
        }

        protected void gvFacility_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFacility.PageIndex = e.NewPageIndex;

            PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
        }
    }
}