namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_SSTHeader
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

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? user_id { get; set; }

        [StringLength(10)]
        public string doc_close { get; set; }

        [StringLength(10)]
        public string doc_cancel { get; set; }

        [StringLength(50)]
        public string doc_candate { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
