namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_tmpcdDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string No_ref { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string pro_code { get; set; }

        public int? sale_unit_code { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(8)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        public double? store_qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_distotamt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_amt { get; set; }

        [StringLength(5)]
        public string pro_code_close { get; set; }

        [StringLength(5)]
        public string pro_code_cancle { get; set; }

        [StringLength(10)]
        public string pro_code_cancle_date { get; set; }

        [StringLength(255)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        [StringLength(255)]
        public string pro_model { get; set; }

        [Key]
        [Column(Order = 4)]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_no_ref { get; set; }
    }
}
