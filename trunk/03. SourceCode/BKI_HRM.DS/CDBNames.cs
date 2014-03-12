namespace BKI_HRM.DS.CDBNames
{
    public enum e_loai_tu_dien
    {
        PHAN_QUYEN = 1
       ,
        DIA_DIEM_QUAN_LY = 2
            ,
        DON_VI_QUAN_LY_CHINH = 3
            ,
        LEVEL_GIANG_VIEN = 4
            ,
        LOAI_HOP_DONG = 5
            ,
        NGANH_DAO_TAO = 6
            ,
        DON_VI_TINH = 7
            ,
        TRANG_THAI_HOP_DONG_KHUNG = 8
            ,
        TRANG_THAI_GIANG_VIEN = 9
            ,
        MA_TAN_SUAT = 10
            ,
        HOC_HAM = 11
            ,
        HOC_VI = 12
            ,
        HINH_THUC_CONG_TAC = 13
            ,
        TRANG_THAI_DOT_THANH_TOAN = 14
            ,
        TRANG_THAI_THANH_TOAN = 15
            ,
        TRANG_THAI_TT_HOP_DONG = 17
            ,
        VAI_TRO_GV = 18
            ,
        LOAI_SU_KIEN = 19
            ,
        TRANG_THAI_SU_KIEN = 20
            ,
        TRANG_THAI_CONG_VIEC_GV = 21
            ,
        TRANG_THAI_HO_SO_GV = 23
            ,
        TRANG_THAI_SU_KIEN_GV = 24
            ,
        LOAI_HO_SO_GV_CM = 25
            ,
        LOAI_HO_SO_GV_HD = 26
            , DV_TO_CHUC_SK = 27
    }

    public class LOAI_TU_DIEN
    {
        public const string PHAN_QUYEN = "PHAN_QUYEN";
        public const string DIA_DIEM_QUAN_LY = "DIA_DIEM_QUAN_LY";
        public const string DON_VI_QUAN_LY_CHINH = "DON_VI_QUAN_LY_CHINH";
        public const string LEVEL_GIANG_VIEN = "LEVEL_GIANG_VIEN";
        public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
        public const string TRANG_THAI_HOP_DONG_KHUNG = "TRANG_THAI_HOP_DONG_KHUNG";
        public const string TRANG_THAI_GIANG_VIEN = "TRANG_THAI_GIANG_VIEN";
        public const string HINH_THUC_CONG_TAC = "HINH_THUC_CONG_TAC";
        public const string TRANG_THAI_DOT_THANH_TOAN = "TRANG_THAI_DOT_THANH_TOAN";
        public const string TRANG_THAI_THANH_TOAN = "TRANG_THAI_THANH_TOAN";
        public const string TRANG_THAI_SU_KIEN = "TRANG_THAI_SU_KIEN";
        public const string TRANG_THAI_CONG_VIEC_GV = "TRANG_THAI_CONG_VIEC_GV";
        public const string TRANG_THAI_SU_KIEN_GV = "TRANG_THAI_SU_KIEN_GV";

    }

    public enum e_user_group
    {
        TESTER = 1
        ,
        PM_TD = 2
            ,
        TRUONG_NHOM_PO = 3
            ,
        PO = 4
            ,
        ADMIN = 5
            , GIANG_VIEN = 6
    }

    public class V_DM_TRANG_THAI_UNG_VIEN
    {
        public const string ID = "ID";
        public const string ID_TRANG_THAI_CAP_TREN = "ID_TRANG_THAI_CAP_TREN";
        public const string MA_TRANG_THAI_CAP_TREN = "MA_TRANG_THAI_CAP_TREN";
        public const string MA_TRANG_THAI = "MA_TRANG_THAI";
        public const string DINH_NGHIA = "DINH_NGHIA";
        public const string DAU_HIEU = "DAU_HIEU";
        public const string VIEC_CAN_LAM = "VIEC_CAN_LAM";
    }
    public class HT_PHAN_QUYEN_HE_THONG {
        public const string ID = "ID";
        public const string MA_PHAN_QUYEN = "MA_PHAN_QUYEN";
        public const string GHI_CHU = "GHI_CHU";
        public const string LOAI_PHAN_QUYEN = "LOAI_PHAN_QUYEN";
    }
    public class HT_PHAN_QUYEN_CHO_NHOM {
        public const string ID = "ID";
        public const string ID_NHOM_NGUOI_SU_DUNG = "ID_NHOM_NGUOI_SU_DUNG";
        public const string ID_PHAN_QUYEN_HE_THONG = "ID_PHAN_QUYEN_HE_THONG";
    }

    public class HT_NHOM_NGUOI_SU_DUNG {
        public const string ID = "ID";
        public const string MA_NHOM = "MA_NHOM";
        public const string GHI_CHU = "GHI_CHU";
        public const string TRANG_THAI_NHOM = "TRANG_THAI_NHOM";
        public const string ID_INPUTED_BY = "ID_INPUTED_BY";
        public const string INPUTED_DATE = "INPUTED_DATE";
        public const string ID_LAST_UPDATED_BY = "ID_LAST_UPDATED_BY";
        public const string LAS_UPDATED_DATE = "LAS_UPDATED_DATE";
    }

    public class SU_KIEN
    {
        public const string ID = "ID";
        public const string ID_LOAI_SU_KIEN = "ID_LOAI_SU_KIEN";
        public const string TEN_SU_KIEN = "TEN_SU_KIEN";
        public const string NGAY_DIEN_RA = "NGAY_DIEN_RA";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string MO_TA = "MO_TA";
    }

    public class CM_DM_TU_DIEN
    {
        public const string ID = "ID";
        public const string MA_TU_DIEN = "MA_TU_DIEN";
        public const string TEN_NGAN = "TEN_NGAN";
        public const string TEN = "TEN";
        public const string ID_LOAI_TU_DIEN = "ID_LOAI_TU_DIEN";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class CM_DM_LOAI_TD
    {
        public const string ID = "ID";
        public const string MA_LOAI = "MA_LOAI";
        public const string TEN_LOAI = "TEN_LOAI";
    }

    public class HT_NGUOI_SU_DUNG
    {
        public const string ID = "ID";
        public const string TEN_TRUY_CAP = "TEN_TRUY_CAP";
        public const string TEN = "TEN";
        public const string MAT_KHAU = "MAT_KHAU";
        public const string NGAY_TAO = "NGAY_TAO";
        public const string NGUOI_TAO = "NGUOI_TAO";
        public const string TRANG_THAI = "TRANG_THAI";
        public const string BUILT_IN_YN = "BUILT_IN_YN";
        public const string ID_USER_GROUP = "ID_USER_GROUP";
        public const string ID_TRAINING_PROJECT = "ID_TRAINING_PROJECT";
    }

    public class HT_CHUC_NANG
    {
        public const string ID = "ID";
        public const string TEN_CHUC_NANG = "TEN_CHUC_NANG";
        public const string URL_FORM = "URL_FORM";
        public const string TRANG_THAI_YN = "TRANG_THAI_YN";
        public const string VI_TRI = "VI_TRI";
        public const string CHUC_NANG_PARENT_ID = "CHUC_NANG_PARENT_ID";
        public const string HIEN_THI_YN = "HIEN_THI_YN";
    }
    public class HT_QUYEN_GROUP
    {
        public const string ID = "ID";
        public const string ID_USER_GROUP = "ID_USER_GROUP";
        public const string ID_QUYEN = "ID_QUYEN";
    }
    public class HT_USER_GROUP
    {
        public const string ID = "ID";
        public const string USER_GROUP_NAME = "USER_GROUP_NAME";
        public const string DESCRIPTION = "DESCRIPTION";
    }

    public class V_HT_USER_DV_QUAN_LY
    {
        public const string ID = "ID";
        public const string ID_NGUOI_SU_DUNG = "ID_NGUOI_SU_DUNG";
        public const string TEN_NGUOI_SU_DUNG = "TEN_NGUOI_SU_DUNG";
        public const string ID_DV_QUAN_LY = "ID_DV_QUAN_LY";
        public const string TEN_DV_QUAN_LY = "TEN_DV_QUAN_LY";
    }
    /// <summary>
    /// 
    /// </summary>
    public class CM_COMPANY_INFO
    {
        public const string ID = "ID";
        public const string COMPANY_NAME = "COMPANY_NAME";
        public const string COMPANY_ADDRESS = "COMPANY_ADDRESS";
    }

    public class V_GD_QUA_TRINH_LAM_VIEC
    {
        public const string MA_NV = "MA_NV";
        public const string HO_DEM = "HO_DEM";
        public const string TEN = "TEN";
        public const string MA_CV = "MA_CV";
        public const string TEN_CV = "TEN_CV";
        public const string ID_NGACH = "ID_NGACH";
        public const string NGACH = "NGACH";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string MA_DON_VI = "MA_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
        public const string ID_CAP_DON_VI = "ID_CAP_DON_VI";
        public const string CAP_DON_VI = "CAP_DON_VI";
        public const string ID_LOAI_DON_VI = "ID_LOAI_DON_VI";
        public const string LOAI_DON_VI = "LOAI_DON_VI";
        public const string ID_DON_VI_CAP_TREN = "ID_DON_VI_CAP_TREN";
        public const string DIA_BAN = "DIA_BAN";
        public const string MA_QUYET_DINH = "MA_QUYET_DINH";
        public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
        public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
        public const string ID_TRANG_THAI_CV = "ID_TRANG_THAI_CV";
        public const string TRANG_THAI_CV = "TRANG_THAI_CV";
        public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
        public const string NGAY_KET_THUC = "NGAY_KET_THUC";
        public const string ID_NHAN_SU = "ID_NHAN_SU";
        public const string ID = "ID";
        public const string ROWNUM = "ROWNUM";
    }

    public class V_GD_TRANG_THAI_LAO_DONG {
        public const string MA_NV = "MA_NV";
        public const string HO_DEM = "HO_DEM";
        public const string TEN = "TEN";
        public const string ID_TRANG_LAO_DONG = "ID_TRANG_LAO_DONG";
        public const string TRANG_THAI_LAO_DONG = "TRANG_THAI_LAO_DONG";
        public const string MA_QUYET_DINH = "MA_QUYET_DINH";
        public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
        public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
        public const string ID_LOAI_QD = "ID_LOAI_QD";
        public const string LOAI_QUYET_DINH = "LOAI_QUYET_DINH";
        public const string TRANG_THAI_HIEN_TAI = "TRANG_THAI_HIEN_TAI";
        public const string ID = "ID";
        public const string ID_NHAN_SU = "ID_NHAN_SU";
        public const string ROWNUM = "ROWNUM";
    }

    public class V_GD_HOP_DONG_LAO_DONG
    {
        public const string MA_NV = "MA_NV";
        public const string HO_DEM = "HO_DEM";
        public const string TEN = "TEN";
        public const string MA_HOP_DONG = "MA_HOP_DONG";
        public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
        public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
        public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
        public const string NGAY_HET_HAN = "NGAY_HET_HAN";
        public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
        public const string CHUC_VU_NGUOI_KY = "CHUC_VU_NGUOI_KY";
        public const string NGUOI_KY = "NGUOI_KY";
        public const string NGAY_KY_HOP_DONG = "NGAY_KY_HOP_DONG";
        public const string ID_PHAP_NHAN = "ID_PHAP_NHAN";
        public const string MA_PHAP_NHAN = "MA_PHAP_NHAN";
        public const string TEN_PHAP_NHAN = "TEN_PHAP_NHAN";
    }

    public class GD_HOP_DONG
    {
        public const string ID = "ID";
        public const string MA_HOP_DONG = "MA_HOP_DONG";
        public const string ID_LOAI_HOP_DONG = "ID_LOAI_HOP_DONG";
        public const string ID_NHAN_SU = "ID_NHAN_SU";
        public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
        public const string NGAY_HET_HAN = "NGAY_HET_HAN";
        public const string LINK = "LINK";
        public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
        public const string CHUC_VU_NGUOI_KY = "CHUC_VU_NGUOI_KY";
        public const string NGUOI_KY = "NGUOI_KY";
        public const string NGAY_KY_HOP_DONG = "NGAY_KY_HOP_DONG";
        public const string ID_PHAP_NHAN = "ID_PHAP_NHAN";
    }

    public class DM_DON_VI {
        public const string ID = "ID";
        public const string MA_DON_VI = "MA_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
        public const string TEN_TA = "TEN_TA";
        public const string ID_CAP_DON_VI = "ID_CAP_DON_VI";
        public const string ID_DON_VI_CAP_TREN = "ID_DON_VI_CAP_TREN";
        public const string ID_LOAI_DON_VI = "ID_LOAI_DON_VI";
        public const string DIA_BAN = "DIA_BAN";
        public const string TRANG_THAI = "TRANG_THAI";
        public const string TU_NGAY = "TU_NGAY";
    }
    public class DM_NHAN_SU
    {
        public const string ID = "ID";
        public const string MA_NV = "MA_NV";
        public const string HO_DEM = "HO_DEM";
        public const string TEN = "TEN";
        public const string GIOI_TINH = "GIOI_TINH";
        public const string NGAY_SINH = "NGAY_SINH";
        public const string NOI_SINH = "NOI_SINH";
        public const string ANH = "ANH";
        public const string NGUYEN_QUAN = "NGUYEN_QUAN";
        public const string CMND = "CMND";
        public const string NGAY_CAP_CMND = "NGAY_CAP_CMND";
        public const string NOI_CAP_CMND = "NOI_CAP_CMND";
        public const string TRINH_DO = "TRINH_DO";
        public const string NOI_DAO_TAO = "NOI_DAO_TAO";
        public const string CHUYEN_NGANH = "CHUYEN_NGANH";
        public const string NAM_TOT_NGHIEP = "NAM_TOT_NGHIEP";
        public const string EMAIL_CQ = "EMAIL_CQ";
        public const string EMAIL_CA_NHAN = "EMAIL_CA_NHAN";
        public const string DT_NHA = "DT_NHA";
        public const string DI_DONG = "DI_DONG";
        public const string CHO_O = "CHO_O";
        public const string HO_KHAU = "HO_KHAU";
        public const string NGUOI_LIEN_HE = "NGUOI_LIEN_HE";
        public const string DI_DONG_LIEN_HE = "DI_DONG_LIEN_HE";
        public const string QUAN_HE = "QUAN_HE";
        public const string TON_GIAO = "TON_GIAO";
        public const string DAN_TOC = "DAN_TOC";
        public const string MA_SO_THUE = "MA_SO_THUE";
        public const string TRANG_THAI = "TRANG_THAI";
    }

    public class V_DM_DON_VI {
        public const string ID = "ID";
        public const string ID_DON_VI_CAP_TREN = "ID_DON_VI_CAP_TREN";
        public const string ID_CAP_DON_VI = "ID_CAP_DON_VI";
        public const string ID_LOAI_DON_VI = "ID_LOAI_DON_VI";
        public const string MA_DON_VI_CAP_TREN = "MA_DON_VI_CAP_TREN";
        public const string TEN_DON_VI_CAP_TREN = "TEN_DON_VI_CAP_TREN";
        public const string TEN_TIENG_ANH_DON_VI_CAP_TREN = "TEN_TIENG_ANH_DON_VI_CAP_TREN";
        public const string MA_DON_VI = "MA_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
        public const string TEN_TIENG_ANH = "TEN_TIENG_ANH";
        public const string CAP_DON_VI = "CAP_DON_VI";
        public const string LOAI_DON_VI = "LOAI_DON_VI";
        public const string TU_NGAY = "TU_NGAY";
        public const string DIA_BAN = "DIA_BAN";
        public const string TRANG_THAI = "TRANG_THAI";
    }

    public class DM_PHAP_NHAN
    {
        public const string ID = "ID";
        public const string MA_PHAP_NHAN = "MA_PHAP_NHAN";
        public const string TEN_PHAP_NHAN = "TEN_PHAP_NHAN";
        public const string MA_SO_THUE = "MA_SO_THUE";
        public const string MA_DK_KINH_DOANH = "MA_DK_KINH_DOANH";
        public const string NGAY_DK_KINH_DOANH = "NGAY_DK_KINH_DOANH";
        public const string DIA_CHI = "DIA_CHI";
        public const string NGUOI_DAI_DIEN = "NGUOI_DAI_DIEN";
    }


   public class DM_CHUC_VU
   {
       public const string ID = "ID";
       public const string MA_CV = "MA_CV";
       public const string TEN_CV = "TEN_CV";
       public const string TEN_CV_TA = "TEN_CV_TA";
       public const string TRANG_THAI = "TRANG_THAI";
       public const string NGAY_AP_DUNG = "NGAY_AP_DUNG";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
   }
   public class V_DM_CHUC_VU
   {
       public const string ID = "ID";
       public const string MA_CV = "MA_CV";
       public const string TEN_CV = "TEN_CV";
       public const string TEN_CV_TA = "TEN_CV_TA";
       public const string ID_NGACH = "ID_NGACH";
       public const string TEN = "TEN";
       public const string TRANG_THAI = "TRANG_THAI";
       public const string NGAY_AP_DUNG = "NGAY_AP_DUNG";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string TRANG_THAI_SU_DUNG = "TRANG_THAI_SU_DUNG";
   }

   public class V_DM_DU_AN_QUYET_DINH_TU_DIEN
   {
       public const string ID = "ID";
       public const string MA_DU_AN = "MA_DU_AN";
       public const string TEN_DU_AN = "TEN_DU_AN";
       public const string TRANG_THAI = "TRANG_THAI";
       public const string LOAI_DU_AN = "LOAI_DU_AN";
       public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string NOI_DUNG = "NOI_DUNG";
       public const string CO_CHE = "CO_CHE";
       public const string MA_QUYET_DINH = "MA_QUYET_DINH";
   }

   public class V_DM_NHAN_SU_DU_AN
   {
       public const string ID_DU_AN = "ID_DU_AN";
       public const string MA_DU_AN = "MA_DU_AN";
       public const string TEN_DU_AN = "TEN_DU_AN";
       public const string ID_NHAN_SU = "ID_NHAN_SU";
       public const string MA_NV = "MA_NV";
       public const string HO_DEM = "HO_DEM";
       public const string TEN = "TEN";
       public const string MA_CV = "MA_CV";
       public const string TEN_CV = "TEN_CV";
       public const string MA_DON_VI = "MA_DON_VI";
       public const string TEN_DON_VI = "TEN_DON_VI";
       public const string VI_TRI = "VI_TRI";
       public const string THOI_DIEM_TG = "THOI_DIEM_TG";
       public const string THOI_DIEM_KT = "THOI_DIEM_KT";
       public const string THOI_GIAN_TG = "THOI_GIAN_TG";
       public const string DANH_HIEU = "DANH_HIEU";
       public const string ID = "ID";
   }
   public class V_BAO_CAO_NHAN_SU {
       public const string ID = "ID";
       public const string MA_NV = "MA_NV";
       public const string HO_DEM = "HO_DEM";
       public const string TEN = "TEN";
       public const string GIOI_TINH = "GIOI_TINH";
       public const string NGAY_SINH = "NGAY_SINH";
       public const string NOI_SINH = "NOI_SINH";
       public const string NGUYEN_QUAN = "NGUYEN_QUAN";
       public const string CMND = "CMND";
       public const string NGAY_CAP_CMND = "NGAY_CAP_CMND";
       public const string NOI_CAP_CMND = "NOI_CAP_CMND";
       public const string TRINH_DO = "TRINH_DO";
       public const string NOI_DAO_TAO = "NOI_DAO_TAO";
       public const string CHUYEN_NGANH = "CHUYEN_NGANH";
       public const string NAM_TOT_NGHIEP = "NAM_TOT_NGHIEP";
       public const string EMAIL_CQ = "EMAIL_CQ";
       public const string EMAIL_CA_NHAN = "EMAIL_CA_NHAN";
       public const string DT_NHA = "DT_NHA";
       public const string DI_DONG = "DI_DONG";
       public const string CHO_O = "CHO_O";
       public const string HO_KHAU = "HO_KHAU";
       public const string NGUOI_LIEN_HE = "NGUOI_LIEN_HE";
       public const string DI_DONG_LIEN_HE = "DI_DONG_LIEN_HE";
       public const string QUAN_HE = "QUAN_HE";
       public const string TON_GIAO = "TON_GIAO";
       public const string DAN_TOC = "DAN_TOC";
       public const string MA_SO_THUE = "MA_SO_THUE";
       public const string TRANG_THAI = "TRANG_THAI";
   }
   public class V_DM_DU_LIEU_NHAN_VIEN
   {
       public const string ID = "ID";
       public const string MA_NV = "MA_NV";
       public const string HO_DEM = "HO_DEM";
       public const string TEN = "TEN";
       public const string GIOI_TINH = "GIOI_TINH";
       public const string NGAY_SINH = "NGAY_SINH";
       public const string TRINH_DO = "TRINH_DO";
       public const string ID_CHUC_VU = "ID_CHUC_VU";
       public const string MA_CV = "MA_CV";
       public const string TEN_CV = "TEN_CV";
       public const string ID_TRANG_THAI_CV = "ID_TRANG_THAI_CV";
       public const string TRANG_THAI_CV = "TRANG_THAI_CV";
       public const string TY_LE_THAM_GIA = "TY_LE_THAM_GIA";
       public const string ID_DON_VI = "ID_DON_VI";
       public const string MA_DON_VI = "MA_DON_VI";
       public const string TEN_DON_VI = "TEN_DON_VI";
       public const string ID_DON_VI_CAP_TREN = "ID_DON_VI_CAP_TREN";
       public const string ID_LOAI_DON_VI = "ID_LOAI_DON_VI";
       public const string LOAI_DON_VI = "LOAI_DON_VI";
       public const string ID_CAP_DON_VI = "ID_CAP_DON_VI";
       public const string CAP_DON_VI = "CAP_DON_VI";
       public const string DIA_BAN = "DIA_BAN";
       public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string ID_TRANG_LAO_DONG = "ID_TRANG_LAO_DONG";
       public const string TRANG_THAI_LAO_DONG = "TRANG_THAI_LAO_DONG";
       public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
       public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
       public const string TRANG_THAI_HIEN_TAI = "TRANG_THAI_HIEN_TAI";
   }



   public class gd_chi_tiet_du_an
   {
       public const string ID = "ID";
       public const string ID_DU_AN = "ID_DU_AN";
       public const string ID_NHAN_SU = "ID_NHAN_SU";
       public const string ID_VI_TRI = "ID_VI_TRI";
       public const string ID_DANH_HIEU = "ID_DANH_HIEU";
       public const string THOI_DIEM_TG = "THOI_DIEM_TG";
       public const string THOI_DIEM_KT = "THOI_DIEM_KT";
       public const string THOI_GIAN_TG = "THOI_GIAN_TG";
   }
   public class V_DM_QUYET_DINH
   {
       public const string ID = "ID";
       public const string MA_QUYET_DINH = "MA_QUYET_DINH";
       public const string ID_LOAI_QD = "ID_LOAI_QD";
       public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
       public const string NGAY_KY = "NGAY_KY";
       public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
       public const string NOI_DUNG = "NOI_DUNG";
       public const string LINK = "LINK";
       public const string TEN = "TEN";
   }
   public class GD_CHI_TIET_TRANG_THAI_LD
   {
       public const string ID = "ID";
       public const string ID_NHAN_SU = "ID_NHAN_SU";
       public const string ID_TRANG_LAO_DONG = "ID_TRANG_LAO_DONG";
       public const string ID_QUYET_DINH = "ID_QUYET_DINH";
       public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
       public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
       public const string TRANG_THAI_HIEN_TAI = "TRANG_THAI_HIEN_TAI";
   }

   public class V_GD_BAO_CAO_DU_AN_2
   {
       public const string TEN_DU_AN = "TEN_DU_AN";
       public const string MA_DU_AN = "MA_DU_AN";
       public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
       public const string TRUONG_DU_AN = "TRUONG_DU_AN";
       public const string SL_THANH_VIEN = "SL_THANH_VIEN";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string CO_CHE = "CO_CHE";
       public const string GHI_CHU = "GHI_CHU";
   }
   public class GD_CHI_TIET_CHUC_VU
   {
       public const string ID = "ID";
       public const string ID_NHAN_SU = "ID_NHAN_SU";
       public const string ID_CHUC_VU = "ID_CHUC_VU";
       public const string ID_DON_VI = "ID_DON_VI";
       public const string ID_QUYET_DINH = "ID_QUYET_DINH";
       public const string ID_TRANG_THAI_CV = "ID_TRANG_THAI_CV";
       public const string TY_LE_THAM_GIA = "TY_LE_THAM_GIA";
       public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
   }

   public class V_GD_CHI_TIET_CAP_BAC {
       public const string ID_NHAN_SU = "ID_NHAN_SU";
       public const string ID = "ID";
       public const string MA_NV = "MA_NV";
       public const string HO_DEM = "HO_DEM";
       public const string TEN = "TEN";
       public const string NGAY_BAT_DAU = "NGAY_BAT_DAU";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string TRANG_THAI_CB = "TRANG_THAI_CB";
       public const string MA_CAP = "MA_CAP";
       public const string MA_BAC = "MA_BAC";
       public const string MA_QUYET_DINH = "MA_QUYET_DINH";
       public const string NGAY_CO_HIEU_LUC = "NGAY_CO_HIEU_LUC";
       public const string NGAY_HET_HIEU_LUC = "NGAY_HET_HIEU_LUC";
       public const string MA_CAP_BAC = "MA_CAP_BAC";
   }

   public class DM_CAP_BAC {
       public const string ID = "ID";
       public const string MA_CAP = "MA_CAP";
       public const string MA_BAC = "MA_BAC";
       public const string TRANG_THAI = "TRANG_THAI";
       public const string NGAY_AP_DUNG = "NGAY_AP_DUNG";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
   }

   public class V_DM_CAP_BAC {
       public const string ID = "ID";
       public const string MA_CAP = "MA_CAP";
       public const string MA_BAC = "MA_BAC";
       public const string TRANG_THAI = "TRANG_THAI";
       public const string NGAY_AP_DUNG = "NGAY_AP_DUNG";
       public const string NGAY_KET_THUC = "NGAY_KET_THUC";
       public const string MA_CAP_BAC = "MA_CAP_BAC";
   }

}
