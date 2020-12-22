namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_prounit
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int unit_code { get; set; }

        [StringLength(255)]
        public string unit_name { get; set; }

        public double? unit_ratio { get; set; }

        [StringLength(255)]
        public string buy_flag { get; set; }

        [StringLength(255)]
        public string sale_flag { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

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
