namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayOwn
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string own_no { get; set; }

        [StringLength(255)]
        public string own_date { get; set; }

        [StringLength(255)]
        public string pay_date { get; set; }

        [StringLength(255)]
        public string chq_bankcode { get; set; }

        [StringLength(255)]
        public string chq_bankbranch { get; set; }

        [StringLength(255)]
        public string pay_custype { get; set; }

        [StringLength(255)]
        public string pay_cuscode { get; set; }

        public double? own_amt { get; set; }

        public double? own_payamt { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
