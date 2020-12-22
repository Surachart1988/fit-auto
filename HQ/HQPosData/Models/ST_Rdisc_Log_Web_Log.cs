namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Rdisc_Log_Web_Log
    {
        public int id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_status { get; set; }

        [StringLength(50)]
        public string log_date { get; set; }

        [StringLength(50)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        public int? user_id { get; set; }

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