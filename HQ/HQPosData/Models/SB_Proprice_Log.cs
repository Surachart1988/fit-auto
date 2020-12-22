namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Proprice_Log
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string log_from_doc { get; set; }

        [StringLength(10)]
        public string proprice_date { get; set; }

        [StringLength(50)]
        public string cus_groupcode { get; set; }

        public double? pro_price_retail { get; set; }

        public double? pro_price_ws { get; set; }

        public int? unit_code { get; set; }

        [StringLength(50)]
        public string unit_name { get; set; }

        public int? doc_no_run_log { get; set; }

        [StringLength(50)]
        public string log_date { get; set; }

        [StringLength(50)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        public int? user_id { get; set; }

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
    }
}
