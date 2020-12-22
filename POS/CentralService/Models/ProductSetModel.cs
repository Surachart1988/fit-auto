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
    public class ProductSetModel
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public int? ps_gen_id { get; set; }
        public string ps_typesale { get; set; }
        public string ps_code { get; set; }
        public string ps_name { get; set; }
        public string ps_startdate { get; set; }
        public string ps_enddate { get; set; }
        public string ps_cancel { get; set; }
        public int? ps_startdate_report { get; set; }
        public int? ps_enddate_report { get; set; }
        public string dealercode { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public int? pro_price_set { get; set; }
        public string include_with_promotion { get; set; }
    }
}
