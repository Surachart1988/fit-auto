namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Letter
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [Column(TypeName = "ntext")]
        public string text01 { get; set; }

        [Column(TypeName = "ntext")]
        public string text02 { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
