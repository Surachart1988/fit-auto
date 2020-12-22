namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Title
    {
        [Key]
        public int TitleID { get; set; }

        [StringLength(50)]
        public string TitleName { get; set; }

        public int? FlagCheck { get; set; }
    }
}
