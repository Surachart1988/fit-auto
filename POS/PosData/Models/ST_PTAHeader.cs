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
    
    public partial class ST_PTAHeader
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string ven_code { get; set; }
        public string ref_number { get; set; }
        public string ref_date { get; set; }
        public Nullable<int> credit_term { get; set; }
        public Nullable<double> credit_limit { get; set; }
        public string ven_paytype { get; set; }
        public Nullable<double> money_credit { get; set; }
        public Nullable<double> pay_net_total { get; set; }
        public string emp_code { get; set; }
        public string flag_status { get; set; }
        public string rec_memo { get; set; }
        public int doc_no_run { get; set; }
        public string AF_Status { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public Nullable<double> ven_limit { get; set; }
        public Nullable<double> ven_balance { get; set; }
        public string Flag_Vat_Transfer { get; set; }
        public string Update_Vat_Transfer { get; set; }
        public string flag_vat { get; set; }
        public string dealercode { get; set; }
    }
}
