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
    public partial class PatientEncounter : System.Web.UI.Page
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
                PopulateGrid();

            }
        }

        private void PopulateGrid()
        {
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();
            DataSet oDs = new DataSet();

           // oClass.EncounterType = "Regular Visit";

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
            oDAL = new PatientEncounterDAL();
            oClass = new PatientEncounterModel();
            string sUserName = Session["User"].ToString();

            oClass.IsDeleted = true;
            oClass.ReasonDelete = itemname.InnerText;
            string lbl = lblPatientCase.Text;
            oClass.ID = Convert.ToInt32(HiddenFieldPatientCase.Value);
            oDAL.DeleteData(sUserName, oClass);
        }

        protected void AddClick(object sender, EventArgs e)
        {

            Response.Redirect("PatientEncounterDetail.aspx?id=");
        }

        protected void UpdateClick(object sender, EventArgs e)
        {

            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string id = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
           // Response.Redirect("PatientEncounterDetail.aspx?id=" + id + "");

            Response.Redirect(String.Format("PatientEncounterDetail.aspx?id={0}&appointmentid={1}&patientNo={2}", id, "", ""));
        }

        protected void SearchClick(object sender, EventArgs e)
        {

            PopulateGrid();
        }
    }
}