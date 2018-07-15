using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedList<string, Classes.Item> slItems = new SortedList<string, Classes.Item>();
            try
            {

           

            foreach (Classes.Item Item in Classes.AllData.Items.Values)
            {
                slItems.Add(Item.strName, Item);
            }
            }
            catch(Exception ex)
            {
                Classes.AllData.Update();
            }
            rptItems.DataSource = slItems.Values;
            rptItems.DataBind();
        }
    }
}