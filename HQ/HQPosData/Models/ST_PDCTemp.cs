namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PDCTemp
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string depay_name { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        public double? depay_price { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        public double? LINE_NO { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
