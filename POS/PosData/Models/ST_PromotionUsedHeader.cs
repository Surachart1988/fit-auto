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
    
    public partial class ST_PromotionUsedHeader
    {
        public int doc_no_run { get; set; }
        public string doc_no { get; set; }
        public string branch_no { get; set; }
        public string doc_no_ref { get; set; }
        public string pro_id { get; set; }
        public Nullable<double> price_cal { get; set; }
        public Nullable<double> used_total { get; set; }
        public string coupon_id { get; set; }
        public string coupon_code { get; set; }
        public string used_date { get; set; }
        public string used_time { get; set; }
        public Nullable<bool> deleted { get; set; }
        public string dealercode { get; set; }
    }
}
