using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class UnitModel
    {
        public int unit_code { get; set; }
        public string unit_name { get; set; }
        public string AF_Status { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
    }
}
