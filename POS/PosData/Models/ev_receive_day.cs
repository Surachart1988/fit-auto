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
    
    public partial class ev_receive_day
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string pre_name { get; set; }
        public string cus_name { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string progroup_code { get; set; }
        public string progroup_name { get; set; }
        public string product_type_service { get; set; }
        public string pro_stock { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_includevat { get; set; }
        public Nullable<double> pro_vat { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
    }
}
