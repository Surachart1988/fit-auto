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
    
    public partial class RP_AgeAp
    {
        public int id { get; set; }
        public string ven_code { get; set; }
        public string ven_name { get; set; }
        public Nullable<int> ven_balance { get; set; }
        public Nullable<int> ven_credit_term { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string cur_date { get; set; }
        public Nullable<int> rdiff { get; set; }
        public string branch_no { get; set; }
        public Nullable<double> ap_amt { get; set; }
        public Nullable<int> DATE_REPORT { get; set; }
        public Nullable<double> ap_increase { get; set; }
        public Nullable<double> ap_decrease { get; set; }
        public string dealercode { get; set; }
    }
}