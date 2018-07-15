using MainUtilitiesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class Submitter
    {
        public int intID;
        public string strFBID;
        public string strName;
        public int intScore;
        public int intStatusID;

        public static Submitter GetSubmitterFromFBID(string strFBID,string strName)
        {
            Submitter clsReturn = new Submitter();

            MDatabaseUtilities.strCurrentConnectionString = Hidden.ExternalConnection;
            List<CStoredProcedureParameter> lclsParameters = new List<CStoredProcedureParameter>();
            lclsParameters.Add(new CStoredProcedureParameter("@intFBID", strFBID));
            lclsParameters.Add(new CStoredProcedureParameter("@strName", strName));
            int intSubmitterID = MDatabaseUtilities.ExecuteStoredProcedure("uspGetSubmitterByFBID", lclsParameters.ToArray());

            DataTable dt = MDatabaseUtilities.CreateDataTable("SELECT * FROM TSubmitters WHERE intSubmitterID = " + intSubmitterID);
            clsReturn.intID = intSubmitterID;
            clsReturn.strFBID = strFBID;
            clsReturn.strName = (string)dt.Rows[0]["strName"];
            clsReturn.intScore = (int)dt.Rows[0]["intScore"];
            clsReturn.intStatusID = (int)dt.Rows[0]["intStatusID"];

            return clsReturn;
        }
    }
}