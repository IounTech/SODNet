using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;
namespace SOD2Compendium.Classes
{
    public static class AllData
    {
        public static bool IsDirty = true;
        public static Dictionary<int, EffectType> EffectTypes = null;
        public static Dictionary<int, Trait> Traits = null;
        public static Dictionary<int, Gun> Guns = null;
        public static Dictionary<int, AmmoType> AmmoTypes = null;
        public static Dictionary<int, GunType> GunTypes = null;
        public static Dictionary<int, HeroBonus> HeroBonuses = null;
        public static Dictionary<int, Item> Items = null;
        public static Dictionary<int, Base> Bases = null;
        public static Dictionary<int, Map> Maps = null;
        public static Dictionary<int, Size> Sizes = null;
        public static Dictionary<int, Facility> Facilities = null;
        public static Dictionary<int, PrebuiltFacility> PrebuiltFacilities = null;
        public static Dictionary<int, MeleeType> MeleeTypes = null;
        public static Dictionary<int, Melee> Melees = null;
        public static Dictionary<int, Mod> Mods = null;
        public static Dictionary<int, ModFile> ModFiles = null;

        public static void Update()
        {
            try {
                if (IsDirty)
                {
                    EffectTypes = EffectType.GetAllEffectTypes();
                    HeroBonuses = HeroBonus.GetAllHeroBonuses();
                    Traits = Trait.GetAllTraits();
                    TraitEffect.AddAllTraitEffectsToTraits();
                    AmmoTypes = AmmoType.GetAllAmmoTypes();
                    GunTypes = GunType.GetAllGunTypes();
                    Guns = Gun.GetAllGuns();
                    Items = Item.GetAllItems();
                    Maps = Map.GetAllMaps();
                    Sizes = Size.GetAllSizes();
                    Bases = Base.GetAllBases();
                    Facilities = Facility.GetAllFacilities();
                    MeleeTypes = MeleeType.GetAllMeleeTypes();
                    Melees = Melee.GetAllMelees();
                    PrebuiltFacilities = PrebuiltFacility.GetAllPrebuiltFacilities();
                    Mods = Mod.GetAllMods();
                    ModFiles = ModFile.GetAllModFiles();
                    AttachPrebuiltsToBases();
                    AttachFilesToMods();
                    IsDirty = false;
                }
           
            }
            catch(Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, ex.Message + '\n' + ex.StackTrace);
            }
        }

        public static void AttachPrebuiltsToBases()
        {
            foreach(KeyValuePair<int,PrebuiltFacility> Prebuilt in PrebuiltFacilities)
            {
                int intBaseID = Prebuilt.Value.intBaseID;
                Bases[intBaseID].lclsPrebuiltFacilities.Add(Prebuilt.Key,Prebuilt.Value);
            }
        }

        public static void AttachFilesToMods()
        {
            foreach (KeyValuePair<int, ModFile> ModFile in ModFiles)
            {
                int intModID = ModFile.Value.intModID;
                Mods[intModID].lclsModFiles.Add(ModFile.Key, ModFile.Value);
            }
        }

        public static int GetTraitIDByName(string strName)
        {
            foreach(int intTraitID in Traits.Keys)
            {
                if (Traits[intTraitID].strName == strName) return intTraitID;
            }

            return -1;
        }
    }
}