using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newPos.Models
{
    public class ReportModels
    {
        public string ReportName { get; set; }
        public string doc_no { get; set; }
        public string ref_docno { get; set; }
        public string thaibaht { get; set; }
        public string branch_no { get; set; }
        public string prn_procode { get; set; }
        public string prn_prodetail { get; set; }
        public string prn_car_reg { get; set; }
        public string prn_pay_type { get; set; }
        public string print_time { get; set; }
        public string wifi_password { get; set; }

        public string MapUrlPrint { get; set; }
        public ReportModels()
        {

        }
    }
}