namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_TRNHeader_Web_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(20)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        public int? ven_code { get; set; }

        [StringLength(50)]
        public string ref_branchno { get; set; }

        [StringLength(50)]
        public string ref_doccode { get; set; }

        [StringLength(50)]
        public string ref_docno { get; set; }

        [StringLength(50)]
        public string docref_no { get; set; }

        [StringLength(50)]
        public string docref_date { get; set; }

        [StringLength(10)]
        public string type_update { get; set; }

        [StringLength(20)]
        public string doc_close { get; set; }

        [StringLength(20)]
        public string doc_cancel { get; set; }

        [StringLength(20)]
        public string doc_candate { get; set; }

        [StringLength(50)]
        public string to_dealercode { get; set; }

        public int? date_report { get; set; }

        [StringLength(20)]
        public string bill_novat_status { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        [StringLength(500)]
        public string doc_canmemo { get; set; }

        public double? total_amt { get; set; }

        [StringLength(20)]
        public string trn_status { get; set; }

        public int? trn_in_user_id { get; set; }

        [StringLength(20)]
        public string trn_in_status_date { get; set; }

        [StringLength(20)]
        public string trn_in_status_time { get; set; }

        public int? trn_in_status_date_report { get; set; }

        public int? trn_reject_user_id { get; set; }

        [StringLength(20)]
        public string trn_reject_status_date { get; set; }

        [StringLength(20)]
        public string trn_reject_status_time { get; set; }

        public int? trn_reject_status_date_report { get; set; }

        [StringLength(50)]
        public string docref_dealercode { get; set; }

        [StringLength(20)]
        public string from_dealercode { get; set; }

        [StringLength(20)]
        public string trn_from_status { get; set; }

        [StringLength(20)]
        public string trn_to_status { get; set; }

        public int? trn_receive_user_id { get; set; }

        [StringLength(20)]
        public string trn_receive_status_date { get; set; }

        [StringLength(20)]
        public string trn_receive_status_time { get; set; }

        public int? trn_receive_status_date_report { get; set; }

        public int? trn_waiting_user_id { get; set; }

        [StringLength(20)]
        public string trn_waiting_status_date { get; set; }

        [StringLength(20)]
        public string trn_waiting_status_time { get; set; }

        public int? trn_waiting_status_date_report { get; set; }

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
