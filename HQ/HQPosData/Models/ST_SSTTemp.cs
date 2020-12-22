namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_SSTTemp
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 2)]
        public int doc_no_run { get; set; }

        public int? line_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? locat_code { get; set; }

        public double? store_qty { get; set; }

        [StringLength(10)]
        public string flag_cst { get; set; }

        public long? last_update { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
