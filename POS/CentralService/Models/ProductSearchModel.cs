using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class ProductSearchModel : DTParameters
    {
        public ProductSearchModel()
        {

        }
        public int product_group_code { get; set; }
        public string progroup_code { get; set; }
        public int pro_brand_code { get; set; }
        public int pro_model_code { get; set; }
        public int pro_size_code { get; set; }
        public string pro_status { get; set; }
        public string keysearch { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string prodSetSearch { get; set; }
    }
}
