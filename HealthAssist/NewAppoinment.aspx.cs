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
    public partial class NewAppoinment : System.Web.UI.Page
    {
        private PatientAppointmentDAL oDAL;
        private PatientAppointmentModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                string patientNo = Request.QueryString["patientNo"].ToString();
              //  LoadStatus();
                LoadPhysician();
                LoadFacility();
                LoadPatient(patientNo);
                if (id != "")
                {

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
        //private void LoadStatus()
        //{
        //    PatientCaseStatusDAL statusDAL = new PatientCaseStatusDAL();

        //    ddlStatus.DataSource = statusDAL.SelectAll();
        //    ddlStatus.DataTextField = "dname";
        //    ddlStatus.DataValueField = "ID";
        //    ddlStatus.DataBind();
        //}
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
           // CaseNo.Value = oDs.Tables[0].Rows[0][1].ToString();
            AppointmentDate.Value = oDs.Tables[0].Rows[0][2].ToString();
            PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();
            ddlHospital.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();

         //   ddlStatus.SelectedValue = oDs.Tables[0].Rows[0]["StatusID"].ToString();
            txtRemarks.Value = oDs.Tables[0].Rows[0][6].ToString();


        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Appointment.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            if (id == "")
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
            oClass.CaseNo = "";
            oClass.AppointmentDate = Convert.ToDateTime(AppointmentDate.Value);
            oClass.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);
            oClass.HospitalID = Convert.ToInt16(ddlHospital.SelectedValue);
            oClass.StatusID = 3;
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