using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;

namespace SOD2Compendium.Classes
{
    public class HeroBonus
    {
        public int intID;
        public int intSubmitterID;
        public string strName = "";
        public string strDescription = "";
        public string strEffects = "";
        public string strNotes = "";
        public string strGameID = "";
        public string strScreenshotLocation = "";
        public List<Trait> lclsLinkedTraits = new List<Trait>();
        public static Dictionary<int,HeroBonus> GetAllHeroBonuses()
        {
            Dictionary<int, HeroBonus> lclsHeroBonuss = new Dictionary<int, HeroBonus>();
            DataTable dtHeroBonuss = MDatabaseUtilities.CreateDataTable("Select * from THeroBonuses", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtHeroBonuss.Rows)
            {
                HeroBonus clsNewHeroBonus = new HeroBonus
                {
                    intID = (int)drRow["intHeroBonusID"],
                    strName = (string)drRow["strName"],
                    strEffects = (string)drRow["strEffects"],
                    strDescription = (string)drRow["strDescription"],
                    strGameID = (string)drRow["strGameID"],
                    strNotes = (string)drRow["strNotes"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    intSubmitterID = (int)drRow["intSubmitterID"]
                };
                lclsHeroBonuss.Add(clsNewHeroBonus.intID, clsNewHeroBonus);
            }



            return lclsHeroBonuss;
        }
    }

   
}