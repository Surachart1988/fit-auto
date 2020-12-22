namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayCard
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string card_code { get; set; }

        [StringLength(255)]
        public string card_id { get; set; }

        public double? card_amt { get; set; }

        public int? user_pay_id { get; set; }

        [StringLength(20)]
        public string void_no { get; set; }

        public int? installment_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public int? expired_month { get; set; }

        public int? expired_year { get; set; }

        public int? appr_code { get; set; }

        public int? bank_code { get; set; }

        [StringLength(10)]
        public string connect_type { get; set; }

        [StringLength(10)]
        public string credit_type { get; set; }

        [StringLength(255)]
        public string card_remark { get; set; }
    }
}
