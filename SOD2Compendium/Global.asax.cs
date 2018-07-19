using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SOD2Compendium.Classes;

namespace SOD2Compendium
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            OAuthManager.RegisterClient
            (
              "google",
              Hidden.GoogleClientID,
              Hidden.GoogleSecret
            );
        }
    }
}