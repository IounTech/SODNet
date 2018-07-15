using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;
namespace SOD2Compendium.Classes
{
    public class TraitEffect : BaseClass
    {
        public int intTraitEffectID;
        public int intSubmitterID;
        public EffectType clsType;
        public string strValue;
        public bool blnIsGlobal;
        public string Text { get {
                string[] Values = strValue.Split(',');
                string strReturn = clsType.strDescription;
                for (int intIndex = 0; intIndex <= Values.Length - 1; intIndex += 1)
                {
                    strReturn = strReturn.Replace("{" + intIndex + "}", Values[intIndex]);

                }
                if (blnIsGlobal) strReturn += "(Everyone)";
                return strReturn;

            } }
        public static void AddAllTraitEffectsToTraits()
        {
 
            DataTable dtTraitEffects = MDatabaseUtilities.CreateDataTable("Select * from TTraitEffects WHERE intStatusID <> 4",Hidden.ExternalConnection);
            foreach (DataRow drRow in dtTraitEffects.Rows)
            {
                Trait clsTrait = AllData.Traits[(int)drRow["intTraitID"]];

                TraitEffect clsNewTraitEffect = new TraitEffect();
                clsNewTraitEffect.blnIsGlobal = (bool)drRow["blnIsGlobal"];
                clsNewTraitEffect.intTraitEffectID = (int)drRow["intTraitEffectID"];
                clsNewTraitEffect.intSubmitterID = (int)drRow["intSubmitterID"];
                clsNewTraitEffect.strValue = (string)drRow["strValue"];
                clsNewTraitEffect.clsType = AllData.EffectTypes[(int)drRow["intTraitEffectTypeID"]];
                clsTrait.Effects.Add(clsNewTraitEffect.intTraitEffectID, clsNewTraitEffect);
           
            }

        }


    }
}