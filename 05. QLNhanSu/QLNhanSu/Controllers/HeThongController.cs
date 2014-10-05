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
        BKI_HRMEntities _db = new BKI_HRMEntities();
        #endregion

        [HttpGet]
        public ActionResult F201_GetAllUsers()
        {
            return View(_db.V_HT_USER);
        }

        public ActionResult F202_AddNewUser()
        {
            return View();
        }
    }
}
