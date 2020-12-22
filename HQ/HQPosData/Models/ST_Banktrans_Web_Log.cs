namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Banktrans_Web_Log
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string trans_type { get; set; }

        public int? trans_no { get; set; }

        [StringLength(255)]
        public string trans_date { get; set; }

        public int? trans_ref { get; set; }

        [StringLength(255)]
        public string bankacc_code { get; set; }

        [StringLength(255)]
        public string bank_code { get; set; }

        [StringLength(255)]
        public string branch { get; set; }

        [StringLength(255)]
        public string cq_code { get; set; }

        [StringLength(255)]
        public string cq_desciption { get; set; }

        public double? cq_amount { get; set; }

        [StringLength(255)]
        public string cq_no { get; set; }

        [StringLength(255)]
        public string cq_date { get; set; }

        [StringLength(255)]
        public string clearing_date { get; set; }

        [StringLength(255)]
        public string trans_status { get; set; }

        public double? total_amount { get; set; }

        [StringLength(255)]
        public string trans_remark { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        public double? DATE_REPORT { get; set; }

        public double? CLEAR_DATE_REPORT { get; set; }

        public double? TRAN_DATE_REPORT { get; set; }

        [StringLength(200)]
        public string ref_chq_no { get; set; }

        [StringLength(10)]
        public string chq_cancel { get; set; }

        [StringLength(20)]
        public string chq_cancel_date { get; set; }

        [StringLength(20)]
        public string chq_cancel_time { get; set; }

        public int? cancel_user_id { get; set; }

        [StringLength(500)]
        public string trans_type_memo { get; set; }

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
