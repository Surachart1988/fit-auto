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
    
    public partial class ev_data_bill_business
    {
        public string doc_no { get; set; }
        public string pro_code { get; set; }
        public int line_no { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public string doc_date { get; set; }
        public string doc_date2 { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public string cus_code { get; set; }
        public string ICARD_ID { get; set; }
        public string car_reg { get; set; }
        public string cartypename { get; set; }
        public string carbrand { get; set; }
        public string carmodel { get; set; }
        public string pro_name { get; set; }
        public string progroupname { get; set; }
        public string probrand { get; set; }
        public string proModel { get; set; }
        public string prosize { get; set; }
        public Nullable<double> tran_qty { get; set; }
        public Nullable<double> pro_price { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public Nullable<double> Average_Cost { get; set; }
    }
}