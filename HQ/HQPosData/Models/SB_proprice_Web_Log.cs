namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_proprice_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(10)]
        public string proprice_date { get; set; }

        [StringLength(50)]
        public string cus_groupcode { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public double? pro_price_retail { get; set; }

        public double? pro_price_ws { get; set; }

        public int? unit_code { get; set; }

        [StringLength(255)]
        public string unit_name { get; set; }

        public double? pro_discpercent { get; set; }

        public double? pro_discount { get; set; }

        [Key]
        public int doc_no_run { get; set; }

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
