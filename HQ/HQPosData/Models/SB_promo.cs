namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_promo
    {
        [Key]
        [StringLength(50)]
        public string pm_code { get; set; }

        [StringLength(255)]
        public string pm_name { get; set; }

        [StringLength(255)]
        public string pm_startdate { get; set; }

        [StringLength(255)]
        public string pm_enddate { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pm_model { get; set; }

        public int? pro_brand_code { get; set; }

        public int? pro_model_code { get; set; }

        public int? pro_size_code { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        [StringLength(255)]
        public string pro_type { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pm_cond { get; set; }

        [StringLength(255)]
        public string free_cond { get; set; }

        [StringLength(255)]
        public string pm_by { get; set; }

        public int? pm_byminqty { get; set; }

        public int? pm_bymaxqty { get; set; }

        public double? pm_byminamt { get; set; }

        public double? pm_bymaxamt { get; set; }

        [StringLength(255)]
        public string pm_promotetype { get; set; }

        [StringLength(255)]
        public string pm_prodtype { get; set; }

        [StringLength(255)]
        public string pm_product { get; set; }

        [StringLength(255)]
        public string pm_prodchoice { get; set; }

        [StringLength(255)]
        public string pm_progroup { get; set; }

        [StringLength(255)]
        public string pm_probrand { get; set; }

        [StringLength(255)]
        public string pm_promodel { get; set; }

        public double? pm_qty { get; set; }

        public double? pm_amt { get; set; }

        public double? pm_discpercent { get; set; }

        public double? pm_discbaht { get; set; }

        [StringLength(255)]
        public string pm_branch { get; set; }

        [StringLength(255)]
        public string pm_cancel { get; set; }

        [StringLength(255)]
        public string pm_remark { get; set; }

        [StringLength(255)]
        public string pm_type { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
