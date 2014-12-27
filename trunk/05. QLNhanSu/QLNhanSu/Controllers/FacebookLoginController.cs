using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNhanSu.Controllers
{
    public class FacebookLoginController : BaseController
    {
        //
        // GET: /FacebookLogin/

        public ActionResult Index(string accessToken)
        {

            return View();
        }

    }
}
