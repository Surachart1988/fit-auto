namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_WTHDetail
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string income1_rate_name { get; set; }

        public double? income1_rate { get; set; }

        public double? income1_amt { get; set; }

        public double? income1_vatamt { get; set; }

        [StringLength(255)]
        public string income2_rate_name { get; set; }

        public double? income2_rate { get; set; }

        public double? income2_amt { get; set; }

        public double? income2_vatamt { get; set; }

        [StringLength(255)]
        public string income3_rate_name { get; set; }

        public double? income3_rate { get; set; }

        public double? income3_amt { get; set; }

        public double? income3_vatamt { get; set; }

        [StringLength(255)]
        public string income4_rate_name { get; set; }

        public double? income4_rate { get; set; }

        public double? income4_amt { get; set; }

        public double? income4_vatamt { get; set; }

        [StringLength(255)]
        public string income4_2_rate_name { get; set; }

        public double? income4_2_1_1_rate { get; set; }

        public double? income4_2_1_1_amt { get; set; }

        public double? income4_2_1_1_vatamt { get; set; }

        public double? income4_2_1_2_rate { get; set; }

        public double? income4_2_1_2_amt { get; set; }

        public double? income4_2_1_2_vatamt { get; set; }

        public double? income4_2_1_3_rate { get; set; }

        public double? income4_2_1_3_amt { get; set; }

        public double? income4_2_1_3_vatamt { get; set; }

        [StringLength(255)]
        public string income4_2_1_4_rate_other { get; set; }

        public double? income4_2_1_4_rate { get; set; }

        public double? income4_2_1_4_amt { get; set; }

        public double? income4_2_1_4_vatamt { get; set; }

        public double? income4_2_2_rate { get; set; }

        public double? income4_2_2_amt { get; set; }

        public double? income4_2_2_vatamt { get; set; }

        public double? income4_2_3_rate { get; set; }

        public double? income4_2_3_amt { get; set; }

        public double? income4_2_3_vatamt { get; set; }

        [StringLength(255)]
        public string income5_rate_name { get; set; }

        public double? income5_rate { get; set; }

        public double? income5_amt { get; set; }

        public double? income5_vatamt { get; set; }

        [StringLength(255)]
        public string income6_rate_name { get; set; }

        public double? income6_rate { get; set; }

        public double? income6_amt { get; set; }

        public double? income6_vatamt { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
