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
    
    public partial class ST_SCARD_DETAIL_TB
    {
        public int ID { get; set; }
        public string DealerCode { get; set; }
        public string branch_no { get; set; }
        public string Branch_Name { get; set; }
        public string cus_code { get; set; }
        public string car_reg { get; set; }
        public Nullable<double> car_mileage { get; set; }
        public string date_card { get; set; }
        public string time_card { get; set; }
        public string scard_group { get; set; }
        public string progroup_name { get; set; }
        public string pro_tname { get; set; }
        public string pro_brand { get; set; }
        public Nullable<double> qty { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<double> point { get; set; }
        public string next_date { get; set; }
        public Nullable<double> car_nextmile { get; set; }
        public string doc_no { get; set; }
        public string PRO_CODE { get; set; }
        public string FLAG_NET { get; set; }
        public string prosub_code { get; set; }
        public string flag_used { get; set; }
        public Nullable<int> num_zigzag { get; set; }
        public string loan_bank { get; set; }
        public string loan_month { get; set; }
        public string TB_Status { get; set; }
        public string EU_Status { get; set; }
        public Nullable<double> EU_Point { get; set; }
        public string TOP_Status { get; set; }
        public Nullable<double> TOP_Point { get; set; }
        public string flag_net_tb { get; set; }
        public string Last_Update { get; set; }
        public string pro_ven_code { get; set; }
        public string pro_model_name { get; set; }
        public string pro_size_name { get; set; }
        public string car_prov_name { get; set; }
        public string icard_id { get; set; }
    }
}
