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
    
    public partial class SB_PromotionCouponDetailEmp
    {
        public int run_id { get; set; }
        public string pro_id { get; set; }
        public string coupon_code { get; set; }
        public string coupon_name { get; set; }
        public Nullable<decimal> coupon_value_amount { get; set; }
        public Nullable<decimal> coupon_value_percent { get; set; }
        public Nullable<System.DateTime> coupon_start_date { get; set; }
        public Nullable<System.DateTime> coupon_end_date { get; set; }
        public Nullable<bool> coupon_status { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
