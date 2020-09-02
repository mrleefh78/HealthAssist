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
    public partial class PatientCaseDetail : System.Web.UI.Page
    {
        private PatientCaseDAL oDAL;
        private PatientCaseModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                LoadHospital();
                LoadAssistanceCompany();
                LoadPhysician();
                LoadStatus();

                if (id != "")
                {

                    PopulatePatientCase(id);
                    PopulateDiagnosis(id);
                    PopulateProcedure(id);
                    PopulateMedication(id);
                }
                else
                {
                    CaseDate.Value = DateTime.Now.ToShortDateString();
                  
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

        private void LoadAssistanceCompany()
        {
            InsuranceCompanyDAL insuranceCompanyDAL = new InsuranceCompanyDAL();

            ddlCompany.DataSource = insuranceCompanyDAL.SelectAll();
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataValueField = "id";
            ddlCompany.DataBind();
        }

        private void LoadPhysician()
        {
            PhysicianDAL physician = new PhysicianDAL();

            ddlPhysician.DataSource = physician.SelectAllCombo();
            ddlPhysician.DataTextField = "Fullname";
            ddlPhysician.DataValueField = "id";
            ddlPhysician.DataBind();
        }

        private void LoadStatus()
        {
            PatientCaseStatusDAL caseStatus = new PatientCaseStatusDAL();

            ddlStatus.DataSource = caseStatus.SelectAll();
            ddlStatus.DataTextField = "dname";
            ddlStatus.DataValueField = "id";
            ddlStatus.DataBind();
        }
        private void PopulatePatientCase(string caseNo)
        {
            oDAL = new PatientCaseDAL();
            oClass = new PatientCaseModel();
            oDs = new DataSet();

            oClass.CaseNo = caseNo;

            oDs = oDAL.SelectByCaseNo(oClass);
            CaseID.Value = oDs.Tables[0].Rows[0]["ID"].ToString();
            RefNo.Value = oDs.Tables[0].Rows[0]["CaseNo"].ToString();
           
            CaseDate.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["CaseDate"]).ToShortDateString();
            PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            ddlCompany.SelectedValue = oDs.Tables[0].Rows[0]["InsuranceCompanyID"].ToString();
            InsuranceNo.Value = oDs.Tables[0].Rows[0]["InsuranceNo"].ToString();
            ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();          
            ServiceType.Value = oDs.Tables[0].Rows[0]["ServiceType"].ToString();
            AdmitDate.Value = oDs.Tables[0].Rows[0]["StartDate"].ToString();
            DischargeDate.Value = oDs.Tables[0].Rows[0]["EndDate"].ToString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();
            Remarks.Value = oDs.Tables[0].Rows[0]["Remarks"].ToString();
            ddlStatus.SelectedValue = oDs.Tables[0].Rows[0]["StatusID"].ToString();

            if (oDs.Tables[0].Rows[0]["StartDate"].ToString() != "")
            {
                AdmitDate.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["StartDate"]).ToShortDateString();
            }

            if (oDs.Tables[0].Rows[0]["EndDate"].ToString() != "")
            {
                DischargeDate.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["EndDate"]).ToShortDateString();
            }

               
        }

        private void PopulateDiagnosis(string caseNo)
        {
           PatientDiagnosisDAL diagnosisDAL = new PatientDiagnosisDAL();
            PatientDiagnosisModel diagnosisModel = new PatientDiagnosisModel();
            oDs = new DataSet();

            diagnosisModel.CaseNo = caseNo;
            diagnosisModel.PatientNo = PatientNo.Value;

            oDs = diagnosisDAL.SeachData(diagnosisModel);

            if (oDs != null)
            {
                gvDiagnosis.DataSource = oDs.Tables[0];
                gvDiagnosis.DataBind();
            }
        }
        protected void gvDiagnosis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDiagnosis.PageIndex = e.NewPageIndex;

            PopulateDiagnosis(RefNo.Value);
        }

        private void PopulateProcedure(string caseNo)
        {
            PatientProcedureDAL procedureDAL = new PatientProcedureDAL();
            PatientProcedureModel procedureModel = new PatientProcedureModel();
            oDs = new DataSet();

            procedureModel.CaseNo = caseNo;
            procedureModel.PatientNo = PatientNo.Value;
            oDs = procedureDAL.SeachData(procedureModel);

            if (oDs != null)
            {
                gvProcedure.DataSource = oDs.Tables[0];
                gvProcedure.DataBind();
            }
        }

        protected void gvProcedure_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcedure.PageIndex = e.NewPageIndex;

            PopulateProcedure(RefNo.Value);
        }

        private void PopulateMedication(string caseNo)
        {
            PatientMedicationDAL medsDAL = new PatientMedicationDAL();
            PatientMedicationModel medsModel = new PatientMedicationModel();
            oDs = new DataSet();

            medsModel.CaseNo = caseNo;
            medsModel.PatientNo = PatientNo.Value;
            oDs = medsDAL.SeachData(medsModel);

            if (oDs != null)
            {

                gvMedications.DataSource = oDs.Tables[0];
                gvMedications.DataBind();
            }
        }

        protected void gvMedication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedications.PageIndex = e.NewPageIndex;

            PopulateMedication(RefNo.Value);
        }

        protected void AddPatientCase(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("PatientCase.aspx");
        }

        protected void ClosePatientCase(object sender, EventArgs e)
        {
            Response.Redirect("PatientCase.aspx");
        }

        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientCaseDAL();
            oClass = new PatientCaseModel();

            oClass.CaseNo = RefNo.Value;
            oClass.CaseDate = Convert.ToDateTime(CaseDate.Value);
            oClass.PatientNo = PatientNo.Value;
            oClass.ServiceType = ServiceType.Value;
            oClass.InsuranceCompanyID = Convert.ToInt16(ddlCompany.SelectedValue);
            oClass.InsuranceNo = InsuranceNo.Value;
            oClass.HospitalID = Convert.ToInt16(ddlHospitalName.SelectedValue);
            oClass.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);
            oClass.Remarks = Remarks.Value;
            oClass.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);

            if (AdmitDate.Value != "")
            {
                oClass.StartDate = Convert.ToDateTime(AdmitDate.Value);
            }

            if (DischargeDate.Value != "")
            {
                oClass.EndDate = Convert.ToDateTime(DischargeDate.Value);
            }

            string id = CaseID.Value;
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

        protected void AddDiagnosis_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientDiagnosisDAL  oDiagnosisDAL = new PatientDiagnosisDAL();
           PatientDiagnosisModel  oDiagnosisClass = new PatientDiagnosisModel();

            oDiagnosisClass.CaseNo  = RefNo.Value;
            oDiagnosisClass.Code = txtICDCode.Value;
            oDiagnosisClass.Description = txtICDDescription.Value;
            oDiagnosisClass.PatientNo = PatientNo.Value;
            oDiagnosisClass.StartDate = DateTime.Now;
            oDiagnosisClass.Notes = "";
            oDiagnosisDAL.InsertData(sUserName, oDiagnosisClass);

            PopulateDiagnosis(RefNo.Value);
        }

        protected void DeleteDiagnosis_ServerClick(object sender, EventArgs e)
        {
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldPatientDiagnosis.Value);

            PatientDiagnosisDAL oDiagnosisDAL = new PatientDiagnosisDAL();
            PatientDiagnosisModel oDiagnosisClass = new PatientDiagnosisModel();

            oDiagnosisClass.IsDeleted = true;
            oDiagnosisClass.ReasonDelete = itemname.InnerText;
            string lbl = lblPatientDiagnosis.Text;
            oDiagnosisClass.ID = ID;
            oDiagnosisDAL.DeleteData(UserName, oDiagnosisClass);

            PopulateDiagnosis(RefNo.Value);
        }
        protected void AddProcedure_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientProcedureDAL oProcedureDAL = new PatientProcedureDAL();
            PatientProcedureModel oProcedureClass = new PatientProcedureModel();

            oProcedureClass.CaseNo = RefNo.Value;
            oProcedureClass.Code = txtCPTCode.Value;
            oProcedureClass.Description = txtCPTDescription.Value;
            oProcedureClass.PatientNo = PatientNo.Value;
            oProcedureClass.StartDate = DateTime.Now;
            oProcedureClass.Notes = "";
            oProcedureDAL.InsertData(sUserName, oProcedureClass);

            PopulateProcedure(RefNo.Value);
        }
        protected void DeleteProcedure_ServerClick(object sender, EventArgs e)
        {
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldPatientProcedure.Value);

            PatientProcedureDAL oProcedureDAL = new PatientProcedureDAL();
            PatientProcedureModel oProcedureClass = new PatientProcedureModel();

            oProcedureClass.IsDeleted = true;
            oProcedureClass.ReasonDelete = deleteCPTReason.InnerText;
            string lbl = lblPatientProcedure.Text;
            oProcedureClass.ID = ID;
            oProcedureDAL.DeleteData(UserName, oProcedureClass);

            PopulateProcedure(RefNo.Value);
        }

        protected void AddMedication_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientMedicationDAL oMedicationDAL = new PatientMedicationDAL();
            PatientMedicationModel oMedicationClass = new PatientMedicationModel();

            oMedicationClass.CaseNo = RefNo.Value;
            oMedicationClass.Code = txtMedCode.Value;
            oMedicationClass.Description = txtMedDescription.Value;
            oMedicationClass.Dosage = txtMedDose.Value;
            oMedicationClass.PatientNo = PatientNo.Value;
            oMedicationClass.StartDate = DateTime.Now;
            oMedicationClass.Notes = "";
            oMedicationDAL.InsertData(sUserName, oMedicationClass);

            PopulateMedication(RefNo.Value);
        }
        protected void DeleteMedication_ServerClick(object sender, EventArgs e)
        {
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldPatientMedication.Value);

            PatientMedicationDAL oMedicationDAL = new PatientMedicationDAL();
            PatientMedicationModel oMedicationClass = new PatientMedicationModel();

            oMedicationClass.IsDeleted = true;
            oMedicationClass.ReasonDelete = deleteMedicationReason.InnerText;
            string lbl = lblPatientMedication.Text;
            oMedicationClass.ID = ID;
            oMedicationDAL.DeleteData(UserName, oMedicationClass);

            PopulateMedication(RefNo.Value);
        }
    }
}