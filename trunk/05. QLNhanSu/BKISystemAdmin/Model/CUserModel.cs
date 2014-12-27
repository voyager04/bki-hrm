using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKISystemAdmin.Model
{
    public class CUserModel
    {
        public Guid ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string HO_TEN { get; set; }
        public string PHONG { get; set; }
        public string SDT { get; set; }
        public Guid ID_USER_GROUP { get; set; }
        public string USER_GROUP { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
