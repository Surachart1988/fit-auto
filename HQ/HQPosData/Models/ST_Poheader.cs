namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Poheader
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string pr_doccode { get; set; }

        [StringLength(255)]
        public string pr_docno { get; set; }

        [StringLength(255)]
        public string docref_no { get; set; }

        [StringLength(255)]
        public string docref_date { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(255)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public int? ship_to { get; set; }

        [StringLength(255)]
        public string ship_date { get; set; }

        public double? po_amt { get; set; }

        public double? po_dispercent { get; set; }

        public double? po_discamt { get; set; }

        public double? po_netamt { get; set; }

        public double? po_vatamt { get; set; }

        public double? po_totalamt { get; set; }

        [StringLength(255)]
        public string po_close { get; set; }

        [StringLength(255)]
        public string po_cancel { get; set; }

        [StringLength(255)]
        public string po_status { get; set; }

        public int? po_laslineno { get; set; }

        public int? count_dtl { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string po_by { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public double? DATE_REPORT { get; set; }

        public double? ven_limit { get; set; }

        public double? ven_balance { get; set; }

        [StringLength(10)]
        public string po_cancel_qty { get; set; }

        [StringLength(10)]
        public string po_close_cancel_qty { get; set; }

        public int? approve_status_id { get; set; }

        public int? approve_ok_user_id { get; set; }

        [StringLength(255)]
        public string approve_ok_date { get; set; }

        [StringLength(255)]
        public string approve_ok_time { get; set; }

        public int? approve_waiting_user_id { get; set; }

        [StringLength(255)]
        public string approve_waiting_date { get; set; }

        [StringLength(255)]
        public string approve_waiting_time { get; set; }

        public int? approve_reject_user_id { get; set; }

        [StringLength(255)]
        public string approve_reject_date { get; set; }

        [StringLength(255)]
        public string approve_reject_time { get; set; }

        public int? lot_no { get; set; }

        [StringLength(20)]
        public string lot_date_time { get; set; }

        [StringLength(20)]
        public string flag_hq_create { get; set; }
    }
}
