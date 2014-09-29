using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKISystemAdmin.Manager;
using BusinessLogic.Management;
using BusinessLogic.Model;
using BusinessLogic.Principal;
using Framework.Extensions;

namespace QLNhanSu.Controllers
{
    public class BaseController : Controller
    {
        #region Properties

        UserModel mCurrentUser;

        public UserModel CurrentUser
        {
            get
            {
                if (mCurrentUser == null)
                {
                    mCurrentUser = UserManager.Instance.GetByUsername(User.Identity.Name);
                }
                return mCurrentUser;
            }
        }

        #endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var v_identity = User.Identity as Identity;
            if (v_identity != null)
            {
                var v_guid_role = Guid.Parse(v_identity.Roles[0]);
                var v_lst_chuc_nang = CRoleManager.Instance.GetAllChucNangByRoleForMenu(v_guid_role);

                ViewBag.LstChucNang = v_lst_chuc_nang;
                string v_str_pageSize = ConfigurationUtility.GetConfigurationSettingValue("pageSize");
                if (v_str_pageSize != null && v_str_pageSize != "")
                {
                    ViewBag.pageSize = Convert.ToInt32(v_str_pageSize);
                }
                else
                {
                    ViewBag.pageSize = 10;

                }
            }
        }
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
