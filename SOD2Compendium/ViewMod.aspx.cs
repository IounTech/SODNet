using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class ViewMod : System.Web.UI.Page
    {
        Classes.Mod clsMod;
        protected void Page_Init(object sender, EventArgs e)
        {
            clsMod = Classes.AllData.Mods[int.Parse(Request.QueryString["ID"])];
            if (Session["Submitter"] != null && ((Classes.Submitter)Session["Submitter"]).intID == clsMod.intSubmitterID)
            {
                Response.Redirect("ModifyMod.aspx?ID=" + clsMod.intID);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            clsMod = Classes.AllData.Mods[int.Parse(Request.QueryString["ID"])];
            lblName.InnerText = clsMod.strName;
            lblDescription.InnerText = clsMod.strDescription;

            rptFiles.DataSource = clsMod.lclsModFiles.Values;
            rptFiles.DataBind();
        }

        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Classes.ModFile clsModFile = clsMod.lclsModFiles[int.Parse(e.CommandArgument.ToString())];
            string header = "attachment; filename=" + clsModFile.strName;
            Response.Clear();
            FileInfo fiFile = new FileInfo(clsModFile.strLocation);
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Length", fiFile.Length.ToString());
            Response.AppendHeader("Content-Disposition", header);
            Response.WriteFile(clsModFile.strLocation);
            Response.End();
        }
    }
}