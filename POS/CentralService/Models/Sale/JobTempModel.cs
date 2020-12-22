using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models.Sale
{
    public class JobTempModel
    {
        public JobTempModel()
        {

        }
        public int DOC_NO_RUN { get; set; }
        public string branch_no { get; set; }
        public string pro_code { get; set; }
        public string doc_no { get; set; }
        public int? line_no { get; set; }
        public string doc_code { get; set; }
        public string pro_name { get; set; }
        public int? sale_unit_code { get; set; }
        public int? locat_code { get; set; }
        public double? store_qty { get; set; }
        public double? pro_price { get; set; }
        public double? pro_disp1 { get; set; }
        public double? pro_disp2 { get; set; }
        public double? pro_disamt { get; set; }
        public double? pro_distotamt { get; set; }
        public double? pro_amt { get; set; }
        public string rec_memo { get; set; }
        public string pm_code { get; set; }
        public string io_by { get; set; }
        public double? pro_amtlasted { get; set; }
        public double? vat_rate { get; set; }
        public double? pro_avg_vat { get; set; }
        public double? pro_avg_novat { get; set; }
        public string flag_mobile { get; set; }
        public double? pro_dis_all { get; set; }
        public string film_code { get; set; }
        public string film_position_code { get; set; }
        public double? pro_add_all { get; set; }
        public string flag_promotion { get; set; }
        public string dealercode { get; set; }
        public int? ps_code { get; set; }
        public int? dot_id { get; set; }

        public string locat_dot_name { get; set; }
        public string dot_name { get; set; }
        public string locat_name { get; set; }
        public string sale_unit_name { get; set; }
        public string pro_tname { get; set; }
        public double? pro_ohqty { get; set; }
        public double? pro_price_retail { get; set; }
        public double? pro_qty { get; set; }
        public string pro_stock { get; set; }
        public string mode { get; set; }
    }
}
