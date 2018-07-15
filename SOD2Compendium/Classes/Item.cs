using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MainUtilitiesLibrary;


namespace SOD2Compendium.Classes
{
    public class Item
    {
        public int intID;
        public string strName;
        public string strNotes;
        public string strType;
        public string strDescription;
        public int intMaxLockerStackSize;
        public int intMaxInventoryStackSize;
        public bool blnIsConsumable;
        public int intInfluenceBuyValue;
        public int intInfluenceSellValue;
        public decimal decWeight;
        public string strScreenshotLocation;
        public bool blnIsBaseResource;
        public int intStatusID;
        public int intSubmitterID;

        public static Dictionary<int, Item> GetAllItems()
        {
            Dictionary<int, Item> lclsItems = new Dictionary<int, Item>();
            DataTable dtItems = MDatabaseUtilities.CreateDataTable("Select * from TItems", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtItems.Rows)
            {
                Item clsNewItem = new Item
                {
                    intID = (int)drRow["intItemID"],
                    strName = (string)drRow["strName"],
                    strDescription = (string)drRow["strDescription"],
                    strNotes = (string)drRow["strNotes"],
                    strType = (string)drRow["strType"],
                    strScreenshotLocation = (string)drRow["strScreenshotLocation"],
                    intSubmitterID = (int)drRow["intSubmitterID"],
                    blnIsBaseResource = (bool)drRow["blnIsBaseResource"],
                    blnIsConsumable = (bool)drRow["blnIsConsumable"],
                    intInfluenceBuyValue = (int)drRow["intInfluenceBuyValue"],
                    intMaxLockerStackSize = (int)drRow["intMaxLockerStackSize"],
                    intInfluenceSellValue = (int)drRow["intInfluenceSellValue"],
                    decWeight = (decimal)drRow["decWeight"],
                    intMaxInventoryStackSize = (int)drRow["intMaxInventoryStackSize"],
                    intStatusID = (int)drRow["intStatusID"]
                };
                lclsItems.Add(clsNewItem.intID, clsNewItem);
            }



            return lclsItems;
        }

    }
}