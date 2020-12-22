namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_TAXSUMGROUP
    {
        [StringLength(50)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string progroup_code { get; set; }

        [StringLength(50)]
        public string progroup_name { get; set; }

        public double? total_qty { get; set; }

        public double? price { get; set; }

        public int id { get; set; }

        public double? pro_price_retail { get; set; }

        public double? pro_price_ws { get; set; }

        public double? avg_cost_recal { get; set; }

        public int? doc_no_run { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
