namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_dcDetail
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

        [StringLength(120)]
        public string SN_ID { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string cus_paytype { get; set; }

        [StringLength(255)]
        public string cus_code { get; set; }

        public int? sale_unit_code { get; set; }

        public double? store_qty { get; set; }

        public double? pro_costamt { get; set; }

        public double? pro_price { get; set; }

        public double? pro_amtlasted { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(255)]
        public string doc_close { get; set; }

        [StringLength(255)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        [StringLength(255)]
        public string io_by { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        public int? locat_code { get; set; }

        [StringLength(20)]
        public string doc_ref_no { get; set; }

        [StringLength(255)]
        public string pro_code_remark { get; set; }

        [StringLength(255)]
        public string doc_ref_no_sd { get; set; }
    }
}
