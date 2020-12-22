namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_VB_income
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_refdate { get; set; }

        [StringLength(255)]
        public string doc_refno { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_tname { get; set; }

        public double? store_qty { get; set; }

        public double? tran_unit { get; set; }

        [StringLength(10)]
        public string bill_novat_status { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
