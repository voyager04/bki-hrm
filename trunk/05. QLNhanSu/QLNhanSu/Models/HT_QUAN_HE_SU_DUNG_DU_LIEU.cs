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
    
    public partial class HT_QUAN_HE_SU_DUNG_DU_LIEU
    {
        public decimal ID { get; set; }
        public decimal ID_DON_VI { get; set; }
        public decimal ID_USER_GROUP { get; set; }
    
        public virtual HT_USER_GROUP HT_USER_GROUP { get; set; }
    }
}