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
    public partial class MyInfo : System.Web.UI.Page
    {
        private PhysicianDAL oDAL;
        private PhysicianModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Session["userid"].ToString();
                LoadHospital();

                if (id != "")
                {
                    PopulateData(Convert.ToInt16(id));
                     PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
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

            oClass.UserID = id;

            oDs = oDAL.SelectByUserID(oClass);
            PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            LastName.Value = oDs.Tables[0].Rows[0][1].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0][2].ToString();
            Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
            //  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0][4].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0][5].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][6].ToString();
            txtContact.Value = oDs.Tables[0].Rows[0][7].ToString();

        }

        private void PopulatePhysicianFacility(int id)
        {
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();
            oClass.ID = id;

            gvFacility.DataSource = oDAL.SelectPhysicianFacilityByID(oClass);
            gvFacility.DataBind();
        }

        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
           // Response.Redirect("Physician.aspx");
        }

        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();

            oClass.LastName = LastName.Value;
            oClass.FirstName = FirstName.Value;
            oClass.Specialty = Specialty.Value;
            // oClass.HospitalID = Convert.ToInt32(ddlHospitalName.SelectedValue);
            oClass.Address = txtAddress.InnerText;
            oClass.Phone = txtContact.Value;
            oClass.Email = txtEmail.Value;
            oClass.ID = Convert.ToInt16(PhysicianID.Value);
            oDAL.UpdateData(sUserName, oClass);
        }
        protected void CloseData(object sender, EventArgs e)
        {
          //  Response.Redirect("Physician.aspx");
        }

        protected void gvFacility_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFacility.PageIndex = e.NewPageIndex;

            PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
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
    }
}