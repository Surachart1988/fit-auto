using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PromotionAndDiscountModal
    {
        public bool? FlagUse { get; set; }
        public int? Id { get; set; }
        public string Code { get; set; }

        public string DocNo { get; set; }

        public string DocCode { get; set; }

        public string Name { get; set; }

        public double? Number { get; set; }

        public double? Money { get; set; }

        public string Note { get; set; }

        public string ProdectDetail { get; set; }

        public string ReferenceNo { get; set; }

        public string Type { get; set; }
        public string PromotionType { get; set; }

        public string SubType { get; set; }

        public string Other { get; set; }

        public string Unit { get; set; }

        public double? Discount { get; set; }

        public string ProductGiveCode { get; set; }

        public string ProductGiveName { get; set; }

        public bool? Active { get; set; }

        public bool? FlagUseShared { get; set; }

        public string ProductBalance { get; set; }

        public string CouponId { get; set; }
        public string CouponCode { get; set; }

        public string CouponCalType { get; set; }

        public string CusTypeCode { get; set; }

        public string GroupCode { get; set; }

        public string GroupType { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionName { get; set; }

        public string Product_Ref_Code { get; set; }

        public string OnlinePaymentRefNo { get; set; }

        public string group_used_detail { get; set; }

        public bool give_same_buy { get; set; }

        public string pmd_pro_code { get; set; }



        public int pro_group_type_used { get; set; }
        public string tmp_No { get; set; }
        public string tmp_Code { get; set; }
        public string tmp_Name { get; set; }
        public string tmp_Type { get; set; }
        public string tmp_ProductDetail { get; set; }
        public string tmp_ProductGiveName { get; set; }
        public double tmp_Number { get; set; }
        public double tmp_Money { get; set; }
        public string tmp_ProductGiveCode { get; set; }
        public string tmp_PromotionType { get; set; }
        public double tmp_Discount { get; set; }
        public string tmp_CouponId { get; set; }
        public string tmp_CouponCode { get; set; }
        public string tmp_CouponCalType { get; set; }
        public string tmp_Product_Ref_Code { get; set; }
        public bool tmp_give_same_buy { get; set; }
    }
}
