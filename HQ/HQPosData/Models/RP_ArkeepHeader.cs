namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_ArkeepHeader
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        public double? sum_totalamt { get; set; }

        [StringLength(255)]
        public string pay_cur_date { get; set; }

        public int? date_report { get; set; }

        public double? DOC_BAL { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
