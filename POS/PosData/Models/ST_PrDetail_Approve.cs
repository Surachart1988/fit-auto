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
    
    public partial class ST_PrDetail_Approve
    {
        public int DOC_NO_RUN { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string pro_code { get; set; }
        public int line_no { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string car_chasis { get; set; }
        public string cus_type { get; set; }
        public string cus_code { get; set; }
        public string cus_name { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> sale_unit_code { get; set; }
        public string store_unit { get; set; }
        public string tran_unit { get; set; }
        public Nullable<double> tran_ratio { get; set; }
        public Nullable<double> tran_qty { get; set; }
        public Nullable<double> store_qty { get; set; }
        public Nullable<double> unit_cost { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_disp1 { get; set; }
        public Nullable<double> pro_disp2 { get; set; }
        public Nullable<double> pro_disamt { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public string rec_close { get; set; }
        public string rec_memo { get; set; }
        public string pm_code { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> pro_sale_price { get; set; }
        public Nullable<int> locat_code { get; set; }
        public Nullable<double> pro_dis_all { get; set; }
        public Nullable<double> lasted_cost { get; set; }
        public string dealercode { get; set; }
    }
}