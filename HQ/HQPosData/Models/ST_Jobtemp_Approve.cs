namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Jobtemp_Approve
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(50)]
        public string app_docno { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        public int? line_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? sale_unit_code { get; set; }

        public int? locat_code { get; set; }

        public double? store_qty { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string pm_code { get; set; }

        [StringLength(255)]
        public string io_by { get; set; }

        public double? pro_amtlasted { get; set; }

        public double? vat_rate { get; set; }

        public double? pro_avg_vat { get; set; }

        public double? pro_avg_novat { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
