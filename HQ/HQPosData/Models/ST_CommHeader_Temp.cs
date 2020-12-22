namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CommHeader_Temp
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(20)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        [StringLength(20)]
        public string start_date { get; set; }

        [StringLength(20)]
        public string end_date { get; set; }

        public int? create_user_id { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
