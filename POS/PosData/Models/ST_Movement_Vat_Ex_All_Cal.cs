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
    
    public partial class ST_Movement_Vat_Ex_All_Cal
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public string doc_no { get; set; }
        public string doc_name { get; set; }
        public string doc_date { get; set; }
        public Nullable<int> date_report { get; set; }
        public string doc_time { get; set; }
        public string doc_code { get; set; }
        public string cus_code { get; set; }
        public string vat_type { get; set; }
        public Nullable<int> locat_code { get; set; }
        public Nullable<double> product_qty { get; set; }
        public Nullable<double> move_qty { get; set; }
        public Nullable<double> incre_qty { get; set; }
        public Nullable<double> decre_qty { get; set; }
        public Nullable<double> decre_qty_tmp { get; set; }
        public Nullable<double> total_qty { get; set; }
        public Nullable<double> vat_move_qty { get; set; }
        public Nullable<double> vat_incre_qty { get; set; }
        public Nullable<double> vat_decre_qty { get; set; }
        public Nullable<double> vat_decre_qty_tmp { get; set; }
        public Nullable<double> vat_total_qty { get; set; }
        public Nullable<double> novat_move_qty { get; set; }
        public Nullable<double> novat_incre_qty { get; set; }
        public Nullable<double> novat_decre_qty { get; set; }
        public Nullable<double> novat_decre_qty_tmp { get; set; }
        public Nullable<double> novat_total_qty { get; set; }
        public Nullable<double> average_cost { get; set; }
        public string dealercode { get; set; }
    }
}
