using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class ModFile
    {
        public int intID;
        public int intModID;
        public string strVersion;
        public string strName;
        public string strLocation;
        public string strDescription;
        public int intStatusID;
        public int intSubmitterID;
        public string ProperLocation { get
            {
                return strLocation.Replace(@"C:\inetpub\wwwroot\SOD\", "");
            } }
        public static Dictionary<int, ModFile> GetAllModFiles()
        {
            Dictionary<int, ModFile> lclsModFiles = new Dictionary<int, ModFile>();
            DataTable dtModFiles = MDatabaseUtilities.CreateDataTable("Select * from TModFiles where intStatusID <> 4 order by strName", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtModFiles.Rows)
            {
                ModFile clsNewModFile = new ModFile
                {
                    intID = (int)drRow["intModFileID"],
                    intModID = (int)drRow["intModID"],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    strLocation = (string)drRow["strLocation"],
                    strVersion = (string)drRow["strVersion"],
                    intStatusID = (int)drRow["intStatusID"],
                    intSubmitterID = (int)drRow["intSubmitterID"]
                };
                lclsModFiles.Add(clsNewModFile.intID, clsNewModFile);
            }



            return lclsModFiles;
        }
    }
}