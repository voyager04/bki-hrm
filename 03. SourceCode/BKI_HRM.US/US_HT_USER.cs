using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BKI_HRM.DS;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;

namespace BKI_HRM.US
{
    public class US_HT_USER
    {
        public Guid ID { get; set; }
        public string BHYT { get; set; }
        public string CMND { get; set; }
        public string MSBN { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public bool IS_ACTIVE { get; set; }
        public Guid ID_USER_GROUP { get; set; }
    }
}