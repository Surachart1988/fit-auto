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
    
    public partial class ev_jobdetail_list_by_sale_id
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public Nullable<int> sale_id { get; set; }
        public string sempno { get; set; }
        public string emp_name { get; set; }
        public string emp_pos { get; set; }
        public int Line_no { get; set; }
        public string pro_code { get; set; }
        public string pro_tname { get; set; }
        public string product_group { get; set; }
        public string product_brand { get; set; }
        public string product_model { get; set; }
        public string product_size { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
    }
}