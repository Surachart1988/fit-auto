namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Movement_Web_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(30)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public double? move_qty { get; set; }

        public double? incre_qty { get; set; }

        public double? decre_qty { get; set; }

        public double? decre_qty_tmp { get; set; }

        public double? total_qty { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(50)]
        public string web_log_send_to { get; set; }

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
