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
    public partial class ModifyItems : System.Web.UI.Page
    {
        Classes.Item clsItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsItem == null)
            {
                if (Request.QueryString["ID"] != "-1") clsItem = Classes.AllData.Items[int.Parse(Request.QueryString["ID"])];
                else
                {
                    clsItem = new Classes.Item();
                    btnFlag.Visible = false;
                }
            }

            if (IsPostBack == false)
            {


                txtName.Text = clsItem.strName;
                txtDescription.Text = clsItem.strDescription;
                txtNotes.Text = clsItem.strNotes;
                txtBuyPrice.Text = clsItem.intInfluenceBuyValue.ToString();
                txtSellPrice.Text = clsItem.intInfluenceSellValue.ToString();
                txtType.Text = clsItem.strType;
                txtMaxInventoryStackSize.Text = clsItem.intMaxInventoryStackSize.ToString();
                txtMaxLockerStackSize.Text = clsItem.intMaxLockerStackSize.ToString();
                txtWeight.Text = clsItem.decWeight.ToString();
                
                    







                hlScreenshot.NavigateUrl = clsItem.strScreenshotLocation;
                txtScreenshot.Text = clsItem.strScreenshotLocation;
                try
                {


                    if (clsItem.strScreenshotLocation == "")
                    {
                        hlScreenshot.Visible = false;
                    }
                    else if (clsItem.strScreenshotLocation != null && clsItem.strScreenshotLocation.ToLower().Contains(".jpg") ||
                            clsItem.strScreenshotLocation.ToLower().Contains(".png") ||
                            clsItem.strScreenshotLocation.ToLower().Contains(".gif") ||
                            clsItem.strScreenshotLocation.ToLower().Contains(".bmp"))
                    {
                        hlScreenshot.NavigateUrl = "ViewScreenshot.aspx?Page=ModifyItems&ID=" + clsItem.intID + "&Target=" + clsItem.strScreenshotLocation;
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
                //btnSave.Visible = false;
                btnFlag.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();

            //lclsParameters.Add(new CStoredProcedureParameter("@intItemID", int.Parse(Request.QueryString["ID"])));
            //lclsParameters.Add(new CStoredProcedureParameter("@intItemTypeID", Numerics.Val(cmbItemType.SelectedValue)));
            //lclsParameters.Add(new CStoredProcedureParameter("@intAmmoTypeID", Numerics.Val(cmbAmmoType.SelectedValue)));
            //lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strNotes", txtNotes.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strScreenshotLocation", txtScreenshot.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strVisual", txtVisual.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strAudio", txtAudio.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strMagMod", txtMagMod.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strSightMod", txtSightMod.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strGameID", txtGameID.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@strDefaultMod", txtDefaultMod.Text));
            //lclsParameters.Add(new CStoredProcedureParameter("@intDurability", Numerics.Val(txtDurability.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@intCapacity", Numerics.Val(txtCapacity.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@intBuyPrice", Numerics.Val(txtBuyPrice.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@intSellPrice", Numerics.Val(txtSellPrice.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@intSalvage", Numerics.Val(txtSalvageValue.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@decWeight", Numerics.Val(txtWeight.Text)));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireSingle", chkSingle.Checked));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireBurst", chkBurst.Checked));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnCanFireAuto", chkAuto.Checked));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnAcceptsAttachments", chkAcceptsAttachments.Checked));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnOneIsTheChamber", chkOneInTheChamber.Checked));
            //lclsParameters.Add(new CStoredProcedureParameter("@blnHasSight", chkHasSight.Checked));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpsertItem", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Items.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Items.aspx");
        }

        protected void btnFlag_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFlagSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", clsItem.intSubmitterID));
            lclsParameters.Add(new CStoredProcedureParameter("@strItemData", UExtensionLibrary.Serialization.Serialization.Serialize(clsItem)));
            MDatabaseUtilities.ExecuteStoredProcedure("uspAddFlagRecord", lclsParameters.ToArray());
            //Classes.AllData.IsDirty = true;
            Response.Redirect("Items.aspx");
        }
    }
}