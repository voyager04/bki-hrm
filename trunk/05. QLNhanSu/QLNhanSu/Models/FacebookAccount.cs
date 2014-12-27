using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNhanSu.Models
{
    public class FacebookAccount
    {
        public Guid ID { get; set; }
        public string MA_NHAN_VIEN { get; set; }
        public string ID_FB { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public Guid ID_USER_GROUP { get; set; }
        public string USER_GROUP { get; set; }
        public string AVATAR { get; set; }
    }
}