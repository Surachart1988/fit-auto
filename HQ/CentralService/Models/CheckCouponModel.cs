using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CentralService.Models
{
   public class CheckCouponModel
    {
        public string coupon_group_id { get; set; }
        public string coupon_name { get; set; }
        public string pro_id  { get; set; }
        public string pro_name { get; set; }
        public string branch_no_list { get; set; }
        public Nullable<bool> allow_muti_promotion { get; set; }
        public Nullable<bool> allow_muti_voucher { get; set; }
        public Nullable<decimal> coupon_value_amount { get; set; }
        public Nullable<decimal> coupon_value_percent { get; set; }
        public Nullable<int> pro_price_id { get; set; }
        public Nullable<double> pro_price_total { get; set; }
        public string can_use_coupon { get; set; }
    }
    public class ResultCouponModel
    {
        public string CanUseCoupon { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionName { get; set; }
        public decimal? DiscountPercen { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool? AllowMutiPromotion { get; set; }
        public bool? AllowMutiVoucher { get; set; }
    }
}
