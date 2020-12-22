namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Chq_Status_Sub
    {
        [Key]
        [StringLength(200)]
        public string sub_chq_status_id { get; set; }

        public int? chq_status_id { get; set; }

        [StringLength(100)]
        public string sub_chq_status_name { get; set; }

        [StringLength(10)]
        public string sub_chq_status_used { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
