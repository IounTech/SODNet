using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class MeleeType
    {
        public int intID;
        public string strName;

        public static Dictionary<int, MeleeType> GetAllMeleeTypes()
        {
            Dictionary<int, MeleeType> dicMeleeTypes = new Dictionary<int, MeleeType>();
            DataTable dtMeleeTypes = MDatabaseUtilities.CreateDataTable("Select * from TMeleeTypes ", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtMeleeTypes.Rows)
            {
                MeleeType clsNewMeleeType = new MeleeType
                {
                    intID = (int)drRow["intMeleeTypeID"],
                    strName = (string)drRow["strName"]
                };
                dicMeleeTypes.Add(clsNewMeleeType.intID, clsNewMeleeType);

            }

            return dicMeleeTypes;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}