using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhanSu.Models
{
    public class ChucVuModel
    {
        public string TU_NGAY { get; set; }
        public string DEN_NGAY { get; set; }
        public string MA_CHUC_VU { get; set; }
        public string TEN_CHUC_VU { get; set; }
        public string TRANG_THAI_CHUC_VU { get; set; }
        public decimal? TY_LE_THAM_GIA { get; set; }
        public string MA_DON_VI { get; set; }
        public string TEN_DON_VI { get; set; }
        public string CAP_DON_VI { get; set; }
        public string MA_QUYET_DINH { get; set; }
        public string NGAY_CO_HIEU_LUC { get; set; }
        public string NGAY_HET_HIEU_LUC { get; set; }
    }
}