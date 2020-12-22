namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_paytype
    {
        [Key]
        [StringLength(50)]
        public string pay_code { get; set; }

        [StringLength(255)]
        public string pay_name { get; set; }

        [StringLength(255)]
        public string pay_date { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }
    }
}
