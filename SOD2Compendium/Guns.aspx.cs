using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Guns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedList<string, Classes.Gun> slGuns = new SortedList<string, Classes.Gun>();

            foreach(Classes.Gun Gun in Classes.AllData.Guns.Values)
            {
                slGuns.Add(Gun.strName, Gun);
            }

            rptGuns.DataSource = slGuns.Values;
            rptGuns.DataBind();
        }
        public void GunChecked(object sender, EventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    if (((CheckBox)sender).Checked)
                    {
                        Response.Write(((CheckBox)sender).Text + " is checked");
                    }
                }
                catch { }
            }
        }
    }
   
}