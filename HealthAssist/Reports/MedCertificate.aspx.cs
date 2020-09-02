using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using System.Data;

namespace HealthAssist.Reports
{
    public partial class MedCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["encounterNo"].ToString();
                PopulatePatientEncounter(id);
               // PopulateOrders(id);
                PopulateMeds(id);
              //  PopulateAssessment(id);
                PopulateDiagnosis(id);
            }
         }

        private void PopulatePatientEncounter(string encounterNo)
        {
            var oDAL = new PatientEncounterDAL();
            var oClass = new PatientEncounterModel();
            var oDs = new DataSet();

            oClass.EncounterNo = encounterNo;

            oDs = oDAL.SelectByEncounterNo(oClass);

            lblDate.Text = DateTime.Today.ToShortDateString();
            lblPatient.Text = oDs.Tables[0].Rows[0]["PatientName"].ToString();
lblGender .Text = oDs.Tables[0].Rows[0]["gender"].ToString();
            lblAge.Text = CalculateAge(Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]));
            lblPhysician.Text = oDs.Tables[0].Rows[0]["PhysicianName"].ToString();

            lblEncounterDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["EncounterDate"]).ToLongDateString();
            lblPhysicianLicense.Text =  oDs.Tables[0].Rows[0]["licenseNo"].ToString();

            string DisPosition = oDs.Tables[0].Rows[0]["Disposition"].ToString();
            var RestDay = oDs.Tables[0].Rows[0]["RestForDays"].ToString();
            var WorkRestriction = oDs.Tables[0].Rows[0]["WorkRestriction"].ToString();
            var followup = oDs.Tables[0].Rows[0]["FollowupDate"].ToString();

            lblRecomen.Text = "";
            string Recommendation = "";
            if (DisPosition != "")
            {
                Recommendation = "<br/><b>DISPOSITION</b> <br/> " + DisPosition + "<br/> </br>";
            }

            Recommendation = Recommendation + " <b> RECOMMENDATIONS </b>";
            if (RestDay !="")
            {
                Recommendation = Recommendation + "<br/>To rest for " + RestDay + "days. </br>";
            }

            if (WorkRestriction != "")
            {
                Recommendation = Recommendation + "<br/>Work restrictions as follows <br/>" + WorkRestriction;
            }

            if (followup != "")
            {
                Recommendation = Recommendation + "<br/>FollowUp Date: <br/>" + Convert.ToDateTime(followup).ToShortDateString();
            }

            lblRecomen.Text = Recommendation;

            //EncounterID.Value = oDs.Tables[0].Rows[0]["ID"].ToString();
            //EncounterNo.Value = oDs.Tables[0].Rows[0]["EncounterNo"].ToString();

            //EncounterDate.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["EncounterDate"]).ToShortDateString();
            //PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            //PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            //DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            //ddlCompany.SelectedValue = oDs.Tables[0].Rows[0]["InsuranceCompanyID"].ToString();
            //InsuranceNo.Value = oDs.Tables[0].Rows[0]["InsuranceNo"].ToString();
            ////  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();
            //ServiceType.Value = oDs.Tables[0].Rows[0]["ServiceType"].ToString();
            //ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();
            //Remarks.Value = oDs.Tables[0].Rows[0]["Remarks"].ToString();
            //ddlStatus.SelectedValue = oDs.Tables[0].Rows[0]["StatusID"].ToString();
        }

        //private void PopulateOrders(string encounterNo)
        //{
        //    lblExam.Text = "";
        //    PatientProcedureDAL procedureDAL = new PatientProcedureDAL();
        //    PatientProcedureModel procedureModel = new PatientProcedureModel();
        //    var oDs = new DataSet();
        //    procedureModel.EncounterNo = encounterNo;
        //    oDs = procedureDAL.SelectByEncounter(procedureModel);
        //   if (oDs != null)
        //    {
        //        if (oDs.Tables[0].Rows.Count >0)
        //        {
        //            for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
        //            {
        //                lblExam.Text = lblExam.Text + "<br>" + oDs.Tables[0].Rows[i]["description"].ToString();
        //            }
        //        }
        //    }

        //}

        private void PopulateMeds(string encounterNo)
        {
            lblMeds.Text = "";
           PatientMedicationDAL medsDAL = new PatientMedicationDAL();
            PatientMedicationModel medsModel = new PatientMedicationModel();
            var oDs = new DataSet();
            medsModel.EncounterNo = encounterNo;
            oDs = medsDAL.SelectByEncounterNo(medsModel);
            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        lblMeds.Text = lblMeds.Text + "<br>" + oDs.Tables[0].Rows[i]["description"].ToString();
                    }
                }
            }

        }

        private void PopulateAssessment(string encounterNo)
        {

            lblRecomen.Text = "";
PatientAssessmentDAL assessmentDAL = new PatientAssessmentDAL();
            PatientAssessmentModel assessmemntModel = new PatientAssessmentModel();
           var oDs = new DataSet();

            assessmemntModel.EncounterNo = encounterNo;
            oDs = assessmentDAL.SelectByEncounterNo(assessmemntModel);
            
            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        lblRecomen.Text =oDs.Tables[0].Rows[0]["PhysicianNote"].ToString();
                    }
                }
            }

        }

        private void PopulateDiagnosis(string encounterNo)
        {
            lblDiagnosis.Text = "";
            PatientDiagnosisDAL diagnosisDAL = new PatientDiagnosisDAL();
            PatientDiagnosisModel diagnosisModel = new PatientDiagnosisModel();
            var oDs = new DataSet();
            diagnosisModel.EncounterNo = encounterNo;
            oDs = diagnosisDAL.SelectByEncounterNo(diagnosisModel);

            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        lblDiagnosis.Text = lblDiagnosis.Text + "<br>" + oDs.Tables[0].Rows[i]["Description"].ToString();
                    }
                }
            }

        }

        private string CalculateAge(DateTime dob)
        {
            var result = "";
            var age = DateTime.Now - dob;

            result = (age.Days / 365).ToString("N0");
            return result;
        }
    }
}