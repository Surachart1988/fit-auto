namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBWorkf_Detail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string sworkf { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string SStep { get; set; }

        [StringLength(255)]
        public string Sempno { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
