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
    public partial class AppointmentDetail : System.Web.UI.Page
    {
        private PatientAppointmentDAL oDAL;
        private PatientAppointmentModel oClass;
        private DataSet oDs;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserType"].ToString() != "Admin")
            {
                this.MasterPageFile = "~/BrightCareStaff.master";
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                string patientNo = Request.QueryString["patientNo"].ToString();
                LoadStatus();
                LoadPhysician();
                LoadFacility();
                LoadPatient(patientNo);
                btnConsent.Visible = false;
                if (id != "")
                {
                    btnConsent.Visible = true;
                    PopulateData(Convert.ToInt16(id));
                }


            }
        }
        private void LoadPatient(string patientNo)
        {
            PatientDAL oPatientDAL = new PatientDAL();
            oDs = new DataSet();

            oDs = oPatientDAL.SeachPatient(patientNo);


            if (oDs != null)
            {
                PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
                PatientName.Value = oDs.Tables[0].Rows[0]["LastName"].ToString() + ", " + oDs.Tables[0].Rows[0]["FirstName"].ToString();
                DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            }

        }
        private void LoadStatus()
        {
            PatientCaseStatusDAL statusDAL = new PatientCaseStatusDAL();

            ddlStatus.DataSource = statusDAL.SelectAll();
            ddlStatus.DataTextField = "dname";
            ddlStatus.DataValueField = "ID";
            ddlStatus.DataBind();
        }
        private void LoadPhysician()
        {
            PhysicianDAL physicianDAL = new PhysicianDAL();

            ddlPhysician.DataSource = physicianDAL.SelectAllCombo();
            ddlPhysician.DataTextField = "Fullname";
            ddlPhysician.DataValueField = "ID";
            ddlPhysician.DataBind();
        }
        private void LoadFacility()
        {
            FacilityDAL facilityDAL = new FacilityDAL();

            ddlHospital.DataSource = facilityDAL.SelectAllHealthCare();
            ddlHospital.DataTextField = "FacilityName";
            ddlHospital.DataValueField = "ID";
            ddlHospital.DataBind();
        }
        private void PopulateData(int id)
        {
            oDAL = new PatientAppointmentDAL();
            oClass = new PatientAppointmentModel();
            oDs = new DataSet();

            oClass.ID = id;

            oDs = oDAL.SelectByID(oClass);
            AppointmentID.Value = oDs.Tables[0].Rows[0][0].ToString();
            ddlAppointmentType.Text = oDs.Tables[0].Rows[0][2].ToString();
            CaseNo.Value = oDs.Tables[0].Rows[0]["CaseNo"].ToString();
            AppointmentDate.Value = oDs.Tables[0].Rows[0][1].ToString();
            PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();
           ddlHospital.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();

            ddlStatus.SelectedValue = oDs.Tables[0].Rows[0]["StatusID"].ToString();
            txtRemarks.Value = oDs.Tables[0].Rows[0]["Remarks"].ToString();


        }

        protected void PrintConsentForm(object sender, EventArgs e)
        {
         
            //Response.Redirect("Report/MedCertificate?encounterNo=" + id);

            Response.Write("<script>window.open ('Reports/ConsentForm.aspx?patientNo=" + PatientNo.Value + "','_blank');</script>");
        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Appointment.aspx");
        }

        protected void AddEncounter(object sender, EventArgs e)
        {
          // Response.Redirect(String.Format("PatientNewEncounter.aspx??appointmentid={0}&patientNo={1}", AppointmentID.Value.ToString(), PatientNo.Value.ToString()));
            Response.Redirect(String.Format("PatientEncounterDetail.aspx?id={0}&appointmentid={1}&patientNo={2}","", Server.UrlEncode(AppointmentID.Value), Server.UrlEncode(PatientNo.Value)));
        }

       
        protected void CloseData(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            if (id =="")
            Response.Redirect("Patient.aspx");
            else
            Response.Redirect("Appointment.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientAppointmentDAL();
            oClass = new PatientAppointmentModel();


            oClass.PatientNo = PatientNo.Value;
            oClass.CaseNo = CaseNo.Value;
            oClass.AppointmentDate = Convert.ToDateTime(AppointmentDate.Value);
            oClass.AppointmentType = ddlAppointmentType.Text;
            oClass.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);
            oClass.HospitalID = Convert.ToInt16(ddlHospital.SelectedValue);
            oClass.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);
            oClass.Remarks = txtRemarks.InnerText;

            string id = AppointmentID.Value;
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