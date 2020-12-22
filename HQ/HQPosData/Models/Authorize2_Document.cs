namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Authorize2_Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int doc_id { get; set; }

        [StringLength(255)]
        public string doc_name_th { get; set; }

        [StringLength(255)]
        public string doc_name_en { get; set; }

        [StringLength(10)]
        public string create_per { get; set; }

        [StringLength(10)]
        public string edit_per { get; set; }

        [StringLength(10)]
        public string view_per { get; set; }

        [StringLength(10)]
        public string delete_per { get; set; }

        [StringLength(10)]
        public string approve_per { get; set; }

        [StringLength(10)]
        public string print_per { get; set; }

        [StringLength(10)]
        public string export_per { get; set; }

        [StringLength(10)]
        public string doc_used { get; set; }

        public int? doc_position { get; set; }

        [StringLength(50)]
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
