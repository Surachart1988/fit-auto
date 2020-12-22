namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRepair_case
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string sRepairID { get; set; }

        [StringLength(50)]
        public string sRepairName { get; set; }
    }
}
