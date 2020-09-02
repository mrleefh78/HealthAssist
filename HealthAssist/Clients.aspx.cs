using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HealthAssist.AppClass;
using HealthAssist.AppDal;
using System.Data;

namespace HealthAssist
{
    public partial class Clients : System.Web.UI.Page
    {
        private InsuranceCompanyDAL oDAL;
        private InsuranceCompanyModel oClass;
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
            oDAL = new InsuranceCompanyDAL();
            oDs = new DataSet();

            if (searchKeyword.Value != "")
            {

                oDs = oDAL.SeachData(searchKeyword.Value);
            }
            else
            {
                oDs = oDAL.SelectAll();
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
            int ID = Convert.ToInt32(HiddenFieldItem.Value);

            oDAL = new InsuranceCompanyDAL();
            oClass = new InsuranceCompanyModel();
            oDs = new DataSet();

            oClass.IsDeleted = true;
            oClass.ReasonDelete = itemname.InnerText;
            string lbl = lblSelectedItem.Text;
            oClass.ID = ID;
            oDAL.DeleteData(UserName, oClass);
            PopulateGrid();
        }
        protected void AddClick(object sender, EventArgs e)
        {
            Response.Redirect("ClientDetail.aspx?id=");
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
            Response.Redirect("ClientDetail.aspx?id=" + id + "");
        }
    }
}