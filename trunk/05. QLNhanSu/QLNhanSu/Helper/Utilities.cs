using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Framework.Extensions;

namespace QLNhanSu.Helper
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


        public static Version CurrentVersion { get; set; }

        public static string CurrentVersionString { get; private set; }

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