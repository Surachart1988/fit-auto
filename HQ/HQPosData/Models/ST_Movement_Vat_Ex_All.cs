namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Movement_Vat_Ex_All
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string doc_name { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        public int? date_report { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string vat_type { get; set; }

        public double? product_qty { get; set; }

        public double? vat_qty { get; set; }

        public double? novat_qty { get; set; }

        public double? total_qty { get; set; }

        public double? vat_buy { get; set; }

        public double? vat_sale { get; set; }

        public double? average_cost { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
