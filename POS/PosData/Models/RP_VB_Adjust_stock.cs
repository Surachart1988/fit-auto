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
    
    public partial class RP_VB_Adjust_stock
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string type_adjust { get; set; }
        public string pro_code { get; set; }
        public string pro_tname { get; set; }
        public Nullable<double> store_qty { get; set; }
        public string bill_novat_status { get; set; }
        public string dealercode { get; set; }
    }
}
