namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_proserial
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(255)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_serial { get; set; }

        [StringLength(255)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string cus_code { get; set; }

        public int? line_no { get; set; }

        [StringLength(255)]
        public string doc_date { get; set; }

        public int? warantee_day { get; set; }

        [StringLength(255)]
        public string exp_date { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        public int? locat_code { get; set; }

        [StringLength(255)]
        public string deep_tyre { get; set; }

        [StringLength(255)]
        public string recamic_serial { get; set; }
    }
}
