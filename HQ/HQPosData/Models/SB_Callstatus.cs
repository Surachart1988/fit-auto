namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Callstatus
    {
        [Key]
        public int auto_id { get; set; }

        [StringLength(10)]
        public string Status_ID { get; set; }

        [StringLength(100)]
        public string Status_name { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
