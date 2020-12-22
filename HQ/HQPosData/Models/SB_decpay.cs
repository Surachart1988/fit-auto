namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_decpay
    {
        [Key]
        [StringLength(50)]
        public string decpay_code { get; set; }

        [StringLength(255)]
        public string decpay_name { get; set; }

        [StringLength(255)]
        public string decpay_date { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
