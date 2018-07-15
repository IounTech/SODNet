using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;

namespace SOD2Compendium.Classes
{
    public class AmmoType
    {
        public int intID;
        public string strName;
        public static Dictionary<int, AmmoType> GetAllAmmoTypes()
        {
            Dictionary<int, AmmoType> dicAmmoTypes = new Dictionary<int, AmmoType>();
            DataTable dtAmmoTypes = MDatabaseUtilities.CreateDataTable("Select * from TAmmoTypes", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtAmmoTypes.Rows)
            {
                AmmoType clsNewAmmoType = new AmmoType
                {
                    intID = (int)drRow["intAmmoTypeID"],
                    strName = (string)drRow["strName"]
                };
                dicAmmoTypes.Add(clsNewAmmoType.intID, clsNewAmmoType);
            }
            return dicAmmoTypes;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}