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
    public partial class PatientNew : System.Web.UI.Page
    {
        private PatientDAL oDAL;
        private PatientModel oClass;
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

                if (id != "")
                {

                    PopulatePatient(id);
                }
                else
                {
                    //dtpDateReg.Text = DateTime.Now.ToShortDateString();
                    DOB.Value = DateTime.Now.AddYears(-20).ToShortDateString();
                    //PopulateLastNo();

                }

            }
        }
        

        private void PopulatePatient(string patientNo)
        {
            oDAL = new PatientDAL();
            oClass = new PatientModel();
            oDs = new DataSet();

            oClass.PatientNo = patientNo;

            oDs = oDAL.SelectByPatientNo(oClass);
            PatientID.Value = oDs.Tables[0].Rows[0][0].ToString();
            PatientNo.Value = oDs.Tables[0].Rows[0][1].ToString();
            //DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0][3]).ToShortDateString();
            LastName.Value = oDs.Tables[0].Rows[0][4].ToString();
            FirstName.Value = oDs.Tables[0].Rows[0][5].ToString();
            MiddleName.Value = oDs.Tables[0].Rows[0][6].ToString();
            DOB.Value = Convert.ToDateTime(oDs.Tables[0].Rows[0][7]).ToShortDateString();
            Gender.Value = oDs.Tables[0].Rows[0][8].ToString();
            txtAddress.InnerText = oDs.Tables[0].Rows[0][13].ToString();
            Contact.Value = oDs.Tables[0].Rows[0][9].ToString();
            PatientEmail.Value = oDs.Tables[0].Rows[0][11].ToString();

        }

        protected void AddPatient(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("PatientDetail.aspx");
        }

        protected void ClosePatient(object sender, EventArgs e)
        {
            Response.Redirect("Patient.aspx");
        }



        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new PatientDAL();
            oClass = new PatientModel();

            //sID = lblID.Text;

            // oClass.PatientNo = PatientNo.Value;
            oClass.DateRegister = DateTime.Now;
            oClass.LastName = LastName.Value;
            oClass.FirstName = FirstName.Value;
            oClass.MiddleName = MiddleName.Value;
            oClass.DOB = Convert.ToDateTime(DOB.Value);
            oClass.Gender = Gender.Value;
            oClass.Address = txtAddress.InnerText;
            oClass.ContactNo = Contact.Value;
            oClass.Email = PatientEmail.Value;
            oClass.Nationality = "";

            string id = PatientID.Value;
            if (id == "")
            {
               
               int lastid = oDAL.InsertNewPatient(sUserName, oClass);

                oDs = new DataSet();
                oClass.ID = lastid;
                oDs = oDAL.SelectByPatientID(oClass);

                id = oDs.Tables[0].Rows[0][1].ToString();

                Response.Redirect("PatientDetail.aspx?id=" + id + "");
            }
            else
            {
                oClass.ID = Convert.ToInt16(id);
                oDAL.UpdatePatient(sUserName, oClass);
                // lblMsg.Text = "Record has been updated";

            }
        }
    }
}