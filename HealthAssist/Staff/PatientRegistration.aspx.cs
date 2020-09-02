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


namespace HealthAssist.Staff
{
   

    public partial class PatientRegistration : System.Web.UI.Page
    {

        private PatientDAL oDAL;
        private PatientModel oClass;
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
            oDAL = new PatientDAL();
            oDs = new DataSet();

            //oDs = oDAL.SelectAllPatient();

            if (searchKeyword.Value != "")
            {

                oDs = oDAL.SeachPatient(searchKeyword.Value);
            }
            else
            {
                oDs = oDAL.SelectAllPatient();
            }



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
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldPatient.Value);

            oDAL = new PatientDAL();
            oClass = new PatientModel();

            oClass.IsDeleted = true;
            oClass.ReasonDelete = itemname.InnerText;
            string lbl = lblPatient.Text;
            oClass.ID = ID;
            oDAL.DeletePatient(UserName, oClass);
            PopulateGrid();
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Response.Redirect("PatientNew.aspx?id=");
        }

        protected void AddEncounterClick(object sender, EventArgs e)
        {
            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string patientNo = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            // Response.Redirect("PatientNewEncounter.aspx?patientNo=" + patientNo + "");

            Response.Redirect(String.Format("PatientEncounterDetail.aspx?id={0}&appointmentid={1}&patientNo={2}", "", "", Server.UrlEncode(patientNo)));
        }

        protected void AddCaseClick(object sender, EventArgs e)
        {
            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string patientNo = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            Response.Redirect("PatientNewCase.aspx?patientNo=" + patientNo + "");
        }

        protected void AddAppointmentClick(object sender, EventArgs e)
        {
            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string patientNo = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            Response.Redirect("AppointmentDetail.aspx?id=&patientNo=" + patientNo + "");
        }

        protected void SearchClick(object sender, EventArgs e)
        {

            PopulateGrid();
        }

        protected void UpdateClick(object sender, EventArgs e)
        {

            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string id = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            Response.Redirect("PatientDetail.aspx?id=" + id + "");
        }
    }
}