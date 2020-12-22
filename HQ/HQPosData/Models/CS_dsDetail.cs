namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_dsDetail
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_No { get; set; }

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

        [StringLength(50)]
        public string ven_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(120)]
        public string SN_ID { get; set; }

        [StringLength(120)]
        public string SN2_ID { get; set; }

        public int? nlot { get; set; }

        [StringLength(15)]
        public string pro_code_new { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nDeep_tyre { get; set; }

        [StringLength(5)]
        public string sn_ID_close { get; set; }

        [StringLength(5)]
        public string sn_ID_cancle { get; set; }

        public int? doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_ref_no { get; set; }

        [StringLength(120)]
        public string DOT { get; set; }

        [StringLength(120)]
        public string SN_REMARK { get; set; }

        public virtual CS_dsHeader CS_dsHeader { get; set; }
    }
}
