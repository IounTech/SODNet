using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;

namespace SOD2Compendium.Classes
{
    public class Trait : BaseClass
    {
        public int intID;
        public string strName = "";
        public string strDescription = "";
        public string strNotes = "";
        public string strScreenshotLocation = "";
        public HeroBonus clsHeroBonus;
        public int intSubmitterID;
        public Dictionary<int,
            TraitEffect> Effects = new Dictionary<int, TraitEffect>();


        public static Dictionary<int,Trait> GetAllTraits()
        {
            Dictionary<int,Trait> lclsTraits = new Dictionary<int, Trait>();
            DataTable dtTraits = MDatabaseUtilities.CreateDataTable("Select * from TTraits where intStatusID <> 4 order by strName",Hidden.ExternalConnection);
            foreach(DataRow drRow in dtTraits.Rows)
            {
                Trait clsNewTrait = new Trait
                {
                    intID = (int)drRow["intTraitID"],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    strNotes = (string)drRow["strNotes"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    clsHeroBonus = AllData.HeroBonuses[(int)drRow["intHeroBonusID"]],
                    intSubmitterID = (int)drRow["intSubmitterID"]
                };
                lclsTraits.Add(clsNewTrait.intID, clsNewTrait);
            }

            

            return lclsTraits;
        }
    }
}