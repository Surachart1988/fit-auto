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
    
    public partial class ST_Return_Log_Web_Log
    {
        public int id { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_status { get; set; }
        public string log_date { get; set; }
        public string log_time { get; set; }
        public string ip_address { get; set; }
        public Nullable<int> user_id { get; set; }
        public string dealercode { get; set; }
        public string web_log_send_to { get; set; }
        public Nullable<int> web_log_user_id { get; set; }
        public string web_log_date { get; set; }
        public string web_log_time { get; set; }
        public Nullable<int> web_log_flag_send { get; set; }
        public string web_log_message { get; set; }
    }
}
