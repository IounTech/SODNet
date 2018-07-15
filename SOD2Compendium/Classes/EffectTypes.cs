using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class EffectType : BaseClass
    {
        public enum DataType
        {
            Boolean = 1,
            String = 2,
            Integer = 3,
            Percent = 4
        }
        public int intID;
        public string strName;
        public string strShortName;
        public string strDescription;
        public DataType enuType;

        public static Dictionary<int,EffectType> GetAllEffectTypes()
        {
            Dictionary<int, EffectType> lclsEffectType = new Dictionary<int, EffectType>();
            DataTable dtEffectType = MDatabaseUtilities.CreateDataTable("Select * from TEffectTypes Order By strName", Hidden.ExternalConnection);
            foreach (DataRow drRow in dtEffectType.Rows)
            {
                EffectType clsNewEffectType = new EffectType();
                clsNewEffectType.intID = (int)drRow["intEffectTypeID"];
                clsNewEffectType.strName = (string)drRow["strName"];
                clsNewEffectType.strDescription = (string)drRow["strDescription"];
                clsNewEffectType.strShortName = (string)drRow["strShortName"];
                clsNewEffectType.enuType = (DataType)drRow["intDataTypeID"];
                lclsEffectType.Add(clsNewEffectType.intID, clsNewEffectType);
            }
            return lclsEffectType;
        }

        public override string ToString()
        {
            return strName;
        }
    }
}