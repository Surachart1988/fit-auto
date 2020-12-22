namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBSale_Temp
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string ssaleid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string ssecno { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string FStoreID { get; set; }

        [StringLength(255)]
        public string FSTOREDETAIL { get; set; }

        public int? FQty { get; set; }

        public double? FUNITPRICE { get; set; }

        public double? FPrice { get; set; }

        [StringLength(255)]
        public string saledate { get; set; }

        [StringLength(255)]
        public string saletype { get; set; }

        [StringLength(255)]
        public string salecash { get; set; }

        [Column(TypeName = "ntext")]
        public string SMemo { get; set; }

        [StringLength(255)]
        public string barcodeid { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
