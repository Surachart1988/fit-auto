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
    
    public partial class ev_rpt_vat3
    {
        public string branch_no { get; set; }
        public string branch_name { get; set; }
        public string doc_date { get; set; }
        public string pay_doc_no { get; set; }
        public string pay_id { get; set; }
        public string cus_code { get; set; }
        public string tax_id { get; set; }
        public string cus_name { get; set; }
        public Nullable<double> money_total { get; set; }
        public Nullable<double> crd_amt { get; set; }
    }
}
