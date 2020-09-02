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
    public partial class PatientDetail : System.Web.UI.Page
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

                LoadInsuranceCompany();
                if (id != "")
                {
                    
                    PopulatePatient(id);
                    PopulatePatientInsurance(id);

                }
                else
                {
                    //dtpDateReg.Text = DateTime.Now.ToShortDateString();
                    DOB.Value  = DateTime.Now.AddYears(-20).ToShortDateString();
                    //PopulateLastNo();
                  
                }

            }
        }
    

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvDependents.PageIndex = e.NewPageIndex;
            string id = Request.QueryString["id"].ToString();
           // this.PopulateOrders(id);
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

        private void PopulatePatientInsurance(string patientNo)
        {
            MembershipType.Value = "Principal";
            PatientInsuranceDAL patInsurance = new PatientInsuranceDAL();
            PatientInsuranceModel patInsuranceModel = new PatientInsuranceModel();

            oDs = new DataSet();

            patInsuranceModel.PatientNo = patientNo;
            oDs = patInsurance.SelectByPatientNo(patInsuranceModel);
            if (oDs != null)
            {
                if (oDs.Tables[0].Rows.Count >0)
                {
                    ddlInsuranceCompany.SelectedValue = oDs.Tables[0].Rows[0][2].ToString();
                    txtDateStart.Value = oDs.Tables[0].Rows[0][3].ToString();
                    txtDateExpire.Value = oDs.Tables[0].Rows[0][4].ToString();
                    txtPolicyNo.Value = oDs.Tables[0].Rows[0][5].ToString();
                    MembershipType.Value = oDs.Tables[0].Rows[0][6].ToString();
                    txtEmployeeNo.Value = oDs.Tables[0].Rows[0][9].ToString();
                    txtCompany.Value = oDs.Tables[0].Rows[0][10].ToString();
                    Remarks.Value = oDs.Tables[0].Rows[0][8].ToString();
                }


             

            }


        }

        protected void AddPatient(object sender, EventArgs e)
        {
            SaveData();
            SaveInsurance();
            Response.Redirect("Patient.aspx");
        }

        protected void ClosePatient(object sender, EventArgs e)
        {
            Response.Redirect("Patient.aspx");
        }

        private void LoadInsuranceCompany()
        {
            InsuranceCompanyDAL insuranceCompanyDAL = new InsuranceCompanyDAL();
            InsuranceCompanyModel insuranceModel = new InsuranceCompanyModel();

            insuranceModel.CountryCode = "PHL";
            oDs = new DataSet();
            oDs = insuranceCompanyDAL.SelectByCountryCode(insuranceModel);
            //var result = oDs.Tables[0].AsEnumerable().Where(myRow => myRow.Field<string>("CountryCode") == "PHL").CopyToDataTable();
            ddlInsuranceCompany.DataSource = oDs.Tables[0];
            ddlInsuranceCompany.DataTextField = "CompanyName";
            ddlInsuranceCompany.DataValueField = "id";
            ddlInsuranceCompany.DataBind();
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

            string id = PatientID.Value ;
            if (id == "")
            {
                oDAL.InsertPatient(sUserName, oClass);
                //lblMsg.Text = "New Record has been saved";
            }
            else
            {
                oClass.ID = Convert.ToInt16(id);
                oDAL.UpdatePatient(sUserName, oClass);
               // lblMsg.Text = "Record has been updated";

            }
        }

        private void SaveInsurance()
        {
            PatientInsuranceDAL patInsurance = new PatientInsuranceDAL();
            PatientInsuranceModel patInsuranceModel = new PatientInsuranceModel();

            string sUserName = Session["User"].ToString();
            
            patInsuranceModel.PatientNo = PatientNo.Value;
            patInsuranceModel.InsuranceID = Convert.ToInt16(ddlInsuranceCompany.SelectedValue);
            patInsuranceModel.StartDate= Convert.ToDateTime(txtDateStart.Value);
            patInsuranceModel.ExpirationDate = Convert.ToDateTime(txtDateExpire.Value);
            patInsuranceModel.PolicyNo = txtPolicyNo.Value;
            patInsuranceModel.MembershipType = MembershipType.Value;
            patInsuranceModel.PrincipalPatientNo = "";
                  patInsuranceModel.EmployeeNo = txtEmployeeNo.Value;
            patInsuranceModel.Company = txtCompany.Value;
            patInsuranceModel.Notes = Remarks.Value;

            patInsurance.InsertPatientInsurance(sUserName, patInsuranceModel);
        }
    }
}