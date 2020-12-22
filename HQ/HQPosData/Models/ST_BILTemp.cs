namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_BILTemp
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string pay_doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string pay_doc_name { get; set; }

        [StringLength(255)]
        public string pay_doc_date { get; set; }

        [StringLength(255)]
        public string pay_end_date { get; set; }

        public double? money_total { get; set; }

        public double? money_keep { get; set; }

        public double? money_pay { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string pay_doc_no2 { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
