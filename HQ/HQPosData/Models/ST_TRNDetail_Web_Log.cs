namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_TRNDetail_Web_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(20)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        public int? ven_code { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(120)]
        public string pro_ven_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? line_no { get; set; }

        public int? sale_unit_code { get; set; }

        public int? locat_code { get; set; }

        public double? store_qty { get; set; }

        public double? pro_price { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        [StringLength(20)]
        public string from_dealercode { get; set; }

        [StringLength(20)]
        public string to_dealercode { get; set; }

        [StringLength(50)]
        public string web_log_dealercode { get; set; }

        public int? web_log_user_id { get; set; }

        [StringLength(255)]
        public string web_log_date { get; set; }

        [StringLength(255)]
        public string web_log_time { get; set; }

        public int? web_log_flag_send { get; set; }

        [StringLength(255)]
        public string web_log_message { get; set; }
    }
}
