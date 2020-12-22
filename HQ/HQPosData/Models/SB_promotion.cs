namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string pm_typesale { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pm_code { get; set; }

        [StringLength(255)]
        public string pm_name { get; set; }

        [StringLength(50)]
        public string pm_startdate { get; set; }

        [StringLength(50)]
        public string pm_enddate { get; set; }

        [StringLength(255)]
        public string pm_procode { get; set; }

        [StringLength(255)]
        public string pm_progroup_code { get; set; }

        public int? pm_pro_brand_code { get; set; }

        public int? pm_pro_model_code { get; set; }

        public int? pm_pro_size_code { get; set; }

        [StringLength(50)]
        public string pm_qty { get; set; }

        [StringLength(50)]
        public string pm_amt { get; set; }

        public double? pm_minqty { get; set; }

        public double? pm_maxqty { get; set; }

        public double? pm_minamt { get; set; }

        public double? pm_maxamt { get; set; }

        [StringLength(50)]
        public string pm_condition { get; set; }

        [StringLength(255)]
        public string free_procode { get; set; }

        [StringLength(50)]
        public string free_qty { get; set; }

        [StringLength(50)]
        public string free_amt_sale { get; set; }

        public double? free_qty_num { get; set; }

        public double? free_amt_sale_num { get; set; }

        [StringLength(50)]
        public string free_condition { get; set; }

        [StringLength(255)]
        public string free_remark { get; set; }

        [StringLength(50)]
        public string pm_cancel { get; set; }

        public int? pm_startdate_report { get; set; }

        public int? pm_enddate_report { get; set; }

        public int? Free_Locat_Code { get; set; }

        [StringLength(10)]
        public string sale_percent { get; set; }

        public double? sale_percent_num { get; set; }

        [StringLength(50)]
        public string sale_condition { get; set; }

        [StringLength(10)]
        public string sale_price { get; set; }

        public double? sale_price_num { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
