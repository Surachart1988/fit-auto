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
    
    public partial class ev_chq_pay_list
    {
        public int DOC_NO_RUN { get; set; }
        public Nullable<int> trans_no { get; set; }
        public string trans_date { get; set; }
        public string cq_code { get; set; }
        public string trans_type { get; set; }
        public string clearing_date { get; set; }
        public string cq_date { get; set; }
        public string cq_desciption { get; set; }
        public Nullable<double> cq_amount { get; set; }
        public string trans_status { get; set; }
        public string chq_cancel { get; set; }
        public string trans_type_memo { get; set; }
        public Nullable<double> CLEAR_DATE_REPORT { get; set; }
        public string cq_date_report { get; set; }
        public string chq_status_name_call { get; set; }
        public string dealercode { get; set; }
    }
}