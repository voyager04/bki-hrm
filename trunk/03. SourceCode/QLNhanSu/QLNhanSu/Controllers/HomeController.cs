using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class HomeController : Controller
    {
        BKI_HRMEntities _db = new BKI_HRMEntities();

        [HttpGet]
        public ActionResult Index()
        {
            // Begin hiện menu cha

            // Lấy item được sử dụng, bỏ item ko được sử dụng
            var allItems = _db.HT_CHUC_NANG.Where(m => m.TRANG_THAI_YN == "Y"
                                                       && m.HIEN_THI_YN == "Y");

            // Lấy menu cha
            var menuItems = allItems.Where(m => m.CHUC_NANG_PARENT_ID == null).OrderBy(m => m.VI_TRI);

            var result = "";
            foreach (var item in menuItems)
            {
                // Lấy menu con
                var subMenu = allItems.Where(m => m.CHUC_NANG_PARENT_ID == item.ID).OrderBy(m => m.VI_TRI);

                if (!subMenu.Any()) // Nếu item cha không có item con nào
                    result += "<li><a href='" + item.URL_FORM + "'>" + item.TEN_CHUC_NANG + "</a></li>";
                else // Nếu có item con
                {
                    result += "<li class='dropdown'>";
                    result += "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>" + item.TEN_CHUC_NANG + " <span class='caret'></span></a>";
                    result += "<ul class='dropdown-menu' role='menu'>";
                    foreach (var subMenuItem in subMenu)    // Hiển thị các item con dạng html
                    {
                        result += "<li><a href='" + subMenuItem.URL_FORM + "'>" + subMenuItem.TEN_CHUC_NANG + "</a></li>";
                    }
                    result += "</ul>";
                    result += "</li>";
                }

            }
            ViewBag.NavbarTop = result;
            // End hiện menu
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
