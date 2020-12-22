namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_AVG_PRO_STOCK
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public double? move_qty { get; set; }

        public double? incre_qty { get; set; }

        public double? decre_qty { get; set; }

        public double? decre_qty_tmp { get; set; }

        public double? total_qty { get; set; }

        [Key]
        [Column(Order = 1)]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public double? pro_amt { get; set; }

        public double? pro_totalamt { get; set; }

        public double? avg_qty { get; set; }

        public double? avg_cost { get; set; }

        public int? ar_doc_no_run { get; set; }

        public int? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        [StringLength(50)]
        public string change_avg { get; set; }

        [StringLength(50)]
        public string docref_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
