using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKISystemAdmin.Model
{
    public class CChucNangModel : BaseModel
    {
        public int VI_TRI { get; set; }
        public bool TRANG_THAI_YN { get; set; }
        public bool HIEN_THI_YN { get; set; }
        public IEnumerable<CChucNangModel> CHUC_NANG_CON { get; set; }
        public CChucNangModel CHUC_NANG_CHA { get; set; }
        public bool HAS_LINK { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string ACTIVITY_NAME { get; set; }
        public string ICON_CLASS { get; set; }
        public string HIEN_THI_MENU { get; set; }

        public Guid ID_HT_USER_GROUP { get; set; }
        public Guid? ID_HT_CONTROLLER { get; set; }
    }
}
