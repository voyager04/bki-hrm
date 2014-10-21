using System;
using System.Collections.Generic;
using System.Text;

namespace BKI_HRM.US {

    public class CONST_HRM {
        public const string KHONG_CO_DU_LIEU = "";
        public const decimal ID_TAT_CA = -1;
        public const string MA_TAT_CA = "-1";
        public const string TAT_CA = "Tất cả";
    }

    public class MA_LOAI_TU_DIEN {
        public const string TRANG_THAI_CHUC_VU = "TRANG_THAI_CHUC_VU";
        public const string TRANG_THAI_LAO_DONG = "TRANG_THAI_LAO_DONG";
        public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
        public const string LOAI_DON_VI = "LOAI_DON_VI";
        public const string CAP_DON_VI = "CAP_DON_VI";
        public const string LOAI_QUYET_DINH = "LOAI_QUYET_DINH";
        public const string NGACH = "NGACH";
        public const string LOAI_CHUC_VU = "LOAI_CHUC_VU";
        public const string TRANG_THAI_HOP_DONG = "TRANG_THAI_HOP_DONG";
        public const string TRANG_THAI_DU_AN = "TRANG_THAI_DU_AN";
        public const string MA_HOP_DONG = "MA_HOP_DONG";
        public const string DANH_HIEU = "DANH_HIEU";
        public const string CO_CHE = "CO_CHE";
        public const string LOAI_DU_AN = "LOAI_DU_AN";
        public const string MA_QUYET_DINH = "MA_QUYET_DINH";
        public const string DIA_BAN = "DIA_BAN";
    }
    public class LOAI_TU_DIEN
    {
        public const decimal id_loai_qd = 3;  
    }
    public class TU_DIEN {
        public const string Q1 = "1";
        public const string Q2 = "2";
        public const string Q3 = "3";
        public const string Q4 = "8";
        public const string KHOI = "641";
        public const string PHONG = "642";
        public const string QD_BO_NHIEM = "643";
        public const string QD_CHINH_THUC = "649";
        public const string QD_DIEU_CHUYEN = "646";
        public const string QD_KIEM_NHIEM = "645";
        public const string QD_MIEN_NHIEM = "644";
        public const string QD_NGHI_VIEC = "647";
        public const string QD_THU_VIEC = "648";
        public const string QD_CONG_TAC = "715";
        public const string CHUC_VU_CU = "652";
        public const string CHUC_VU_HIEN_TAI = "650";
        public const string KIEM_NHIEM = "651";
        public const string CHINH_THUC = "654";
        public const string NGHI_KHAC = "658";
        public const string NGHI_KHONG_LUONG = "657";
        public const string NGHI_THAI_SAN = "656";
        public const string NGHI_VIEC = "655";
        public const string THU_VIEC = "653";
        public const string QUAN_LY_HOC_TAP = "669";
        public const string TONG_HOP = "667";
        public const string TU_VAN_TUYEN_SINH = "668";
        public const string VHOL = "670";
        public const string VHTT = "671";
        public const string QD_THANH_LAP_DU_AN = "679";
    }

    public class CAP_DON_VI {
        public const decimal TO_HOP = 0;
        public const decimal CONG_TY = 1;
        public const decimal KHOI = 2;
        public const decimal TRUNG_TAM = 3;
        public const decimal PHONG_BAN = 4;
    }
    public class LOAI_CHUC_VU
    {
        public const decimal CHUC_VU_CHINH = 650;
        public const decimal CHUC_VU_KIEM_NHIEM = 651;
    }
    public class PHAP_NHAN
    {
        public const decimal TU = 1;
        public const decimal TE = 2;
        public const decimal TEG = 3;
        public const decimal Tatca = -1;
    }
    public class CHON_QUYET_DINH
    {
        public const decimal TAT_CA = -1;
        public const decimal BO_NHIEM = 1;
        public const decimal MIEN_NHIEM = 2;
        public const decimal DU_AN = 679;
        public const decimal CONG_TAC = 715;
        public const decimal DIEU_CHUYEN = 646;
        public const decimal TRANG_THAI_LD = 6;
    }
    public class SESSION
    {
        public const string UserFullName = "UserFullName";
        public const string UserName = "UserName";
        public const string UserID = "UserID";
        public const string AccounLoginYN = "AccounLoginYN";
        public const string UserQuyen = "user_quyen";
        public const string Allow2DeleteDataYN = "Allow2DeleteDataYN";
        public const string NHOM_PHAN_QUYEN = "NHOM_PHAN_QUYEN";
    }
    public class ID_USER_GROUP
    {
        public const decimal ADMIN = 1;
        public const decimal NHAN_DAN = 2;
        public const decimal QUAN_LY = 3;
    }
}
