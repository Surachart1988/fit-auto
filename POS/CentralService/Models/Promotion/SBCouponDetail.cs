using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CentralService.Models
{
    public class SBCouponDetail
    {
        public int run_id { get; set; }
        public string coupon_group_id { get; set; }
        public string coupon_code { get; set; }
        public string coupon_name { get; set; }
        public decimal? coupon_value_amount { get; set; }
        public decimal? coupon_value_percent { get; set; }
        public DateTime? coupon_start_date { get; set; }
        public DateTime? coupon_end_date { get; set; }
        public bool? coupon_status { get; set; }
        public bool? deleted { get; set; }
    }
}

