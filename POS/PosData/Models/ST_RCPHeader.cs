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
    
    public partial class ST_RCPHeader
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public int doc_no_run { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string cus_type { get; set; }
        public string cus_paytype { get; set; }
        public string cus_code { get; set; }
        public string invoice_type { get; set; }
        public string member_code { get; set; }
        public string ref_jobmem { get; set; }
        public string car_reg { get; set; }
        public string car_chasis { get; set; }
        public string car_mileage { get; set; }
        public string ref_branchno { get; set; }
        public string ref_doccode { get; set; }
        public string ref_docno { get; set; }
        public string docref_no { get; set; }
        public string docref_date { get; set; }
        public string payment_duedate { get; set; }
        public string vat_type { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> ar_prodamt { get; set; }
        public Nullable<double> ar_servamt { get; set; }
        public Nullable<double> ar_amt { get; set; }
        public Nullable<double> ar_disamt { get; set; }
        public Nullable<double> ar_netamt { get; set; }
        public Nullable<double> ar_vatamt { get; set; }
        public Nullable<double> ar_totalamt { get; set; }
        public Nullable<double> ar_recamt { get; set; }
        public Nullable<double> ar_payamt { get; set; }
        public Nullable<double> ar_drcramt { get; set; }
        public Nullable<double> ar_taxamt { get; set; }
        public Nullable<double> ar_paycash { get; set; }
        public Nullable<double> ar_paycard { get; set; }
        public Nullable<double> ar_paychq { get; set; }
        public Nullable<double> ar_paydeposit { get; set; }
        public Nullable<double> ar_payother { get; set; }
        public Nullable<double> ar_onacccredit { get; set; }
        public Nullable<double> ar_writeup { get; set; }
        public Nullable<double> ar_writeoff { get; set; }
        public Nullable<double> ar_payown { get; set; }
        public Nullable<double> ar_directdebit { get; set; }
        public Nullable<double> ar_paytot { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public string doc_candate { get; set; }
        public string disputed { get; set; }
        public string receipt_flag { get; set; }
        public Nullable<int> detail_line { get; set; }
        public Nullable<int> print_no { get; set; }
        public string rec_memo { get; set; }
        public string discount_memo { get; set; }
        public Nullable<double> ar_pmamt { get; set; }
        public string user_id { get; set; }
        public string statement_no { get; set; }
        public Nullable<double> ar_payonacccredit { get; set; }
        public Nullable<double> credit_charge_percen { get; set; }
        public Nullable<int> credit_change_amt { get; set; }
        public string dep_branch { get; set; }
        public string dep_code { get; set; }
        public string dep_no { get; set; }
        public string emp_code { get; set; }
        public string AF_Status { get; set; }
        public string doc_no2 { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public Nullable<double> cust_limit { get; set; }
        public Nullable<double> cust_balance { get; set; }
        public Nullable<double> money_credit { get; set; }
        public string Flag_Vat_Transfer { get; set; }
        public string Update_Vat_Transfer { get; set; }
        public string ref_docno_vat { get; set; }
        public string ref_doccode_vat { get; set; }
        public string dealercode { get; set; }
        public string doc_canmemo { get; set; }
    }
}
