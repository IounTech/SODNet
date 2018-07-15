using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPullFromMasterSheet_Click(object sender, EventArgs e)
        {
            try
            {


                Classes.GoogleSheetsAPIController.ProcessRipSheet();
            }
            catch (Exception ex)
            {
                throw new Exception("DON'T PUSH THIS BUTTON");
            }
        }
    }
}