using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class HeroBonuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedList<string, Classes.HeroBonus> slHeroBonuses = new SortedList<string, Classes.HeroBonus>();

            foreach (Classes.HeroBonus HeroBonus in Classes.AllData.HeroBonuses.Values)
            {
                slHeroBonuses.Add(HeroBonus.strName, HeroBonus);
            }

            rptHeroBonuses.DataSource = slHeroBonuses.Values;
            rptHeroBonuses.DataBind();
        }
    }
}