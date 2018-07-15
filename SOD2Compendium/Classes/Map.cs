using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Map
    {
        public int intID;
        public string strName;
        public static Dictionary<int, Map> GetAllMaps()
        {
            Dictionary<int, Map> dicMaps = new Dictionary<int, Map>();
            DataTable dtMaps = MDatabaseUtilities.CreateDataTable("Select * from TMaps ", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtMaps.Rows)
            {
                Map clsNewMap = new Map
                {
                    intID = (int)drRow["intMapID"],
                    strName = (string)drRow["strName"]
                };
                dicMaps.Add(clsNewMap.intID, clsNewMap);

            }

            return dicMaps;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}
