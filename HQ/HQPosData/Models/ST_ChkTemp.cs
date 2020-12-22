namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ChkTemp
    {
        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? line_no { get; set; }

        public int? check_id { get; set; }

        [StringLength(255)]
        public string check_name { get; set; }

        [StringLength(120)]
        public string check_product_1 { get; set; }

        [StringLength(120)]
        public string check_product_2 { get; set; }

        [StringLength(120)]
        public string check_product_3 { get; set; }

        public double? check_price { get; set; }

        [StringLength(50)]
        public string check_pass { get; set; }

        [StringLength(255)]
        public string check_comment { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
