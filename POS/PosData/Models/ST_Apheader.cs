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
    
    public partial class ST_Apheader
    {
        public string branch_no { get; set; }
        public string doc_no { get; set; }
        public int doc_no_run { get; set; }
        public string doc_code { get; set; }
        public string doc_date { get; set; }
        public string doc_time { get; set; }
        public string ven_code { get; set; }
        public string ref_branchno { get; set; }
        public string ref_doccode { get; set; }
        public string ref_docno { get; set; }
        public string docref_no { get; set; }
        public string docref_date { get; set; }
        public string pay_date { get; set; }
        public string emp_code { get; set; }
        public string vat_type { get; set; }
        public Nullable<double> vat_rate { get; set; }
        public Nullable<double> ap_amt { get; set; }
        public Nullable<double> ap_dispercent { get; set; }
        public Nullable<double> ap_disamt { get; set; }
        public Nullable<double> ap_netamt { get; set; }
        public Nullable<double> ap_vatamt { get; set; }
        public Nullable<double> ap_totalamt { get; set; }
        public Nullable<double> ap_receiptnet { get; set; }
        public Nullable<double> ap_receiptvat { get; set; }
        public Nullable<double> ap_receiptamt { get; set; }
        public Nullable<double> ap_payment { get; set; }
        public Nullable<double> ap_drcramt { get; set; }
        public Nullable<double> ap_adjamt { get; set; }
        public Nullable<double> ap_taxamt { get; set; }
        public Nullable<double> ap_inteamt { get; set; }
        public Nullable<double> ap_paycash { get; set; }
        public Nullable<double> ap_paycard { get; set; }
        public Nullable<double> ap_paychq { get; set; }
        public Nullable<double> ap_paydeposit { get; set; }
        public Nullable<double> ap_payother { get; set; }
        public Nullable<double> ap_paytot { get; set; }
        public string doc_close { get; set; }
        public string doc_cancel { get; set; }
        public string doc_candate { get; set; }
        public Nullable<int> detail_line { get; set; }
        public Nullable<double> ap_recamt { get; set; }
        public Nullable<double> ap_writeoff { get; set; }
        public Nullable<double> ap_writeup { get; set; }
        public Nullable<double> ap_onacccredit { get; set; }
        public string rec_memo { get; set; }
        public string AF_Status { get; set; }
        public string doc_no2 { get; set; }
        public Nullable<double> DATE_REPORT { get; set; }
        public Nullable<double> ven_limit { get; set; }
        public Nullable<double> ven_balance { get; set; }
        public Nullable<double> DOCREFDATE_REPORT { get; set; }
        public string bill_novat_status { get; set; }
        public string tire_import { get; set; }
        public string novat_send { get; set; }
        public string po_config_ini { get; set; }
        public string Flag_Vat_Transfer { get; set; }
        public string Update_Vat_Transfer { get; set; }
        public string dealercode { get; set; }
        public string rec_memo_cancel { get; set; }
    }
}
