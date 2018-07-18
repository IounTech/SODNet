using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Mod
    {
        public int intID;
        public string strName;
        public string strDescription;
        public string strScreenshotLocation;
        public int intScore;
        
        public int intStatusID;
        public int intSubmitterID;
        public Dictionary<int, ModFile> lclsModFiles = new Dictionary<int, ModFile>();


        public static Dictionary<int, Mod> GetAllMods()
        {
            Dictionary<int, Mod> lclsMods = new Dictionary<int, Mod>();
            DataTable dtMods = MDatabaseUtilities.CreateDataTable("Select * from TMods where intStatusID <> 4 order by intScore desc", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtMods.Rows)
            {
                Mod clsNewMod = new Mod
                {
                    intID = (int)drRow["intModID"],
                    strName = (string)drRow["strName"],
                    strDescription = ((string)drRow["strDescription"]),
                    intScore = (int)drRow["intScore"],
                    intStatusID = (int)drRow["intStatusID"],
                    intSubmitterID = (int)drRow["intSubmitterID"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"]
                };
                lclsMods.Add(clsNewMod.intID, clsNewMod);
            }



            return lclsMods;
        }

    }
}