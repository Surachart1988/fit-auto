using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    //public class CampaignfModel
    //{
    //    public string campaign_id { get; set; }
    //    public string campaign_name { get; set; }
    //    public string campaign_add_date { get; set; }
    //    public string campaign_edit_date { get; set; }
    //    public string campaign_add_time { get; set; }
    //    public string campaign_edit_time { get; set; }
    //    public bool? deleted { get; set; }
    //    public string dealercode { get; set; }
    //    public string branch_no { get; set; }
    //    //public string Code { get; set; }

    //    //public string Name { get; set; }
    //}
    public class ProdFirstGrpModel
    {
        public string product_group_code { get; set; }

        public string product_group_name { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ProGrpListModel
    {
        public string progroup_code { get; set; }

        public string progroup_name { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ProBrandListModel
    {
        public string pro_brand { get; set; }
        //public int pro_brand_codes { get; set; }
        public string pro_brand_code { get; set; }
        public bool IsCheck { get; set; }
    }
    public class PromodelModel
    {
        public string pro_model { get; set; }
        public string pro_model_code { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ProSizeModel
    {
        public string size_name { get; set; }
        public string pro_size_code { get; set; }
        public bool IsCheck { get; set; }
    }
    public class ProductsModel
    {
        public string pro_tname { get; set; }
        public string pro_code { get; set; }
        public bool IsCheck { get; set; }
    }
}
