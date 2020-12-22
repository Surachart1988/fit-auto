namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Coupon
    {
        [Key]
        [StringLength(10)]
        public string coupon_id { get; set; }

        [StringLength(50)]
        public string coupon_code { get; set; }

        [StringLength(255)]
        public string coupon_name { get; set; }

        public int? coupon_start_number { get; set; }

        public int? number_want { get; set; }

        [StringLength(50)]
        public string coupon_end_date { get; set; }

        public bool? used_more_than_once { get; set; }

        public bool? allow_coupon { get; set; }

        [StringLength(50)]
        public string coupon_add_date { get; set; }

        [StringLength(50)]
        public string coupon_edit_date { get; set; }

        [StringLength(20)]
        public string coupon_add_time { get; set; }

        [StringLength(20)]
        public string coupon_edit_time { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
