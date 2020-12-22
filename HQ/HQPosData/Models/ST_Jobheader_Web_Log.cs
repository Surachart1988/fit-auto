namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Jobheader_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string member_code { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        public int? car_mileage { get; set; }

        [StringLength(255)]
        public string car_bcontact { get; set; }

        public int? car_bmileage { get; set; }

        public double? car_balance { get; set; }

        public double? cust_balance { get; set; }

        [StringLength(255)]
        public string job_contact { get; set; }

        [StringLength(255)]
        public string job_conttel { get; set; }

        [StringLength(255)]
        public string ref_jobmem { get; set; }

        [StringLength(255)]
        public string ref_branchno { get; set; }

        [StringLength(255)]
        public string ref_doccode { get; set; }

        [StringLength(255)]
        public string ref_docno { get; set; }

        [StringLength(255)]
        public string job_detail { get; set; }

        [StringLength(255)]
        public string reception_by { get; set; }

        [StringLength(255)]
        public string mechanic_by { get; set; }

        [StringLength(255)]
        public string qc_by { get; set; }

        [StringLength(255)]
        public string invoice_type { get; set; }

        [StringLength(255)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? job_amt { get; set; }

        public double? job_discpercent { get; set; }

        public double? job_discountamt { get; set; }

        public double? job_netamt { get; set; }

        public double? job_vatamt { get; set; }

        public double? job_totalamt { get; set; }

        public double? job_payamt { get; set; }

        public double? job_paydeposit { get; set; }

        public double? job_paytotal { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        [StringLength(255)]
        public string doc_canmemo { get; set; }

        public int? detail_line { get; set; }

        public int? print_no { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string job_pmamt { get; set; }

        [StringLength(255)]
        public string user_id { get; set; }

        [Column(TypeName = "ntext")]
        public string job_prodamt { get; set; }

        [StringLength(255)]
        public string job_servamt { get; set; }

        [StringLength(255)]
        public string test_by { get; set; }

        [StringLength(255)]
        public string return_by { get; set; }

        [StringLength(255)]
        public string appoint_fdate { get; set; }

        [StringLength(255)]
        public string appoint_ftime { get; set; }

        public int? appoint_count { get; set; }

        [StringLength(255)]
        public string appoint_ldate { get; set; }

        [StringLength(255)]
        public string appoint_ltime { get; set; }

        [StringLength(255)]
        public string finish_date { get; set; }

        [StringLength(255)]
        public string finish_time { get; set; }

        [StringLength(255)]
        public string return_date { get; set; }

        [StringLength(255)]
        public string return_time { get; set; }

        [StringLength(255)]
        public string close_date { get; set; }

        [StringLength(255)]
        public string close_time { get; set; }

        [StringLength(255)]
        public string job_status { get; set; }

        public int? km_perday { get; set; }

        public int? km_permonth { get; set; }

        [StringLength(255)]
        public string ccp_create { get; set; }

        [StringLength(255)]
        public string ccp_status { get; set; }

        [StringLength(255)]
        public string type_amt { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        public double? Car_Avg { get; set; }

        [StringLength(255)]
        public string CALL_STATUS { get; set; }

        [StringLength(255)]
        public string CALL_MEMO { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(255)]
        public string meeting_id { get; set; }

        [StringLength(255)]
        public string CALL_POINT { get; set; }

        [StringLength(255)]
        public string MISS_CALL_NUM { get; set; }

        [StringLength(255)]
        public string priceown_code { get; set; }

        public double? cust_limit { get; set; }

        [StringLength(255)]
        public string pcc_docno { get; set; }

        [StringLength(255)]
        public string docno_ref { get; set; }

        [StringLength(255)]
        public string docno_refdate { get; set; }

        [StringLength(255)]
        public string car_reg_tail { get; set; }

        [StringLength(255)]
        public string car_chasis_tail { get; set; }

        public int? car_tail_mileage { get; set; }

        public int? car_btail_mileage { get; set; }

        public int? km_tail_perday { get; set; }

        public int? km_tail_permonth { get; set; }

        public double? car_tail_avg { get; set; }

        [StringLength(255)]
        public string last_tail_contdate { get; set; }

        [StringLength(255)]
        public string sale_docno { get; set; }

        [StringLength(50)]
        public string sale_docrefdate { get; set; }

        [StringLength(10)]
        public string approve_cust_limit { get; set; }

        [StringLength(10)]
        public string approve_cust_term { get; set; }

        [StringLength(10)]
        public string approve_sale_limit { get; set; }

        [StringLength(10)]
        public string approve_avg_cost { get; set; }

        public double? cust_limit_new { get; set; }

        public double? cust_term { get; set; }

        public double? cust_term_old { get; set; }

        public double? sale_credit_limit { get; set; }

        public double? sale_credit_limit_old { get; set; }

        public int? sale_id { get; set; }

        public int? create_user_id { get; set; }

        [StringLength(10)]
        public string admin_cust_limit { get; set; }

        [StringLength(10)]
        public string admin_cust_term { get; set; }

        [StringLength(10)]
        public string admin_sale_limit { get; set; }

        [StringLength(10)]
        public string admin_avg_cost { get; set; }

        [StringLength(50)]
        public string app_docno { get; set; }

        public int? approve_complete { get; set; }

        public int? Approve_1 { get; set; }

        public int? Approve_2 { get; set; }

        public int? Approve_3 { get; set; }

        public int? Approve_4 { get; set; }

        [StringLength(255)]
        public string config_tyre { get; set; }

        [StringLength(50)]
        public string Call_Date { get; set; }

        [StringLength(50)]
        public string Call_Time { get; set; }

        [StringLength(50)]
        public string Call_User { get; set; }

        public int? Call_UserID { get; set; }

        [StringLength(50)]
        public string Call_IP { get; set; }

        public int? Call_DATE_REPORT { get; set; }

        [StringLength(500)]
        public string shipping_memo { get; set; }

        [StringLength(50)]
        public string shipping_status { get; set; }

        [StringLength(10)]
        public string flag_mobile { get; set; }

        [StringLength(500)]
        public string call_rec_memo { get; set; }

        [StringLength(50)]
        public string quo_ref_docno { get; set; }

        [StringLength(50)]
        public string quo_ref_docdate { get; set; }

        [StringLength(10)]
        public string car_send_claim_status { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

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
