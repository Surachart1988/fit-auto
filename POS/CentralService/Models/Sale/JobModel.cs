using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models.Sale
{
    public class JobModel
    {
        public JobModel()
        {
            Mode = "";
            ddlSaleUnitCodeList = new List<UnitModel> {
                new UnitModel {
                    unit_code = 0,
                    unit_name = "หน่วยสินค้า"
                } };
            JobTempDetail = new List<JobTempModel>();
        }
        [Display(Name = "เลขที่ใบสั่งซ่อม")]
        public string doc_no { get; set; }
        [Display(Name = "วันที่")]
        public string doc_date { get; set; }
        [Display(Name = "รหัสลูกค้า")]
        public string cus_code { get; set; }
        [Display(Name = "ชื่อ-สกุล")]
        public string cus_name { get; set; }
        [Display(Name = "เลขทะเบียน")]
        public string car_reg { get; set; } = "";
        [Display(Name = "จำนวน")]
        public double Qty { get; set; }
        [Display(Name = "ราคารวม")]
        public double? job_amt { get; set; }
        [Display(Name = "ปิด")]
        public string doc_close { get; set; }
        [Display(Name = "สถานะ")]
        public string doc_cancel { get; set; }
        public double? job_totalamt { get; set; }
        public double? job_vatamt { get; set; }
        public double? job_netamt { get; set; }
        public string Mode { get; set; }
        public string branch_no { get; set; }
        public int doc_no_run { get; set; }
        public string doc_code { get; set; }
        public string doc_time { get; set; }
        public string cus_type { get; set; }
        public string member_code { get; set; }
        public string car_chasis { get; set; }
        public int? car_mileage { get; set; } = 0;
        public string car_bcontact { get; set; }
        public int? car_bmileage { get; set; }
        public double? car_balance { get; set; }
        public double? cust_balance { get; set; }
        public string job_contact { get; set; }
        public string job_conttel { get; set; }
        public string ref_jobmem { get; set; }
        public string ref_branchno { get; set; }
        public string ref_doccode { get; set; }
        public string ref_docno { get; set; }
        public string job_detail { get; set; }
        public string reception_by { get; set; }
        public string mechanic_by { get; set; }
        public string qc_by { get; set; }
        public string invoice_type { get; set; }
        public string vat_type { get; set; }
        public double? vat_rate { get; set; }
        public double? job_discpercent { get; set; }
        public double? job_discountamt { get; set; }
        public double? job_payamt { get; set; }
        public double? job_paydeposit { get; set; }
        public double? job_paytotal { get; set; }
        public string doc_candate { get; set; }
        public string doc_canmemo { get; set; }
        public int? detail_line { get; set; }
        public int? print_no { get; set; }
        public string rec_memo { get; set; }
        public string job_pmamt { get; set; }
        public string user_id { get; set; }
        public string job_prodamt { get; set; }
        public string job_servamt { get; set; }
        public string test_by { get; set; }
        public string return_by { get; set; }
        public string appoint_fdate { get; set; }
        public string appoint_ftime { get; set; }
        public int? appoint_count { get; set; }
        public string appoint_ldate { get; set; }
        public string appoint_ltime { get; set; }
        public string finish_date { get; set; }
        public string finish_time { get; set; }
        public string return_date { get; set; }
        public string return_time { get; set; }
        public string close_date { get; set; }
        public string close_time { get; set; }
        public string job_status { get; set; }
        public int? km_perday { get; set; }
        public int? km_permonth { get; set; }
        public string ccp_create { get; set; }
        public string ccp_status { get; set; }
        public string type_amt { get; set; }
        public string AF_Status { get; set; }
        public double? Car_Avg { get; set; }
        public string CALL_STATUS { get; set; }
        public string CALL_MEMO { get; set; }
        public double? DATE_REPORT { get; set; }
        public string meeting_id { get; set; }
        public string CALL_POINT { get; set; }
        public string MISS_CALL_NUM { get; set; }
        public string priceown_code { get; set; }
        public double? cust_limit { get; set; }
        public string pcc_docno { get; set; }
        public string docno_ref { get; set; }
        public string docno_refdate { get; set; }
        public string car_reg_tail { get; set; }
        public string car_chasis_tail { get; set; }
        public int? car_tail_mileage { get; set; }
        public int? car_btail_mileage { get; set; }
        public int? km_tail_perday { get; set; }
        public int? km_tail_permonth { get; set; }
        public double? car_tail_avg { get; set; }
        public string last_tail_contdate { get; set; }
        public string sale_docno { get; set; }
        public string sale_docrefdate { get; set; }
        public string approve_cust_limit { get; set; }
        public string approve_cust_term { get; set; }
        public string approve_sale_limit { get; set; }
        public string approve_avg_cost { get; set; }
        public double? cust_limit_new { get; set; }
        public double? cust_term { get; set; }
        public double? cust_term_old { get; set; }
        public double? sale_credit_limit { get; set; }
        public double? sale_credit_limit_old { get; set; }
        public int? sale_id { get; set; }
        public int? create_user_id { get; set; }
        public string admin_cust_limit { get; set; }
        public string admin_cust_term { get; set; }
        public string admin_sale_limit { get; set; }
        public string admin_avg_cost { get; set; }
        public string app_docno { get; set; }
        public int? approve_complete { get; set; }
        public int? Approve_1 { get; set; }
        public int? Approve_2 { get; set; }
        public int? Approve_3 { get; set; }
        public int? Approve_4 { get; set; }
        public string config_tyre { get; set; }
        public string Call_Date { get; set; }
        public string Call_Time { get; set; }
        public string Call_User { get; set; }
        public int? Call_UserID { get; set; }
        public string Call_IP { get; set; }
        public int? Call_DATE_REPORT { get; set; }
        public string shipping_memo { get; set; }
        public string shipping_status { get; set; }
        public string flag_mobile { get; set; }
        public string call_rec_memo { get; set; }
        public string quo_ref_docno { get; set; }
        public string quo_ref_docdate { get; set; }
        public string car_send_claim_status { get; set; }
        public string dealercode { get; set; }
        public string FLAG_NET { get; set; }
        public string Last_Update { get; set; }
        public string online_reserv { get; set; }
        public int? flag_edc_check { get; set; }
        public string car_province { get; set; }
        public string Car_Brand { get; set; }
        public string Car_model { get; set; }
        public string vat_mrate { get; set; } = "7";
        public string first_contdate { get; set; }
        public string last_contdate { get; set; }
        public int first_mileage { get; set; }
        public int last_mileage { get; set; }
        public string PaymentRoundDigit { get; set; }
        #region สินค้า/บริการ
        public string pro_code { get; set; }
        public string pro_tname { get; set; }
        public string locat_name { get; set; }
        public int locat_code { get; set; }
        public int sale_unit_code { get; set; }
        public IEnumerable<UnitModel> ddlSaleUnitCodeList { get; set; }
        public string dot_name { get; set; }
        public int dot_id { get; set; }
        public string store_qty { get; set; }
        public double pro_price { get; set; }
        public double pro_amt { get; set; }
        public string io_by { get; set; }
        public int pro_qty { get; set; }
        public int pro_ohqty { get; set; }
        public int doc_ps_code { get; set; }


        public bool is_proset { get; set; }
        public int? ps_gen_id { get; set; }
        public string ps_code { get; set; }
        public string ps_name { get; set; }

        #endregion

        public List<JobTempModel> JobTempDetail { get; set; }
    }
}
