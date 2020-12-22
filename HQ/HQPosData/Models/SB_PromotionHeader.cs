namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class SB_PromotionHeader
    {
        //public SB_PromotionHeader()
        //{
        //    SbPromotionDetail = new List<SB_PromotionDetail>();
        //}
        [Key]
        [StringLength(10)]
        public string pro_id { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(50)]
        public string pro_start_date { get; set; }

        [StringLength(20)]
        public string pro_start_time { get; set; }

        [StringLength(50)]
        public string pro_end_date { get; set; }

        [StringLength(20)]
        public string pro_end_time { get; set; }

        [StringLength(10)]
        public string campaign_id { get; set; }

        public int? pro_condition_time_id { get; set; }

        [StringLength(255)]
        public string pro_condition_time_detail { get; set; }

        public bool? allow_muti_promotion { get; set; }

        public bool? allow_muti_voucher { get; set; }

        public bool? required_coupon_code { get; set; }

        public bool? allow_promotion { get; set; }

        [StringLength(50)]
        public string pro_add_date { get; set; }

        [StringLength(20)]
        public string pro_add_time { get; set; }

        [StringLength(50)]
        public string pro_edit_date { get; set; }

        [StringLength(20)]
        public string pro_edit_time { get; set; }

        public int? pro_group_used_id { get; set; }

        [StringLength(255)]
        public string pro_group_used_detail { get; set; }

        public int? pro_type_id { get; set; }

        public double? pro_type_detail { get; set; }

        public int? pro_price_id { get; set; }

        public double? pro_price_total { get; set; }

        public int? pro_give_type_id { get; set; }

        public int? pro_give_type_detail { get; set; }

        public bool? pro_give_product_same { get; set; }

        public bool? pro_give_same_buy { get; set; }

        public int? pro_discount_id { get; set; }

        public double? pro_discount_num { get; set; }

        public double? pro_discount_rate { get; set; }

        [StringLength(20)]
        public string pro_discount_unit { get; set; }

        [StringLength(20)]
        public string rate_price_cal { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }

        public string pro_condition_time_start { get; set; }

        public string pro_condition_time_end { get; set; }
        public string allow_muti_promotion_detail { get; set; }
        public string branch_no_list { get; set; }
        public int? group_coupon_id { get; set; }
        public string coupon_id { get; set; }
        public int pro_give_free_amount { get; set; }

        public SB_PromotionConditionTime ProConditionTime { get; set; }
        public SB_PromotionDiscount ProDiscount { get; set; }
        public SB_PromotionGiveType ProGiveType { get; set; }
        public SB_PromotionGroupUsed ProGroupUsed { get; set; }
        public SB_PromotionType ProType { get; set; }
        public List<SB_PromotionDetail> SbPromotionDetail { get; set; }
        //public List<SB_CouponDetail> SBCouponDetail { get; set; }
    }
}
