namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Movement_Export
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(30)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        public double? move_qty { get; set; }

        public double? incre_qty { get; set; }

        public double? decre_qty { get; set; }

        public double? decre_qty_tmp { get; set; }

        public double? total_qty { get; set; }

        public int? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
