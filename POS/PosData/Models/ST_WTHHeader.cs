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
    
    public partial class ST_WTHHeader
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string ven_code { get; set; }
        public string ref_docno { get; set; }
        public Nullable<int> tax_con_id { get; set; }
        public Nullable<int> tax_type_id { get; set; }
        public Nullable<int> tax_money_id { get; set; }
        public string vat_type { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> ap_netamt { get; set; }
        public Nullable<double> ap_totalamt { get; set; }
        public string docno_ref { get; set; }
        public string docno_ref_date { get; set; }
        public string tax_id { get; set; }
        public string tax_branch_id { get; set; }
        public string tax_branch { get; set; }
        public Nullable<double> total_tax { get; set; }
        public Nullable<double> total_tax_vat { get; set; }
        public string rec_memo { get; set; }
        public Nullable<int> add_user_id { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public Nullable<int> edit_user_id { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public string cancel_detail { get; set; }
        public Nullable<int> date_report { get; set; }
        public string doc_date_used { get; set; }
        public string dealercode { get; set; }
    }
}
