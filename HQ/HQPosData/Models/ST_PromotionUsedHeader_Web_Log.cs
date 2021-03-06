namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PromotionUsedHeader_Web_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no_ref { get; set; }

        [StringLength(10)]
        public string pro_id { get; set; }

        public double? price_cal { get; set; }

        public double? used_total { get; set; }

        [StringLength(10)]
        public string coupon_id { get; set; }

        [StringLength(50)]
        public string coupon_code { get; set; }

        [StringLength(50)]
        public string used_date { get; set; }

        [StringLength(20)]
        public string used_time { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(50)]
        public string web_log_send_to { get; set; }

        public int? web_log_user_id { get; set; }

        [StringLength(255)]
        public string web_log_date { get; set; }

        [StringLength(255)]
        public string web_log_time { get; set; }

        public int? web_log_flag_send { get; set; }

        [StringLength(255)]
        public string web_log_message { get; set; }
    }
}
