namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_AutoCheck_Set_Detail
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        public int? set_gen_id { get; set; }

        [StringLength(50)]
        public string set_code { get; set; }

        public int? set_check_id { get; set; }

        public int? set_line_no { get; set; }

        [StringLength(120)]
        public string set_product_1 { get; set; }

        [StringLength(120)]
        public string set_product_2 { get; set; }

        [StringLength(120)]
        public string set_product_3 { get; set; }

        public double? set_price { get; set; }

        [StringLength(50)]
        public string ck_percent { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        [StringLength(255)]
        public string promotion { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
