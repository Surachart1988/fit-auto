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
    
    public partial class V_Get_AllowedPromotion
    {
        public string doc_no { get; set; }
        public string promotion_code_show { get; set; }
        public string promotion_code { get; set; }
        public string promotion_name { get; set; }
        public string promotion_product { get; set; }
        public Nullable<int> pro_type_id { get; set; }
        public string pro_type_name { get; set; }
        public Nullable<double> promotion_discount { get; set; }
        public string pro_discount_unit { get; set; }
        public string give_product_group_code { get; set; }
        public string give_progroup_code { get; set; }
        public string give_pro_brand_code { get; set; }
        public string promotion_detail_code { get; set; }
        public string promotion_detail { get; set; }
        public string promotion_give_code { get; set; }
        public string promotion_give { get; set; }
        public string promotion_num { get; set; }
        public Nullable<bool> promotion_active { get; set; }
        public Nullable<bool> flag_use_shared { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<int> pro_give_type_detail { get; set; }
        public Nullable<int> pro_give_type_id { get; set; }
        public Nullable<int> pro_group_used_id { get; set; }
        public Nullable<bool> pro_give_product_same { get; set; }
        public Nullable<bool> pro_give_same_buy { get; set; }
        public Nullable<int> pro_price_id { get; set; }
        public Nullable<double> pro_price_total { get; set; }
        public string pro_group_used_detail { get; set; }
        public Nullable<bool> status_give_product { get; set; }
        public Nullable<double> promotion_count_balance { get; set; }
        public Nullable<decimal> promotion_price { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<int> product_group_code { get; set; }
        public string progroup_code { get; set; }
        public Nullable<int> prod_brandcode { get; set; }
        public string promotion_pro_code { get; set; }
    }
}
