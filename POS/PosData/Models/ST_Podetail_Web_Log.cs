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
    
    public partial class ST_Podetail_Web_Log
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string pro_code { get; set; }
        public Nullable<int> line_no { get; set; }
        public string dealercode { get; set; }
        public string doc_code { get; set; }
        public string pro_ven_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public Nullable<int> ship_tobranch { get; set; }
        public string ship_todate { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> buy_unit_code { get; set; }
        public string store_unit { get; set; }
        public string tran_unit { get; set; }
        public Nullable<double> tran_ratio { get; set; }
        public Nullable<double> tran_qty { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> receive_qty { get; set; }
        public Nullable<double> pro_beforevat { get; set; }
        public Nullable<double> pro_includevat { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_disamt { get; set; }
        public Nullable<double> pro_disp1 { get; set; }
        public Nullable<double> pro_disp2 { get; set; }
        public Nullable<double> pro_distot { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public string pro_free { get; set; }
        public string pro_close { get; set; }
        public string cancel_date { get; set; }
        public string rec_memo { get; set; }
        public Nullable<int> po_line { get; set; }
        public string ven_code { get; set; }
        public string progroup_code { get; set; }
        public string pro_brand { get; set; }
        public string pro_model { get; set; }
        public int doc_no_run { get; set; }
        public Nullable<double> average_cost { get; set; }
        public Nullable<double> pro_dis_all { get; set; }
        public string cancel_qty { get; set; }
        public Nullable<int> cancel_user_id { get; set; }
        public string cancel_qty_date { get; set; }
        public string cancel_qty_time { get; set; }
        public string cancel_memo { get; set; }
        public string rop { get; set; }
        public string eoq { get; set; }
        public string web_log_send_to { get; set; }
        public Nullable<int> web_log_user_id { get; set; }
        public string web_log_date { get; set; }
        public string web_log_time { get; set; }
        public Nullable<int> web_log_flag_send { get; set; }
        public string web_log_message { get; set; }
    }
}
