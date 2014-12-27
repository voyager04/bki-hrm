using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace BusinessLogic.Principal
{
    public static class UserIdentityExtension
    {

        public static string UserName(this IPrincipal user)
        {
            try
            {
                return user.Identity.Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static Guid UserId(this IPrincipal user)
        {
            try
            {
                return user.Identity().ID;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static IEnumerable<Guid> RoleId(this IPrincipal user)
        {
            try
            {
                return (user.Identity as CustomIdentity).Roles.Select(x => Guid.Parse(x));
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static CustomIdentity Identity(this IPrincipal user)
        {
            try
            {
                return (user.Identity as CustomIdentity);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static bool IsAuthenticated(this IPrincipal user)
        {
            try
            {
                return user.Identity.IsAuthenticated;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
