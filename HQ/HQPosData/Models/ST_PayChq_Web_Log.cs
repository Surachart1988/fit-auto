namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayChq_Web_Log
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string chq_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(255)]
        public string chq_type { get; set; }

        [StringLength(255)]
        public string chq_date { get; set; }

        [StringLength(255)]
        public string pay_date { get; set; }

        [StringLength(255)]
        public string chq_bankcode { get; set; }

        [StringLength(255)]
        public string chq_bankbranch { get; set; }

        [StringLength(255)]
        public string pay_custype { get; set; }

        [StringLength(255)]
        public string pay_cuscode { get; set; }

        [StringLength(255)]
        public string pay_vencode { get; set; }

        public double? chq_amt { get; set; }

        public double? chq_balance { get; set; }

        public double? chq_payamt { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public int? user_pay_id { get; set; }

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
