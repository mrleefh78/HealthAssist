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
    public partial class InvoiceDetail : System.Web.UI.Page
    {
        private InvoiceDAL oDAL;
        private InvoiceModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Request.QueryString["id"].ToString();
                LoadInsurance();
                LoadStatus();
                LoadActiveCasePatient();
                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));
                }


            }
        }
        private void LoadActiveCasePatient()
        {
            PatientCaseDAL caseDAL = new PatientCaseDAL();

            var data = caseDAL.SelectAll().Tables[0].AsEnumerable().Where(p => p["StatusID"].ToString() == "1").CopyToDataTable();
            ddlPatient.DataSource = data.DefaultView;
            ddlPatient.DataTextField = "PatientName";
            ddlPatient.DataValueField = "PatientNo";
            ddlPatient.DataBind();
        }
        private void LoadInsurance()
        {
            InsuranceCompanyDAL insuranceDAL = new InsuranceCompanyDAL();

            ddlInsurance.DataSource = insuranceDAL.SelectAll();
            ddlInsurance.DataTextField = "CompanyName";
            ddlInsurance.DataValueField = "ID";
            ddlInsurance.DataBind();
        }
        private void LoadStatus()
        {
            InvoiceStatusDAL insuranceDAL = new InvoiceStatusDAL();

            ddlStatus.DataSource = insuranceDAL.SelectAll();
            ddlStatus.DataTextField = "dname";
            ddlStatus.DataValueField = "ID";
            ddlStatus.DataBind();
        }
        private void PopulateData(int id)
        {
            oDAL = new InvoiceDAL();
            oClass = new InvoiceModel();
            oDs = new DataSet();

            oClass.ID = id;

            oDs = oDAL.SelectByID(oClass);
            InvoiceID.Value = oDs.Tables[0].Rows[0][0].ToString();
            InvoiceNo.Value = oDs.Tables[0].Rows[0][1].ToString();
            ddlInsurance.SelectedValue = oDs.Tables[0].Rows[0][2].ToString();
            PatientNo.Value = oDs.Tables[0].Rows[0]["PatientNo"].ToString();
            ddlPatient.SelectedValue = oDs.Tables[0].Rows[0]["PatientNo"].ToString();           
            CaseNo.Value = oDs.Tables[0].Rows[0][4].ToString();
            InvoiceDate.Value = oDs.Tables[0].Rows[0][5].ToString();
            Medex.Value = oDs.Tables[0].Rows[0][6].ToString();
            CaseFee.Value = oDs.Tables[0].Rows[0][7].ToString();
            TotalBill.Value = oDs.Tables[0].Rows[0][8].ToString();
            BillingDate.Value = oDs.Tables[0].Rows[0][9].ToString();
            PaidDate.Value = oDs.Tables[0].Rows[0][10].ToString();
            ddlStatus.SelectedValue = oDs.Tables[0].Rows[0][11].ToString();
            txtRemarks.Value = oDs.Tables[0].Rows[0][12].ToString();
         

        }
        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("Invoice.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("Invoice.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            oDAL = new InvoiceDAL();
            oClass = new InvoiceModel();


            oClass.InvoiceNo = InvoiceNo.Value;
            oClass.InsuranceCompanyID = ddlInsurance.SelectedValue;
            oClass.PatientNo = ddlPatient.SelectedValue;
            oClass.CaseNo = CaseNo.Value ;
            oClass.InvoiceDate = Convert.ToDateTime(InvoiceDate.Value);
            oClass.Medex = Convert.ToDecimal(Medex.Value);
            oClass.CaseFee = Convert.ToDecimal(CaseFee.Value);
            oClass.TotalBilled = Convert.ToDecimal(TotalBill.Value);
            oClass.DateBilled = Convert.ToDateTime(BillingDate.Value);
            oClass.DatePaid = Convert.ToDateTime(PaidDate.Value);
            oClass.StatusID = ddlStatus.SelectedValue;
            oClass.Remarks = txtRemarks.InnerText;

            string id = InvoiceID.Value;
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