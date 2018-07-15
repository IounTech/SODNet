using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;

namespace SOD2Compendium.Classes
{
    public class Gun
    {
        public int intID;
        public GunType clsGunType;
        public AmmoType clsAmmoType;
        public string strName;
        public string strDescription;
        public string strNotes;
        public string strAudio;
        public string strVisual;
        public string strMagMod;
        public string strSightMod;
        public string strGameID;
        public string strDefaultMod;
        public int intDurabilityInRounds;
        public int intCapacity;
        public decimal decWeight;
        public bool blnCanFireSingle;
        public bool blnCanFireBurst;
        public bool blnCanFireAuto;
        public bool blnAcceptsAttachments;
        public bool blnHasSight;
        public bool blnOneInTheChamber;

        public int intBuyPrice;
        public int intSellPrice;
        public int intSalvage;
        public string strScreenshotLocation;
        public bool blnRequiresModding;
        public int intSubmitterID;

        public static Dictionary<int, Gun> GetAllGuns()
        {
            Dictionary<int, Gun> dicGuns = new Dictionary<int, Gun>();
            DataTable dtGuns = MDatabaseUtilities.CreateDataTable("Select * from TGuns", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtGuns.Rows)
            {
                Gun clsNewGun = new Gun
                {
                    intID = (int)drRow["intGunID"],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    strNotes = (string)drRow["strNotes"],
                    strVisual = (string)drRow["strVisual"],
                    strAudio = (string)drRow["strAudio"],
                    strMagMod = (string)drRow["strMagMod"],
                    strSightMod = (string)drRow["strSightMod"],
                    strDefaultMod = (string)drRow["strDefaultMod"],
                    strGameID = (string)drRow["strGameID"],
                    clsGunType = AllData.GunTypes[(int)drRow["intGunTypeID"]],
                    clsAmmoType = AllData.AmmoTypes[(int)drRow["intAmmoTypeID"]],
                    decWeight = (decimal)drRow["decWeight"],
                    intCapacity = (int)drRow["intCapacity"],
                    intDurabilityInRounds = (int)drRow["intDurabilityInRounds"],
                    blnCanFireSingle = (bool)drRow["blnCanFireSingle"],
                    blnCanFireBurst = (bool)drRow["blnCanFireBurst"],
                    blnCanFireAuto = (bool)drRow["blnCanFireAuto"],
                    blnAcceptsAttachments = (bool)drRow["blnAcceptsAttachments"],
                    blnOneInTheChamber = (bool)drRow["blnOneInTheChamber"],
                    blnHasSight = (bool)drRow["blnHasSight"],
                    intBuyPrice = (int)drRow["intBuyPrice"],
                    intSellPrice = (int)drRow["intSellPrice"],
                    intSalvage = (int)drRow["intSalvage"],
                    blnRequiresModding = (bool)drRow["blnRequiresModding"],
                    intSubmitterID = (int)drRow["intSubmitterID"]

                };
                dicGuns.Add(clsNewGun.intID, clsNewGun);
            }
            return dicGuns;
        }

    }
    
}