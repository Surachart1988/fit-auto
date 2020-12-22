namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_DocNo
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string sbranch_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string sdate { get; set; }

        [StringLength(1)]
        public string cflag { get; set; }
    }
}
