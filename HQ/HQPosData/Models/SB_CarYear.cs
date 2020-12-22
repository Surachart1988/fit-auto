namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CarYear
    {
        [Key]
        [StringLength(6)]
        public string Car_Year_Code { get; set; }

        [StringLength(4)]
        public string Car_Year_Name { get; set; }
    }
}
