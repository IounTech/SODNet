using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;
using System.Data;

namespace SOD2Compendium.Classes
{
    public class GunType
    {
        public int intID;
        public string strName;
        public static Dictionary<int, GunType> GetAllGunTypes()
        {
            Dictionary<int, GunType> dicGunTypes = new Dictionary<int, GunType>();
            DataTable dtGunTypes = MDatabaseUtilities.CreateDataTable("Select * from TGunTypes", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtGunTypes.Rows)
            {
                GunType clsNewGunType = new GunType
                {
                    intID = (int)drRow["intGunTypeID"],
                    strName = (string)drRow["strName"]
                };
                dicGunTypes.Add(clsNewGunType.intID, clsNewGunType);
            }
            return dicGunTypes;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}