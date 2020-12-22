namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_proprice
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string proprice_date { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string cus_groupcode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string dealercode { get; set; }

        public double? pro_price_retail { get; set; }

        public double? pro_price_ws { get; set; }

        public int? unit_code { get; set; }

        [StringLength(255)]
        public string unit_name { get; set; }

        public double? pro_discpercent { get; set; }

        public double? pro_discount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }
    }
}
