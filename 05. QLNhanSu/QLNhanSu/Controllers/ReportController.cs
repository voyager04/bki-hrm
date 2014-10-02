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
        #region Member
        private CoCauTopicaManager m_manager_CoCauTopica = CoCauTopicaManager.Instance;
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult F101_CoCauTopica()
        {
            var v_AllDonVi = m_manager_CoCauTopica.GetAllDonVi();
            return View(v_AllDonVi);
        }

        public ActionResult F102_TraCuuQuaTrinhLamViecCaNhan()
        {
            return View();
        }

        public ActionResult F103_TraCuuThuNhapCaNhan()
        {
            return View();
        }

        public ActionResult F104_DanhSachNhanVienPhongBan()
        {
            return View();
        }

        public ActionResult F105_QuaTrinhLamViecCuaCacNhanVienPhongBan()
        {
            return View();
        }

        public ActionResult F106_ThuNhapCuaCacNhanVienTrongPhongBan()
        {
            return View();
        }
    }
}
