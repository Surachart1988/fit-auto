namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SBSale_Head
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
        public string sale_type { get; set; }

        [StringLength(255)]
        public string cash_type { get; set; }

        public int? change_money { get; set; }

        [StringLength(255)]
        public string DSaleDATE { get; set; }

        [StringLength(255)]
        public string DSaleTime { get; set; }

        [StringLength(255)]
        public string SaleRef { get; set; }

        [StringLength(255)]
        public string FREQUESTDATE { get; set; }

        [StringLength(255)]
        public string SEmpno { get; set; }

        [StringLength(255)]
        public string SCust { get; set; }

        [StringLength(255)]
        public string FPLACE { get; set; }

        [StringLength(255)]
        public string ssaleno { get; set; }

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
