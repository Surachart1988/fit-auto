namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Vote_Web_Log
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vote_id { get; set; }

        [StringLength(255)]
        public string vote_name { get; set; }

        public int? vote_active { get; set; }

        [StringLength(255)]
        public string vote_choice_type { get; set; }

        [StringLength(255)]
        public string vote_start { get; set; }

        [StringLength(255)]
        public string vote_end { get; set; }

        public int? vote_multi { get; set; }

        [StringLength(255)]
        public string vote_multi_time { get; set; }

        public int? vote_random { get; set; }

        public int? vote_order { get; set; }

        [StringLength(255)]
        public string vote_date { get; set; }

        [StringLength(255)]
        public string vote_time { get; set; }

        public double? date_report { get; set; }

        public int? vote_used { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

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
