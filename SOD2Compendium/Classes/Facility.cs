using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Facility
    {
        public int intID;
        public string strName;
        public string strDescription;
        public bool blnCanBePlacedOutdoors;
        public bool blnCanBePlacedIndoors;
        public Size clsSize;
        public int intStatusID;
        public int intSubmitterID;

        public static Dictionary<int, Facility> GetAllFacilities()
        {
            Dictionary<int, Facility> dicFacilities = new Dictionary<int, Facility>();
            DataTable dtFacilities = MDatabaseUtilities.CreateDataTable("Select * from TFacilities where intStatusID <> 4", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtFacilities.Rows)
            {
                Facility clsNewFacility = new Facility
                {
                    intID = (int)drRow["intFacilityID"],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    blnCanBePlacedIndoors = (bool)drRow["blnCanBePlacedIndoors"],
                    blnCanBePlacedOutdoors = (bool)drRow["blnCanBePlacedOutdoors"],
                    intStatusID = (int)drRow["intStatusID"],
                    intSubmitterID = (int)drRow["intSubmitterID"],
                    clsSize = AllData.Sizes[(int)drRow["intSizeID"]]
                };
                dicFacilities.Add(clsNewFacility.intID, clsNewFacility);

            }
            return dicFacilities;
        }
        public override string ToString()
        {
            return strName;
        }

    }
}