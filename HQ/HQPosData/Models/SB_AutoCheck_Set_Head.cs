namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_AutoCheck_Set_Head
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        public int? set_gen_id { get; set; }

        [StringLength(50)]
        public string set_code { get; set; }

        [StringLength(255)]
        public string set_name { get; set; }

        [StringLength(20)]
        public string set_startdate { get; set; }

        [StringLength(20)]
        public string set_enddate { get; set; }

        [StringLength(10)]
        public string set_cancel { get; set; }

        public int? set_startdate_report { get; set; }

        public int? set_enddate_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public int? SendClient { get; set; }
    }
}
