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
    
    public partial class SB_product_group_detail
    {
        public string pro_group_code { get; set; }
        public string pro_code { get; set; }
        public string pro_name { get; set; }
        public Nullable<int> pro_qty { get; set; }
        public Nullable<double> pro_price { get; set; }
        public int DOC_NO_RUN { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
    }
}
