namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_System
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int branch_id { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string formprint { get; set; }

        [StringLength(255)]
        public string cashdw { get; set; }

        public int? provid { get; set; }

        public int? alert_month { get; set; }

        [StringLength(255)]
        public string print_comp { get; set; }

        [StringLength(255)]
        public string print_tax { get; set; }

        [StringLength(255)]
        public string formprint_2 { get; set; }

        [StringLength(255)]
        public string doc_select { get; set; }

        [StringLength(255)]
        public string formprint_bill { get; set; }

        [StringLength(255)]
        public string DATE_REPORT_TYPE { get; set; }

        [StringLength(10)]
        public string pay_rt_tmp { get; set; }

        [StringLength(10)]
        public string pay_rt_inv { get; set; }

        [StringLength(10)]
        public string pay_ws_tmp { get; set; }

        [StringLength(10)]
        public string pay_ws_inv { get; set; }

        [StringLength(10)]
        public string all_nextservices { get; set; }

        [StringLength(50)]
        public string used_edit_doc_no2 { get; set; }

        [StringLength(50)]
        public string used_edit_doc_no2_key { get; set; }

        [StringLength(500)]
        public string ROOT_PATH { get; set; }

        [StringLength(50)]
        public string used_film_option { get; set; }

        public int? used_dayservices_alert { get; set; }

        [StringLength(8)]
        public string used_docno_ref_num { get; set; }

        public int? used_locat_barcode { get; set; }

        [StringLength(50)]
        public string dayend_avgcost { get; set; }

        [StringLength(50)]
        public string dayend_avgcost_date { get; set; }

        [StringLength(50)]
        public string dayend_avgcost_time { get; set; }

        [StringLength(50)]
        public string dayend_custbalance { get; set; }

        [StringLength(50)]
        public string dayend_custbalance_date { get; set; }

        [StringLength(50)]
        public string dayend_custbalance_time { get; set; }

        [StringLength(50)]
        public string dayend_financial { get; set; }

        [StringLength(50)]
        public string dayend_financial_date { get; set; }

        [StringLength(50)]
        public string dayend_financial_time { get; set; }

        [StringLength(50)]
        public string dayend_nextserv { get; set; }

        [StringLength(50)]
        public string dayend_nextserv_date { get; set; }

        [StringLength(50)]
        public string dayend_nextserv_time { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance_date { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance_time { get; set; }

        [StringLength(50)]
        public string dayend_venbalance { get; set; }

        [StringLength(50)]
        public string dayend_venbalance_date { get; set; }

        [StringLength(50)]
        public string dayend_venbalance_time { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance_ex { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance_ex_date { get; set; }

        [StringLength(50)]
        public string dayend_vatbalance_ex_time { get; set; }

        [StringLength(500)]
        public string hq_url { get; set; }

        [StringLength(50)]
        public string pro_name_order { get; set; }

        [StringLength(50)]
        public string po_config_ini { get; set; }

        [StringLength(10)]
        public string print_header_footer_report { get; set; }

        [StringLength(10)]
        public string Job_Head_Technician { get; set; }

        [StringLength(10)]
        public string Job_Detail_Technician { get; set; }

        [StringLength(10)]
        public string card_port_no { get; set; }

        [StringLength(10)]
        public string default_doc { get; set; }

        [StringLength(10)]
        public string check_credit_total { get; set; }

        [StringLength(10)]
        public string check_close_job { get; set; }

        [StringLength(10)]
        public string special_promotion { get; set; }

        [StringLength(10)]
        public string fastcash_openjob { get; set; }

        [StringLength(10)]
        public string cus_pro_price { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string Used_Handheld { get; set; }

        [StringLength(500)]
        public string client_url { get; set; }
        [StringLength(10)]
        public string payment_round_digit { get; set; }

        [StringLength(10)]
        public string rpt_print_price { get; set; }
        [StringLength(200)]
        public string printer_default { get; set; }
        [StringLength(200)]
        public string printer_slip_default { get; set; }
        [StringLength(500)]
        public string bluecard_url { get; set; }
    }
}
