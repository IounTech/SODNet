using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using MainUtilitiesLibrary;


namespace SOD2Compendium
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch(Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, ex.Message + '\n' + ex.StackTrace);
            }
        }

        
    }
}