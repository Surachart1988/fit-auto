namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int add_provid { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string add_province { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
