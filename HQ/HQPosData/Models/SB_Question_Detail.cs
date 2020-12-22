namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Question_Detail
    {
        [Key]
        public int question_detail_id { get; set; }

        public int? question_id { get; set; }

        [StringLength(500)]
        public string question_detail { get; set; }

        [StringLength(50)]
        public string question_detail_used { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
