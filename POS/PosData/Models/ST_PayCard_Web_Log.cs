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
    
    public partial class ST_PayCard_Web_Log
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_code { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string card_code { get; set; }
        public string card_id { get; set; }
        public Nullable<double> card_amt { get; set; }
        public Nullable<int> user_pay_id { get; set; }
        public string void_no { get; set; }
        public Nullable<int> installment_id { get; set; }
        public string dealercode { get; set; }
        public string web_log_send_to { get; set; }
        public Nullable<int> web_log_user_id { get; set; }
        public string web_log_date { get; set; }
        public string web_log_time { get; set; }
        public Nullable<int> web_log_flag_send { get; set; }
        public string web_log_message { get; set; }
    }
}
