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
    
    public partial class SB_TBPoint
    {
        public int id { get; set; }
        public string pro_code { get; set; }
        public string eu_status { get; set; }
        public string top_status { get; set; }
        public Nullable<double> price_point { get; set; }
        public Nullable<double> eu_point { get; set; }
        public Nullable<double> top_point { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
