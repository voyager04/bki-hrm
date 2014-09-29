using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Model;
using BusinessLogic.Management;

namespace QLNhanSu.Controllers
{
    public class ReportController : BaseController
    {
        #region Fields
        private CoCauTopicaManager m_manager_CoCauTopica = CoCauTopicaManager.Instance;
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoCauTopica()
        {
            var v_AllDonVi = m_manager_CoCauTopica.GetAllDonVi();
            return View(v_AllDonVi);
        }

        public ActionResult TraCuuQuaTrinhLamViecCaNhan()
        {
            return View();
        }

        public ActionResult TraCuuThuNhapCaNhan()
        {
            return View();
        }

        public ActionResult DanhSachNhanVienPhongBan()
        {
            return View();
        }

        public ActionResult QuaTrinhLamViecCuaCacNhanVienPhongBan()
        {
            return View();
        }

        public ActionResult ThuNhapCuaCacNhanVienTrongPhongBan()
        {
            return View();
        }
    }
}
