using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainUtilitiesLibrary;
using SOD2Compendium.Classes;

namespace SOD2Compendium
{
    public partial class ModifyHeroBonus : System.Web.UI.Page
    {
            Classes.HeroBonus clsHeroBonus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != "-1") clsHeroBonus = Classes.AllData.HeroBonuses[int.Parse(Request.QueryString["ID"])];
            else
            {
                clsHeroBonus = new Classes.HeroBonus();
                btnFlag.Visible = false;
            }


            if (IsPostBack == false)
            {

                if (clsHeroBonus.strName != "") Page.Title = clsHeroBonus.strName;
                else Page.Title = "New Hero Bonus";
                txtName.Text = clsHeroBonus.strName;
                txtDescription.Text = clsHeroBonus.strDescription;
                txtNotes.Text = clsHeroBonus.strNotes;
                txtEffects.Text = clsHeroBonus.strEffects;
                txtGameID.Text = clsHeroBonus.strGameID;
                hlScreenshot.NavigateUrl = clsHeroBonus.strScreenshotLocation;
                txtScreenshot.Text = clsHeroBonus.strScreenshotLocation;
                if (clsHeroBonus.strScreenshotLocation == "")
                {
                    hlScreenshot.Visible = false;
                }
                else if (clsHeroBonus.strScreenshotLocation.ToLower().Contains(".jpg") ||
                        clsHeroBonus.strScreenshotLocation.ToLower().Contains(".png") ||
                        clsHeroBonus.strScreenshotLocation.ToLower().Contains(".gif") ||
                        clsHeroBonus.strScreenshotLocation.ToLower().Contains(".bmp"))
                {
                    hlScreenshot.NavigateUrl = "ViewScreenshot.aspx?Page=ModifyHeroBonus&ID=" + clsHeroBonus.intID + "&Target=" + clsHeroBonus.strScreenshotLocation;
                }
            }
            if (Session["Submitter"] == null)
            {
                btnSave.Visible = false;
                btnFlag.Visible = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intHeroBonusID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strEffects", txtEffects.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strNotes", txtNotes.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strGameID", txtGameID.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@ScreenshotLocation", txtScreenshot.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertHeroBonus", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("HeroBonuses.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HeroBonuses.aspx");
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsHeroBonus.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsHeroBonus)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("HeroBonuses.aspx");
        }
    }
}