using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models.MasterData
{
    public class VendorModel
    {
        public VendorModel()
        {
            Mode = "";
            VattypeList = new List<VattypeModel>();
            BvatList = new List<BvatModel>();
        }
        public string Mode { get; set; }
        public string branch_no { get; set; }
        [Display(Name = "รหัสผู้จำหน่าย")]
        public string ven_code { get; set; }
        public int ven_code_run { get; set; }
        [Display(Name = "คำนำหน้าชื่อ")]
        public string pre_name { get; set; }
        [Display(Name = "ชื่อผู้จำหน่าย")]
        public string ven_name { get; set; }
        [Display(Name = "ชื่อผู้ติดต่อ")]
        public string contact_name { get; set; }
        [Display(Name = "ที่อยู่")]
        public string add_name { get; set; }
        public string add_no { get; set; }
        public string add_moo { get; set; }
        public string add_soi { get; set; }
        public string add_trog { get; set; }
        public string add_road { get; set; }
        [Display(Name = "แขวง/ตำบล")]
        public string add_tumbol { get; set; }
        [Display(Name = "อำเภอ/เขต")]
        public string add_amphur { get; set; }
        public Nullable<int> add_provid { get; set; }
        [Display(Name = "จังหวัด")]
        public string add_province { get; set; }
        [Display(Name = "รหัสไปรษณีย์")]
        public string add_zip { get; set; }
        [Display(Name = "โทรศัพท์")]
        public string add_tel { get; set; }
        [Display(Name = "แฟกซ์")]
        public string add_fax { get; set; }
        [Display(Name = "อีเมล์")]
        public string add_email { get; set; }
        public string vengroup_code { get; set; }
        [Display(Name = "ชนิดภาษีมูลค่าเพิ่ม")]
        public string vat_type { get; set; }
        [Display(Name = "อัตราภาษี(%)")]
        public string vat_code { get; set; }
        public Nullable<double> ven_discount { get; set; }
        public Nullable<int> ven_ship_term { get; set; }
        public string ven_ct_code { get; set; }
        [Display(Name = "ระยะเวลาชำระ(วัน)")]
        public Nullable<int> ven_credit_term { get; set; }
        [Display(Name = "วงเงินอนุมัติ")]
        public Nullable<int> ven_credit_limit { get; set; }
        [Display(Name = "ค้างชำระ")]
        public Nullable<double> ven_balance { get; set; }
        [Display(Name = "วันที่ติดต่อครั้งแรก")]
        public string contact_fdate { get; set; }
        [Display(Name = "วันที่ติดต่อล่าสุด")]
        public string contact_ldate { get; set; }
        [Display(Name = "วันที่ยกเลิก")]
        public string cancel_date { get; set; }
        [Display(Name = "หมายเหตุ")]
        public string rec_memo { get; set; }
        public Nullable<int> ordering_date { get; set; }
        public Nullable<int> ordering_cycle { get; set; }
        public string AF_Status { get; set; }
        public Nullable<double> ven_balance_cs { get; set; }
        [Display(Name = "เลขประจำตัวผู้เสียภาษี")]
        public string tax_id { get; set; }
        [Display(Name = "เลขที่สาขา")]
        public string tax_branch_id { get; set; }
        [Display(Name = "สถานประกอบการ")]
        public string tax_branch { get; set; }
        public string dealercode { get; set; }
        public string add_date { get; set; }
        public string add_time { get; set; }
        public string edit_date { get; set; }
        public string edit_time { get; set; }
        [Display(Name = "ต่อ")]
        public string add_tel1_ext { get; set; }
        [Display(Name = "ต่อ")]
        public string add_fax_ext { get; set; }
        [Display(Name = "ประเภทการสั่งซื้อ")]
        public string vender_type { get; set; }
        [Display(Name = "มือถือ")]
        public string add_phone { get; set; }
        [Display(Name = "หมายเลขอ้างอิง(SAP)")]
        public string sap_no { get; set; }



        public int? add_tumbol_id { get; set; }
        public int? add_amphur_id { get; set; }

      
       
        public IEnumerable<VattypeModel> VattypeList { get; set; }
        public IEnumerable<BvatModel> BvatList { get; set; }
        public class VattypeModel
        {

            public string vat_type { get; set; }

            public string vat_type_name { get; set; }
        }
        public class BvatModel
        {

            public string vat_code { get; set; }

            public string vat_desc { get; set; }
        }
    }
}
