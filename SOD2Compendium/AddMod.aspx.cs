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
    public partial class AddMod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@strName", txtName.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strDescription", txtDescription.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@strScreenshotLocation", txtScreenshot.Text));
            lclsParameters.Add(new CStoredProcedureParameter("@intSubmitterID", ((Classes.Submitter)Session["Submitter"]).intID));
            int intModID = MDatabaseUtilities.ExecuteStoredProcedure("uspAddMod", lclsParameters.ToArray());

            if(intModID > 0)
            {
                foreach(HttpPostedFile hpfFile in fuModFiles.PostedFiles)
                {
#if DEBUG
                    string strFileLocation = @"C:\Dev\ModFiles\" + txtName.Text + @"\" + hpfFile.FileName;
#else
                     string strFileLocation = @"C:\inetpub\wwwroot\SOD\ModFiles\" + txtName.Text + @"\"+ hpfFile.FileName;
#endif
                  
                    FileInfo fiFile = new FileInfo(strFileLocation);
                    fiFile.Directory.Create();
                    hpfFile.SaveAs(strFileLocation);

                    lclsParameters.Clear();
                    lclsParameters.Add(new CStoredProcedureParameter("@intModID", intModID));
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
    }
}