using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhanSu.CustomRoutes
{
    public static class DomainRouteHelper
    {
        public static void RedirectToAccessDenined(this HttpContextBase ctx)
        {
            ctx.Response.Redirect("~/Error?code=403", false);
        }
    }
}