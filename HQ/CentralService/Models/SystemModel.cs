using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public class SystemModel
    {
        public SystemModel()
        {
            PrinterList = new List<PrinterComModel>();
            //AddressModel = new AddressModel();
        }
        public int branch_id { get; set; }
        public string branch_no { get; set; }
        public string formprint { get; set; }
        public string cashdw { get; set; }
        public int? provid { get; set; }
        public int? alert_month { get; set; }
        public string print_comp { get; set; }
        public string print_tax { get; set; }
        public string formprint_2 { get; set; }
        public string doc_select { get; set; }
        public string formprint_bill { get; set; }
        public string DATE_REPORT_TYPE { get; set; }
        public string pay_rt_tmp { get; set; }
        public string pay_rt_inv { get; set; }
        public string pay_ws_tmp { get; set; }
        public string pay_ws_inv { get; set; }
        public string all_nextservices { get; set; }
        public string used_edit_doc_no2 { get; set; }
        public string used_edit_doc_no2_key { get; set; }
        public string ROOT_PATH { get; set; }
        public string used_film_option { get; set; }
        public int? used_dayservices_alert { get; set; }
        public string used_docno_ref_num { get; set; }
        public int? used_locat_barcode { get; set; }
        public string dayend_avgcost { get; set; }
        public string dayend_avgcost_date { get; set; }
        public string dayend_avgcost_time { get; set; }
        public string dayend_custbalance { get; set; }
        public string dayend_custbalance_date { get; set; }
        public string dayend_custbalance_time { get; set; }
        public string dayend_financial { get; set; }
        public string dayend_financial_date { get; set; }
        public string dayend_financial_time { get; set; }
        public string dayend_nextserv { get; set; }
        public string dayend_nextserv_date { get; set; }
        public string dayend_nextserv_time { get; set; }
        public string dayend_vatbalance { get; set; }
        public string dayend_vatbalance_date { get; set; }
        public string dayend_vatbalance_time { get; set; }
        public string dayend_venbalance { get; set; }
        public string dayend_venbalance_date { get; set; }
        public string dayend_venbalance_time { get; set; }
        public string dayend_vatbalance_ex { get; set; }
        public string dayend_vatbalance_ex_date { get; set; }
        public string dayend_vatbalance_ex_time { get; set; }
        public string hq_url { get; set; }
        public string pro_name_order { get; set; }
        public string po_config_ini { get; set; }
        public string print_header_footer_report { get; set; }
        public string Job_Head_Technician { get; set; }
        public string Job_Detail_Technician { get; set; }
        public string card_port_no { get; set; }
        public string default_doc { get; set; }
        public string check_credit_total { get; set; }
        public string check_close_job { get; set; }
        public string special_promotion { get; set; }
        public string fastcash_openjob { get; set; }
        public string cus_pro_price { get; set; }
        public string dealercode { get; set; }
        public string Used_Handheld { get; set; }
        public string client_url { get; set; }
        public string payment_round_digit { get; set; }
        public string printer_default { get; set; }
        public string printer_slip_default { get; set; }
        public string rpt_print_price { get; set; }
        public string bluecard_url { get; set; }
        public IEnumerable<PrinterComModel> PrinterList { get; set; }
        //public AddressModel AddressModel { get; set; }
    }

    public class PrinterComModel
    {
        public string print_id { get; set; }

        public string print_name { get; set; }
    }
}
