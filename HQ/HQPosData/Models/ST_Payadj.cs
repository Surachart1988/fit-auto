namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Payadj
    {
        [Key]
        public int doc_no_run { get; set; }

        public int? branch_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string adjpay_type { get; set; }

        [StringLength(255)]
        public string adjpay_code { get; set; }

        public double? adj_amt { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
