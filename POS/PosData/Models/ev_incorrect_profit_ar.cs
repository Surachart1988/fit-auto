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
    
    public partial class ev_incorrect_profit_ar
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string cus_code { get; set; }
        public string pre_name { get; set; }
        public string cus_name { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string vat_type { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public Nullable<double> PRO_AMT_INC { get; set; }
        public Nullable<double> PRO_AMT_EXC { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> COST { get; set; }
        public Nullable<double> PROFIT_INC { get; set; }
        public Nullable<double> PROFIT_EXC { get; set; }
        public Nullable<double> PROFIT_PERCENT_INC { get; set; }
        public Nullable<double> PROFIT_PERCENT_EXC { get; set; }
        public string doc_close { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public string progroup_code { get; set; }
        public int pro_brand_code { get; set; }
        public int pro_model_code { get; set; }
        public string size_name { get; set; }
        public int pro_size_code { get; set; }
        public string ref_docno { get; set; }
        public string docno_ref { get; set; }
        public Nullable<int> locat_code { get; set; }
    }
}
