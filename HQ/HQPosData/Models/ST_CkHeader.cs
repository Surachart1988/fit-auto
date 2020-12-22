namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CkHeader
    {
        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string car_brand { get; set; }

        [StringLength(255)]
        public string car_model { get; set; }

        [StringLength(120)]
        public string user_receive { get; set; }

        [StringLength(120)]
        public string user_check { get; set; }

        [StringLength(50)]
        public string checklist_status { get; set; }

        [StringLength(20)]
        public string doc_close { get; set; }

        [StringLength(20)]
        public string doc_cancel { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        public int? date_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
