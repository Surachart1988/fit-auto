namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_bankaccount
    {
        [Key]
        [StringLength(50)]
        public string bankacc_code { get; set; }

        [StringLength(255)]
        public string bankacc_id { get; set; }

        [StringLength(255)]
        public string bankacc_name { get; set; }

        [StringLength(255)]
        public string bank_code { get; set; }

        [StringLength(255)]
        public string bank_branch { get; set; }

        public double? open_balance { get; set; }

        [StringLength(255)]
        public string open_date { get; set; }

        public double? current_balance { get; set; }

        [StringLength(255)]
        public string current_date { get; set; }

        [StringLength(255)]
        public string bankacc_type { get; set; }

        [StringLength(255)]
        public string date_type { get; set; }

        [StringLength(255)]
        public string bankacc_remark { get; set; }

        public double? cq_date_top { get; set; }

        public double? cq_date_left { get; set; }

        public double? cq_payto_top { get; set; }

        public double? cq_payto_left { get; set; }

        public double? cq_amount_top { get; set; }

        public double? cq_amount_left { get; set; }

        public double? cq_baht_top { get; set; }

        public int? date_report { get; set; }

        public double? cq_baht_left { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
