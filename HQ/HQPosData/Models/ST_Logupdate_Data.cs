namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Logupdate_Data
    {
        [Key]
        public int logupdate_seq { get; set; }

        [StringLength(50)]
        public string po_log_id { get; set; }

        [StringLength(2)]
        public string logupdate_typetransfer { get; set; }

        [StringLength(200)]
        public string doc_id { get; set; }

        [StringLength(5)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(3)]
        public string doc_type { get; set; }

        [StringLength(10)]
        public string logupdate_type { get; set; }

        [StringLength(10)]
        public string logupdate_status { get; set; }

        [StringLength(300)]
        public string logupdate_note { get; set; }

        public DateTime? create_date { get; set; }

        [StringLength(50)]
        public string create_user { get; set; }
    }
}
