using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var v_identity = User.Identity as Identity;
            if (v_identity != null)
            {
                //var v_guid_role = Guid.Parse(v_identity.Roles[0]);
                //var v_lst_chuc_nang = CRoleManager.Instance.GetAllChucNangByRoleForMenu(v_guid_role);

                //ViewBag.LstCucNang = v_lst_chuc_nang;
            }
        }
    }
}
