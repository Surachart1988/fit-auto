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
    
    public partial class SB_log
    {
        public int ID { get; set; }
        public string user_name { get; set; }
        public string user_date { get; set; }
        public string user_time { get; set; }
        public string menu_number { get; set; }
        public string menu_type { get; set; }
        public string menu_name { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
