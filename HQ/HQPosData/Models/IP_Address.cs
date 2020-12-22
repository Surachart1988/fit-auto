namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IP_Address
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string ip_main { get; set; }

        [Column("ip_address")]
        [StringLength(255)]
        public string ip_address1 { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
