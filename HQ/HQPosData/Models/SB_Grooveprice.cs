namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Grooveprice
    {
        public int id { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string groove_type { get; set; }

        [StringLength(255)]
        public string groove_name { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string progroup_code { get; set; }

        public int? pro_brand_code { get; set; }

        public int? pro_model_code { get; set; }

        [StringLength(50)]
        public string sale_type { get; set; }

        [StringLength(50)]
        public string rate_type { get; set; }

        public double? rate_price { get; set; }

        [StringLength(50)]
        public string groove_start_date { get; set; }

        [StringLength(10)]
        public string cancel_status { get; set; }

        [StringLength(50)]
        public string start_date_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
