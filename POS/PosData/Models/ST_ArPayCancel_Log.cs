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
    
    public partial class ST_ArPayCancel_Log
    {
        public int doc_no_run { get; set; }
        public string branch_no { get; set; }
        public string sUserName { get; set; }
        public string ip_address { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string doc_no { get; set; }
        public Nullable<double> ar_totalamt { get; set; }
        public string dealercode { get; set; }
    }
}
