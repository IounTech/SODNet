using MainUtilitiesLibrary;
using SOD2Compendium.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UExtensionLibrary.Numerics;

namespace SOD2Compendium
{
    public partial class ModifyBase : System.Web.UI.Page
    {
        Classes.Base clsBase;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (Request.QueryString["ID"] != "-1") clsBase = Classes.AllData.Bases[int.Parse(Request.QueryString["ID"])];
                else
                {
                    clsBase = new Classes.Base();
                    btnFlag.Visible = false;
                    btnDelete.Visible = false;

                }

                txtName.Text = clsBase.strName;
                txtInfluenceCost.Text = clsBase.intInfluenceCost.ToString();
                txtLargeEmptyCount.Text = clsBase.intLargeEmptyCount.ToString();
                cmbMap.DataSource = Classes.AllData.Maps;
                cmbMap.DataValueField = "Key";
                cmbMap.DataTextField = "Value";
                if(clsBase.clsMap != null) cmbMap.SelectedValue = clsBase.clsMap.intID.ToString();
                cmbSize.DataSource = Classes.AllData.Sizes;
                cmbSize.DataValueField = "Key";
                cmbSize.DataTextField = "Value";
                if(clsBase.clsSize != null) cmbSize.SelectedValue = clsBase.clsSize.intID.ToString();


                txtParkingCount.Text = clsBase.intParkingCount.ToString();
                txtSlotsScreenshotLocation.Text = clsBase.strSlotsScreenshotLocation;
                txtSmallExternalEmptyCount.Text = clsBase.intSmallExternalEmptyCount.ToString();
                txtSmallInternalEmptyCount.Text = clsBase.intSmallInternalEmptyCount.ToString();
                txtSurvivorsRequired.Text = clsBase.intSurvivorsRequired.ToString();
                txtLocationScreenshotLocation.Text = clsBase.strLocationScreenshotLocation;
                txtSlotsScreenshotLocation.Text = clsBase.strSlotsScreenshotLocation;

                cmbSize.DataBind();
                cmbMap.DataBind();
                rptPrebuilts.DataSource = clsBase.lclsPrebuiltFacilities.Values;
                rptPrebuilts.DataBind();

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
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
           lclsParameters.Add(new CStoredProcedureParameter("@intBasesID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intMapID", Numerics.Val(cmbMap.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intSmallExternalEmptyCount", txtSmallExternalEmptyCount.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSmallInternalEmptyCount", txtSmallInternalEmptyCount.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intParkingCount", txtParkingCount.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSizeID", Numerics.Val(cmbSize.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intInfluenceCost", txtInfluenceCost.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSurvivorsRequired", txtSurvivorsRequired.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intLargeEmptyCount", txtLargeEmptyCount.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strLocationScreenshotLocation", txtLocationScreenshotLocation.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strSlotsScreenshotLocation", txtSlotsScreenshotLocation.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intStatusID", 3));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertBase", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Bases.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bases.aspx");
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsBase.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsBase)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("Bases.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intBaseID", int.Parse(Request.QueryString["ID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteBase", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Bases.aspx");

        }
    }
}