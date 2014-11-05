using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BKISystemAdmin.Manager;
using BKISystemAdmin.Model;
using Framework.Extensions;

namespace BusinessLogic.Principal
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly CustomIdentity _identity;

        public CustomPrincipal(CustomIdentity ip_identity)
        {
            if (ip_identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            _identity = ip_identity;
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }


        /// <summary>
        /// Check an acitivity
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool IsInActivity(string controller, string acctivity)
        {
            var v_lst_activities = new List<CChucNangModel>();

            foreach (var lp_role in _identity.Roles)
            {
                // To decense object
                v_lst_activities = v_lst_activities.Add(
                    CRoleManager.Instance.GetAllChucNangByRoleForAuthenticate(Guid.Parse(lp_role)).ToArray()).ToList();
            }

            return v_lst_activities.Any(r => r.HAS_LINK &&
                r.CONTROLLER_NAME.Equals(controller, StringComparison.InvariantCultureIgnoreCase)
                && r.ACTIVITY_NAME.Equals(acctivity, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
