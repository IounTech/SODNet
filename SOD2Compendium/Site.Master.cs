﻿using Facebook;
using Nemiro.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SOD2Compendium.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOD2Compendium
{
    public partial class SiteMaster : MasterPage
    {
        public bool IsSubmitter = false;
        protected void Page_Init(object sender, EventArgs e)
        {
            SocialAPI fbAPI = new SocialAPI();
            var provider = Request.QueryString["provider"];
            if (provider == "google")
            {
                var result = OAuthWeb.VerifyAuthorization();
                if (!result.IsSuccessfully)
                {
                    throw new UnauthorizedAccessException("Not authorized");
                }

                if (result.ProviderName != "Google")
                {
                    throw new NotSupportedException("Provider not supported");
                }

                fbAPI.AccessToken = result.AccessToken;
                Submitter clsSubmitter = Submitter.GetSubmitterFromFBID("google-" + result.UserId, result.UserInfo.DisplayName);
                Session["Submitter"] = clsSubmitter;
                IsSubmitter = true;
                btnFBLogin.OnClientClick = "return false;";
                btnFBLogin.Text = ((Submitter)Session["Submitter"]).strName;
                btnGoogleLogin.Visible = false;

                return;
            }


            Classes.AllData.Update();
            string code = Request.QueryString["code"];
//#if DEBUG
//            Session["Submitter"] = Submitter.GetSubmitterFromFBID(Hidden.TestFBID, Hidden.TestFBName);
//#endif

            if (Session["Submitter"] == null)
            {
                if (!string.IsNullOrEmpty(code))
                {


                    string[] accessTokenDetails = SocialAPI.GetAccessTokenAndExpirationDays(code, fbAPI);

                    //store access token and expiration in your database for reuse/renew it
                    fbAPI.AccessToken = accessTokenDetails[0];
                    string expiration = accessTokenDetails[1];

                    Submitter clsSubmitter = GetSubmitter(fbAPI);
                    NLog.LogManager.GetCurrentClassLogger().Debug(UExtensionLibrary.Serialization.Serialization.Serialize(clsSubmitter));
                    Session["Submitter"] = clsSubmitter;
                    btnFBLogin.OnClientClick = "return false;";
                    btnFBLogin.Text = clsSubmitter.strName;
                    btnGoogleLogin.Visible = false;

                }
            }
            else
            {
                IsSubmitter = true;
                btnFBLogin.OnClientClick = "return false;";
                btnFBLogin.Text = ((Submitter)Session["Submitter"]).strName;
                btnGoogleLogin.Visible = false;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public Submitter GetSubmitter(SocialAPI fbAPI)
        {
            try
            {
                dynamic userProfile = fbAPI.FbClient.Get("me?fields=id,name,birthday,email,education,photos{picture,album},cover");
                try
                {
                    NLog.LogManager.GetCurrentClassLogger().Debug(UExtensionLibrary.Serialization.Serialization.Serialize(userProfile));
                }
                catch
                {

                }

                return Submitter.GetSubmitterFromFBID(userProfile.id, userProfile.name);

               
            }
            catch (FacebookApiException ex)
            {
                throw ex;
            }
        }
        public string[] GetRenewedAccessTokenAndExpirationDays(string oldAccessToken, SocialAPI fbAPI)
        {
            //get security code
            Uri targetUri = new Uri("https://graph.facebook.com/oauth/client_code?access_token=" + oldAccessToken + "&client_secret=" + fbAPI.AppSecret + "&redirect_uri=" + fbAPI.RedirectURL + "&client_id=" + fbAPI.AppId);
            HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            StreamReader str = new StreamReader(httpReq.GetResponse().GetResponseStream());

            string query = str.ReadToEnd().ToString();

            var data = (JObject)JsonConvert.DeserializeObject(query);
            string code = data["code"].Value<string>();

            //get new access token
            targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + fbAPI.AppId + "&client_secret=" + fbAPI.AppSecret + "&redirect_uri=" + fbAPI.RedirectURL + "&code=" + code);
            httpReq = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            str = new StreamReader(httpReq.GetResponse().GetResponseStream());

            query = str.ReadToEnd().ToString();
            data = (JObject)JsonConvert.DeserializeObject(query);
            string accessToken = data["access_token"].Value<string>();
            string expires = data["expires_in"].Value<string>();

            TimeSpan ts = TimeSpan.FromSeconds(double.Parse(expires));
            expires = ts.TotalDays.ToString();

            return new string[] { accessToken, expires };
        }

        public void btnFBLogin_Click(Object sender,
                           EventArgs e)
        {
            SocialAPI fbAPI = new SocialAPI();
            Response.Redirect("https://graph.facebook.com/oauth/authorize?client_id=" + fbAPI.AppId + "&redirect_uri=" + fbAPI.RedirectURL);
        }

        protected void btnPayPal_Click(object sender, ImageClickEventArgs e)
        {
            
                string business = "djhughes@iountech.com";
                string itemName = "Help support development!";
                double itemAmount = 0;
                string currencyCode = "USD";

                StringBuilder ppHref = new StringBuilder();

                ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_donations");
                ppHref.Append("&business=" + business);
                ppHref.Append("&item_name=" + itemName);
                ppHref.Append("&amount=" + itemAmount.ToString("#.00"));
                ppHref.Append("&currency_code=" + currencyCode);

                Response.Redirect(ppHref.ToString(), true);
            
        }
        public void btnGoogleLogin_Click(Object sender,
                       EventArgs e)
        {
            SocialAPI socialApi = new SocialAPI();
            OAuthWeb.RedirectToAuthorization("google", socialApi.RedirectURL + "?provider=google");
        }
    }
}