//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_TRANG_THAI_UNG_VIEN
    {
        public DM_TRANG_THAI_UNG_VIEN()
        {
            this.DM_TRANG_THAI_UNG_VIEN1 = new HashSet<DM_TRANG_THAI_UNG_VIEN>();
            this.GD_CHI_TIET_TUYEN_DUNG = new HashSet<GD_CHI_TIET_TUYEN_DUNG>();
        }
    
        public decimal ID { get; set; }
        public string MA_TRANG_THAI { get; set; }
        public Nullable<decimal> ID_TRANG_THAI_PARENT { get; set; }
        public string DINH_NGHIA { get; set; }
        public string DAU_HIEU { get; set; }
        public string VIEC_CAN_LAM { get; set; }
    
        public virtual ICollection<DM_TRANG_THAI_UNG_VIEN> DM_TRANG_THAI_UNG_VIEN1 { get; set; }
        public virtual DM_TRANG_THAI_UNG_VIEN DM_TRANG_THAI_UNG_VIEN2 { get; set; }
        public virtual ICollection<GD_CHI_TIET_TUYEN_DUNG> GD_CHI_TIET_TUYEN_DUNG { get; set; }
    }
}
