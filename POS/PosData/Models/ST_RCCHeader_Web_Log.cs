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
    
    public partial class ST_RCCHeader_Web_Log
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string cus_code { get; set; }
        public string ref_number { get; set; }
        public string ref_date { get; set; }
        public Nullable<int> credit_term { get; set; }
        public Nullable<double> credit_limit { get; set; }
        public string cus_paytype { get; set; }
        public Nullable<double> money_credit { get; set; }
        public Nullable<double> pay_net_total { get; set; }
        public string emp_code { get; set; }
        public string flag_status { get; set; }
        public string rec_memo { get; set; }
        public string AF_Status { get; set; }
        public string doc_no2 { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public Nullable<double> cust_limit { get; set; }
        public Nullable<double> cust_balance { get; set; }
        public string flag_vat { get; set; }
        public string Flag_Vat_Transfer { get; set; }
        public string Update_Vat_Transfer { get; set; }
        public string dealercode { get; set; }
        public string web_log_send_to { get; set; }
        public Nullable<int> web_log_user_id { get; set; }
        public string web_log_date { get; set; }
        public string web_log_time { get; set; }
        public Nullable<int> web_log_flag_send { get; set; }
        public string web_log_message { get; set; }
    }
}
