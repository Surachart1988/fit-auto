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
    
    public partial class ST_DayEnd_Last
    {
        public int id { get; set; }
        public int branch_no { get; set; }
        public string doc_no { get; set; }
        public string emp_id { get; set; }
        public Nullable<System.DateTime> doc_date_start { get; set; }
        public Nullable<System.DateTime> doc_date_end { get; set; }
        public string money_default { get; set; }
        public string sum_paydeposit { get; set; }
        public string sum_amt { get; set; }
        public string sum_paycash { get; set; }
        public string amount_in_safe { get; set; }
        public string payment_total_cash { get; set; }
        public string payment_total { get; set; }
    }
}