namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Qty
    {
        [Key]
        public int pro_qty_id { get; set; }

        [Required]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [Required]
        [StringLength(120)]
        public string pro_code { get; set; }

        public double? pro_poqty { get; set; }

        public double? pro_ohqty { get; set; }

        public double? pro_otqty { get; set; }

        public double? pro_accqty { get; set; }

        [StringLength(50)]
        public string last_update { get; set; }
    }
}
