//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_DU_AN
    {
        public DM_DU_AN()
        {
            this.GD_CHI_TIET_DU_AN = new HashSet<GD_CHI_TIET_DU_AN>();
            this.GD_QUYET_DINH_DU_AN = new HashSet<GD_QUYET_DINH_DU_AN>();
        }
    
        public decimal ID { get; set; }
        public string MA_DU_AN { get; set; }
        public string TEN_DU_AN { get; set; }
        public decimal ID_TRANG_THAI { get; set; }
        public decimal ID_LOAI_DU_AN { get; set; }
        public System.DateTime NGAY_BAT_DAU { get; set; }
        public Nullable<System.DateTime> NGAY_KET_THUC { get; set; }
        public string NOI_DUNG { get; set; }
        public Nullable<decimal> ID_CO_CHE { get; set; }
    
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN { get; set; }
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN1 { get; set; }
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN2 { get; set; }
        public virtual ICollection<GD_CHI_TIET_DU_AN> GD_CHI_TIET_DU_AN { get; set; }
        public virtual ICollection<GD_QUYET_DINH_DU_AN> GD_QUYET_DINH_DU_AN { get; set; }
    }
}
