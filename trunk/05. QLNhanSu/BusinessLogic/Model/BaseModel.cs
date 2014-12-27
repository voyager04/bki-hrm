using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataAccess;

namespace BusinessLogic.Model
{
    public abstract class BaseModel
    {
        public virtual Guid ID { get; set; }
        public string NGUOI_TAO { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public string NGUOI_SUA { get; set; }
        public DateTime? NGAY_SUA { get; set; }
        public bool DA_XOA { get; set; }
        public virtual EDataState State { get; set; }
    }
}
