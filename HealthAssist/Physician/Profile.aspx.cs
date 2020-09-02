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
    public partial class Profile : System.Web.UI.Page
    {
        private PhysicianDAL oDAL;
        private PhysicianModel oClass;
        private DataSet oDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("~/login.aspx");
            if (!(IsPostBack))
            {
                int id = Convert.ToInt16(Session["userid"]);
                PopulateProfile(id);
                LoadHospital();

                if (id != 0)
                {
                    PopulateData(Convert.ToInt16(id));
                    PopulatePhysicianFacility(Convert.ToInt16(PhysicianID.Value));
                }
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
                //currentUserLabel.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
                //UserLabelLeft.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
                //UserLabelProfile.Text = oDS.Tables[0].Rows[0]["Fullname"].ToString();
            }

        }

        private void PopulateProfile(int id)
        {
            var oDAL = new PhysicianDAL();
            var oClass = new PhysicianModel();
            var oDs = new DataSet();

            oClass.UserID = id;

            oDs = oDAL.SelectByUserID(oClass);
            var fullname = oDs.Tables[0].Rows[0][3].ToString() + " " + oDs.Tables[0].Rows[0][2].ToString() + ", " + oDs.Tables[0].Rows[0][4].ToString();
            UserFullName.Text = fullname;
            UserFullNameMain.Text = fullname;
            UserFullNameSide .Text = fullname;
            UserFullNameHeader.Text = fullname;
            UserSpecialty.Text = oDs.Tables[0].Rows[0][5].ToString();
            //PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            //LastName.Value = oDs.Tables[0].Rows[0][1].ToString();
            //FirstName.Value = oDs.Tables[0].Rows[0][2].ToString();
            //Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
            //txtAddress.Value = oDs.Tables[0].Rows[0][5].ToString();
            //txtEmail.Value = oDs.Tables[0].Rows[0][6].ToString();
            //txtContact.Value = oDs.Tables[0].Rows[0][7].ToString();

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
            LastName.Value = oDs.Tables[0].Rows[0][2].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0][3].ToString();
            Suffix.Value = oDs.Tables[0].Rows[0][4].ToString();
            Specialty.Value = oDs.Tables[0].Rows[0][5].ToString();
            LicenseNo.Value = oDs.Tables[0].Rows[0][7].ToString();
            txtEmail.Value = oDs.Tables[0].Rows[0][8].ToString();
            txtAddress.Value = oDs.Tables[0].Rows[0][9].ToString();
          
            txtContact.Value = oDs.Tables[0].Rows[0][10].ToString();

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

            oClass.Title = "Dr";
            oClass.LastName = LastName.Value;
            oClass.FirstName = FirstName.Value;
            oClass.Suffix = Suffix.Value;
            oClass.Specialty = Specialty.Value;
            oClass.LicenseNo = LicenseNo.Value;
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