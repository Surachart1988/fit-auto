namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Set_Head
    {
        [Key]
        public int doc_no_run { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        public int? ps_gen_id { get; set; }

        [StringLength(50)]
        public string ps_typesale { get; set; }

        [StringLength(50)]
        public string ps_code { get; set; }

        [StringLength(255)]
        public string ps_name { get; set; }

        [StringLength(50)]
        public string ps_startdate { get; set; }

        [StringLength(50)]
        public string ps_enddate { get; set; }

        [StringLength(50)]
        public string ps_cancel { get; set; }

        public int? ps_startdate_report { get; set; }

        public int? ps_enddate_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        public int? SendClient { get; set; }
    }
}
