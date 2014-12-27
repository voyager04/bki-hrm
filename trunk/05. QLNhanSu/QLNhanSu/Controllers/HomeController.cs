using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Management;

namespace QLNhanSu.Controllers
{
    public class HomeController : BaseController
    {
        UserManager m_mana_User = UserManager.Instance;

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (UserManager.check_is_not_topica_mail(User.Identity.Name))
                return RedirectToAction("TuChoiTaiKhoan", "Account");
            if (!m_mana_User.CheckProfileIsFull(User.Identity.Name)) return RedirectToAction("F104_ThongTinNhanVien", "Report");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
