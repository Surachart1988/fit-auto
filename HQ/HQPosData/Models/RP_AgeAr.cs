namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_AgeAr
    {
        public int id { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [Column(TypeName = "ntext")]
        public string cus_name { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string cur_date { get; set; }

        public int? rdiff { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        public int? credit_bal { get; set; }

        public int? credit_term { get; set; }

        public double? ar_amt { get; set; }

        public int? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
