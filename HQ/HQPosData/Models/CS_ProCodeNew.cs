namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_ProCodeNew
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pro_code_new { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        [StringLength(255)]
        public string pro_tname { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pro_brand_code { get; set; }

        [StringLength(255)]
        public string pro_model_code { get; set; }

        [StringLength(255)]
        public string pro_size_code { get; set; }

        [StringLength(1)]
        public string cStatus { get; set; }
    }
}
