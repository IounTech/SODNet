using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Traits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //SortedList<string, Classes.Trait> slTraits = new SortedList<string, Classes.Trait>();
                //foreach(Classes.Trait clsTrait in Classes.AllData.Traits.Values)
                //{
                //    if(chkMissingScreenshots.Checked == false  || (chkMissingScreenshots.Checked == true && (clsTrait.strScreenshotLocation == null  || clsTrait.strScreenshotLocation == "")))
                    
                //    slTraits.Add(clsTrait.strName, clsTrait);
                //}
                
                rptTraits.DataSource = Classes.AllData.Traits.Values;
                rptTraits.DataBind();

            }
            catch (Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, ex.Message + '\n' + ex.StackTrace);
            }
        }
    }
}