using System;

namespace BKISystemAdmin.Model
{
    public class CUserModel
    {
        public int ID { get; set; }
        public string TEN_TRUY_CAP { get; set; }
        public string TEN { get; set; }
        public string MAT_KHAU { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public string NGUOI_TAO { get; set; }
        public string TRANG_THAI { get; set; }
        public bool BUILT_IN_YN { get; set; }
        public int ID_USER_GROUP_WEB { get; set; }
        public string USER_GROUP_WEB { get; set; }
    }
}