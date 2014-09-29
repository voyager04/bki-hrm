using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Principal;
using QLNhanSu.CustomRoutes;

namespace QLNhanSu.Filters
{
    public class AuthActivityAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            bool validated = true;

            if (filterContext.ActionDescriptor.IsDefined(typeof(AuthActivityAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AuthActivityAttribute), true))
            {
                HttpContextBase context = filterContext.HttpContext;
                var principal = context.User as Principal;
                if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
                {
                    var v_str_controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    var v_str_action = filterContext.ActionDescriptor.ActionName;

                    if (!principal.IsInActivity(v_str_controller, v_str_action))
                    {
                        context.RedirectToAccessDenined();
                        validated = false;
                    }
                }
            }

            if (validated)
                base.OnAuthorization(filterContext);

        }
    }
}