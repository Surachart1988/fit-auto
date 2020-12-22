namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SB_PromotionCouponDetailEmp
    {
        [Key]
        public int run_id { get; set; }
        [StringLength(10)]
        public string pro_id { get; set; }
        [StringLength(50)]
        public string coupon_code { get; set; }
        [StringLength(200)]
        public string coupon_name { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? coupon_value_amount { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? coupon_value_percent { get; set; }
        public DateTime? coupon_start_date { get; set; }
        public DateTime? coupon_end_date { get; set; }
        public bool? coupon_status { get; set; }
        public bool? deleted { get; set; }
    }
}
