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
    
    public partial class ST_DayEnd_Head
    {
        public int de_id { get; set; }
        public string branch_no { get; set; }
        public string doc_code { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public Nullable<int> date_report { get; set; }
        public string doc_time { get; set; }
        public string emp_id { get; set; }
        public Nullable<int> bill_1000 { get; set; }
        public Nullable<int> bill_500 { get; set; }
        public Nullable<int> bill_100 { get; set; }
        public Nullable<int> bill_50 { get; set; }
        public Nullable<int> bill_20 { get; set; }
        public Nullable<int> bill_10 { get; set; }
        public Nullable<int> bill_5 { get; set; }
        public Nullable<int> bill_2 { get; set; }
        public Nullable<int> bill_1 { get; set; }
        public Nullable<int> bill_050 { get; set; }
        public Nullable<int> bill_025 { get; set; }
        public Nullable<double> billtotal_1000 { get; set; }
        public Nullable<double> billtotal_500 { get; set; }
        public Nullable<double> billtotal_100 { get; set; }
        public Nullable<double> billtotal_50 { get; set; }
        public Nullable<double> billtotal_20 { get; set; }
        public Nullable<double> billtotal_10 { get; set; }
        public Nullable<double> billtotal_5 { get; set; }
        public Nullable<double> billtotal_2 { get; set; }
        public Nullable<double> billtotal_1 { get; set; }
        public Nullable<double> billtotal_050 { get; set; }
        public Nullable<double> billtotal_025 { get; set; }
        public Nullable<double> billtotal_card { get; set; }
        public Nullable<double> billtotal_chq { get; set; }
        public Nullable<double> billtotal_banktrans { get; set; }
        public Nullable<double> billtotal_all { get; set; }
        public string doc_date_start { get; set; }
        public string doc_date_end { get; set; }
        public Nullable<int> doc_date_start_cal { get; set; }
        public Nullable<int> doc_date_end_cal { get; set; }
        public string rec_memo { get; set; }
    }
}
