namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CSTHeader_Approve
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

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
        public string pay_date { get; set; }

        [StringLength(255)]
        public string type_update { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [StringLength(255)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? ap_amt { get; set; }

        public double? ap_dispercent { get; set; }

        public double? ap_disamt { get; set; }

        public double? ap_netamt { get; set; }

        public double? ap_vatamt { get; set; }

        public double? ap_totalamt { get; set; }

        public double? ap_receiptnet { get; set; }

        public double? ap_receiptvat { get; set; }

        public double? ap_receiptamt { get; set; }

        public double? ap_payment { get; set; }

        public double? ap_drcramt { get; set; }

        public double? ap_adjamt { get; set; }

        public double? ap_taxamt { get; set; }

        public double? ap_inteamt { get; set; }

        public double? ap_paycash { get; set; }

        public double? ap_paycard { get; set; }

        public double? ap_paychq { get; set; }

        public double? ap_paydeposit { get; set; }

        public double? ap_payother { get; set; }

        public double? ap_paytot { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        public int? detail_line { get; set; }

        public double? ap_recamt { get; set; }

        public double? ap_writeoff { get; set; }

        public double? ap_writeup { get; set; }

        public double? ap_onacccredit { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(255)]
        public string change_avg { get; set; }

        [StringLength(255)]
        public string doc_canmemo { get; set; }

        public int? create_user_id { get; set; }

        [StringLength(50)]
        public string app_docno { get; set; }

        [StringLength(10)]
        public string approve_store_qty { get; set; }

        [StringLength(10)]
        public string admin_store_qty { get; set; }

        [StringLength(255)]
        public string admin_store_qty_memo { get; set; }

        public int? APP_DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
