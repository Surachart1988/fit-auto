namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SBQtyInv")]
    public partial class SBQtyInv
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ssecno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string FStoreID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime Invdate { get; set; }

        public double? FQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? Funitprice { get; set; }

        [StringLength(255)]
        public string pstatus { get; set; }

        [Column(TypeName = "money")]
        public decimal? discount { get; set; }

        [StringLength(255)]
        public string startdate { get; set; }

        [StringLength(255)]
        public string enddate { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
