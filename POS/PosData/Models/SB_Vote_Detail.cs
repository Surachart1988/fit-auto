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
    
    public partial class SB_Vote_Detail
    {
        public int id { get; set; }
        public int vote_id { get; set; }
        public int choice_id { get; set; }
        public string choice_name { get; set; }
        public Nullable<int> choice_score { get; set; }
        public string choice_date { get; set; }
        public string choice_time { get; set; }
        public Nullable<int> choice_used { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
