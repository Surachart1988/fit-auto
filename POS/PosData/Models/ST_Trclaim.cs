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
    
    public partial class ST_Trclaim
    {
        public int id { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string cus_code { get; set; }
        public string claim_date { get; set; }
        public string pro_code { get; set; }
        public Nullable<int> quqntity { get; set; }
        public string claim_detail { get; set; }
        public string clear_date { get; set; }
        public string due_date { get; set; }
        public Nullable<double> CLEAR_DATE_REPORT { get; set; }
        public Nullable<double> DUE_DATE_REPORT { get; set; }
        public Nullable<double> CLAIM_DATE_REPORT { get; set; }
        public string dealercode { get; set; }
    }
}