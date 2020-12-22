namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Bank
    {
        [Key]
        [StringLength(50)]
        public string bank_code { get; set; }

        [StringLength(255)]
        public string bank_name { get; set; }

        [StringLength(255)]
        public string REC_DATE { get; set; }

        [StringLength(200)]
        public string report_name { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }
    }
}
