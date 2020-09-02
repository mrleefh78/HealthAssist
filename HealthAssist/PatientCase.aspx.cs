using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using System.Data;

namespace HealthAssist
{
    public partial class PatientCase : System.Web.UI.Page
    {
        private PatientCaseDAL oDAL;
        private PatientCaseModel oClass;
        private DataSet oDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                PopulateGrid();

            }
        }

        private void PopulateGrid()
        {
            oDAL = new PatientCaseDAL();
            oClass = new PatientCaseModel();
             DataSet oDs = new DataSet();

            //if (tsbPatName.Text == "")
            //{
            //    oDs = oDAL.SelectAllReferrals();
            //}
            //else
            //{
            //    oClass.FileName = tsbPatName.Text;
            //    oDs = oDAL.SelectReferralsByName(oClass);
            //}
            oDs = oDAL.SelectAll();



            if (oDs != null)
            {
                gvList.DataSource = oDs.Tables[0];
                gvList.DataBind();
            }

        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;

            PopulateGrid();
        }

        protected void Ok_ServerClick(object sender, EventArgs e)
        {
            oDAL = new PatientCaseDAL();
            oClass = new PatientCaseModel();
            string sUserName = Session["User"].ToString();

            oClass.IsDeleted = true;
            oClass.ReasonDelete = itemname.InnerText;
            string lbl = lblPatientCase.Text;
            oClass.ID = Convert.ToInt32(HiddenFieldPatientCase.Value);
            oDAL.DeleteData(sUserName,oClass);
        }

        protected void AddClick(object sender, EventArgs e)
        {

            Response.Redirect("PatientCaseDetail.aspx?id=");
        }

        protected void UpdateClick(object sender, EventArgs e)
        {

            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string id = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            Response.Redirect("PatientCaseDetail.aspx?id=" + id + "");
        }

        protected void SearchClick(object sender, EventArgs e)
        {

            PopulateGrid();
        }
    }
}