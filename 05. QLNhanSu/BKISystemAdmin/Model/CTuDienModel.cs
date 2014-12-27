using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKISystemAdmin.Model
{
    public class CTuDienModel
    {
        public Guid ID { get; set; }
        public Guid ID_LOAI_TU_DIEN { get; set; }
        public string MA_TU_DIEN { get; set; }
        public string TEN { get; set; }
        public string TEN_NGAN { get; set; }
        public string GHI_CHU { get; set; }
        public decimal UU_TIEN { get; set; }
    }
}
