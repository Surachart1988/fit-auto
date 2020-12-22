namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_JobApprove_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Required]
        [StringLength(50)]
        public string app_docno { get; set; }

        [Required]
        [StringLength(50)]
        public string doc_no { get; set; }

        public int? app_user_id { get; set; }

        [StringLength(10)]
        public string app_date { get; set; }

        [StringLength(10)]
        public string app_time { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(10)]
        public string approve_cust_limit { get; set; }

        [StringLength(10)]
        public string approve_cust_term { get; set; }

        [StringLength(10)]
        public string approve_sale_limit { get; set; }

        [StringLength(10)]
        public string approve_avg_cost { get; set; }

        [StringLength(10)]
        public string admin_cust_limit { get; set; }

        [StringLength(10)]
        public string admin_cust_term { get; set; }

        [StringLength(10)]
        public string admin_sale_limit { get; set; }

        [StringLength(10)]
        public string admin_avg_cost { get; set; }

        [StringLength(255)]
        public string admin_cust_limit_memo { get; set; }

        [StringLength(255)]
        public string admin_cust_term_memo { get; set; }

        [StringLength(255)]
        public string admin_sale_limit_memo { get; set; }

        [StringLength(255)]
        public string admin_avg_cost_memo { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
