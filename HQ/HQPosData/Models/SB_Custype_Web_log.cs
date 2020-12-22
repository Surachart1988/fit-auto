namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Custype_Web_log
    {
        [Key]
        [StringLength(50)]
        public string custype_code { get; set; }

        [StringLength(255)]
        public string custype_name { get; set; }

        [StringLength(255)]
        public string custype_pay { get; set; }

        [StringLength(255)]
        public string custype_fcode { get; set; }

        public int? custype_rundigits { get; set; }

        [StringLength(255)]
        public string custype_btype { get; set; }

        [StringLength(255)]
        public string custype_mhq { get; set; }

        [StringLength(255)]
        public string custype_mbr { get; set; }

        public int? cust_discount { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

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
