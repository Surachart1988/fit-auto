namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_WTHHeader
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(50)]
        public string ref_docno { get; set; }

        public int? tax_con_id { get; set; }

        public int? tax_type_id { get; set; }

        public int? tax_money_id { get; set; }

        [StringLength(10)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? ap_netamt { get; set; }

        public double? ap_totalamt { get; set; }

        [StringLength(50)]
        public string docno_ref { get; set; }

        [StringLength(50)]
        public string docno_ref_date { get; set; }

        [StringLength(50)]
        public string tax_id { get; set; }

        [StringLength(50)]
        public string tax_branch_id { get; set; }

        [StringLength(50)]
        public string tax_branch { get; set; }

        public double? total_tax { get; set; }

        public double? total_tax_vat { get; set; }

        [StringLength(2000)]
        public string rec_memo { get; set; }

        public int? add_user_id { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        public int? edit_user_id { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(50)]
        public string cancel_detail { get; set; }

        public int? date_report { get; set; }

        [StringLength(50)]
        public string doc_date_used { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
