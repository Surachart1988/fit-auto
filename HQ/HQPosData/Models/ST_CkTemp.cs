namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CkTemp
    {
        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? line_no { get; set; }

        public int? check_id { get; set; }

        [StringLength(255)]
        public string check_name { get; set; }

        [StringLength(120)]
        public string deep_tire { get; set; }

        [StringLength(120)]
        public string wind_tire { get; set; }

        [StringLength(50)]
        public string ck_percent { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        [StringLength(255)]
        public string promotion { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
