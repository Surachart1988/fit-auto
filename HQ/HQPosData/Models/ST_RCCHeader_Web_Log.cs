namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_RCCHeader_Web_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string ref_number { get; set; }

        [StringLength(255)]
        public string ref_date { get; set; }

        public int? credit_term { get; set; }

        public double? credit_limit { get; set; }

        [StringLength(255)]
        public string cus_paytype { get; set; }

        public double? money_credit { get; set; }

        public double? pay_net_total { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [StringLength(255)]
        public string flag_status { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        public double? DATE_REPORT { get; set; }

        public double? cust_limit { get; set; }

        public double? cust_balance { get; set; }

        [StringLength(10)]
        public string flag_vat { get; set; }

        [StringLength(10)]
        public string Flag_Vat_Transfer { get; set; }

        [StringLength(50)]
        public string Update_Vat_Transfer { get; set; }

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
