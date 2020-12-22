namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Prov_Bak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prov_id { get; set; }

        [StringLength(255)]
        public string prov_name { get; set; }

        public int? zone_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
