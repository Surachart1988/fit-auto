namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBSale_Head_Prn
    {
        [Key]
        [StringLength(255)]
        public string SSaleID { get; set; }

        [StringLength(255)]
        public string Scompno { get; set; }

        [StringLength(255)]
        public string SDeparno { get; set; }

        [StringLength(255)]
        public string SSecno { get; set; }

        [StringLength(255)]
        public string Sale_type { get; set; }

        [StringLength(255)]
        public string Cash_type { get; set; }

        [Column(TypeName = "money")]
        public decimal? Change_money { get; set; }

        [StringLength(255)]
        public string Dsaledate { get; set; }

        [StringLength(255)]
        public string Dsaletime { get; set; }

        [StringLength(255)]
        public string SaleRef { get; set; }

        [StringLength(255)]
        public string FRequestdate { get; set; }

        [StringLength(255)]
        public string Sempno { get; set; }

        [StringLength(255)]
        public string SCust { get; set; }

        [StringLength(255)]
        public string Fplace { get; set; }

        [StringLength(255)]
        public string SSaleno { get; set; }

        [StringLength(255)]
        public string crd_fname { get; set; }

        [StringLength(255)]
        public string crd_sname { get; set; }

        [StringLength(255)]
        public string crd_number { get; set; }

        [StringLength(255)]
        public string crd_bank { get; set; }

        [StringLength(255)]
        public string crd_type { get; set; }

        [StringLength(255)]
        public string sale_status { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
