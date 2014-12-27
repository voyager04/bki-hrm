using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKISystemAdmin.Manager;
using BusinessLogic.Management;
using BusinessLogic.Model;
using Facebook;
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
            var user_name = User.Identity.Name;

            if (UserManager.check_is_not_topica_mail(user_name))
            {
                IEnumerable<BKISystemAdmin.Model.CChucNangModel> lst_cn = CRoleManager.Instance.GetAllChucNangByRolForMenu(System.Guid.NewGuid());
                BKISystemAdmin.Model.CChucNangModel v_cn = new BKISystemAdmin.Model.CChucNangModel();
                v_cn.CHUC_NANG_CHA = null;
                v_cn.CHUC_NANG_CON = null;
                v_cn.CONTROLLER_NAME = "Account";
                v_cn.ACTIVITY_NAME = "TuChoiTaiKhoan";
                v_cn.ID = System.Guid.NewGuid();
                v_cn.TRANG_THAI_YN = true;
                v_cn.HIEN_THI_MENU = "Y";
                lst_cn.Add(v_cn);
                ViewBag.LstChucNang = lst_cn;
                return;
            }
            if (user_name == null) return;
            UserManager.Instance.InsertIfDoNotHaveUser(user_name);
            mCurrentUser = CurrentUser;
            //var v_identity = User.Identity as EhrIdentity;
            if (user_name != null && !user_name.Equals(""))
            {
                var v_guid_role = mCurrentUser.ID_USER_GROUP;
                ViewBag.LstChucNang = CRoleManager.Instance.GetAllChucNangByRolForMenu(v_guid_role);
                //string v_str_pageSize = ConfigurationUtility.GetConfigurationSettingValue("pageSize");
                //if (v_str_pageSize != null && v_str_pageSize != "")
                //{
                //    ViewBag.pageSize = Convert.ToInt32(v_str_pageSize);
                //}
                //else
                //{
                //    ViewBag.pageSize = 10;

                //}
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
