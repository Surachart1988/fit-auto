namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayOther
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
        public string pay_code { get; set; }

        [StringLength(255)]
        public string pay_id { get; set; }

        public double? crd_amt { get; set; }

        public int? user_pay_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public string crd_remark { get; set; }
    }
}
