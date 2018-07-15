using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;

namespace SOD2Compendium.Classes
{
    public class PrebuiltFacility
    {
        public int intID;
        public int intBaseID;
        public Facility clsFacility;
        public string strName;
        public string strDescription;
        public int intEffectiveLevel;
        public bool blnIsDestroyable;
        public string strNotes;
        public string strScreenshotLocation;
        public int intStatusID;
        public int intSubmitterID;
        public static Dictionary<int, PrebuiltFacility> GetAllPrebuiltFacilities()
        {
            Dictionary<int, PrebuiltFacility> lclsPrebuiltFacilities = new Dictionary<int, PrebuiltFacility>();
            DataTable dtPrebuiltFacilities = MDatabaseUtilities.CreateDataTable("Select * from [TBaseFacilityPrebuilts] where intStatusID <> 4 order by strName", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtPrebuiltFacilities.Rows)
            {
                PrebuiltFacility clsNewPrebuiltFacility = new PrebuiltFacility
                {
                    intID = (int)drRow["intPrebuiltFacilityID"],
                    intBaseID = (int)drRow["intBaseID"],
                    clsFacility = AllData.Facilities[(int)drRow["intFacilityID"]],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    strNotes = (string)drRow["strNotes"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    intSubmitterID = (int)drRow["intSubmitterID"],
                    intStatusID = (int)drRow["intStatusID"],
                    intEffectiveLevel = (int)drRow["intEffectiveLevel"],
                    blnIsDestroyable = (bool)drRow["blnIsDestroyable"]
                    
                };
                lclsPrebuiltFacilities.Add(clsNewPrebuiltFacility.intID, clsNewPrebuiltFacility);
            }



            return lclsPrebuiltFacilities;
        }

        public override string ToString()
        {
            return strName;
        }
    }
}