namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Docno_Ref_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(10)]
        public string docno_ref_num_old { get; set; }

        [StringLength(10)]
        public string docno_ref_num_new { get; set; }

        [StringLength(20)]
        public string log_date { get; set; }

        [StringLength(20)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
