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
    public partial class ModifyFacility : System.Web.UI.Page
    {
        Classes.Facility clsFacility;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                if (Request.QueryString["ID"] != "-1") clsFacility = Classes.AllData.Facilities[int.Parse(Request.QueryString["ID"])];
                else
                {
                    clsFacility = new Classes.Facility();
                    btnFlag.Visible = false;
                    btnDelete.Visible = false;

                }
                if (clsFacility.strName != "") Page.Title = clsFacility.strName;
                else Page.Title = "New Facility";
                txtName.Text = clsFacility.strName;
                txtDescription.Text = clsFacility.strDescription;
                chkCanBePlacedIndoors.Checked = clsFacility.blnCanBePlacedIndoors;
                chkCanBePlacedOutdoors.Checked = clsFacility.blnCanBePlacedOutdoors;

                cmbSize.DataSource = Classes.AllData.Sizes;
                cmbSize.DataValueField = "Key";
                cmbSize.DataTextField = "Value";
                if (clsFacility.clsSize != null) cmbSize.SelectedValue = clsFacility.clsSize.intID.ToString();
                cmbSize.DataBind();

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
            lclsParameters.Add(new CStoredProcedureParameter("@intFacilityID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@blnCanBePlacedOutdoors", chkCanBePlacedOutdoors.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnCanBePlacedIndoors", chkCanBePlacedIndoors.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@intSizeID", Numerics.Val(cmbSize.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertFacility", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Facilities.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facilities.aspx");
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsFacility.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsFacility)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("Facilities.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFacilityID", int.Parse(Request.QueryString["ID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteFacility", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Facilities.aspx");

        }
    }
}