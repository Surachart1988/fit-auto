namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PDCHeader
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

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(255)]
        public string ref_number { get; set; }

        [StringLength(255)]
        public string ref_date { get; set; }

        public int? credit_term { get; set; }

        public double? credit_limit { get; set; }

        [StringLength(255)]
        public string ven_paytype { get; set; }

        public double? money_credit { get; set; }

        public double? pay_net_total { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [StringLength(255)]
        public string flag_status { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        public double? DATE_REPORT { get; set; }

        public double? ven_limit { get; set; }

        public double? ven_balance { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
