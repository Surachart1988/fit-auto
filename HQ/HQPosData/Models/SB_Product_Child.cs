namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Child
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string root_pro_code { get; set; }

        [StringLength(120)]
        public string child_pro_code { get; set; }

        public int? child_unit_code { get; set; }

        public double? child_qty { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        public int? date_report { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
