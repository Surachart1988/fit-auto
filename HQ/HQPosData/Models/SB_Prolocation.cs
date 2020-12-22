namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Prolocation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locat_code { get; set; }

        [StringLength(255)]
        public string location_code { get; set; }

        public double? pro_qoh { get; set; }

        [StringLength(255)]
        public string novat_status { get; set; }

        public double? pro_qoh_export { get; set; }
    }
}
