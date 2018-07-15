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
    public partial class ModifyTraitEffects : System.Web.UI.Page
    {
        Classes.Trait clsTrait; 
        Classes.TraitEffect clsTraitEffect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                clsTrait = Classes.AllData.Traits[int.Parse(Request.QueryString["TID"])];



                if (Request.QueryString["EID"] != "-1") clsTraitEffect = clsTrait.Effects[int.Parse(Request.QueryString["EID"])];
                else
                {
                    clsTraitEffect = new Classes.TraitEffect();
                    btnFlag.Visible = false;
                };

            cmbEffectType.DataSource = Classes.AllData.EffectTypes;
            cmbEffectType.DataValueField = "Key";
            cmbEffectType.DataTextField = "Value";
            cmbEffectType.DataBind();
            if(clsTraitEffect.clsType != null)
            {
                cmbEffectType.SelectedValue = clsTraitEffect.clsType.intID.ToString();

            }

            txtValue.Text = clsTraitEffect.strValue;
            chkIsGlobal.Checked = clsTraitEffect.blnIsGlobal;
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
            lclsParameters.Add(new CStoredProcedureParameter("@intTraitEffectID", int.Parse(Request.QueryString["EID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@intEffectTypeID", int.Parse(cmbEffectType.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intTraitID", int.Parse(Request.QueryString["TID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@blnIsGlobal", chkIsGlobal.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@strValue", txtValue.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertTraitEffect", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyTraits.aspx?ID=" + Request.QueryString["TID"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyTraits.aspx?ID=" + Request.QueryString["TID"]);
        }
        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsTraitEffect.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsTrait)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyTraits.aspx?ID=" + Request.QueryString["TID"]);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intTraitEffectID", int.Parse(Request.QueryString["EID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteTraitEffect", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("ModifyTraits.aspx?ID=" + Request.QueryString["TID"]);
        }
    }
}