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
    
    public partial class ST_CST_Create_Cancel
    {
        public int doc_no_run { get; set; }
        public int random_id { get; set; }
        public string branch_no { get; set; }
        public string date_create { get; set; }
        public string time_create { get; set; }
        public string pro_code { get; set; }
        public Nullable<int> locat_code { get; set; }
        public Nullable<double> pro_qoh { get; set; }
        public Nullable<int> user_id { get; set; }
        public string dealercode { get; set; }
    }
}
