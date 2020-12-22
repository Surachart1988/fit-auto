namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Progroup_Web_Log
    {
        [Key]
        [StringLength(50)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string progroup_name { get; set; }

        public double? progroup_guarantee { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        public double? scard_type { get; set; }

        [StringLength(255)]
        public string Progroup_Type { get; set; }

        [StringLength(1)]
        public string Default_CS { get; set; }

        [StringLength(255)]
        public string progroup_name_en { get; set; }

        [StringLength(10)]
        public string type_package { get; set; }

        public double? scard_type_mobile { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

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
