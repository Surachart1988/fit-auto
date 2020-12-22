namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Set_Temp
    {
        [Key]
        public int doc_no_run { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        public int? ps_gen_id { get; set; }

        [StringLength(50)]
        public string ps_code { get; set; }

        [StringLength(120)]
        public string ps_pro_code { get; set; }

        public int? ps_line_no { get; set; }

        public int? ps_locat_code { get; set; }

        public double? ps_qty { get; set; }

        public double? ps_price { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
