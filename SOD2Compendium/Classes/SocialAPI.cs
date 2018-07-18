using Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SOD2Compendium.Classes
{
    public class SocialAPI
    {
        public FacebookClient FbClient;

        string appId = string.Empty;
        string appSecret = string.Empty;
        string redirectURL = string.Empty;

        public string AppId { get { return appId; } }
        public string AppSecret { get { return appSecret; } }
        public string RedirectURL { get { return redirectURL; } }

        public string AccessToken
        {
            get { return FbClient.AccessToken; }
            set { FbClient.AccessToken = value; }
        }

        public SocialAPI()
        {
            FbClient = new FacebookClient();
            appId = Hidden.appId;
            appSecret = Hidden.appSecret;
            redirectURL = Hidden.redirectURL;
        }
        public static string[] GetAccessTokenAndExpirationDays(string code, SocialAPI fbAPI)
        {
            string uriString = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&redirect_uri={2}&code={3}", fbAPI.AppId, fbAPI.AppSecret, fbAPI.RedirectURL, code);
            Uri targetUri = new Uri(uriString);
            HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            StreamReader sr = new StreamReader(httpReq.GetResponse().GetResponseStream());
            //{"access_token":"EAAeeWk0qTegBAKZCSZB7OvIHUCviaKFNDNmvhCfyOwRdWjbNSQDG5x2Jm5nqAjhmCfqxF1uAFud6Qgn5UYxLun8GxxEi2AAe46glxlZCDf2E2RxvdonI5MlD1Ek9gFZBxCFWqoXm4drPWR7wgOH8HBhFfLeBNKAZD","token_type":"bearer","expires_in":5135310}
            string query = sr.ReadToEnd().ToString();
            FBQuery clsQuery = UExtensionLibrary.Serialization.Serialization.Deserialize<FBQuery>(query);
            string accessToken = HttpUtility.ParseQueryString(query).Get("access_token");
            string expires = HttpUtility.ParseQueryString(query).Get("expires");

            TimeSpan ts = TimeSpan.FromSeconds(double.Parse(clsQuery.expires_in));
            expires = ts.TotalDays.ToString();

            return new string[] { clsQuery.access_token, expires };
        }
        public class FBQuery
        {
            public string access_token;
            public string token_type;
            public string expires_in;
        }

    }
}