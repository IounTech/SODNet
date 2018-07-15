using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Base
    {
        public int intID;
        public string strName;
        public Map clsMap;
        public int intSmallExternalEmptyCount;
        public int intSmallInternalEmptyCount;
        public int intParkingCount;
        public Size clsSize;
        public int intInfluenceCost;
        public int intSurvivorsRequired;
        public int intLargeEmptyCount;
        public string strLocationScreenshotLocation;
        public string strSlotsScreenshotLocation;
        public int intStatusID;
        public int intSubmitterID;
        public Dictionary<int, PrebuiltFacility> lclsPrebuiltFacilities = new Dictionary<int, PrebuiltFacility>();
        public int TotalSlots { get {
                int intReturn = 0;
                intReturn = intLargeEmptyCount + intSmallExternalEmptyCount + intSmallInternalEmptyCount + intParkingCount;
                intReturn += lclsPrebuiltFacilities.Count;
                return intReturn;
            } }

        public static Dictionary<int,Base> GetAllBases()
        {
            Dictionary<int, Base> dicBases = new Dictionary<int, Base>();
            DataTable dtBases = MDatabaseUtilities.CreateDataTable("Select * from TBases where intStatusID <> 4", Hidden.ExternalConnection);
            foreach(DataRow drRow in dtBases.Rows)
            {
                Base clsNewBase = new Base
                {
                    intID = (int)drRow["intBaseID"],
                    strName = (string)drRow["strName"],
                    clsMap = AllData.Maps[(int)drRow["intMapID"]],
                    intSmallExternalEmptyCount = (int)drRow["intSmallExternalEmptyCount"],
                    intSmallInternalEmptyCount = (int)drRow["intSmallInternalEmptyCount"],
                    intParkingCount = (int)drRow["intParkingCount"],
                    clsSize = AllData.Sizes[(int)drRow["intSizeID"]],
                    intInfluenceCost = (int)drRow["intInfluenceCost"],
                    intSurvivorsRequired = (int)drRow["intSurvivorsRequired"],
                    intLargeEmptyCount = (int)drRow["intLargeEmptyCount"],
                    strLocationScreenshotLocation = (string)drRow["strLocationScreenshotLocation"],
                    strSlotsScreenshotLocation = (string)drRow["strSlotsScreenshotLocation"],
                    intStatusID = (int)drRow["intStatusID"],
                    intSubmitterID = (int)drRow["intSubmitterID"]
                };
                dicBases.Add(clsNewBase.intID, clsNewBase);

            }
            return dicBases;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}