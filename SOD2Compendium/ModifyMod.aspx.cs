using MainUtilitiesLibrary;
using SOD2Compendium.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class ModifyMod : System.Web.UI.Page
    {
        Classes.Mod clsMod;
        protected void Page_Init(object sender, EventArgs e)
        {

            clsMod = Classes.AllData.Mods[int.Parse(Request.QueryString["ID"])];
            if (Session["Submitter"] == null || ((Classes.Submitter)Session["Submitter"]).intID != clsMod.intSubmitterID)
            {
                Response.Redirect("ViewMod.aspx?ID=" + clsMod.intID);
            }
        }
            protected void Page_Load(object sender, EventArgs e)
        {
            clsMod = Classes.AllData.Mods[int.Parse(Request.QueryString["ID"])];
            if (IsPostBack == false)
            {
                txtName.Text = clsMod.strName;
                txtDescription.Text = clsMod.strDescription;

                rptFiles.DataSource = clsMod.lclsModFiles.Values;
                rptFiles.DataBind();
            }
            
        }

       
        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Classes.ModFile clsModFile = clsMod.lclsModFiles[int.Parse(e.CommandArgument.ToString())];
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intModFileID", int.Parse(e.CommandArgument.ToString())));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteModFile", lclsParameters.ToArray());
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intModID", int.Parse(Request.QueryString["ID"])));
            MDatabaseUtilities.ExecuteStoredProcedure("uspDeleteMod", lclsParameters.ToArray());
            Classes.AllData.IsDirty = true;
            Response.Redirect("Mods.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intModID", int.Parse(Request.QueryString["ID"])));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strScreenshotLocation", txtScreenshot.Text));
            MDatabaseUtilities.ExecuteStoredProcedure("uspUpdateMod", lclsParameters.ToArray());

            foreach (HttpPostedFile hpfFile in fuModFiles.PostedFiles)
            {
                if (hpfFile.FileName != "")
                {


                    string strFileLocation = @"C:\inetpub\wwwroot\SOD\ModFiles\" + txtName.Text + @"\" + hpfFile.FileName;
                    FileInfo fiFile = new FileInfo(strFileLocation);
                    fiFile.Directory.Create();
                    hpfFile.SaveAs(strFileLocation);

                    lclsParameters.Clear();
                    lclsParameters.Add(new CStoredProcedureParameter("@intModID", int.Parse(Request.QueryString["ID"])));
                    lclsParameters.Add(new CStoredProcedureParameter("@strName", hpfFile.FileName));
                    lclsParameters.Add(new CStoredProcedureParameter("@strVersion", "0"));
                    lclsParameters.Add(new CStoredProcedureParameter("@strLocation", strFileLocation));
                    lclsParameters.Add(new CStoredProcedureParameter("@strDescription", ""));
                    lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
                    MDatabaseUtilities.ExecuteStoredProcedure("uspAddModFile", lclsParameters.ToArray());
                }
                
            }
            




            Classes.AllData.IsDirty = true;
            Response.Redirect("Mods.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mods.aspx");
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {

        }
    }
}