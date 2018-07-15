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
    public partial class ModifyTraits : System.Web.UI.Page
    {
        Classes.Trait clsTrait;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                if (Request.QueryString["ID"] != "-1") clsTrait = Classes.AllData.Traits[int.Parse(Request.QueryString["ID"])];
                else
                {
                    clsTrait = new Classes.Trait();
                    btnFlag.Visible = false;
                    btnDelete.Visible = false;

                }
                if (clsTrait.strName != "") Page.Title = clsTrait.strName;
                else Page.Title = "New Trait";
                lblMainHeader.InnerText = clsTrait.strName;
                txtName.Text = clsTrait.strName;
                txtDescription.Text = clsTrait.strDescription;
                txtNotes.Text = clsTrait.strNotes;
                rptEffects.DataSource = clsTrait.Effects.Values;
                rptEffects.DataBind();
                hlScreenshot.NavigateUrl = clsTrait.strScreenshotLocation;
                txtScreenshot.Text = clsTrait.strScreenshotLocation;
                if(clsTrait.strScreenshotLocation == "")
                {
                    hlScreenshot.Visible = false;
                }
                else if(clsTrait.strScreenshotLocation.ToLower().Contains(".jpg") ||
                        clsTrait.strScreenshotLocation.ToLower().Contains(".png") ||
                        clsTrait.strScreenshotLocation.ToLower().Contains(".gif") ||
                        clsTrait.strScreenshotLocation.ToLower().Contains(".bmp"))
                {
                    hlScreenshot.NavigateUrl = "ViewScreenshot.aspx?Page=ModifyTraits&ID=" + clsTrait.intID + "&Target=" + clsTrait.strScreenshotLocation;
                }
            }
            if (Session["Submitter"] == null)
            {
                btnSave.Visible = false;
                btnFlag.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString =Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intTraitID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strNotes", txtNotes.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@ScreenshotLocation", txtScreenshot.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertTrait", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Traits.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Traits.aspx");
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsTrait.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsTrait)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("Traits.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intTraitID", int.Parse(Request.QueryString["ID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteTrait", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Traits.aspx");

        }
    }
}