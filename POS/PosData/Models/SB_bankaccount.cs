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
    
    public partial class SB_bankaccount
    {
        public string bankacc_code { get; set; }
        public string bankacc_id { get; set; }
        public string bankacc_name { get; set; }
        public string bank_code { get; set; }
        public string bank_branch { get; set; }
        public Nullable<double> open_balance { get; set; }
        public string open_date { get; set; }
        public Nullable<double> current_balance { get; set; }
        public string current_date { get; set; }
        public string bankacc_type { get; set; }
        public string date_type { get; set; }
        public string bankacc_remark { get; set; }
        public Nullable<double> cq_date_top { get; set; }
        public Nullable<double> cq_date_left { get; set; }
        public Nullable<double> cq_payto_top { get; set; }
        public Nullable<double> cq_payto_left { get; set; }
        public Nullable<double> cq_amount_top { get; set; }
        public Nullable<double> cq_amount_left { get; set; }
        public Nullable<double> cq_baht_top { get; set; }
        public Nullable<int> date_report { get; set; }
        public Nullable<double> cq_baht_left { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
