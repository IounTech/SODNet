using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Bases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedList<string, Classes.Base> slBases = new SortedList<string, Classes.Base>();

            foreach (Classes.Base Base in Classes.AllData.Bases.Values)
            {
                slBases.Add(Base.strName, Base);
            }

            rptBases.DataSource = slBases.Values;
            rptBases.DataBind();
        }
    }
}