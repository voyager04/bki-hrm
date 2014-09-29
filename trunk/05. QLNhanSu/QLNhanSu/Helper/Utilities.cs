using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Management;
using BusinessLogic.Model;
using BusinessLogic.Principal;
using Framework.Extensions;

namespace Helper
{
    public static class Utilities
    {
        static Utilities()
        {
            try
            {
                if (CurrentVersionString.IsNullOrEmpty())
                {
                    CurrentVersionString =
                        (Type.GetType("QLNhanSu.Controllers.BaseController, QLNhanSu")
                        .Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0] as AssemblyFileVersionAttribute)
                        .Version;
                    CurrentVersion = new Version(CurrentVersionString);
                }

            }
            catch (Exception ex)
            {
                CurrentVersion = new Version(0, 0, 0, 0);
                CurrentVersionString = CurrentVersion.ToString();
                throw;
            }
        }

        public static Identity CurrentUser
        {
            get
            {
                Identity result;
                var principal = HttpContext.Current != null ?
                    HttpContext.Current.User : Thread.CurrentPrincipal;
                if (principal != null)
                {
                    result = principal.Identity as Identity;
                }
                else
                {
                    result = null;
                }

                return result;
            }
        }

        public static Guid CurrentUserID
        {
            get
            {
                var usr = CurrentUser;
                return usr != null ? usr.ID : Guid.Empty;
            }
        }

        public static UserModel CurrentUserObj
        {
            get
            {
                var urs = UserManager.Instance.GetByUsername(CurrentUser.Name);
                return urs;
            }
        }

        public static Version CurrentVersion { get; set; }

        public static string CurrentVersionString { get; private set; }

        public static string CurrentUserImage
        {
            get
            {
                var ursImage = string.Format("/Content/Upload/{0}.jpg", CurrentUserObj.USERNAME + "-" + DateTime.Now);
                return ursImage;
            }
        }
    }

    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Thực hiện xác thực user theo nguyên lý:
            // http://lostechies.com/derickbailey/2011/05/24/dont-do-role-based-authorization-checks-do-activity-based-checks/ 
            base.OnAuthorization(filterContext);



            var a = filterContext.ActionDescriptor.ActionName;
        }
    }
}