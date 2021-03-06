namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PrDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOC_NO_RUN { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_no { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? sale_unit_code { get; set; }

        [StringLength(255)]
        public string store_unit { get; set; }

        [StringLength(255)]
        public string tran_unit { get; set; }

        public double? tran_ratio { get; set; }

        public double? tran_qty { get; set; }

        public double? store_qty { get; set; }

        public double? unit_cost { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(255)]
        public string rec_close { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string pm_code { get; set; }

        public double? vat_rate { get; set; }

        public double? pro_sale_price { get; set; }

        public double? lasted_cost { get; set; }

        public double? pro_dis_all { get; set; }

        public int? locat_code { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
