namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_ProLocation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locat_code { get; set; }

        [StringLength(255)]
        public string location_code { get; set; }

        public double? pro_qoh { get; set; }

        [StringLength(255)]
        public string novat_status { get; set; }
    }
}
