//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PosData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_Prheader_Web_Log
    {
        public int DOC_NO_RUN { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string ref_branchno { get; set; }
        public string ref_doccode { get; set; }
        public string car_reg { get; set; }
        public string car_chasis { get; set; }
        public string car_engine { get; set; }
        public string cus_type { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string cus_addr_1 { get; set; }
        public string cus_addr_2 { get; set; }
        public string cus_province { get; set; }
        public string cus_zip { get; set; }
        public string car_brand { get; set; }
        public string car_model { get; set; }
        public string car_color { get; set; }
        public Nullable<double> car_mileage { get; set; }
        public Nullable<double> credit_term { get; set; }
        public string due_date { get; set; }
        public string vat_type { get; set; }
        public Nullable<double> vat_rateprod { get; set; }
        public Nullable<double> vat_rateserv { get; set; }
        public Nullable<double> disc_percent { get; set; }
        public Nullable<double> disc_bath { get; set; }
        public Nullable<double> amt_discount { get; set; }
        public Nullable<double> amt_sumprod { get; set; }
        public Nullable<double> amt_sumserv { get; set; }
        public Nullable<double> amt_netamt { get; set; }
        public Nullable<double> amt_vatprod { get; set; }
        public Nullable<double> amt_vatserv { get; set; }
        public Nullable<float> amt_totalprod { get; set; }
        public Nullable<double> amt_totalserv { get; set; }
        public Nullable<double> grand_total { get; set; }
        public Nullable<int> last_line { get; set; }
        public Nullable<int> print_no { get; set; }
        public string rec_memo { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public string priceown_code { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public Nullable<int> create_user_id { get; set; }
        public string app_docno { get; set; }
        public string approve_pro_price { get; set; }
        public string admin_pro_price { get; set; }
        public string admin_pro_price_memo { get; set; }
        public string dealercode { get; set; }
        public string web_log_send_to { get; set; }
        public Nullable<int> web_log_user_id { get; set; }
        public string web_log_date { get; set; }
        public string web_log_time { get; set; }
        public Nullable<int> web_log_flag_send { get; set; }
        public string web_log_message { get; set; }
    }
}