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
    public partial class ConsentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["patientNo"].ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                PopulatePatient(id);
            }

        }

        private void PopulatePatient(string patientNo)
        {
            PatientDAL oDAL = new PatientDAL();
            PatientModel oClass = new PatientModel();
            DataSet oDs = new DataSet();

            oClass.PatientNo = patientNo;

            oDs = oDAL.SelectByPatientNo(oClass);

            lblPatientName.Text = oDs.Tables[0].Rows[0][5].ToString() + " " + oDs.Tables[0].Rows[0][4].ToString();


        }


    }
}