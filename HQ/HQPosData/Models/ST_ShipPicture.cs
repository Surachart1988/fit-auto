namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ShipPicture
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string pic_comment { get; set; }

        [StringLength(120)]
        public string pic_name { get; set; }

        [StringLength(500)]
        public string pic_path { get; set; }

        [Column(TypeName = "image")]
        public byte[] pic_binary { get; set; }

        public int? gen_id { get; set; }

        public int? pic_number { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
