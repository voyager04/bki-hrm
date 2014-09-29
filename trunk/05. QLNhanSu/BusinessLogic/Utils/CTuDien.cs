using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EHR.BusinessLogic.Utils
{
    public class CTrangThaiHoSo
    {
        public static string DaKhamChiDinh = "DA_KHAM_CHI_DINH";
        public static string DaTaoLanKham = "DA_TAO_LAN_KHAM";
        public static string DaKetLuan = "DA_KHAM_KET_LUAN";
        public static string DaDangKyKham = "DA_DANG_KY_KHAM";
        public static string VE = "VE";
        public static string CHUYEN_VIEN = "CHUYEN_VIEN";
        public static string CHUYEN_KHOA = "CHUYEN_KHOA";
    }
    public class CMaCLS
    {
        public const string SieuAm = "SA";
        public const string XQuang = "XQ";
        public const string HuyetHoc = "HH";
        public const string ViSinh = "VS";
        public const string NuocTieu = "NT";
        public const string SinhHoa = "SH";
        public const string MienDich = "MD";
        public const string XNPhan = "PH";
        public const string XNCapCuu = "CAP_CUU";
        public const string PhongXNCapCuu = "Tầng 1, P103";
        public const string HuyetHoc18Ts = "C4.1.49";
        public const string NuocTieu10Ts = "C5.4.14";
    }
    public class CLoaiBuongKham
    {
        public static string CLS = "CLS";
        public static string Thuong = "THUONG";
        public static string CapCuu = "CAP_CUU";
    }

    public class CLoaiTinhThanh
    {
        public static string QuocGia = "QUOC_GIA";
        public static string TinhThanh = "TINH_THANH";
        public static string QuanHuyen = "QUAN_HUYEN";
    }

    public class CLoaiChiDinh
    {
        public static string CLS = "CLS";
        public static string PTTT = "PTTT";
    }
    public class CIdUserGroup {
        public static string ID_BAC_XET_NGHIEM = "AB9E2F46-94C1-4C46-9C00-169337CCF8CD";
        public static string ID_BAC_SY_KHAM = "2999129E-C21E-42C5-95DB-DE81735AB4D8";
        public static string ID_BAC_SY_SIEU_AM = "725C64CD-DEC1-4AE5-85FC-039A2DAA256F";
        public static string ID_BAC_SY_X_QUANG = "0CECF74C-C175-4DA0-8B68-16747A9FFE45";
        public static string ID_BENH_NHAN = "303E3414-503B-40F7-BB48-A04D034AD7CB";
    }
    public class CBenhVien
    {
        public static string BV_DaKhoa_YenPhong = "04bc7de3-15fa-442f-a115-cf890a5ecc78";
    }
    public class CM_DM_TU_DIEN
    {
        public static string ID_XN = "C0C0EABF-74A2-4344-98A5-3E7B0DFBE970";
        public static string ID_SA = "171CD6B1-DB20-4C0C-BEFE-39E7510A3D17";
        public static string ID_XQ = "24E322D2-5DFC-4DDD-BCA0-CB89F73F4776";
        public static string ID_PTTT = "D3E35DB9-B4C6-437A-91ED-9802F97A2E75";
        public static string ID_CLS = "C4422999-1A37-4975-A998-F82DF9373EF3";
        public static string ANH = "BDC1F900-D71E-4EEC-8B88-26E1309A1CE3";
        public static string VIDEO = "3C3F9243-1F2A-46EC-B119-C4F8990E8BA8";
    }
    public class CLoaiCLS
    {
        public const string SINH_HOA = "SINH HÓA";
        public const string MA_SINH_HOA = "SH";
        public const string SIEU_AM = "SIEU_AM";
        public const string XET_NGHIEM = "XET_NGHIEM";
        public const string X_QUANG = "X_QUANG";
        public const string CAP_CUU = "CAP_CUU";
    }
    public class MA_BENHNHAN {
        public static string MA_BN = "MA_BN";
    }
    public class CUserGroup
    {
        public static string BenhNhan = "303e3414-503b-40f7-bb48-a04d034ad7cb";
        public static string CanBo = "9bf9232e-1844-4e82-8821-037692cb51be";
    }

    public class CLoaiResource
    {
        public static string ANH = "ANH";
        public static string VIDEO = "VIDEO";
    }

    public class CTenBenhVien {
        public static string PhongKhamDaKhoaYenPhong = "Phòng khám đa khoa Yên Phong";
    }

    public class CTemPlate {
        public static string PhieuChiDinhCLS = "phieu_chi_dinh_cls.html";
        public static string PhieuChiDinhSinhHoaMau = "";
    }

    public class CMaLoaiKhamBenh {
        public static string BHYT = "BH";
        public static string DV = "DV";
    }
}
