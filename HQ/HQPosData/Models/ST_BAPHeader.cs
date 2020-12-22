namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_BAPHeader
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

        [StringLength(255)]
        public string ref_number { get; set; }

        [StringLength(50)]
        public string ref_date { get; set; }

        public int? ven_credit_term { get; set; }

        public double? ven_credit_limit { get; set; }

        public double? ven_balance { get; set; }

        public double? pay_net_total { get; set; }

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
        public string doc_cancel { get; set; }

        [StringLength(2000)]
        public string cancel_detail { get; set; }

        public int? date_report { get; set; }

        public int? print_total { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
