using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class LoginController : Controller
    {
        private const string GOOGLE_OAUTH_ENDPOINT =
        "https://www.google.com/accounts/o8/id";
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        /// <summary>
        /// Authentication/Login post action.
        /// Original code concept from
        /// DotNetOpenAuth/Samples/OpenIdRelyingPartyMvc/Controller/UserController
        /// for demo purposes I took out the returnURL, for this demo I
        /// always want to login to the home page.
        /// </summary>
        [ValidateInput(false)]
        public ActionResult Authenticate()
        {
            var response = openid.GetResponse();
            var statusMessage = "";
            if (response == null)
            {
                Identifier id;
                //make sure your users openid_identifier is valid.
                if (Identifier.TryParse(GOOGLE_OAUTH_ENDPOINT, out id))
                {
                    try
                    {
                        //request openid_identifier
                        //  return openid.CreateRequest(GOOGLE_OAUTH_ENDPOINT)
                        //  .RedirectingResponse.AsActionResult();
                        IAuthenticationRequest request = openid.CreateRequest(GOOGLE_OAUTH_ENDPOINT);
                        var fetch = new FetchRequest();
                        fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                        request.AddExtension(fetch);
                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        statusMessage = ex.Message;
                        return View("Login", statusMessage);
                    }
                }
                else
                {
                    statusMessage = "Invalid identifier";
                    return View("Login", statusMessage);
                }
            }
            else
            {
                //check the response status
                switch (response.Status)
                {
                    //success status
                    case AuthenticationStatus.Authenticated:
                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                        FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);

                        var fetch = response.GetExtension<FetchResponse>();
                        string email = string.Empty;
                        string firstname = string.Empty;
                        string lastname = string.Empty;
                        if (fetch != null)
                        {
                            email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                            firstname = fetch.GetAttributeValue(WellKnownAttributes.Name.First);
                            lastname = fetch.GetAttributeValue(WellKnownAttributes.Name.Last);
                            FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
                            FormsAuthentication.SetAuthCookie(email, false);
                            //FormsAuthentication.RedirectFromLoginPage(response.ClaimedIdentifier, false);

                        }
                        else //we didn't fetch any info. Too bad.
                        {
                            ThrowSecurityException();
                        }
                        //Session["userInfo"] = new UserInfor { Email = email, LastName = lastname, FirstName = firstname };
                        Session["Email"] = email;
                        Session["LastName"] = lastname;
                        Session["FirstName"] = firstname;
                        return RedirectToAction("F104_ThongTinNhanVien", "Report");
                    case AuthenticationStatus.Canceled:
                        statusMessage = "Canceled at provider";
                        return View("Login", statusMessage);

                    case AuthenticationStatus.Failed:
                        statusMessage = response.Exception.Message;
                        return View("Login", statusMessage);
                }
            }
            return new EmptyResult();
        }
        public void ThrowSecurityException()
        {
            throw new SecurityException("Authentication failed");
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}
