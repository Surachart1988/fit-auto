namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Picture
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pic_comment { get; set; }

        [StringLength(255)]
        public string pic_comment_detail { get; set; }

        [StringLength(120)]
        public string pic_name { get; set; }

        [StringLength(500)]
        public string pic_path { get; set; }

        [Column(TypeName = "image")]
        public byte[] pic_binary { get; set; }

        public int? gen_id { get; set; }

        public int? pic_number { get; set; }

        [StringLength(50)]
        public string pic_from { get; set; }

        [StringLength(50)]
        public string pic_display { get; set; }

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
