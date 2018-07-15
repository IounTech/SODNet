using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Melee
    {
        public int intID;
        public string strName;
        public MeleeType clsMeleeType;
        public decimal decWeight;
        public string strScreenshotLocation;
        public int intStatusID;
        public int intSubmitterID;
        public static Dictionary<int, Melee> GetAllMelees()
        {
            Dictionary<int, Melee> dicMelees = new Dictionary<int, Melee>();
            DataTable dtMelees = MDatabaseUtilities.CreateDataTable("Select * from TMelees ", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtMelees.Rows)
            {
                Melee clsNewMelee = new Melee
                {
                    intID = (int)drRow["intMeleeID"],
                    strName = (string)drRow["strName"],
                    clsMeleeType = AllData.MeleeTypes[(int)drRow["intMeleeTypeID"]],
                    decWeight = (decimal)drRow["decWeight"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    intStatusID = (int)drRow["intStatusID"],
                    intSubmitterID = (int)drRow["intSubmitterID"]
                };
                dicMelees.Add(clsNewMelee.intID, clsNewMelee);

            }

            return dicMelees;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}