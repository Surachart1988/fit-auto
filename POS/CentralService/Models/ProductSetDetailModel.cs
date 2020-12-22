using CentralService.Enums;
using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Models
{
    public class ProductSetDetailModel
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public int? ps_gen_id { get; set; }
        public string ps_code { get; set; }
        public string ps_pro_code { get; set; }
        public int? ps_line_no { get; set; }
        public int? ps_locat_code { get; set; }
        public double? ps_qty { get; set; }
        public double? ps_price { get; set; }
        public string dealercode { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }

        public string pro_name { get; set; }
        public string pro_stock { get; set; }
        public string locat_name { get; set; }
        public double pro_qoh { get; set; }
        public IEnumerable<locationDotModel> ddlobj { get; set; }
    }
}
