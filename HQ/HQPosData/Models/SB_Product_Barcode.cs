namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Barcode
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(120)]
        public string substitution_code { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        [StringLength(10)]
        public string flag_used { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        [StringLength(20)]
        public string flag_master { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
