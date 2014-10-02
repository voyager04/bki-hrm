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
    public class ReportController : BaseController
    {
        #region Member
        BKI_HRMEntities _db = new BKI_HRMEntities();
        private string _result = "";
        private CoCauTopicaManager m_manager_CoCauTopica = CoCauTopicaManager.Instance;
        #endregion

        #region Function
        private void GetAllChildNode(V_DM_DON_VI parent, List<V_DM_DON_VI> ip_allDonVi)
        {
            var childNode = ip_allDonVi.Where(m => m.ID_DON_VI_CAP_TREN == parent.ID);

            foreach (var item in childNode)
            {
                _result += "<tr data-tt-id=" + item.ID + " data-tt-parent-id=" + item.ID_DON_VI_CAP_TREN + ">";
                _result += "<td>" + item.MA_DON_VI + "</td>";
                _result += "<td>" + item.TEN_DON_VI + "</td>";
                _result += "<td>" + item.DIA_BAN + "</td>";
                _result += "<td>" + item.SO_LUONG + "</td>";
                _result += "<td>" + item.TEN_TIENG_ANH + "</td>";
                _result += "<td>" + item.LOAI_DON_VI + "</td>";
                _result += "<td>" + item.CAP_DON_VI + "</td>";
                _result += "<td>" + item.TRANG_THAI + "</td>";
                _result += "<td>" + string.Format("{0:dd/MM/yyyy}", item.TU_NGAY) + "</td>";
                _result += "</tr>";
                GetAllChildNode(item, ip_allDonVi);
            }
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult F101_CoCauTopica()
        {
            var v_allDonVi = _db.pr_V_DM_DON_VI_search("", -1, -1, "Y", 3).ToList();
            var rootDonVi = v_allDonVi.FirstOrDefault(m => m.ID_LEVEL.GetValueOrDefault() == Enumerable.Min(v_allDonVi, x => x.ID_LEVEL));
            if (rootDonVi != null)
            {
                _result += "<tr data-tt-id=" + rootDonVi.ID + ">";
                _result += "<td>" + rootDonVi.MA_DON_VI + "</td>";
                _result += "<td>" + rootDonVi.TEN_DON_VI + "</td>";
                _result += "<td>" + rootDonVi.DIA_BAN + "</td>";
                _result += "<td>" + rootDonVi.SO_LUONG + "</td>";
                _result += "<td>" + rootDonVi.TEN_TIENG_ANH + "</td>";
                _result += "<td>" + rootDonVi.LOAI_DON_VI + "</td>";
                _result += "<td>" + rootDonVi.CAP_DON_VI + "</td>";
                _result += "<td>" + rootDonVi.TRANG_THAI + "</td>";
                _result += "<td>" + string.Format("{0:dd/MM/yyyy}", rootDonVi.TU_NGAY) + "</td>";
                _result += "</tr>";
            }
            GetAllChildNode(rootDonVi, v_allDonVi);

            ViewBag.CoCauTOPICA = _result;
            return View();
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
