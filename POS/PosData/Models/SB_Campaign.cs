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
    
    public partial class SB_Campaign
    {
        public string campaign_id { get; set; }
        public string campaign_name { get; set; }
        public string campaign_add_date { get; set; }
        public string campaign_edit_date { get; set; }
        public string campaign_add_time { get; set; }
        public string campaign_edit_time { get; set; }
        public Nullable<bool> deleted { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}