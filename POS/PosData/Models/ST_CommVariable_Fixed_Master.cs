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
    
    public partial class ST_CommVariable_Fixed_Master
    {
        public int doc_no_run { get; set; }
        public string doc_no { get; set; }
        public Nullable<int> type_of_cal_id { get; set; }
        public Nullable<int> type_emp_id { get; set; }
        public Nullable<double> fixed_rate { get; set; }
        public string pro_code { get; set; }
        public string update_date { get; set; }
        public string update_time { get; set; }
        public string dealercode { get; set; }
        public string branch_no { get; set; }
    }
}
