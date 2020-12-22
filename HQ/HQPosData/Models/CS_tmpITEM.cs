namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_tmpITEM
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
        [StringLength(120)]
        public string SN_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(120)]
        public string SN2_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        public int line_No { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(5)]
        public string sRepairID { get; set; }

        [StringLength(5)]
        public string sClamID { get; set; }

        public int? nlot { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nDiff { get; set; }

        [StringLength(15)]
        public string pro_code_new { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? pro_disamt { get; set; }

        [StringLength(500)]
        public string sRemark { get; set; }

        [StringLength(5)]
        public string sn_ID_close { get; set; }

        [StringLength(5)]
        public string sn_ID_cancle { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(120)]
        public string doc_no_ref { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? doc_no_run { get; set; }
    }
}
