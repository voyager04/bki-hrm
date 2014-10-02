using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using BusinessLogic.Management;
using BusinessLogic.Principal;
using Framework.Extensions;
using Helper;

namespace QLNhanSu
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Optimize JS
            App_Start.BundleConfig.JsOptimize();

            // Optimize Css
            App_Start.BundleConfig.CssOptimize();

            // Init log4net
            //log4net.Config.XmlConfigurator.Configure();
        }

        public override void Init()
        {
            base.Init();
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var ctx = HttpContext.Current;
                if (ctx == null || ctx.Request == null
                    || ctx.Request.Url.AbsolutePath.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase)
                    || ctx.Request.Url.AbsolutePath.EndsWith(".js", StringComparison.InvariantCultureIgnoreCase)
                    || ctx.Request.Url.AbsolutePath.EndsWith(".jsrex", StringComparison.InvariantCultureIgnoreCase)
                    || ctx.Request.Url.AbsolutePath.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase)
                    || ctx.Request.Url.AbsolutePath.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase)
                    || ctx.Request.Url.AbsolutePath.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

                var usr = ctx.User;
                if (usr == null) return;

                if (usr.Identity == null || String.IsNullOrEmpty(usr.Identity.Name))
                {
                    return;
                }

                //Build up the custom Identity and Principle here from cookie cache for
                //from database for Authorization MVC attibutes to work
                string cookieName = "HRMIdentity_" + usr.Identity.Name;
                var usrCookie = CookieHelper.GetTripleDESEncryptedCookieObject(cookieName);//Get encrypted cookie
                Identity identity = null;
                if (usrCookie != null)
                {
                    var cookieValue = CookieHelper.GetTripleDESEncryptedCookieValue(cookieName);
                    identity = new Identity(usr.Identity.Name, cookieValue);

                    // anti -fake, edit cookie name
                    //if (!identity.OrgDomainName.Equals(ctx.ParseCurrentDomain(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //    ctx.User = null;
                    //    return;
                    //}
                }
                else
                {
                    var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {
                        UserManager vUserManager = UserManager.Instance;

                        var u = vUserManager.GetByUsername(User.Identity.Name);
                        if (u != null)
                        {
                            identity = new Identity(u.ID, u.USERNAME, u.DISPLAY_NAME
                                , new[] { u.ID_USER_GROUP.ToString() });
                            CookieHelper.SetTripleDESEncryptedCookie(cookieName, identity.ToString());
                        }
                        else
                        {
                            throw new UnauthorizedAccessException();
                        }
                    }
                    else
                    {
                        throw new UnauthorizedAccessException();
                    }
                }

                var principal = new Principal(identity);
                ctx.User = Thread.CurrentPrincipal = principal;
            }
            catch (UnauthorizedAccessException uae)
            {
                uae.Log();
                return;
            }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }
        }
    }
}