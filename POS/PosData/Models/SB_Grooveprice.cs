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
    
    public partial class SB_Grooveprice
    {
        public int groove_id { get; set; }
        public string branch_no { get; set; }
        public string groove_type { get; set; }
        public string groove_name { get; set; }
        public string pro_code { get; set; }
        public string progroup_code { get; set; }
        public Nullable<int> pro_brand_code { get; set; }
        public Nullable<int> pro_model_code { get; set; }
        public string sale_type { get; set; }
        public string rate_type { get; set; }
        public Nullable<double> rate_price { get; set; }
        public string groove_start_date { get; set; }
        public string cancel_status { get; set; }
        public string start_date_report { get; set; }
        public string dealercode { get; set; }
        public string groove_end_date { get; set; }
        public string cus_code { get; set; }
    }
}
