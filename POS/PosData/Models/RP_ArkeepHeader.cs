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
    
    public partial class RP_ArkeepHeader
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string cus_code { get; set; }
        public string doc_code { get; set; }
        public Nullable<double> sum_totalamt { get; set; }
        public string pay_cur_date { get; set; }
        public Nullable<int> date_report { get; set; }
        public Nullable<double> DOC_BAL { get; set; }
        public string dealercode { get; set; }
    }
}
