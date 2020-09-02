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
    public partial class MyPatientDetail : System.Web.UI.Page
    {
        private PatientEncounterDAL oDAL;
        private PatientEncounterModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {


                string id = Request.QueryString["id"].ToString();
                LoadMedicines();
                // LoadPatient(patientNo);
                //LoadHospital();
                LoadAssistanceCompany();
                LoadPhysician();
                LoadStatus();
                LoadPrescriptionFavorite(Convert.ToInt16(ddlPhysician.SelectedValue));
                EncounterDate.Value = DateTime.Now.ToShortDateString();

                if (id != "")
                {
                    PopulatePatientEncounter(id);
                    PopulateVitals(id);
                    PopulateAssessment(id);
                    PopulateDiagnosis(id);
                    PopulateOrders(id);
                    PopulateMeds(id);
                    // ddlPrescriptionTemplate.AutoPostBack = true;
                   // ddlPhysician.Enabled = false;
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
                    }

                }



            }
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
               // dynamic array = JsonConvert.DeserializeObject(json);
                //foreach (var item in array)
                //{
                //    Console.WriteLine("{0} {1}", item.temp, item.vcc);
                //}
            }
        }


        private void LoadMedicines()
        {
            var medModel = new MedicineModel ();
            var medDal = new MedicineDAL();
            oDs = new DataSet();

            medModel.ItemName = SearchMed.Value;

            //oDs = medDal.SeachData(medModel);
            oDs = medDal.SelectAll();
            cbMedList.DataSource = oDs.Tables[0];
            cbMedList.DataValueField = "code";
            cbMedList.DataTextField = "dname";

            cbMedList.DataBind();

            myDropDownlistID.DataSource = oDs.Tables[0];
            myDropDownlistID.DataValueField = "code";
            myDropDownlistID.DataTextField = "dname";
            myDropDownlistID.DataBind();
        }
        private void LoadPrescriptionFavorite(int PhysicianID)
        {
            var prescriptionFavoriteModel = new PhysicianPrescriptionTemplateModel();
            var prescriptionFavoriteDAl = new PhysicianPrescriptionTemplateDAL();
            oDs = new DataSet();

            prescriptionFavoriteModel.PhysicianID = PhysicianID;
            oDs = prescriptionFavoriteDAl.SelectByPhysicianID(prescriptionFavoriteModel);

            var dosageTable = new DataTable();
            dosageTable.Columns.Add("Dosage");
            var dosageRow = dosageTable.NewRow();
            dosageRow[0] = "--Select Favorite--";
            dosageTable.Rows.Add(dosageRow);

            if (oDs !=null)
            {
                if (oDs.Tables[0].Rows.Count >0)
                {
                    for (int i=0; i<= oDs.Tables[0].Rows.Count-1; i++ )
                    {
                        var dosageFavorite = dosageTable.NewRow();
                        dosageFavorite[0] = oDs.Tables[0].Rows[i]["dosage"].ToString();
                        dosageTable.Rows.Add(dosageFavorite);
                    }
                }
            }

            ddlPrescriptionTemplate.DataSource = dosageTable;
            ddlPrescriptionTemplate.DataTextField = "dosage";
            ddlPrescriptionTemplate.DataValueField = "dosage";
            ddlPrescriptionTemplate.DataBind();


        }
        private void LoadAppointment(int appointmentID)
        {
            PatientAppointmentDAL appointmentDAL = new PatientAppointmentDAL();
            PatientAppointmentModel appointmentModel = new PatientAppointmentModel();
            appointmentModel.ID = appointmentID;
            oDs = new DataSet();

            oDs = appointmentDAL.SelectByID(appointmentModel);

          //  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0]["FacilityID"].ToString();
            ddlPhysician.SelectedValue = oDs.Tables[0].Rows[0]["PhysicianID"].ToString();

            LoadPatient(oDs.Tables[0].Rows[0]["PatientNo"].ToString());
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

        private void LoadHospital()
        {
            FacilityDAL facilityDAL = new FacilityDAL();

            //ddlHospitalName.DataSource = facilityDAL.SelectAllHealthCare();
            //ddlHospitalName.DataTextField = "FacilityName";
            //ddlHospitalName.DataValueField = "id";
            //ddlHospitalName.DataBind();
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
        }

        private void LoadICDCode()
        {
           
            var fileString = "Content/icd10.json";
          //  var readFile = System.IO.rea(fileString);
        }

        private void PopulateVitals(string encounterNo)
        {
            PatientVitalsDAL vitalDAL = new PatientVitalsDAL();
            PatientVitalsModel vitalModel = new PatientVitalsModel();

            oDs = new DataSet();

            vitalModel.EncounterNo = encounterNo;

            oDs = vitalDAL.SelectByEncounterNo(vitalModel);
            hfVitalsID.Value = oDs.Tables[0].Rows[0]["id"].ToString();
            txtTemperature.Value = (oDs.Tables[0].Rows[0]["Temperature"].ToString() == "0.00") ? "" : oDs.Tables[0].Rows[0]["Temperature"].ToString();
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
            hfAssessmentID .Value = oDs.Tables[0].Rows[0]["id"].ToString();
            txtCC.InnerText = oDs.Tables[0].Rows[0]["ChiefComplaint"].ToString();
            txtHPI.InnerText = oDs.Tables[0].Rows[0]["hpi"].ToString();
           txtROS.InnerText = oDs.Tables[0].Rows[0]["ros"].ToString();
            txtPFSC.InnerText = oDs.Tables[0].Rows[0]["pfsh"].ToString();
            txtPhysicalExam.InnerText = oDs.Tables[0].Rows[0]["physicalexam"].ToString();
             txtDoctorNote.InnerText = oDs.Tables[0].Rows[0]["PhysicianNote"].ToString();

        }

        private void PopulateDiagnosis(string encounterNo)
        {
            PatientDiagnosisDAL diagnosisDAL = new PatientDiagnosisDAL();
            PatientDiagnosisModel diagnosisModel = new PatientDiagnosisModel();
            oDs = new DataSet();
            diagnosisModel.EncounterNo = encounterNo;
            oDs = diagnosisDAL.SelectByEncounterNo(diagnosisModel);

            gvDiagnosis.DataSource = oDs.Tables[0];
            gvDiagnosis.DataBind();

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

        protected void AddPatientEncounter(object sender, EventArgs e)
        {
            SaveEncounterData();
            Response.Redirect("MyActivePatients.aspx");
        }

        protected void ClosePatientCase(object sender, EventArgs e)
        {
            Response.Redirect("MyActivePatients.aspx");
        }

        protected void CompletePatientEncounter(object sender, EventArgs e)
        {
            ddlStatus.SelectedValue = "4";
            SaveEncounterData();
            Response.Redirect("MyActivePatients.aspx");
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

            oClass.ID = Convert.ToInt16(EncounterID.Value);
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

            oDAL.UpdateData(sUserName, oClass);

            PatientVitalsModel vitalModel = new PatientVitalsModel();
            PatientVitalsDAL vitalDAL = new PatientVitalsDAL();

            vitalModel.ID = Convert.ToInt16(hfVitalsID.Value);
            vitalModel.PatientNo = PatientNo.Value;
            vitalModel.EncounterNo = EncounterNo.Value;
            vitalModel.Temperature = VitalValue(txtTemperature.Value);
            vitalModel.Systolic = VitalValue(txtSystolic.Value);
            vitalModel.Diastolic = VitalValue(txtDiastolic.Value);
            vitalModel.PulseRate = VitalValue(txtPulseRate.Value);
            vitalModel.Height = VitalValue(txtHeight.Value);
            vitalModel.Weight = VitalValue(txtWeight.Value);
            vitalModel.BloodSugar = VitalValue(txtBloodSugar.Value);
            vitalModel.Notes = txtOther.Value;

            vitalDAL.UpdateData(sUserName,vitalModel);

            PatientAssessmentModel assessmentModel = new PatientAssessmentModel();
            PatientAssessmentDAL assessmentDAL = new PatientAssessmentDAL();

            assessmentModel.ID = Convert.ToInt16(hfAssessmentID.Value);
            assessmentModel.EncounterNo = EncounterNo.Value;
            assessmentModel.PatientNo = PatientNo.Value;
            assessmentModel.ChiefComplaint = txtCC.InnerText;
            assessmentModel.HPI = txtHPI.InnerText;
            assessmentModel.ROS = txtROS.InnerText;
            assessmentModel.PFSC = txtPFSC.InnerText;
            assessmentModel.PhysicalExam = txtPhysicalExam.InnerText;
            assessmentModel.PhysicianNote = txtDoctorNote.InnerText;

         
           assessmentDAL.UpdateData(sUserName,assessmentModel);

        }
        private double VitalValue(string EntryValue)
        {
            var Result = 0.0;

            if (EntryValue != "")
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
            vitalModel.BloodSugar = Convert.ToDouble(txtBloodSugar.Value);
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

        protected void AddDiagnosis_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientDiagnosisDAL oDiagnosisDAL = new PatientDiagnosisDAL();
            PatientDiagnosisModel oDiagnosisClass = new PatientDiagnosisModel();

            oDiagnosisClass.EncounterNo  = EncounterNo.Value;
            oDiagnosisClass.CaseNo = "";
            oDiagnosisClass.PatientNo = PatientNo.Value;
            oDiagnosisClass.Code = ICDCode.Value;// txtICDCode.Value;
            oDiagnosisClass.Description = ICDDesc.Value;// txtICDDescription.Value;
            oDiagnosisClass.PatientNo = PatientNo.Value;
            oDiagnosisClass.StartDate = DateTime.Now;
            oDiagnosisClass.Notes = "";
            oDiagnosisDAL.InsertData(sUserName, oDiagnosisClass);

            PopulateDiagnosis(EncounterNo.Value);
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

            PopulateDiagnosis(EncounterNo.Value);
        }
        protected void AddProcedure_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientProcedureDAL oProcedureDAL = new PatientProcedureDAL();
            PatientProcedureModel oProcedureClass = new PatientProcedureModel();

            oProcedureClass.EncounterNo = EncounterNo.Value;
            oProcedureClass.PatientNo = PatientNo.Value;
            oProcedureClass.CaseNo = "";
            oProcedureClass.Code = CPTCode.Value;// txtCPTCode.Value;
            oProcedureClass.Description = CPTDesc.Value;// txtCPTDescription.Value;
            oProcedureClass.PatientNo = PatientNo.Value;
            oProcedureClass.StartDate = DateTime.Now;
            oProcedureClass.Notes = "";
            oProcedureDAL.InsertData(sUserName, oProcedureClass);

            PopulateOrders(EncounterNo.Value);
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

            PopulateOrders(EncounterNo.Value);
        }

        protected void AddMedication_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientMedicationDAL oMedicationDAL = new PatientMedicationDAL();
            PatientMedicationModel oMedicationClass = new PatientMedicationModel();

            oMedicationClass.EncounterNo = EncounterNo.Value;
            oMedicationClass.PatientNo = PatientNo.Value;
            oMedicationClass.CaseNo = "";
            oMedicationClass.Code = MedCode.Value;//txtMedCode.Value;
            oMedicationClass.Description = MedDescription.Value;//txtMedDescription.Value;
            oMedicationClass.Dosage = Prescription.Value;//txtMedDose.Value;
            oMedicationClass.PatientNo = PatientNo.Value;
            oMedicationClass.StartDate = DateTime.Now;
            oMedicationClass.Notes = "";
            oMedicationDAL.InsertData(sUserName, oMedicationClass);

            if (cbFavorite.Checked == true)
            {
                var medFavoriteModel = new PhysicianPrescriptionTemplateModel();
                var medFavoriteDal = new PhysicianPrescriptionTemplateDAL();

                medFavoriteModel.PhysicianID = Convert.ToInt16(ddlPhysician.SelectedValue);
                medFavoriteModel.Dosage= Prescription.Value;
                medFavoriteDal.InsertData(sUserName, medFavoriteModel);
                LoadPrescriptionFavorite(Convert.ToInt16(ddlPhysician.SelectedValue));
            }

            PopulateMeds(EncounterNo.Value);
            ClearEntry();
        }

        private void ClearEntry()
        {
            MedCode.Value = "";
            MedDescription.Value = "";
            Prescription.Value = "";

            ICDCode.Value = "";
            ICDDesc.Value = "";
            cbFavorite.Checked = false;
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

            PopulateMeds(EncounterNo.Value);
        }

       
    }
}