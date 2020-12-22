namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Movement_Vat_Ex_All_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        public int? locat_code { get; set; }

        public double? incre_qty { get; set; }

        public double? vat_incre_qty { get; set; }

        public double? novat_incre_qty { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
