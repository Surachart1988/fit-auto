namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBQty0000
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string ssecno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string FStoreID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime Invdate { get; set; }

        public double? FQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? Funitprice { get; set; }

        [StringLength(1)]
        public string pstatus { get; set; }

        [Column(TypeName = "money")]
        public decimal? discount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? startdate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? enddate { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
