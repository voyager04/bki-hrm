﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNhanSu.Models;

namespace QLNhanSu.Controllers
{
    public class ReportController : Controller
    {
        #region Member
        BKI_HRMEntities _db = new BKI_HRMEntities();
        private string _result = "";
        #endregion

        #region Function
        public ActionResult GetNhanVienByPhongBan(string ipMaDonVi)
        {
            var v_NhanVien = _db.pr_V_GD_QUA_TRINH_LAM_VIEC_2_Search_NhanVien_TheoPhongBanTaiMotThoiDiem(ipMaDonVi, DateTime.Now, 3, -1).ToList();
            return Json(v_NhanVien.Select(m => new
            {
                MA_DON_VI = m.MA_DON_VI,
                TEN_DON_VI = m.TEN_DON_VI,
                CAP_DON_VI = m.CAP_DON_VI,
                LOAI_DON_VI = m.LOAI_DON_VI,
                DIA_BAN = m.DIA_BAN,
                MA_NHAN_VIEN = m.MA_NV,
                HO_DEM = m.HO_DEM,
                TEN = m.TEN,
                TRANG_THAI_LD_HIEN_TAI = m.TRANG_THAI_LD_HIEN_TAI,
                MA_CHUC_VU = m.MA_CV,
                TEN_CHUC_VU = m.TEN_CV,
                LOAI_CHUC_VU = m.LOAI_CV,
                NGAY_BAT_DAU_CHUC_VU = string.Format("{0: dd/MM/yyyy}", m.NGAY_BAT_DAU),
                NGAY_KET_THUC_CHUC_VU = string.Format("{0: dd/MM/yyyy}", m.NGAY_KET_THUC),
                MA_QUYET_DINH = m.MA_QUYET_DINH,
                LOAI_QUYET_DINH = m.LOAI_QD,
                NGAY_BAT_DAU_QUYET_DINH = string.Format("{0: dd/MM/yyyy}", m.NGAY_CO_HIEU_LUC),
                NGAY_KET_THUC_QUYET_DINH = string.Format("{0: dd/MM/yyyy}", m.NGAY_HET_HIEU_LUC),
                NGACH = m.NGACH,
                TRANG_THAI_CHUC_VU = m.TRANG_THAI_CV,
                MA_QUYET_DINH_MIEN_NHIEM = m.MA_QUYET_DINH_MIEN_NHIEM,
                TY_LE_THAM_GIA = m.TY_LE_THAM_GIA ?? 0
            }), JsonRequestBehavior.AllowGet);
        }

        private void GetAllChildNode(pr_V_DM_DON_VI_search_Result parent, List<pr_V_DM_DON_VI_search_Result> ip_allDonVi)
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
                _result += "<td class='btnViewDetails' data-don-vi='" + item.MA_DON_VI + "' data-toggle='modal' data-target='.model-donvi-detail'>";
                _result += "<span class='glyphicon glyphicon-user'></span>";
                _result += "</td>";
                _result += "</tr>";
                GetAllChildNode(item, ip_allDonVi);
            }
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
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
                _result += "<td class='btnViewDetails' data-don-vi='" + rootDonVi.MA_DON_VI + "' data-toggle='modal' data-target='.model-donvi-detail'>";
                _result += "<span class='glyphicon glyphicon-user'></span></td>";
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

        public JsonResult GetQuaTrinhLamViec(string ip_MaNhanVien, string ip_DieuKien = "")
        {
            if (ip_MaNhanVien == "") return null;
            var v_QuaTrinhLamViec = _db.pr_GD_QUA_TRINH_CONG_TAC_WEB(ip_MaNhanVien, ip_DieuKien, DateTime.Parse("01/01/2009"), DateTime.Now, 3).ToList();
            return Json(v_QuaTrinhLamViec.Select(m => new
            {
                TU_NGAY = string.Format("{0: dd/MM/yyyy}", m.TU_NGAY),
                DEN_NGAY = string.Format("{0: dd/MM/yyyy}", m.DEN_NGAY),
                LAM_GI = m.LAM_GI,
                O_DAU = m.O_DAU,
                VAI_TRO = m.VAI_TRO,
                TY_LE_THAM_GIA = m.TY_LE_THAM_GIA ?? 0,
                MA_QUYET_DINH = m.MA_QUYET_DINH ?? "",
                LOAI_QD = m.LOAI_QD ?? "",
                MA_QUYET_DINH_MIEN_NHIEM = m.MA_QUYET_DINH_MIEN_NHIEM ?? ""
            }), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult F103_TraCuuThuNhapCaNhan()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult F104_DanhSachNhanVienPhongBan(string ipMaDonVi)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult F105_QuaTrinhLamViecCuaCacNhanVienPhongBan()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult F106_ThuNhapCuaCacNhanVienTrongPhongBan()
        {
            return View();
        }
    }
}