namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_document
    {
        [Key]
        [StringLength(20)]
        public string doc_code { get; set; }

        [StringLength(150)]
        public string doc_desc { get; set; }

        [StringLength(20)]
        public string doc_type { get; set; }

        [StringLength(50)]
        public string doc_userbranch { get; set; }

        [StringLength(50)]
        public string doc_usetype { get; set; }

        [StringLength(50)]
        public string doc_runby { get; set; }

        public int? doc_rundigit { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(20)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }
    }
}
