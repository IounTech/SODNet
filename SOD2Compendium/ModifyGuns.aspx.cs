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
    public partial class ModifyGuns : System.Web.UI.Page
    {
        Classes.Gun clsGun;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(clsGun == null)
            {
                if (Request.QueryString["ID"] != "-1") clsGun = Classes.AllData.Guns[int.Parse(Request.QueryString["ID"])];
                else
                {
                    clsGun = new Classes.Gun();
                    btnFlag.Visible = false;
                }
            }
           
            if (IsPostBack == false)
            {

                if (clsGun.strName != "") Page.Title = clsGun.strName;
                else  Page.Title = "New Gun";
                lblMainHeader.InnerText = clsGun.strName;
                txtName.Text = clsGun.strName;
                txtDescription.Text = clsGun.strDescription;
                txtNotes.Text = clsGun.strNotes;
                txtVisual.Text = clsGun.strVisual;
                txtAudio.Text = clsGun.strAudio;
                txtMagMod.Text = clsGun.strMagMod;
                txtSightMod.Text = clsGun.strSightMod;
                txtDefaultMod.Text = clsGun.strDefaultMod;
                txtGameID.Text = clsGun.strGameID;
                txtDurability.Text = clsGun.intDurabilityInRounds.ToString();
                txtCapacity.Text = clsGun.intCapacity.ToString();
                txtWeight.Text = clsGun.decWeight.ToString();
                txtSellPrice.Text = clsGun.intSellPrice.ToString();
                txtBuyPrice.Text = clsGun.intBuyPrice.ToString();
                txtSalvageValue.Text = clsGun.intSalvage.ToString();
                chkAcceptsAttachments.Checked = clsGun.blnAcceptsAttachments;
                chkAuto.Checked = clsGun.blnCanFireAuto;
                chkBurst.Checked = clsGun.blnCanFireBurst;
                chkSingle.Checked = clsGun.blnCanFireSingle;
                chkHasSight.Checked = clsGun.blnHasSight;
                chkOneInTheChamber.Checked = clsGun.blnOneInTheChamber;
                
                cmbAmmoType.DataSource = Classes.AllData.AmmoTypes;
                cmbAmmoType.DataValueField = "Key";
                cmbAmmoType.DataTextField = "Value";
                cmbAmmoType.DataBind();
                if (clsGun.clsAmmoType != null)
                {
                    cmbAmmoType.SelectedValue = clsGun.clsAmmoType.intID.ToString();
                }

                cmbGunType.DataSource = Classes.AllData.GunTypes;
                cmbGunType.DataValueField = "Key";
                cmbGunType.DataTextField = "Value";
                cmbGunType.DataBind();
                if (clsGun.clsGunType != null)
                {
                    cmbGunType.SelectedValue = clsGun.clsGunType.intID.ToString();
                }








                hlScreenshot.NavigateUrl = clsGun.strScreenshotLocation;
                txtScreenshot.Text = clsGun.strScreenshotLocation;
                try
                {

                
                if (clsGun.strScreenshotLocation == "")
                {
                    hlScreenshot.Visible = false;
                }
                else if (clsGun.strScreenshotLocation != null && clsGun.strScreenshotLocation.ToLower().Contains(".jpg") ||
                        clsGun.strScreenshotLocation.ToLower().Contains(".png") ||
                        clsGun.strScreenshotLocation.ToLower().Contains(".gif") ||
                        clsGun.strScreenshotLocation.ToLower().Contains(".bmp"))
                {
                    hlScreenshot.NavigateUrl = "ViewScreenshot.aspx?Page=ModifyGuns&ID=" + clsGun.intID + "&Target=" + clsGun.strScreenshotLocation;
                }
                else
                {
                    hlScreenshot.Visible = false;
                }
                }
                catch
                {
                    hlScreenshot.Visible = false;
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

            lclsParameters.Add(new CStoredProcedureParameter("@intGunID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@intGunTypeID", Numerics.Val(cmbGunType.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@intAmmoTypeID", Numerics.Val(cmbAmmoType.SelectedValue)));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strNotes", txtNotes.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strScreenshotLocation", txtScreenshot.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strVisual", txtVisual.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strAudio", txtAudio.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strMagMod", txtMagMod.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strSightMod", txtSightMod.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strGameID", txtGameID.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDefaultMod", txtDefaultMod.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intDurability", Numerics.Val(txtDurability.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@intCapacity", Numerics.Val(txtCapacity.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@intBuyPrice", Numerics.Val(txtBuyPrice.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@intSellPrice", Numerics.Val(txtSellPrice.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@intSalvage", Numerics.Val(txtSalvageValue.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@decWeight", Numerics.Val(txtWeight.Text)));
            lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireSingle", chkSingle.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireBurst", chkBurst.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireAuto", chkAuto.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnAcceptsAttachments", chkAcceptsAttachments.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnOneIsTheChamber", chkOneInTheChamber.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@blnHasSight", chkHasSight.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertGun", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Guns.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guns.aspx");
        }

        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsGun.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsGun)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("Guns.aspx");
        }
    }
}