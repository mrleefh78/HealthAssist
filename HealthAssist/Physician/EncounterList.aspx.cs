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
    public partial class EncounterList : System.Web.UI.Page
    {
        private PhysicianDAL oDAL;
        private PhysicianModel oClass;
        private DataSet oDs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("~/login.aspx");

            if (!(IsPostBack))
            {
                int id = Convert.ToInt16(Session["userid"]);
                PopulateProfile(id);
                PopulateGrid();
               
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
            //LastName.Value = oDs.Tables[0].Rows[0][1].ToString();
            //FirstName.Value = oDs.Tables[0].Rows[0][2].ToString();
            //Specialty.Value = oDs.Tables[0].Rows[0][3].ToString();
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

                string status = Request.QueryString["View"].ToString();

                if (status == "Pending" || status == "In Consultation")
                {

                    var activePatients = oDs.Tables[0].AsEnumerable()
                        .Where(f => ((int)f["StatusID"]) == 1 || (int)f["StatusID"] ==3);
                      //  .Where(f => ((int)f["StatusID"]) == 3);
                    if (activePatients.Count() > 0)
                    {
                        gvList.DataSource = activePatients.CopyToDataTable();
                        gvList.DataBind();

                    }
                }

                else
                {
                    gvList.DataSource = oDs.Tables[0];
                    gvList.DataBind();
                } 
                
                if (searchKeyword.Value !="")
                {
                    
                    var SearchPatients = oDs.Tables[0].AsEnumerable().Where(f => ((string)f["PatientName"]).ToLower().Contains(searchKeyword.Value.ToLower()));
                    if (SearchPatients.Count() > 0)
                    {
                        gvList.DataSource = SearchPatients.CopyToDataTable();
                        gvList.DataBind();

                    }
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
            string patientNo = gvList.Rows[gvrow.RowIndex].Cells[2].Text;
            // Response.Redirect("PatientEncounterDetail.aspx?id=" + id + "");
            string status = gvList.Rows[gvrow.RowIndex].Cells[9].Text;
            if (status == "Pending")
            {
                UpdateStatus(id);
                SaveEncounterLog(3,id, patientNo);
            }
          
            Response.Redirect(String.Format("EncounterDetail.aspx?id={0}&appointmentid={1}&patientNo={2}", id, "", ""));
        }

        private void UpdateStatus(string id)
        {
            string sUserName = Session["User"].ToString();
            PatientEncounterDAL MyPatientDAL = new PatientEncounterDAL();
            PatientEncounterModel MyPatientClass = new PatientEncounterModel();

            MyPatientClass.EncounterNo = id;
            MyPatientClass.StatusID = 3;
            MyPatientDAL.UpdateDataStatus(sUserName,MyPatientClass);

            
        }

        private void SaveEncounterLog(int statusID, string encounterNo, string patientNo)
        {
            var logModel = new PatientEncounterLogModel();
            var logDal = new PatientEncounterLogDAL();

            string sUserName = Session["User"].ToString();

            logModel.LogDate = DateTime.Now;
            logModel.StatusID = statusID;
            logModel.EncounterNo = encounterNo;
            logModel.PatientNo = patientNo;
            logDal.InsertData(sUserName, logModel);
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