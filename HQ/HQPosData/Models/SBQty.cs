namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SBQty")]
    public partial class SBQty
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ssecno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string FStoreID { get; set; }

        public int? FQty { get; set; }

        [StringLength(255)]
        public string edtdate { get; set; }

        [StringLength(255)]
        public string pstatus { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [StringLength(255)]
        public string StartDate { get; set; }

        [StringLength(255)]
        public string EndDate { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
