namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Paydoc
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string rf_docno { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public int? line_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string rf_bran { get; set; }

        [StringLength(255)]
        public string rf_doccode { get; set; }

        public double? doc_amt { get; set; }

        public double? doc_bal { get; set; }

        public double? doc_payamt { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public double? DATE_REPORT { get; set; }

        public int? user_pay_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public string dep_pay_remark { get; set; }
    }
}
