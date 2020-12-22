namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_RDPHeader
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string cus_paytype { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string invoice_type { get; set; }

        [StringLength(255)]
        public string member_code { get; set; }

        [StringLength(255)]
        public string ref_jobmem { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(255)]
        public string car_mileage { get; set; }

        [StringLength(255)]
        public string ref_branchno { get; set; }

        [StringLength(255)]
        public string ref_doccode { get; set; }

        [StringLength(255)]
        public string ref_docno { get; set; }

        [StringLength(255)]
        public string docref_no { get; set; }

        [StringLength(255)]
        public string docref_date { get; set; }

        [StringLength(255)]
        public string payment_duedate { get; set; }

        [StringLength(255)]
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

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        [StringLength(255)]
        public string disputed { get; set; }

        [StringLength(255)]
        public string receipt_flag { get; set; }

        public int? detail_line { get; set; }

        public int? print_no { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [Column(TypeName = "ntext")]
        public string discount_memo { get; set; }

        public double? ar_pmamt { get; set; }

        [StringLength(255)]
        public string user_id { get; set; }

        [StringLength(255)]
        public string statement_no { get; set; }

        public double? ar_payonacccredit { get; set; }

        public double? credit_charge_percen { get; set; }

        public int? credit_charge_amt { get; set; }

        [StringLength(255)]
        public string dep_branch { get; set; }

        [StringLength(255)]
        public string dep_code { get; set; }

        [StringLength(255)]
        public string dep_no { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        public double? DATE_REPORT { get; set; }

        public double? cust_limit { get; set; }

        public double? cust_balance { get; set; }

        public double? money_credit { get; set; }

        [StringLength(10)]
        public string Flag_Vat_Transfer { get; set; }

        [StringLength(50)]
        public string Update_Vat_Transfer { get; set; }

        [StringLength(50)]
        public string ref_docno_vat { get; set; }

        [StringLength(10)]
        public string ref_doccode_vat { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
