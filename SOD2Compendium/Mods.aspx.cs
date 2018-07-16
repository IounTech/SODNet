using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Mods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMods.DataSource = Classes.AllData.Mods.Values;
            rptMods.DataBind();
        }
    }
}