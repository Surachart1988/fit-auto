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
    
    public partial class ev_data_bill_business_cn_dn
    {
        public string doc_no { get; set; }
        public string pro_code { get; set; }
        public int line_no { get; set; }
        public string doc_date { get; set; }
        public string doc_date2 { get; set; }
        public string doc_date3 { get; set; }
        public string cus_code { get; set; }
        public string ICARD_ID { get; set; }
        public string car_reg { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
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
        public string vat_type { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> pro_disp1 { get; set; }
        public Nullable<double> pro_disp2 { get; set; }
        public Nullable<double> pro_disamt { get; set; }
        public Nullable<double> pro_distotamt { get; set; }
        public Nullable<double> pro_amt { get; set; }
        public Nullable<double> Average_Cost { get; set; }
        public Nullable<double> total_cn { get; set; }
        public Nullable<double> total_dn { get; set; }
        public string Pay_PayCard_FLAG { get; set; }
        public string Pay_PayCash_FLAG { get; set; }
        public string Pay_PayCashCard_FLAG { get; set; }
        public string Pay_PayChq_FLAG { get; set; }
        public string Pay_PayDep_FLAG { get; set; }
        public string Pay_Paydoc_FLAG { get; set; }
        public string Pay_PayOnAcc_FLAG { get; set; }
        public string Pay_PayOther_FLAG { get; set; }
        public string Pay_RPADETAIL_FLAG { get; set; }
        public string loan_month { get; set; }
        public string loan_bank { get; set; }
    }
}