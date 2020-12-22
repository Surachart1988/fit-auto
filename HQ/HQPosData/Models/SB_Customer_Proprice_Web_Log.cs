namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Customer_Proprice_Web_Log
    {
        [Key]
        public int auto_id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(10)]
        public string sale_type { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public double? pro_price { get; set; }

        public double? sale_percent1 { get; set; }

        public double? sale_percent2 { get; set; }

        public double? sale_price { get; set; }

        [StringLength(20)]
        public string start_date { get; set; }

        public int? start_date_int { get; set; }

        public int? unit_code { get; set; }

        public int? add_user_id { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

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
