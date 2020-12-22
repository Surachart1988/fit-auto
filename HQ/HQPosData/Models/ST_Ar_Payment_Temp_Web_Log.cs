namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Ar_Payment_Temp_Web_Log
    {
        public int id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        public double? num_of_pay { get; set; }

        [StringLength(20)]
        public string type_pay { get; set; }

        [StringLength(10)]
        public string flag_delete { get; set; }

        [StringLength(20)]
        public string delete_date { get; set; }

        [StringLength(20)]
        public string delete_time { get; set; }

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
