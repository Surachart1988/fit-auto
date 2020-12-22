namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_TextReport
    {
        [Key]
        public int auto_id { get; set; }

        [StringLength(50)]
        public string text_id { get; set; }

        [StringLength(50)]
        public string text_position { get; set; }

        [StringLength(50)]
        public string text_document { get; set; }

        [StringLength(2000)]
        public string text_report { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }
    }
}
