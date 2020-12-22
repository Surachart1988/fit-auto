namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SB_PromotionDetail
    {
        [Key]
        public int doc_no_run { get; set; }
        [StringLength(10)]
        public string pro_id { get; set; }
        public string product_group_code { get; set; }
        public string progroup_code { get; set; }
        public string pro_brand_code { get; set; }
        public string pro_model_code { get; set; }
        public string pro_size_code { get; set; }
        public double? pro_discount_rate_special { get; set; }
        [StringLength(20)]
        public string pro_discount_unit_special { get; set; }
        public bool? status_give_product { get; set; }
        [StringLength(120)]
        public string pro_code_show { get; set; }
        public string pro_code { get; set; }
        public bool? deleted { get; set; }
        [StringLength(50)]
        public string dealercode { get; set; }
        [StringLength(20)]
        public string branch_no { get; set; }

    }
}
