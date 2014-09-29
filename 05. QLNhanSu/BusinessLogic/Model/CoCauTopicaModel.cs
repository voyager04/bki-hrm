using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class CoCauTopicaModel
    {
        public int ID { get; set; }
        public int ID_DON_VI_CAP_TREN { get; set; }
        public int ID_CAP_DON_VI { get; set; }
        public int ID_LOAI_DON_VI { get; set; }
        public string MA_DON_VI_CAP_TREN { get; set; }
        public string TEN_DON_VI_CAP_TREN { get; set; }
        public string TEN_TIENG_ANH_DON_VI_CAP_TREN { get; set; }
        public string MA_DON_VI { get; set; }
        public string TEN_DON_VI { get; set; }
        public string TEN_TIENG_ANH { get; set; }
        public string CAP_DON_VI { get; set; }
        public string LOAI_DON_VI { get; set; }
        public DateTime TU_NGAY { get; set; }
        public string DIA_BAN { get; set; }
        public string TRANG_THAI { get; set; }
        public string TRANG_THAI_YN { get; set; }
        public int SO_LUONG { get; set; }
        public int ID_LEVEL { get; set; }
        public int ID_PHAP_NHAN { get; set; }
        public string MA_PHAP_NHAN { get; set; }
        public string TEN_PHAP_NHAN { get; set; }
    }
}
