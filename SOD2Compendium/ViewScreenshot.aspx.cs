using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class ViewScreenshot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgScreenshot.ImageUrl = Request.QueryString["Target"];
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["Page"] + ".aspx?ID=" + Request.QueryString["ID"]);
        }
    }
}