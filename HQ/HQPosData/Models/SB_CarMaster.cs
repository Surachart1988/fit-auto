namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CarMaster
    {
        [Key]
        [StringLength(100)]
        public string Car_Code { get; set; }

        [StringLength(100)]
        public string Car_Brand_Codetxt { get; set; }

        [StringLength(255)]
        public string Car_Brand { get; set; }

        [StringLength(100)]
        public string Car_Model_Codetxt { get; set; }

        [StringLength(255)]
        public string Car_Model { get; set; }

        [StringLength(100)]
        public string Car_Variant_Code { get; set; }

        [StringLength(100)]
        public string Car_Variant { get; set; }

        [StringLength(255)]
        public string Car_Year_Code { get; set; }

        public double? Car_Year { get; set; }

        [StringLength(255)]
        public string Car_Desc { get; set; }
    }
}
