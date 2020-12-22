namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CheckStock_Transaction
    {
        [Key]
        public int id_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(250)]
        public string pro_code { get; set; }

        public int? locat_code { get; set; }

        public int? last_store_qty { get; set; }

        public int? last_real_qty { get; set; }

        public int? last_diff_qty { get; set; }

        public DateTime? last_date_check { get; set; }

        [StringLength(50)]
        public string last_doc_no { get; set; }

        public int? flag_check { get; set; }
    }
}
