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
    
    public partial class ST_PCPDetail
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string pro_code { get; set; }
        public int line_no { get; set; }
        public string doc_date { get; set; }
        public string doc_code { get; set; }
        public string doc_time { get; set; }
        public Nullable<int> po_line { get; set; }
        public string pro_ven_code { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> sale_unit_code { get; set; }
        public string store_unit { get; set; }
        public string tran_unit { get; set; }
        public string tran_ration { get; set; }
        public Nullable<int> locat_code { get; set; }
        public string location_code { get; set; }
        public Nullable<double> tran_qty { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> receive_qty { get; set; }
        public Nullable<double> pro_beforevat { get; set; }
        public Nullable<double> pro_incluludevat { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_disamt { get; set; }
        public Nullable<double> pro_disp1 { get; set; }
        public Nullable<double> pro_disp2 { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public string pro_free { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public string doc_candate { get; set; }
        public string rec_memo { get; set; }
        public string ven_code { get; set; }
        public string progroup_code { get; set; }
        public string pro_brand { get; set; }
        public string pro_model { get; set; }
        public int doc_no_run { get; set; }
        public int ap_doc_no_run { get; set; }
        public string dealercode { get; set; }
    }
}
