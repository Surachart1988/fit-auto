namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Records
    {
        [Key]
        public int doc_no_run { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string ref_doc_no { get; set; }

        [StringLength(50)]
        public string ref_doc_date { get; set; }

        [StringLength(500)]
        public string comment_customer { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string doc_status { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        public int? user_id_edit { get; set; }

        [StringLength(50)]
        public string ip_address_edit { get; set; }

        public int? date_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
