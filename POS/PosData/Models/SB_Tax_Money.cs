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
    
    public partial class SB_Tax_Money
    {
        public int tax_money_id { get; set; }
        public Nullable<int> tax_type_id { get; set; }
        public string tax_money_name { get; set; }
        public string flag_used { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
    }
}
