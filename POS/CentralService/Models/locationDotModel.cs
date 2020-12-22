using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class locationDotModel
    {
        public string dealercode { get; set; }
        public string pro_code { get; set; }
        public int dot_id { get; set; }
        public int locat_code { get; set; }
        public double? pro_qty { get; set; }
        public int? status { get; set; }
        public string locat_name { get; set; }
        //public int dot_id { get; set; }
        public string dot_name { get; set; }
        public string flag_used { get; set; }
        //public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public int? SendClient { get; set; }
        public bool is_selected { get; set; }
    }
}
