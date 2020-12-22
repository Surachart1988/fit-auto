namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Claim_Online_Serial
    {
        [Key]
        public int pk_id { get; set; }

        [StringLength(50)]
        public string id_auto { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string pro_serial { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string warantee_day { get; set; }

        [StringLength(255)]
        public string exp_date { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string doc_no_run { get; set; }
    }
}
