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
    
    public partial class ST_PTADetail
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string pay_doc_no { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string ven_code { get; set; }
        public string pay_doc_name { get; set; }
        public string pay_doc_date { get; set; }
        public string pay_end_date { get; set; }
        public Nullable<double> money_total { get; set; }
        public Nullable<double> money_keep { get; set; }
        public Nullable<double> money_pay { get; set; }
        public string rec_memo { get; set; }
        public int doc_no_run { get; set; }
        public string dealercode { get; set; }
    }
}
