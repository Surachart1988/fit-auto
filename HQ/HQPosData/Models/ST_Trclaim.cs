namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Trclaim
    {
        public int id { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string claim_date { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        public int? quqntity { get; set; }

        [StringLength(255)]
        public string claim_detail { get; set; }

        [StringLength(255)]
        public string clear_date { get; set; }

        [StringLength(255)]
        public string due_date { get; set; }

        public double? CLEAR_DATE_REPORT { get; set; }

        public double? DUE_DATE_REPORT { get; set; }

        public double? CLAIM_DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
