namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Approve_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int approve_status_id { get; set; }

        [Required]
        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(100)]
        public string approve_status_name { get; set; }
    }
}
