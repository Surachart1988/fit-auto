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
    
    public partial class SB_Prov_Tambol
    {
        public int id { get; set; }
        public Nullable<int> tambol_id { get; set; }
        public Nullable<int> tambol_code { get; set; }
        public string tambol_name { get; set; }
        public Nullable<int> amphur_id { get; set; }
        public Nullable<int> prov_id { get; set; }
        public Nullable<int> zone_id { get; set; }
        public string zipcode { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
    }
}