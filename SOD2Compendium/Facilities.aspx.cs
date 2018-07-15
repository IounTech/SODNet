using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Facilitys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedList<string, Classes.Facility> slFacilities = new SortedList<string, Classes.Facility>();
            try
            {
                foreach (Classes.Facility Facility in Classes.AllData.Facilities.Values)
                {
                    slFacilities.Add(Facility.strName, Facility);
                }
            }
            catch (Exception ex)
            {
                Classes.AllData.Update();
            }
            rptFacilities.DataSource = slFacilities.Values;
            rptFacilities.DataBind();
        }
    }
}