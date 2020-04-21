using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAdmin.Areas.Client.Models
{
    public class PaypalConfiguration
    {
        public static readonly string ClientID;
        public static readonly string ClientSecret;

        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientID = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string,string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }
        //Create access token
        private static string GetAccessToken()
        {
            return new OAuthTokenCredential(ClientID, ClientSecret, GetConfig()).GetAccessToken();
        }

        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}