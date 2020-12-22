using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newPos.Models
{
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