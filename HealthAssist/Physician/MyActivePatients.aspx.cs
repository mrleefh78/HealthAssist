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
    public partial class MyActivePatients : System.Web.UI.Page
    {
        private PhysicianDAL oDAL;
        private PhysicianModel oClass;
        private DataSet oDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                string id = Session["userid"].ToString();

                if (id != "")
                {
                    PopulatePhysicianData(Convert.ToInt16(id));
                    PopulateGrid();
                }


            }
        }

        private void PopulatePhysicianData(int id)
        {
            oDAL = new PhysicianDAL();
            oClass = new PhysicianModel();
            oDs = new DataSet();

            oClass.UserID = id;

            oDs = oDAL.SelectByUserID(oClass);
            PhysicianID.Value = oDs.Tables[0].Rows[0][0].ToString();
            //LastName.Value = oDs.Tables[0].Rows[0][1].ToString();
            //FirstName.Value = oDs.Tables[0].Rows[0][2].ToString();
            //Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
            ////  ddlHospitalName.SelectedValue = oDs.Tables[0].Rows[0][4].ToString();
            //txtAddress.Value = oDs.Tables[0].Rows[0][5].ToString();
            //txtEmail.Value = oDs.Tables[0].Rows[0][6].ToString();
            //txtContact.Value = oDs.Tables[0].Rows[0][7].ToString();

        }

        private void PopulateGrid()
        {
            PatientEncounterDAL MyPatientDAL = new PatientEncounterDAL();
            PatientEncounterModel MyPatientClass = new PatientEncounterModel();
            DataSet oDs = new DataSet();

            MyPatientClass.PhysicianID = Convert.ToInt16(PhysicianID.Value);

            oDs = MyPatientDAL.SelectByPhysician(MyPatientClass);


            if (oDs != null)
            {             
                MyPatientClass.StatusID = 1;
                var activePatients = oDs.Tables[0].AsEnumerable().Where(f => ((int)f["StatusID"]) == MyPatientClass.StatusID);
                if (activePatients.Count()>0)
                {
                    gvList.DataSource = activePatients.CopyToDataTable();
                    gvList.DataBind();

                }

            }

        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;

            PopulateGrid();
        }

        protected void UpdateClick(object sender, EventArgs e)
        {

            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string id = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            // Response.Redirect("PatientEncounterDetail.aspx?id=" + id + "");

            Response.Redirect(String.Format("MyPatientDetail.aspx?id={0}&appointmentid={1}&patientNo={2}", id, "", ""));
        }

        protected void SearchClick(object sender, EventArgs e)
        {

            PopulateGrid();
        }

        protected void Ok_ServerClick(object sender, EventArgs e)
        {
            PatientEncounterDAL encounterDAL = new PatientEncounterDAL();
            PatientEncounterModel encounterClass = new PatientEncounterModel();
            string sUserName = Session["User"].ToString();

            encounterClass.IsDeleted = true;
            encounterClass.ReasonDelete = itemname.InnerText;
            string lbl = lblPatientCase.Text;
            encounterClass.ID = Convert.ToInt32(HiddenFieldPatientCase.Value);
            encounterDAL.DeleteData(sUserName, encounterClass);
        }
    }
}