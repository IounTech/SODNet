using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainUtilitiesLibrary;
using SOD2Compendium.Classes;
using UExtensionLibrary.Numerics;

namespace SOD2Compendium
{
    public partial class ModifyPrebuiltFacility : System.Web.UI.Page
    {
        Classes.PrebuiltFacility clsPrebuiltFacility;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                if (Request.QueryString["PID"] != "-1") clsPrebuiltFacility = Classes.AllData.PrebuiltFacilities[int.Parse(Request.QueryString["PID"])];
                else
                {
                    clsPrebuiltFacility = new Classes.PrebuiltFacility();
                    btnFlag.Visible = false;
                    btnDelete.Visible = false;

                }
                txtEffectiveLevel.Text = clsPrebuiltFacility.intEffectiveLevel.ToString();
                txtIsDestroyable.Checked = clsPrebuiltFacility.blnIsDestroyable;
                txtScreenshotLocation.Text = clsPrebuiltFacility.strScreenshotLocation;
                txtName.Text = clsPrebuiltFacility.strName;
                txtDescription.Text = clsPrebuiltFacility.strDescription;
                txtNotes.Text = clsPrebuiltFacility.strNotes;
                cmbFacility.DataSource = Classes.AllData.Facilities;
                cmbFacility.DataValueField = "Key";
                cmbFacility.DataTextField = "Value";
                cmbFacility.DataBind();
                cmbBase.DataSource = Classes.AllData.Bases;
                cmbBase.DataValueField = "Key";
                cmbBase.DataTextField = "Value";
                cmbBase.DataBind();

                if(clsPrebuiltFacility.clsFacility != null) cmbFacility.SelectedValue = clsPrebuiltFacility.clsFacility.intID.ToString();
                cmbBase.SelectedValue = Request.QueryString["BID"];

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
            lclsParameters.Add(new CStoredProcedureParameter("@intPrebuiltFacilityID", int.Parse(Request.QueryString["PID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@intBaseID", Numerics.Val(cmbBase.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intFacilityID", Numerics.Val(cmbFacility.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intEffectiveLevel", Numerics.Val(txtEffectiveLevel.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@blnIsDestroyable", txtIsDestroyable.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@strNotes", txtNotes.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strScreenshotLocation", txtScreenshotLocation.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertPrebuiltFacility", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyBase.aspx?ID=" + Request.QueryString["BID"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyBase.aspx?ID=" + Request.QueryString["BID"]);
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsPrebuiltFacility.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsPrebuiltFacility)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyBase.aspx?ID=" + Request.QueryString["BID"]);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intPrebuiltFacilityID", int.Parse(Request.QueryString["ID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeletePrebuiltFacility", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyBase.aspx?ID=" + Request.QueryString["BID"]);

        }
    }
}