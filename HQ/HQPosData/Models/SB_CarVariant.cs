namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CarVariant
    {
        [Key]
        [StringLength(6)]
        public string Car_Variant_Code { get; set; }

        public int? Car_Brand_Code { get; set; }

        public int? Car_Model_Code { get; set; }

        [StringLength(100)]
        public string Car_Variant { get; set; }

        [StringLength(6)]
        public string Car_Brand_Codetxt { get; set; }

        [StringLength(6)]
        public string Car_Model_Codetxt { get; set; }

        [StringLength(255)]
        public string rec_date { get; set; }

        [StringLength(50)]
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
