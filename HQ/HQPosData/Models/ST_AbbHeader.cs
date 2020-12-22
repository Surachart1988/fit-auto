namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_AbbHeader
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        [StringLength(20)]
        public string cus_type { get; set; }

        [StringLength(20)]
        public string cus_paycode { get; set; }

        [StringLength(20)]
        public string cus_code_org { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        [StringLength(20)]
        public string invoice_type { get; set; }

        [StringLength(20)]
        public string member_code { get; set; }

        [StringLength(20)]
        public string ref_jobmem { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        [StringLength(200)]
        public string car_chasis { get; set; }

        public int? car_mileage { get; set; }

        [StringLength(20)]
        public string ref_branchno { get; set; }

        [StringLength(20)]
        public string ref_doccode { get; set; }

        [StringLength(20)]
        public string ref_docno { get; set; }

        [StringLength(20)]
        public string docref_no { get; set; }

        [StringLength(20)]
        public string docref_date { get; set; }

        [StringLength(20)]
        public string payment_duedate { get; set; }

        [StringLength(10)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? ar_prodamt { get; set; }

        public double? ar_servamt { get; set; }

        public double? ar_amt { get; set; }

        public double? ar_disamt { get; set; }

        public double? ar_netamt { get; set; }

        public double? ar_vatamt { get; set; }

        public double? ar_totalamt { get; set; }

        public double? ar_recamt { get; set; }

        public double? ar_payamt { get; set; }

        public double? ar_drcramt { get; set; }

        public double? ar_taxamt { get; set; }

        public double? ar_paycash { get; set; }

        public double? ar_paycard { get; set; }

        public double? ar_paychq { get; set; }

        public double? ar_paydeposit { get; set; }

        public double? ar_payother { get; set; }

        public double? ar_onacccredit { get; set; }

        public double? ar_writeup { get; set; }

        public double? ar_writeoff { get; set; }

        public double? ar_payown { get; set; }

        public double? ar_directdebit { get; set; }

        public double? ar_paytot { get; set; }

        [StringLength(10)]
        public string doc_close { get; set; }

        [StringLength(10)]
        public string doc_cancel { get; set; }

        [StringLength(20)]
        public string doc_candate { get; set; }

        [StringLength(50)]
        public string disputed { get; set; }

        [StringLength(50)]
        public string receipt_flag { get; set; }

        public int? detail_line { get; set; }

        public int? print_no { get; set; }

        [StringLength(2000)]
        public string rec_memo { get; set; }

        [StringLength(2000)]
        public string discount_memo { get; set; }

        public double? ar_pmamt { get; set; }

        [StringLength(20)]
        public string user_id { get; set; }

        [StringLength(20)]
        public string statement_no { get; set; }

        public double? ar_payonacccredit { get; set; }

        public double? credit_charge_percen { get; set; }

        public double? credit_charge_amt { get; set; }

        [StringLength(50)]
        public string dep_branch { get; set; }

        [StringLength(50)]
        public string dep_code { get; set; }

        [StringLength(50)]
        public string dep_no { get; set; }

        [StringLength(20)]
        public string emp_code { get; set; }

        [StringLength(20)]
        public string AF_Status { get; set; }

        [StringLength(20)]
        public string doc_no2 { get; set; }

        [StringLength(20)]
        public string FULL_PAYDATE { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        public int? DATE_REPORT { get; set; }

        public double? cust_limit { get; set; }

        public double? cust_balance { get; set; }

        [StringLength(20)]
        public string pcc_docno { get; set; }

        [StringLength(20)]
        public string warranty_date { get; set; }

        [StringLength(50)]
        public string voidno { get; set; }

        [StringLength(10)]
        public string PRINT_WARRANTY { get; set; }

        public int? NUM_PRINT_WARRANTY { get; set; }

        [StringLength(20)]
        public string doc_payment { get; set; }

        [StringLength(20)]
        public string docno_ref { get; set; }

        [StringLength(20)]
        public string docno_refdate { get; set; }

        [StringLength(120)]
        public string car_reg_tail { get; set; }

        public int? car_tail_mileage { get; set; }

        public double? car_tail_avg { get; set; }

        [StringLength(10)]
        public string ST_RPADETAIL_FLAG { get; set; }

        [StringLength(10)]
        public string ST_RCPHeader_FLAG { get; set; }

        [StringLength(10)]
        public string ST_RDPHeader_FLAG { get; set; }

        [StringLength(10)]
        public string ST_Rdisc_Head_FLAG { get; set; }

        [StringLength(10)]
        public string ST_BILDetail_FLAG { get; set; }

        [StringLength(10)]
        public string RZ_FLAG { get; set; }

        [StringLength(10)]
        public string Warranty_FLAG { get; set; }

        [StringLength(20)]
        public string Last_edit_date { get; set; }

        [StringLength(20)]
        public string icard_id { get; set; }

        [StringLength(20)]
        public string Dealercode { get; set; }

        [StringLength(500)]
        public string Branch_name { get; set; }

        public int? record_total { get; set; }

        [StringLength(20)]
        public string Last_Update { get; set; }

        [StringLength(10)]
        public string Flag_card_add { get; set; }

        [StringLength(10)]
        public string Flag_nocard_add { get; set; }

        [StringLength(10)]
        public string Flag_card_add_date { get; set; }

        [StringLength(10)]
        public string Flag_nocard_add_date { get; set; }

        [StringLength(10)]
        public string Pay_PayCard_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayCash_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayCashCard_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayChq_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayDep_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_Paydoc_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayOnAcc_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_PayOther_FLAG { get; set; }

        [StringLength(10)]
        public string Pay_RPADETAIL_FLAG { get; set; }

        public double? sum_store_qty { get; set; }

        public double? car_avg { get; set; }

        public double? km_perday { get; set; }

        public int? print_total { get; set; }

        [StringLength(10)]
        public string flag_net_tb { get; set; }

        [StringLength(255)]
        public string car_chasis_tail { get; set; }

        public int? car_btail_mileage { get; set; }

        public int? km_tail_perday { get; set; }

        public int? km_tail_permonth { get; set; }

        [StringLength(20)]
        public string last_tail_contdate { get; set; }

        [StringLength(50)]
        public string flag_fleet { get; set; }

        [StringLength(20)]
        public string cuscont_code { get; set; }

        [StringLength(20)]
        public string coupon_id { get; set; }

        [StringLength(20)]
        public string config_tyre { get; set; }

        public int? docref_date_report { get; set; }

        [StringLength(2000)]
        public string rec_memo2 { get; set; }

        [StringLength(500)]
        public string doc_canmemo { get; set; }

        [StringLength(20)]
        public string Bill_Status { get; set; }

        [StringLength(10)]
        public string Flag_Vat_Transfer { get; set; }

        [StringLength(50)]
        public string Update_Vat_Transfer { get; set; }
    }
}
