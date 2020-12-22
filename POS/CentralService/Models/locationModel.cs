using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class locationModel
    {
        public string branch_no { get; set; }
        public string pro_code { get; set; }
        public int locat_code { get; set; }
        public string location_code { get; set; }
        public double? pro_qoh { get; set; }
        public string novat_status { get; set; }
        public double? pro_qoh_export { get; set; }
        public string dealercode { get; set; }

        //public int locat_code { get; set; }
        public string locat_name { get; set; }
        //public string novat_status { get; set; }
        public string AF_Status { get; set; }
        public string show_status { get; set; }
        //public string branch_no { get; set; }
        public int locat_main_id { get; set; }
        public int locat_dot_id { get; set; }
        //public string dealercode { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public int SendClient { get; set; }
    }
}
