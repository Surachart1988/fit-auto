namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Movement_View
    {
        public int id { get; set; }

        public int? doc_no_run { get; set; }

        [Required]
        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        public int? locat_code { get; set; }

        public double? Move_Qty { get; set; }

        public double? Incre_qty { get; set; }

        public double? Decre_qty { get; set; }

        public double? Decre_qty_tmp { get; set; }

        public double? Total_qty { get; set; }

        public int? update_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
