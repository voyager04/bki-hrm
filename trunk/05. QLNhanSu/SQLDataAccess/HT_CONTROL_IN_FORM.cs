//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class HT_CONTROL_IN_FORM
    {
        public decimal ID { get; set; }
        public decimal ID_FORM { get; set; }
        public string CONTROL_NAME { get; set; }
        public string CONTROL_TYPE { get; set; }
        public decimal ID_CHUC_NANG { get; set; }
    
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN { get; set; }
        public virtual HT_FORM HT_FORM { get; set; }
    }
}
