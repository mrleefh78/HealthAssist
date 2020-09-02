using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthAssist
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = " $(document).ready(function () {$('#myDropDownlistID2').select2();});";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}