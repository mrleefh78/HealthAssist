using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace HealthAssist
{
    public partial class PatientEncounterDetail : System.Web.UI.Page
    {
        private PatientEncounterDAL oDAL;
        private PatientEncounterModel oClass;
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

                // LoadPatient(patientNo);
              //  LoadHospital();
                LoadAssistanceCompany();
                LoadPhysician();
                LoadStatus();
                EncounterDate.Value = DateTime.Now.ToShortDateString();

                btnMedCertificate.Visible = false;
                btnPrescription.Visible = false;

                txRate.Value = GetRate().ToString();
                if (id !="")
                {
                    PopulatePatientEncounter(id);
                    PopulateVitals(id);
                    PopulateAssessment(id);
                    PopulateOrders(id);
                    PopulateMeds(id);
                    PopulateLog(id);
                }
                else
                {
                    string appointmentID = Request.QueryString["appointmentid"].ToString();
                    if (appointmentID != "")
                    {
                        LoadAppointment(Convert.ToInt16(appointmentID));
                    }
                    else
                    {
                        string patientNo = Request.QueryString["patientNo"].ToString();
                        LoadPatient(patientNo);
                        LoadPatientInsurance(patientNo);
                    }

                }

            


            }
        }
        private void LoadAppointment(int appointmentID)
        {
            PatientAppointmentDAL appointmentDAL = new PatientAppointmentDAL();
            PatientAppointmentModel appointmentModel = new PatientAppointmentModel();
            appointmentModel.ID = appointmentID;
            oDs = new DataSet();

            oDs = appointmentDAL.SelectByID(appointmentModel);

          //   ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();

            LoadPatient(oDs.Tables[0].Rows[0]["PatientNo"].ToString());
            LoadPatientInsurance(oDs.Tables[0].Rows[0]["PatientNo"].ToString());
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

        private void LoadPatientInsurance(string patientNo)
        {
            PatientInsuranceDAL patientInsurance = new PatientInsuranceDAL();
            oDs = new DataSet();

            oDs = patientInsurance.SeachPatient(patientNo);
            if (oDs != null)
            {
                InsuranceNo.Value = oDs.Tables[0].Rows[0]["PolicyNo"].ToString();
                ddlCompany.SelectedValue = oDs.Tables[0].Rows[0]["InsuranceID"].ToString();
            }
        }


        //private void LoadHospital()
        //{
        //    FacilityDAL facilityDAL = new FacilityDAL();

        //    ddlHospitalName.DataSource = facilityDAL.SelectAllHealthCare();
        //    ddlHospitalName.DataTextField = "FacilityName";
        //    ddlHospitalName.DataValueField = "id";
        //    ddlHospitalName.DataBind();
        //}

        private void LoadAssistanceCompany()
        {
            InsuranceCompanyDAL insuranceCompanyDAL = new InsuranceCompanyDAL();
            InsuranceCompanyModel insuranceModel = new InsuranceCompanyModel();

            insuranceModel.CountryCode = "PHL";
            oDs = new DataSet();
            oDs = insuranceCompanyDAL.SelectByCountryCode(insuranceModel);
            //var result = oDs.Tables[0].AsEnumerable().Where(myRow => myRow.Field<string>("CountryCode") == "PHL").CopyToDataTable();
            ddlCompany.DataSource = oDs.Tables[0];
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

        private double GetRate()
        {
            double result=0;
            PhysicianDAL physician = new PhysicianDAL();
            PhysicianModel physicianModel = new PhysicianModel();
            DataSet physicianData = new DataSet();

            physicianModel.ID = Convert.ToInt16(ddlPhysician.SelectedValue);
            physicianData = physician.SelectByID(physicianModel);

            result = Convert.ToDouble(physicianData.Tables[0].Rows[0]["Rate"]);
            return result;
        }

        protected void PhysicianRate(object sender, EventArgs e)
        {
            txRate.Value = GetRate().ToString();
        }

        private void LoadStatus()
        {
            PatientCaseStatusDAL caseStatus = new PatientCaseStatusDAL();

            ddlStatus.DataSource = caseStatus.SelectAll();
            ddlStatus.DataTextField = "dname";
            ddlStatus.DataValueField = "id";
            ddlStatus.DataBind();
        }
        private void PopulatePatientEncounter(string encounterNo)
        {
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();
            oDs = new DataSet();

            oClass.EncounterNo = encounterNo;

            oDs = oDAL.SelectByEncounterNo(oClass);
            EncounterID.Value = oDs.Tables[0].Rows[0]["ID"].ToString();
            EncounterNo.Value = oDs.Tables[0].Rows[0]["EncounterNo"].ToString();
            
            EncounterDate.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["EncounterDate"]).ToShortDateString();
            PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            ddlCompany.SelectedValue = oDs.Tables[0].Rows[0]["InsuranceCompanyID"].ToString();
            InsuranceNo.Value = oDs.Tables[0].Rows[0]["InsuranceNo"].ToString();
          //  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();
            ServiceType.Value = oDs.Tables[0].Rows[0]["ServiceType"].ToString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();
            Remarks.Value = oDs.Tables[0].Rows[0]["Remarks"].ToString();
            ddlStatus.SelectedValue = oDs.Tables[0].Rows[0]["StatusID"].ToString();

            if (oDs.Tables[0].Rows[0]["StatusID"].ToString() == "4")
            {
                btnMedCertificate.Visible = true;
                btnPrescription.Visible = true;
                btnSave.Visible = false;
                btnSaveDoctor.Visible = false;
            }
        }

        private void PopulateVitals(string encounterNo)
        {
            PatientVitalsDAL vitalDAL = new PatientVitalsDAL();
            PatientVitalsModel vitalModel = new PatientVitalsModel();

            oDs = new DataSet();

            vitalModel.EncounterNo = encounterNo;

            oDs = vitalDAL.SelectByEncounterNo(vitalModel);

            txtTemperature.Value = (oDs.Tables[0].Rows[0]["Temperature"].ToString()=="0.00") ? "" : oDs.Tables[0].Rows[0]["Temperature"].ToString();
            txtSystolic.Value = (oDs.Tables[0].Rows[0]["Systolic"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["Systolic"].ToString();
            txtDiastolic.Value = (oDs.Tables[0].Rows[0]["Diastolic"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["Diastolic"].ToString();
            txtPulseRate.Value = (oDs.Tables[0].Rows[0]["PulseRate"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["PulseRate"].ToString();
            txtHeight.Value = (oDs.Tables[0].Rows[0]["Height"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["Height"].ToString();
            txtWeight.Value = (oDs.Tables[0].Rows[0]["Weight"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["Weight"].ToString();
            txtBloodSugar.Value = (oDs.Tables[0].Rows[0]["BloodSugar"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["BloodSugar"].ToString();
            txtOther.Value = oDs.Tables[0].Rows[0]["notes"].ToString();

        }

        private void PopulateAssessment(string encounterNo)
        {
            PatientAssessmentDAL assessmentDAL = new PatientAssessmentDAL();
            PatientAssessmentModel assessmemntModel = new PatientAssessmentModel();
            oDs = new DataSet();

            assessmemntModel.EncounterNo = encounterNo;
            oDs = assessmentDAL.SelectByEncounterNo(assessmemntModel);

            txtCC.InnerText = oDs.Tables[0].Rows[0]["ChiefComplaint"].ToString();

        }

        private void PopulateOrders(string encounterNo)
        {
            PatientProcedureDAL procedureDAL = new PatientProcedureDAL();
            PatientProcedureModel procedureModel = new PatientProcedureModel();
            oDs = new DataSet();
            procedureModel.EncounterNo = encounterNo;
            oDs = procedureDAL.SelectByEncounter(procedureModel);
            gvOrders.DataSource = oDs.Tables[0];
            gvOrders.DataBind();
           
        }

        private void PopulateMeds(string encounterNo)
        {
            PatientMedicationDAL medsDAL = new PatientMedicationDAL();
            PatientMedicationModel medsModel = new PatientMedicationModel();
            oDs = new DataSet();
            medsModel.EncounterNo = encounterNo;
            oDs = medsDAL.SelectByEncounterNo(medsModel);
            gvPrescription.DataSource = oDs.Tables[0];
            gvPrescription.DataBind();

        }

        private void PopulateLog(string encounterNo)
        {
            PatientEncounterLogDAL logDAL = new PatientEncounterLogDAL();
            PatientEncounterLogModel logModel = new PatientEncounterLogModel();
            oDs = new DataSet();
            logModel.EncounterNo = encounterNo;
            oDs = logDAL.SelectByEncounterNo(logModel);
            
            gvEncounterLog.DataSource = oDs.Tables[0];
            gvEncounterLog.DataBind();

        }

        protected void PrintMedCertificate(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            //Response.Redirect("Report/MedCertificate?encounterNo=" + id);

            Response.Write("<script>window.open ('Reports/MedCertificate.aspx?encounterNo=" + id + "','_blank');</script>");
        }

        protected void PrinPrescription(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            //Response.Redirect("Report/MedCertificate?encounterNo=" + id);

            Response.Write("<script>window.open ('Reports/PatientPrescription.aspx?encounterNo=" + id + "','_blank');</script>");
        }

        protected void ExportOrdersToPDF(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gvOrders.AllowPaging = false;
                    this.PopulateOrders(id);

                    gvOrders.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + id + "CPTOrders.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        protected void ExportMedsToPDF(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gvPrescription.AllowPaging = false;
                    this.PopulateMeds(id);

                    gvPrescription.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + id + "Meds.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void OnOrdersPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvOrders.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            this.PopulateOrders(id);
        }

        protected void OnMedsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPrescription.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            this.PopulateMeds(id);
        }

        protected void OnLogPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvEncounterLog.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            this.PopulateLog(id);
        }

        protected void AddPatientEncounter(object sender, EventArgs e)
        {
            SaveEncounterData();

            Response.Redirect("PatientEncounter.aspx");
        }

        protected void ClosePatientCase(object sender, EventArgs e)
        {
            Response.Redirect("PatientEncounter.aspx");
        }

        protected void AddPhysicianClick(object sender, EventArgs e)
        {
            Response.Redirect("PhysicianDetail.aspx?id=");
        }

        protected void AddHospitalClick(object sender, EventArgs e)
        {
            Response.Redirect("FacilityDetail.aspx?id=");
        }

        protected void AddInsuranceCompanyClick(object sender, EventArgs e)
        {
            Response.Redirect("InsuranceCompanyDetail.aspx?id=");
        }

        private void SaveEncounterData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();

            oClass.EncounterNo = EncounterNo.Value;
            oClass.EncounterDate = Convert.ToDateTime(EncounterDate.Value);
            oClass.PatientNo = PatientNo.Value;
            oClass.EncounterType = ServiceType.Value;
            oClass.InsuranceCompanyID = Convert.ToInt16(ddlCompany.SelectedValue);
            oClass.InsuranceNo = InsuranceNo.Value;
            oClass.HospitalID = 0;//Convert.ToInt16(ddlHospitalName.SelectedValue);
            oClass.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);

            oClass.Remarks = Remarks.InnerText;
            oClass.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);

            PatientVitalsModel vitalModel = new PatientVitalsModel();

            vitalModel.PatientNo = PatientNo.Value;
            vitalModel.Temperature = VitalValue(txtTemperature.Value);
            vitalModel.Systolic = VitalValue(txtSystolic.Value);
            vitalModel.Diastolic = VitalValue(txtDiastolic.Value);
            vitalModel.PulseRate = VitalValue(txtPulseRate.Value);
            vitalModel.Height = VitalValue(txtHeight.Value);
            vitalModel.Weight = VitalValue(txtWeight.Value);
            vitalModel.BloodSugar = VitalValue(txtBloodSugar.Value);
            vitalModel.Notes = txtOther.Value;

            PatientAssessmentModel assessmentModel = new PatientAssessmentModel();

            assessmentModel.EncounterNo = EncounterNo.Value;
            assessmentModel.PatientNo = PatientNo.Value;
            assessmentModel.ChiefComplaint = txtCC.InnerText;

            string id = Request.QueryString["id"].ToString();
            if (id == "")
            {
                oDAL.InsertNewEncounterData(sUserName, oClass, assessmentModel, vitalModel);
              

            }
            else
            {
                oDAL.UpdateEncounterData(sUserName, oClass);

                var patientVitalDAL = new PatientVitalsDAL();
                vitalModel.EncounterNo = EncounterNo.Value;
                patientVitalDAL.UpdateDataByEncounter(sUserName, vitalModel);

                var patientAssessmentDAL = new PatientAssessmentDAL();
                patientAssessmentDAL.UpdateDataByEncounter(sUserName, assessmentModel);
            }
               

        }

        private void SaveEncounterLog(string encounterno)
        {
            var logModel = new PatientEncounterLogModel();
            var logDal = new PatientEncounterLogDAL();

            string sUserName = Session["User"].ToString();
            logModel.EncounterNo = encounterno;
            logModel.PatientNo = PatientNo.Value;
            logModel.LogDate = DateTime.Now;
            logModel.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);
            logDal.InsertData(sUserName,logModel);
        }

     

        private double VitalValue(string EntryValue)
        {
            var Result = 0.0;

            if (EntryValue !="")
            {
                Result = Convert.ToDouble(EntryValue);
            };

            return Result;
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();

            oClass.EncounterNo = EncounterNo.Value;
            oClass.EncounterDate = Convert.ToDateTime(EncounterDate.Value);
            oClass.PatientNo = PatientNo.Value;
            oClass.EncounterType = ServiceType.Value;
            oClass.InsuranceCompanyID = Convert.ToInt16(ddlCompany.SelectedValue);
            oClass.InsuranceNo = InsuranceNo.Value;
            oClass.HospitalID = 0;// Convert.ToInt16(ddlHospitalName.SelectedValue);
            oClass.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);
           
            oClass.Remarks = Remarks.InnerText;
            oClass.StatusID = Convert.ToInt16(ddlStatus.SelectedValue);

            string id = "";// EncounterID.Value;
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

        private void SaveVitals()
        {
            string sUserName = Session["User"].ToString();
            PatientVitalsDAL vitalDAL = new PatientVitalsDAL();
           PatientVitalsModel vitalModel = new PatientVitalsModel();

            vitalModel.EncounterNo = EncounterNo.Value;
            vitalModel.PatientNo = PatientNo.Value;
            vitalModel.Temperature = Convert.ToDouble(txtTemperature.Value);
            vitalModel.Systolic = Convert.ToDouble(txtSystolic.Value);
            vitalModel.Diastolic = Convert.ToDouble(txtDiastolic.Value);
            vitalModel.PulseRate = Convert.ToDouble(txtPulseRate.Value);
            vitalModel.Height = Convert.ToDouble(txtHeight.Value);
            vitalModel.Weight = Convert.ToDouble(txtWeight.Value);
            vitalModel.BloodSugar  = Convert.ToDouble(txtBloodSugar.Value);
            vitalModel.Notes = txtOther.Value;

            string id = "";// EncounterID.Value;
            if (id == "")
            {
                vitalDAL.InsertData(sUserName, vitalModel);
                //lblMsg.Text = "New Record has been saved";
            }
            else
            {
                oClass.ID = Convert.ToInt16(id);
                vitalDAL.UpdateData(sUserName, vitalModel);
                // lblMsg.Text = "Record has been updated";

            }
        }

        private void SaveAssessment()
        {
            string sUserName = Session["User"].ToString();
            PatientAssessmentDAL assessmentDAL = new PatientAssessmentDAL();
            PatientAssessmentModel assessmentModel = new PatientAssessmentModel();

            assessmentModel.EncounterNo = EncounterNo.Value;
            assessmentModel.PatientNo = PatientNo.Value;
            assessmentModel.ChiefComplaint = txtCC.InnerText;

            string id = "";// EncounterID.Value;
            if (id == "")
            {
                assessmentDAL.InsertData(sUserName, assessmentModel);
                //lblMsg.Text = "New Record has been saved";
            }
            else
            {
                oClass.ID = Convert.ToInt16(id);
                assessmentDAL.UpdateData(sUserName, assessmentModel);
                // lblMsg.Text = "Record has been updated";

            }
        }


    }
}