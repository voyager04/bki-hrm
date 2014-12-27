using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Model
{
    public class UserModel : BaseModel
    {
        public string BHYT { get; set; }
        public string CMND { get; set; }
        public string MSBH { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public string IS_ACTIVE { get; set; }
        public Guid ID_USER_GROUP { get; set; }
    }
}
