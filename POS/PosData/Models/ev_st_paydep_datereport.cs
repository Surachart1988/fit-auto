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
    
    public partial class ev_st_paydep_datereport
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_code { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public Nullable<int> ref_branch { get; set; }
        public string ref_doccode { get; set; }
        public string ref_docno { get; set; }
        public Nullable<double> dep_balamt { get; set; }
        public Nullable<double> dep_payamt { get; set; }
        public Nullable<int> user_pay_id { get; set; }
        public string date_report { get; set; }
    }
}
