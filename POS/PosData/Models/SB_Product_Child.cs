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
    
    public partial class SB_Product_Child
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string root_pro_code { get; set; }
        public string child_pro_code { get; set; }
        public Nullable<int> child_unit_code { get; set; }
        public Nullable<double> child_qty { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public Nullable<int> date_report { get; set; }
        public Nullable<int> user_id { get; set; }
        public string ip_address { get; set; }
        public string dealercode { get; set; }
    }
}
