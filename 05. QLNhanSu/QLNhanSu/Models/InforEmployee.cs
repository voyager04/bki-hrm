using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhanSu.Models
{
    public class InforEmployee
    {
        public string HO_TEN { get; set; }
        public string GIOI_TINH { get; set; }
        public string NGAY_SINH { get; set; }
        public string NOI_SINH { get; set; }
        public string NGUYEN_QUAN { get; set; }
        public string DK_HO_KHAU { get; set; }
        public string DIA_CHI { get; set; }
        public string CMTND { get; set; }
        public string NGAY_CAP { get; set; }
        public string NOI_CAP { get; set; }
        public string MA_SO_THUE { get; set; }
        public string DTDD { get; set; }
        public string DT_NHA_RIENG { get; set; }
        public string EMAIL_CO_QUAN { get; set; }
        public string EMAIL_CA_NHAN { get; set; }
        public string TRANG_THAI_LAO_DONG { get; set; }
        public List<ChucVuModel> LIST_CHUC_VU { get; set; }
    }
}