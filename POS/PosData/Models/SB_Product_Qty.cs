//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PosData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SB_Product_Qty
    {
        public int pro_qty_id { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string pro_code { get; set; }
        public Nullable<double> pro_poqty { get; set; }
        public Nullable<double> pro_ohqty { get; set; }
        public Nullable<double> pro_otqty { get; set; }
        public Nullable<double> pro_accqty { get; set; }
        public string last_update { get; set; }
    }
}
