using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKISystemAdmin.Manager;
using BKISystemAdmin.Model;
using BusinessLogic.Principal;

namespace QLNhanSu.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //var v_lst_controller = new List<CChucNangModel>();
            //User.RoleId().ToList().ForEach(x =>
            // v_lst_controller.AddRange(CRoleManager.Instance.GetAllChucNangByRoleForAuthenticate(x)));
            //var v_controller = v_lst_controller.FirstOrDefault(x => x.HIEN_THI_YN);

            //return RedirectToAction(v_controller.ACTIVITY_NAME, v_controller.CONTROLLER_NAME);
            return View();
        }
    }
}
