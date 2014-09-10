using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using QLNhanSu.Filters;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class HomeController : Controller
    {
        BKI_HRMEntities _db = new BKI_HRMEntities();

        public ActionResult Index()
        {
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

        [ChildActionOnly]
        public ActionResult CreateNavBarTop(string navbarTop = "")
        {
            // Lấy item được sử dụng, bỏ item ko được sử dụng
            var allItems = _db.HT_CHUC_NANG.Where(m => m.TRANG_THAI_YN == "Y"
                                                       && m.HIEN_THI_YN == "Y");

            // User Account sau khi đăng nhập
            var userName = User.Identity.Name;

            if (userName != null)
            {
                // Lấy ID của user name
                var userAccount = _db.HT_NGUOI_SU_DUNG_WEB.FirstOrDefault(m => m.TEN_TRUY_CAP == userName);

                if (userAccount != null)
                {
                    // Tìm userAccount thuộc Group nào
                    var userGroup = _db.HT_USER_GROUP_WEB.FirstOrDefault(m => m.ID == userAccount.ID_USER_GROUP_WEB);

                    if (userGroup != null)
                    {
                        // Tìm tất cả quyền của Group đó
                        var permissionGroup = _db.V_HT_PHAN_QUYEN_USER_WEB.Where(m => m.ID_USER_GROUP == userGroup.ID
                                                                                    && m.TEN_TRUY_CAP == userName)
                                                                          .OrderBy(m => m.VI_TRI);

                        // For từng quyền và query trong bảng HT_CHUC_NANG để lấy ra item menu
                        foreach (var permission in permissionGroup)
                        {
                            // Lấy menu cha
                            var menuItems = allItems.Where(m => m.CHUC_NANG_PARENT_ID == null && m.ID == permission.ID_QUYEN).OrderBy(m => m.VI_TRI);

                            foreach (var item in menuItems)
                            {
                                // Lấy menu con theo ID của menu cha
                                var subMenu = allItems.Where(m => m.CHUC_NANG_PARENT_ID == item.ID).OrderBy(m => m.VI_TRI);

                                // Lặp các menu con. So sánh xem chức năng đã có trong quyền chưa?
                                // Có rồi thì đưa vào 1 list để sử dụng hiển thị dạng html
                                var listSubMenu = new List<HT_CHUC_NANG>();
                                foreach (var subMenuItem in subMenu)
                                {
                                    if (permissionGroup.Any(m => m.ID_QUYEN == subMenuItem.ID))
                                    {
                                        listSubMenu.Add(subMenuItem);
                                    }
                                }

                                if (!listSubMenu.Any()) // Nếu item cha không có item con nào
                                    navbarTop += "<li><a href='" + item.URL_FORM + "'>" + item.TEN_CHUC_NANG + "</a></li>";
                                else // Nếu có item con
                                {
                                    navbarTop += "<li class='dropdown'>";
                                    navbarTop += "<a href='#' class='dropdown-toggle' data-toggle='dropdown'>" + item.TEN_CHUC_NANG + " <span class='caret'></span></a>";
                                    navbarTop += "<ul class='dropdown-menu' role='menu'>";
                                    foreach (var subMenuItem in listSubMenu)    // Hiển thị các item con dạng html
                                    {
                                        if (permissionGroup.Any(m => m.ID_QUYEN == subMenuItem.ID))
                                        {
                                            navbarTop += "<li><a href='" + subMenuItem.URL_FORM + "'>" + subMenuItem.TEN_CHUC_NANG + "</a></li>";
                                        }
                                    }
                                    navbarTop += "</ul>";
                                    navbarTop += "</li>";
                                }
                            }
                        }
                    }
                }
            }
            else // Nếu chưa đăng nhập
            {
                navbarTop = "";
            }
            ViewBag.NavbarTop = navbarTop;
            return PartialView();
        }
    }
}
