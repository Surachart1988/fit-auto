namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_sdDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal line_No { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

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

        public int? sale_unit_code { get; set; }

        public double? store_qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_amt { get; set; }

        [StringLength(5)]
        public string pro_code_close { get; set; }

        [StringLength(5)]
        public string pro_code_cancle { get; set; }

        [StringLength(10)]
        public string pro_code_cancle_date { get; set; }

        [StringLength(255)]
        public string ven_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(120)]
        public string SN_ID { get; set; }

        [StringLength(120)]
        public string SN2_ID { get; set; }

        [StringLength(15)]
        public string SN_pro_code_new { get; set; }

        public int? nlot { get; set; }

        [StringLength(50)]
        public string reduce_no { get; set; }

        [StringLength(15)]
        public string pro_code_new { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nDeep_Tyre { get; set; }

        [StringLength(2)]
        public string cStatus { get; set; }

        [StringLength(255)]
        public string repair_remark { get; set; }

        [StringLength(255)]
        public string clam_remark { get; set; }

        [StringLength(255)]
        public string reduce_remark { get; set; }

        [StringLength(255)]
        public string product_Remark { get; set; }

        [StringLength(1)]
        public string sn_ID_close { get; set; }

        [StringLength(1)]
        public string sn_ID_cancle { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_ref_no { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_disamt { get; set; }

        [StringLength(15)]
        public string Width_Face { get; set; }
    }
}
