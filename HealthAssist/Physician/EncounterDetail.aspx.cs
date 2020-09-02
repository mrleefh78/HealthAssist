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
using Newtonsoft;
using Newtonsoft.Json;

namespace HealthAssist
{
    public partial class EncounterDetail : System.Web.UI.Page
    {
        private PatientEncounterDAL oDAL;
        private PatientEncounterModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("~/login.aspx");
            if (!(IsPostBack))
            {
                int id = Convert.ToInt16(Session["userid"]);
                PopulateProfile(id);

                string encounterid = Request.QueryString["id"].ToString();
                LoadMedicines();
                LoadICDJson();
                LoadCPT();
                LoaDispositions();
                LoadPrescriptionFavorite(Convert.ToInt16(PhysicianID.Value));
                EncounterDate.Value = DateTime.Now.ToShortDateString();

                if (encounterid != "")
                {
                    PopulatePatientEncounter(encounterid);
                    PopulateVitals(encounterid);
                    PopulateAssessment(encounterid);
                    PopulateDiagnosis(encounterid);
                    PopulateMeds(encounterid);
                    PopulateCpt(encounterid);


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
            UserSpecialty.Text = oDs.Tables[0].Rows[0][5].ToString();
            PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
          
            //PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            //LastName.Value = oDs.Tables[0].Rows[0][1].ToString();
            //FirstName.Value = oDs.Tables[0].Rows[0][2].ToString();
            //Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
            //txtAddress.Value = oDs.Tables[0].Rows[0][5].ToString();
            //txtEmail.Value = oDs.Tables[0].Rows[0][6].ToString();
            //txtContact.Value = oDs.Tables[0].Rows[0][7].ToString();

        }

        #region "Binding Reference"
        private void LoadMedicines()
        {
            var medModel = new MedicineModel();
            var medDal = new MedicineDAL();
            oDs = new DataSet();

            //medModel.ItemName = SearchMed.Value;

            ////oDs = medDal.SeachData(medModel);
            oDs = medDal.SelectAll();

            var medsTable = new DataTable();
            medsTable.Columns.Add("id");
            medsTable.Columns.Add("dname");
            var medsRow = medsTable.NewRow();
            medsRow[0] = 0;
            medsRow[1] = "--Select Medicine--";
            medsTable.Rows.Add(medsRow);

            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        var medsFinal = medsTable.NewRow();
                        medsFinal[0] = oDs.Tables[0].Rows[i]["id"].ToString();
                        medsFinal[1] = oDs.Tables[0].Rows[i]["dname"].ToString();
                        medsTable.Rows.Add(medsFinal);
                    }
                }
            }




            medsList.DataSource = medsTable;
            medsList.DataValueField = "id";
            medsList.DataTextField = "dname";

            medsList.DataBind();

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

            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
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

        private void LoaDispositions()
        {
            var dispositionModel = new DispositionModel();
            var dispositionDal = new DispositionDAL();
            oDs = new DataSet();

            //medModel.ItemName = SearchMed.Value;

            ////oDs = medDal.SeachData(medModel);
            oDs = dispositionDal.SelectAll();

            var dispostionTable = new DataTable();
            dispostionTable.Columns.Add("id");
            dispostionTable.Columns.Add("dname");
            var medsRow = dispostionTable.NewRow();
            medsRow[0] = 0;
            medsRow[1] = "--Select Disposition--";
            dispostionTable.Rows.Add(medsRow);

            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        var resultFinal = dispostionTable.NewRow();
                        resultFinal[0] = oDs.Tables[0].Rows[i]["id"].ToString();
                        resultFinal[1] = oDs.Tables[0].Rows[i]["dname"].ToString();
                        dispostionTable.Rows.Add(resultFinal);
                    }
                }
            }




            ddlDisposition.DataSource = dispostionTable;
            ddlDisposition.DataValueField = "id";
            ddlDisposition.DataTextField = "dname";

            ddlDisposition.DataBind();

        }
        #endregion

        #region" Binding Data"
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
            PatientNameValue.Text = oDs.Tables[0].Rows[0]["PatientName"].ToString() + ", " + oDs.Tables[0].Rows[0]["Gender"].ToString() + ", " + CalculateAge(Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]));
            PatientName.Value = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]).ToShortDateString();
            Insurance.Value = oDs.Tables[0].Rows[0]["CompanyName"].ToString();
            InsuranceNo.Value = oDs.Tables[0].Rows[0]["InsuranceNo"].ToString();
            ServiceType.Value = oDs.Tables[0].Rows[0]["ServiceType"].ToString();
            PhysicianName.Value = oDs.Tables[0].Rows[0]["PhysicianName"].ToString();
            Remarks.Value = oDs.Tables[0].Rows[0]["Remarks"].ToString();
            Status.Value = oDs.Tables[0].Rows[0]["Status"].ToString();
            ddlDisposition.SelectedValue = oDs.Tables[0].Rows[0]["dispositionID"].ToString();
           RestDays.Value =  oDs.Tables[0].Rows[0]["RestForDays"].ToString();
            Recommendation.Value = oDs.Tables[0].Rows[0]["WorkRestriction"].ToString();
            FollowUpDate.Value = oDs.Tables[0].Rows[0]["FollowUpDate"].ToString();

            int StatusID = Convert.ToInt16(oDs.Tables[0].Rows[0]["StatusID"]);
            if ((StatusID == 2) || (StatusID == 4))
            {
                btnSave.Visible = false;
            }
        }

        private string CalculateAge(DateTime dob)
        {
            int Age = (DateTime.Now.Year - Convert.ToDateTime(dob).Year);

            if (dob.Date > DateTime.Now.AddYears(-Age))
            {
                Age = Age - 1;
            }

            return Age.ToString("N0");
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
            hfAssessmentID.Value = oDs.Tables[0].Rows[0]["id"].ToString();
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

        private void PopulateCpt(string encounterNo)
        {
            PatientProcedureDAL cptDAL = new PatientProcedureDAL();
            PatientProcedureModel cptModel = new PatientProcedureModel();
            oDs = new DataSet();
            cptModel.EncounterNo = encounterNo;
            oDs = cptDAL.SelectByEncounter(cptModel);

            gvCpt.DataSource = oDs.Tables[0];
            gvCpt.DataBind();

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
        #endregion

        public void LoadICDJson()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("../Content/icd10copy.json")))
            {
                string json = r.ReadToEnd();
                // dynamic items = JsonConvert.DeserializeObject<List<items>>(json);
                dynamic jsonICD = JsonConvert.DeserializeObject(json);

                var icdList = new List<ICDModel>();
                var selectICD = new ICDModel();
                selectICD.Code = "0";
                selectICD.Description = "--Select ICD--";
                icdList.Add(selectICD);


                foreach (var item in jsonICD)
                {
                    var icd = new ICDModel();
                    icd.Code = item["CODE"];
                    icd.Description = item["Description"];
                    icdList.Add(icd);
                }


                ddlICD.DataSource = icdList;
                ddlICD.DataValueField = "Code";
                ddlICD.DataTextField = "Description";
                ddlICD.DataBind();
                // var item = new List<ICDModel>();
                //item = JsonConvert.DeserializeObject<List<ICDModel>>(json);

            }
        }

        private void LoadCPT()
        {
            var cptModel = new ICDModel();
            var cptDal = new CPTDAL();
            oDs = new DataSet();

            //medModel.ItemName = SearchMed.Value;

            ////oDs = medDal.SeachData(medModel);
            oDs = cptDal.SelectAll();

            var cptTable = new DataTable();
            cptTable.Columns.Add("code");
            cptTable.Columns.Add("dname");
            var cptRow = cptTable.NewRow();
            cptRow[0] = 0;
            cptRow[1] = "--Select CPT--";
            cptTable.Rows.Add(cptRow);

            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= oDs.Tables[0].Rows.Count - 1; i++)
                    {
                        var cptFinal = cptTable.NewRow();
                        cptFinal[0] = oDs.Tables[0].Rows[i]["code"].ToString();
                        cptFinal[1] = oDs.Tables[0].Rows[i]["dname"].ToString();
                        cptTable.Rows.Add(cptFinal);
                    }
                }
            }




            ddlCpt.DataSource = cptTable;
            ddlCpt.DataValueField = "code";
            ddlCpt.DataTextField = "dname";

            ddlCpt.DataBind();

        }


        protected void OnMedsPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPrescription.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            this.PopulateMeds(id);
        }

        protected void OnDiagnosisPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDiagnosis.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            this.PopulateDiagnosis(id);
        }

        protected void OnCptPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCpt.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
            PopulateCpt(id);
        }

        protected void SavePatientEncounter(object sender, EventArgs e)
        {
            SaveEncounterData(3);
           // Response.Redirect("EncounterList.aspx?View=Pending");
        }

        protected void ClosePatientCase(object sender, EventArgs e)
        {
            Response.Redirect("EncounterList.aspx?View=All");
        }

        protected void CompletePatientEncounter(object sender, EventArgs e)
        {
         
            SaveEncounterData(4);
            SaveEncounterLog(4);
            Response.Redirect("EncounterList.aspx?View=Pending");
        }

        private void SaveEncounterLog(int statusID)
        {
            var logModel = new PatientEncounterLogModel();
            var logDal = new PatientEncounterLogDAL();

            string sUserName = Session["User"].ToString();

            logModel.EncounterNo = EncounterNo.Value;
            logModel.PatientNo = PatientNo.Value;
            logModel.LogDate = DateTime.Now;
            logModel.StatusID = statusID;
            logDal.InsertData(sUserName, logModel);
        }

        private void SaveEncounterData(int statusID)
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();

            oClass.ID = Convert.ToInt16(EncounterID.Value);
            oClass.EncounterNo = EncounterNo.Value;
            oClass.DispositionID = Convert.ToInt16(ddlDisposition.SelectedValue);
            if (RestDays.Value !="")
            {
                oClass.NoOfDays = Convert.ToInt16(RestDays.Value);
            }
          
            if (FollowUpDate.Value !="")
            {
                oClass.FollowUpDate = Convert.ToDateTime(FollowUpDate.Value);
            }

            oClass.WorkRestriction = Recommendation.InnerHtml;

            oClass.StatusID = statusID;

            oDAL.UpdateEncounterDoctorData(sUserName, oClass);

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

            vitalDAL.UpdateData(sUserName, vitalModel);

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


            assessmentDAL.UpdateData(sUserName, assessmentModel);

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

            oDiagnosisClass.EncounterNo = EncounterNo.Value;
            oDiagnosisClass.CaseNo = "";
            oDiagnosisClass.PatientNo = PatientNo.Value;
            oDiagnosisClass.Code = ICDCode.Value;// txtICDCode.Value;
            oDiagnosisClass.Description = ICDDesc.Value;// txtICDDescription.Value;
            oDiagnosisClass.PatientNo = PatientNo.Value;
            oDiagnosisClass.StartDate = DateTime.Now;
            oDiagnosisClass.Notes = "";
            oDiagnosisDAL.InsertData(sUserName, oDiagnosisClass);

            PopulateDiagnosis(EncounterNo.Value);

            ClearEntry();
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

            PopulateCpt(EncounterNo.Value);
            ClearEntry();
            

        }
        //protected void DeleteProcedure_ServerClick(object sender, EventArgs e)
        //{
        //    string UserName = Session["User"].ToString();
        //    int ID = Convert.ToInt32(HiddenFieldPatientProcedure.Value);

        //    PatientProcedureDAL oProcedureDAL = new PatientProcedureDAL();
        //    PatientProcedureModel oProcedureClass = new PatientProcedureModel();

        //    oProcedureClass.IsDeleted = true;
        //    oProcedureClass.ReasonDelete = deleteCPTReason.InnerText;
        //    string lbl = lblPatientProcedure.Text;
        //    oProcedureClass.ID = ID;
        //    oProcedureDAL.DeleteData(UserName, oProcedureClass);

        //    PopulateOrders(EncounterNo.Value);
        //}

        protected void AddMedication_ServerClick(object sender, EventArgs e)
        {
            string sUserName = Session["User"].ToString();

            PatientMedicationDAL oMedicationDAL = new PatientMedicationDAL();
            PatientMedicationModel oMedicationClass = new PatientMedicationModel();

            oMedicationClass.EncounterNo = EncounterNo.Value;
            oMedicationClass.PatientNo = PatientNo.Value;
            oMedicationClass.CaseNo = "";
            oMedicationClass.Code = medsList.SelectedValue;//txtMedCode.Value;
            oMedicationClass.Description = medsList.SelectedItem.Text;//txtMedDescription.Value;
            oMedicationClass.Dosage = Prescription.Value;//txtMedDose.Value;
            oMedicationClass.PatientNo = PatientNo.Value;
            oMedicationClass.StartDate = DateTime.Now;
            oMedicationClass.Notes = "";
            oMedicationDAL.InsertData(sUserName, oMedicationClass);
            
            if (cbFavorite.Checked == true)
            {
                var medFavoriteModel = new PhysicianPrescriptionTemplateModel();
                var medFavoriteDal = new PhysicianPrescriptionTemplateDAL();

                medFavoriteModel.PhysicianID = Convert.ToInt16(PhysicianID.Value);
                medFavoriteModel.Dosage = Prescription.Value;
                medFavoriteDal.InsertData(sUserName, medFavoriteModel);
                LoadPrescriptionFavorite(Convert.ToInt16(PhysicianID.Value));
            }

            PopulateMeds(EncounterNo.Value);
            ClearEntry();
        }

        private void ClearEntry()
        {
            //MedCode.Value = "";
            //MedDescription.Value = "";
            Prescription.Value = "";

            ICDCode.Value = "";
            ICDDesc.Value = "";

            CPTCode.Value = "";
            CPTDesc.Value = "";
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