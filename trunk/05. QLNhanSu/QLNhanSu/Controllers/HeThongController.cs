using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Model;
using BusinessLogic.Management;
using DataAccess;

namespace QLNhanSu.Controllers
{
    public class HeThongController : BaseController
    {
        #region Member
        private string _result = "";
        private UserManager m_UserManager = UserManager.Instance;
        #endregion

        [HttpGet]
        public ActionResult F201_GetAllUsers()
        {
            return View();
        }


    }
}
