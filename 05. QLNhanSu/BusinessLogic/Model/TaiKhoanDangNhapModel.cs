using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BKISystemAdmin.Model;

namespace BusinessLogic.Model
{
    public class UserModel : BaseModel
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string CMND { get; set; }
        public string BHYT { get; set; }
        public string MSBN { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public string DISPLAY_NAME { get; set; }
        public Guid ID_USER_GROUP { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
