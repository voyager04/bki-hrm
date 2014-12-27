using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Model
{
    public class TuDienModel : BaseModel
    {
        public Guid ID_LOAI_TU_DIEN { get; set; }
        public string LOAI_TU_DIEN { get; set; }
        public string MA_TU_DIEN { get; set; }
        public string TEN { get; set; }
        public string TEN_NGAN { get; set; }
        public int UU_TIEN { get; set; }
    }
}
