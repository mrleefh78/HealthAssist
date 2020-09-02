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
    public partial class Prescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["encounterNo"].ToString();
                PopulatePatientEncounter(id);
                PopulateMeds(id);
            }
        }

        private void PopulatePatientEncounter(string encounterNo)
        {
            lblAddress.Text = "";
           var oDAL = new PatientEncounterDAL();
            var oClass = new PatientEncounterModel();
            var oDs = new DataSet();

            oClass.EncounterNo = encounterNo;

            oDs = oDAL.SelectByEncounterNo(oClass);

            lblDate.Text = DateTime.Today.ToShortDateString();
            lblPatient.Text = oDs.Tables[0].Rows[0]["PatientName"].ToString();
            lblGender.Text = oDs.Tables[0].Rows[0]["gender"].ToString();
            lblAge.Text = CalculateAge(Convert.ToDateTime(oDs.Tables[0].Rows[0]["DOB"]));
            lblPhysician.Text = oDs.Tables[0].Rows[0]["PhysicianName"].ToString();
            lblAddress.Text = oDs.Tables[0].Rows[0]["Address"].ToString();
            //  lblEncounterDate.Text = Convert.ToDateTime(oDs.Tables[0].Rows[0]["EncounterDate"]).ToLongDateString();
            lblPhysicianLicense.Text = oDs.Tables[0].Rows[0]["licenseNo"].ToString();

        }

        private string CalculateAge(DateTime dob)
        {
            var result = "";
            var age = DateTime.Now - dob;

            result = (age.Days / 365).ToString("N0");
            return result;
        }

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
                        lblMeds.Text = lblMeds.Text + "<br>" + oDs.Tables[0].Rows[i]["description"].ToString() + "      " + oDs.Tables[0].Rows[i]["dosage"].ToString() + "<br>";
                    }
                }
            }

        }
    }
}