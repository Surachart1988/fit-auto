using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public  class SbPromotionDetailDisc
    {
        public int doc_no_run { get; set; }
        public string pro_id { get; set; }
        public string pro_code_show { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string progroup_code { get; set; }
        public string pro_brand_code { get; set; }
        public int? pro_model_code { get; set; }
        public int? pro_size_code { get; set; }
        public double? pro_discount_rate_special { get; set; }
        public string pro_discount_unit_special { get; set; }
        public bool? status_give_product { get; set; }
        public bool? deleted { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string product_group_code { get; set; }
        public double pro_price_detail { get; set; }
        //public ExtraPromotionModel Pro { get; set; }
    }
}

