using System;
using System.Collections.Generic;
using System.Data.Objects;
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
                HO_TEN = m.HO_DEM + " " + m.TEN,
                GIOI_TINH = m.GIOI_TINH,
                EMAIL_CQ = m.EMAIL_CQ,
                DTDD = m.DI_DONG,
                TRANG_THAI_LD_HIEN_TAI = m.TRANG_THAI_LD_HIEN_TAI,
                MA_CHUC_VU = m.MA_CV,
                TEN_CHUC_VU = m.TEN_CV,
                LOAI_CHUC_VU = m.LOAI_CV,
                NGAY_BAT_DAU_CHUC_VU = string.Format("{0: dd/MM/yyyy}", m.NGAY_BAT_DAU),
                MA_QUYET_DINH = m.MA_QUYET_DINH,
                LOAI_QUYET_DINH = m.LOAI_QD,
                NGACH = m.NGACH,
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

        public ActionResult F103_TraCuuThuNhapCaNhan()
        {
            return View();
        }

        public JsonResult GetThuNhapCaNhan(string ip_MaNhanVien)
        {
            return Json(_db.pr_V_GD_LUONG_THEO_QD_WEB(3, ip_MaNhanVien, "N", -1, -1, DateTime.Parse("01/01/2009"), DateTime.Now)
                .Select(m => new
                                 {
                                     //HO_TEN = m.HO_DEM + " " + m.TEN,
                                     LUONG = m.LUONG,
                                     NGAY_AP_DUNG = string.Format("{0: dd/MM/yyyy}", m.NGAY_AP_DUNG),
                                     LUONG_HIEN_TAI = m.LUONG_HIEN_TAI_YN,
                                     MA_KY = m.MA_KY,
                                     NGAY_BD_KY = string.Format("{0: dd/MM/yyyy}", m.NGAY_BAT_DAU_KY),
                                     NGAY_KT_KY = string.Format("{0: dd/MM/yyyy}", m.NGAY_KET_THUC_KY),
                                     MA_QUYET_DINH = m.MA_QD,
                                     LOAI_QUYET_DINH = m.TEN_QD,
                                     NGAY_CO_HIEU_LUC = string.Format("{0: dd/MM/yyyy}", m.NGAY_CO_HIEU_LUC),
                                     NGAY_KY = string.Format("{0: dd/MM/yyyy}", m.NGAY_KY),
                                     NOI_DUNG = m.NOI_DUNG,
                                     MA_SO_THUE = m.MA_SO_THUE
                                 }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult F104_ThongTinNhanVien()
        {
            return View();
        }

        public JsonResult GetChucVuNhanVien(string ip_MaNhanVien)
        {
            var listChucVu = _db.pr_V_GD_QUA_TRINH_LAM_VIEC_chuc_vu_hien_tai(ip_MaNhanVien, 3);
            var list = listChucVu.Select(item => new ChucVuModel()
                                                     {
                                                         TU_NGAY = string.Format("{0: dd/MM/yyyy}", item.NGAY_BAT_DAU),
                                                         DEN_NGAY = string.Format("{0: dd/MM/yyyy}", item.NGAY_KET_THUC), 
                                                         MA_CHUC_VU = item.MA_CV, 
                                                         TEN_CHUC_VU = item.TEN_CV, 
                                                         TRANG_THAI_CHUC_VU = item.TRANG_THAI_CV,
                                                         TY_LE_THAM_GIA = item.TY_LE_THAM_GIA ?? 0, 
                                                         MA_DON_VI = item.MA_DON_VI, 
                                                         TEN_DON_VI = item.TEN_DON_VI, 
                                                         CAP_DON_VI = item.CAP_DON_VI, 
                                                         MA_QUYET_DINH = item.MA_QUYET_DINH,
                                                         NGAY_CO_HIEU_LUC = string.Format("{0: dd/MM/yyyy}", item.NGAY_CO_HIEU_LUC),
                                                         NGAY_HET_HIEU_LUC = string.Format("{0: dd/MM/yyyy}", item.NGAY_HET_HIEU_LUC)
                                                     }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetThongTinNhanVien(string ip_MaNhanVien)
        {
            var inforEmployee = new InforEmployee();
            var infors = _db.pr_DM_NHAN_SU_Search(ip_MaNhanVien).FirstOrDefault();
            if (infors == null) return null;
            var trangThaiLd = _db.pr_V_GD_TRANG_THAI_LAO_DONG_By_Ma_nhan_vien(ip_MaNhanVien).FirstOrDefault();
            if (trangThaiLd == null) return null;
            var listChucVu = _db.pr_V_GD_QUA_TRINH_LAM_VIEC_chuc_vu_hien_tai(ip_MaNhanVien, 3);

            inforEmployee.HO_TEN = infors.HO_DEM + " " + infors.TEN;
            inforEmployee.GIOI_TINH = infors.GIOI_TINH;
            inforEmployee.NGAY_SINH = string.Format("{0: dd/MM/yyyy}", infors.NGAY_SINH);
            inforEmployee.NOI_SINH = infors.NOI_SINH;
            inforEmployee.NGUYEN_QUAN = infors.NGUYEN_QUAN;
            inforEmployee.DK_HO_KHAU = infors.HO_KHAU;
            inforEmployee.DIA_CHI = infors.CHO_O;
            inforEmployee.CMTND = infors.CMND;
            inforEmployee.NGAY_CAP = string.Format("{0: dd/MM/yyyy}", infors.NGAY_CAP_CMND);
            inforEmployee.NOI_CAP = infors.NOI_CAP_CMND;
            inforEmployee.MA_SO_THUE = infors.MA_SO_THUE;
            inforEmployee.DTDD = infors.DI_DONG;
            inforEmployee.DT_NHA_RIENG = infors.DT_NHA;
            inforEmployee.EMAIL_CO_QUAN = infors.EMAIL_CQ;
            inforEmployee.EMAIL_CA_NHAN = infors.EMAIL_CA_NHAN;
            inforEmployee.TRANG_THAI_LAO_DONG = trangThaiLd.TRANG_THAI_LAO_DONG;

            inforEmployee.LIST_CHUC_VU = new List<ChucVuModel>();
            foreach (var item in listChucVu)
            {
                inforEmployee.LIST_CHUC_VU.Add(new ChucVuModel()
                {
                    TU_NGAY = string.Format("{0}: dd/MM/yyyy", item.NGAY_BAT_DAU),
                    DEN_NGAY = string.Format("{0}: dd/MM/yyyy", item.NGAY_KET_THUC),
                    MA_CHUC_VU = item.MA_CV,
                    TEN_CHUC_VU = item.TEN_CV,
                    TRANG_THAI_CHUC_VU = item.TRANG_THAI_CV,
                    TY_LE_THAM_GIA = item.TY_LE_THAM_GIA ?? 0,
                    MA_DON_VI = item.MA_DON_VI,
                    TEN_DON_VI = item.TEN_DON_VI,
                    CAP_DON_VI = item.CAP_DON_VI,
                    MA_QUYET_DINH = item.MA_QUYET_DINH,
                    NGAY_CO_HIEU_LUC = string.Format("{0}: dd/MM/yyyy", item.NGAY_CO_HIEU_LUC),
                    NGAY_HET_HIEU_LUC = string.Format("{0}: dd/MM/yyyy", item.NGAY_HET_HIEU_LUC)
                });
            }
            return Json(inforEmployee, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult F105_QuaTrinhLamViecCuaCacNhanVienPhongBan()
        //{
        //    return View();
        //}

        //public ActionResult F106_ThuNhapCuaCacNhanVienTrongPhongBan()
        //{
        //    return View();
        //}
    }
}
