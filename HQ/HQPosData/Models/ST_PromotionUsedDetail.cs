namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PromotionUsedDetail
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(10)]
        public string pro_id { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public double? pro_price { get; set; }

        [StringLength(120)]
        public string pro_code_show { get; set; }

        public double? used_detail_total { get; set; }

        public int? give_qty { get; set; }

        public bool? give_product { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
