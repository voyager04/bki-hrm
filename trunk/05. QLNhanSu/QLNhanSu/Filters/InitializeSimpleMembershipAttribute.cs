using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Management;
using WebMatrix.WebData;
using QLNhanSu.Models;

namespace QLNhanSu.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }

    public class AuthActivityAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            bool validated = true;
            if (filterContext.ActionDescriptor.IsDefined(typeof(AuthActivityAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AuthActivityAttribute), true))
            {
                HttpContextBase context = filterContext.HttpContext;
                var principal = context.User;
                string v_str_user_name = context.User.Identity.Name;
                if (UserManager.check_is_not_topica_mail(v_str_user_name))
                {
                    context.Response.Redirect("~/Account/TuChoiTaiKhoan", false);
                    return;
                }
                if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
                {
                    var v_str_controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    var v_str_action = filterContext.ActionDescriptor.ActionName;
                    UserManager m_mana_User = UserManager.Instance;
                    if (!m_mana_User.CheckRolesOfUser(v_str_user_name, v_str_controller, v_str_action))
                    {
                        context.Response.Redirect("~/Home/Index", false);
                        validated = false;
                    }
                }
            }

            if (validated)
                base.OnAuthorization(filterContext);

        }
    }
}
