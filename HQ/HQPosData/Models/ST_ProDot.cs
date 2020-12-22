namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ProDot
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_dot { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public int? line_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
