namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CarColor
    {
        [Key]
        public int color_id { get; set; }

        [StringLength(255)]
        public string color_name_th { get; set; }

        [StringLength(255)]
        public string color_name_en { get; set; }

        [StringLength(10)]
        public string flag_used { get; set; }

        [StringLength(20)]
        public string Dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }
    }
}
