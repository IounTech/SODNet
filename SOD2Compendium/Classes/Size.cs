using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Size
    {
        public int intID;
        public string strName;
        public static Dictionary<int, Size> GetAllSizes()
        {
            Dictionary<int, Size> dicSizes = new Dictionary<int, Size>();
            DataTable dtSizes = MDatabaseUtilities.CreateDataTable("Select * from TSizes ", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtSizes.Rows)
            {
                Size clsNewSize = new Size
                {
                    intID = (int)drRow["intSizeID"],
                    strName = (string)drRow["strName"],
                };
                dicSizes.Add(clsNewSize.intID, clsNewSize);

            }

            return dicSizes;
        }
        public override string ToString()
        {
            return strName;
        }
    }
}