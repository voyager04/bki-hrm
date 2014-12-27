using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Extensions;
using GooglePlusOAuthLogin;
using Microsoft.Web.WebPages.OAuth;
using QLNhanSu.Models;

namespace QLNhanSu
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "972954086052159",
            //    appSecret: "beb10063ed7b6de82b25c534c332249d");

            OAuthWebSecurity.RegisterClient(
                new GooglePlusClient(
                    ConfigurationUtility.GetConfigurationSettingValue("ClientID")
                    , ConfigurationUtility.GetConfigurationSettingValue("ClientSecret")
                    )
                    , "Google+", null);
        }
    }
}
