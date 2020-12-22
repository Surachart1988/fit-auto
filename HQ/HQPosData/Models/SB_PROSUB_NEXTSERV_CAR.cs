namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_PROSUB_NEXTSERV_CAR
    {
        [Key]
        [StringLength(50)]
        public string prosub_code { get; set; }

        [StringLength(255)]
        public string SUB_NEXTSERV_Name { get; set; }

        [StringLength(255)]
        public string SUB_NEXTSERV_Code { get; set; }

        public double? Km { get; set; }

        public double? Ser_day { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
