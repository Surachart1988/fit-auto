namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Sub
    {
        [Key]
        [StringLength(50)]
        public string prosub_code { get; set; }

        [StringLength(255)]
        public string prosub_name { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        public double? km { get; set; }

        public double? ser_day { get; set; }

        public double? loop { get; set; }

        [StringLength(255)]
        public string link { get; set; }

        [StringLength(255)]
        public string link1 { get; set; }

        [StringLength(255)]
        public string link2 { get; set; }

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
