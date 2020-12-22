namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Customer
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string cus_code { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cus_code_run { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string custype_code { get; set; }

        [StringLength(255)]
        public string buss_code { get; set; }

        [StringLength(255)]
        public string cus_paytype { get; set; }

        [StringLength(255)]
        public string pre_name { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string cuscont_name { get; set; }

        [StringLength(255)]
        public string add_name { get; set; }

        [StringLength(255)]
        public string add_no { get; set; }

        [StringLength(255)]
        public string add_moo { get; set; }

        [StringLength(255)]
        public string add_soi { get; set; }

        [StringLength(255)]
        public string add_trog { get; set; }

        [StringLength(255)]
        public string add_road { get; set; }

        [StringLength(255)]
        public string add_tumbol { get; set; }

        [StringLength(255)]
        public string add_amphur { get; set; }

        public int? add_provid { get; set; }

        [StringLength(255)]
        public string add_province { get; set; }

        [StringLength(255)]
        public string add_zip { get; set; }

        [StringLength(255)]
        public string add_tel { get; set; }

        [StringLength(255)]
        public string add_fax { get; set; }

        [StringLength(255)]
        public string add_email { get; set; }

        [StringLength(255)]
        public string cusgroup_code { get; set; }

        [StringLength(255)]
        public string cus_member { get; set; }

        public double? pro_discount { get; set; }

        public double? lab_discount { get; set; }

        public double? cust_discount { get; set; }

        public int? vat_code { get; set; }

        public double? pay_method { get; set; }

        public double? credit_term_code { get; set; }

        public double? credit_term { get; set; }

        public double? credit_limit { get; set; }

        public double? credit_bal { get; set; }

        [StringLength(255)]
        public string contact_fdate { get; set; }

        [StringLength(255)]
        public string contact_ldate { get; set; }

        [StringLength(255)]
        public string cancel_date { get; set; }

        [Column(TypeName = "ntext")]
        public string behavior_memo { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string on_acccredit { get; set; }

        [StringLength(255)]
        public string cus_birth { get; set; }

        [StringLength(255)]
        public string cus_sex { get; set; }

        [StringLength(255)]
        public string discount_type { get; set; }

        [StringLength(255)]
        public string deposit_amount { get; set; }

        [StringLength(255)]
        public string add_mobile { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string card_number { get; set; }

        [StringLength(255)]
        public string registration_number { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(255)]
        public string cuscont_name_eng { get; set; }

        [StringLength(255)]
        public string work_company { get; set; }

        [StringLength(50)]
        public string work_type1 { get; set; }

        [StringLength(50)]
        public string work_type2 { get; set; }

        [StringLength(50)]
        public string work_type3 { get; set; }

        [StringLength(50)]
        public string work_type4 { get; set; }

        [StringLength(50)]
        public string work_type5 { get; set; }

        [StringLength(255)]
        public string work_type5_detail { get; set; }

        [StringLength(255)]
        public string work_position { get; set; }

        [StringLength(255)]
        public string work_section { get; set; }

        [StringLength(255)]
        public string work_tower { get; set; }

        [StringLength(255)]
        public string work_floor { get; set; }

        [StringLength(255)]
        public string work_no { get; set; }

        [StringLength(255)]
        public string work_soi { get; set; }

        [StringLength(255)]
        public string work_road { get; set; }

        [StringLength(255)]
        public string work_tumbol { get; set; }

        [StringLength(255)]
        public string work_amphur { get; set; }

        public int? work_provid { get; set; }

        [StringLength(255)]
        public string work_province { get; set; }

        [StringLength(255)]
        public string work_zipcode { get; set; }

        [StringLength(255)]
        public string work_phone { get; set; }

        [StringLength(255)]
        public string work_phone2 { get; set; }

        [StringLength(255)]
        public string work_fax { get; set; }

        [StringLength(255)]
        public string work_email { get; set; }

        [StringLength(50)]
        public string type_newsletter1 { get; set; }

        [StringLength(50)]
        public string type_newsletter2 { get; set; }

        [StringLength(50)]
        public string type_newsletter3 { get; set; }

        [StringLength(50)]
        public string type_newsletter4 { get; set; }

        [StringLength(50)]
        public string type_newsletter5 { get; set; }

        public int? add_tambol_id { get; set; }

        public int? add_amphur_id { get; set; }

        public int? work_tambol_id { get; set; }

        public int? work_amphur_id { get; set; }

        [StringLength(255)]
        public string add_tel_ext { get; set; }

        [StringLength(255)]
        public string add_tel2 { get; set; }

        [StringLength(255)]
        public string add_tel2_ext { get; set; }

        [StringLength(255)]
        public string add_tel3 { get; set; }

        [StringLength(255)]
        public string add_tel3_ext { get; set; }

        [StringLength(255)]
        public string add_fax_ext { get; set; }

        [StringLength(255)]
        public string add_mobile2 { get; set; }

        [StringLength(255)]
        public string work_moo { get; set; }

        [StringLength(255)]
        public string work_trog { get; set; }

        [StringLength(255)]
        public string work_fax2 { get; set; }

        [StringLength(255)]
        public string work_phone3 { get; set; }

        [StringLength(255)]
        public string work_phone4 { get; set; }

        [StringLength(255)]
        public string work_mobile { get; set; }

        [StringLength(255)]
        public string work_mobile2 { get; set; }

        public int? FLAG_UPDATE_PROV { get; set; }

        [StringLength(255)]
        public string TB_Customer_type { get; set; }

        [StringLength(255)]
        public string TB_Customer_code { get; set; }

        [StringLength(255)]
        public string cuscont_add_name { get; set; }

        [StringLength(255)]
        public string cuscont_add_no { get; set; }

        [StringLength(255)]
        public string cuscont_add_moo { get; set; }

        [StringLength(255)]
        public string cuscont_add_soi { get; set; }

        [StringLength(255)]
        public string cuscont_add_trog { get; set; }

        [StringLength(255)]
        public string cuscont_add_road { get; set; }

        public int? cuscont_add_amphur_id { get; set; }

        [StringLength(255)]
        public string cuscont_add_amphur { get; set; }

        public int? cuscont_add_tambol_id { get; set; }

        [StringLength(255)]
        public string cuscont_add_tumbol { get; set; }

        public int? cuscont_add_provid { get; set; }

        [StringLength(255)]
        public string cuscont_add_province { get; set; }

        [StringLength(255)]
        public string cuscont_add_zip { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel_ext { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel2 { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel2_ext { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel3 { get; set; }

        [StringLength(255)]
        public string cuscont_add_tel3_ext { get; set; }

        [StringLength(255)]
        public string cuscont_add_fax { get; set; }

        [StringLength(255)]
        public string cuscont_add_fax_ext { get; set; }

        [StringLength(255)]
        public string cuscont_add_mobile { get; set; }

        [StringLength(255)]
        public string cuscont_add_mobile2 { get; set; }

        [StringLength(255)]
        public string cuscont_add_email { get; set; }

        public double? credit_bal_cs { get; set; }

        [StringLength(50)]
        public string tax_id { get; set; }

        [StringLength(50)]
        public string tax_branch_id { get; set; }

        [StringLength(50)]
        public string cuscont_tax_id { get; set; }

        [StringLength(50)]
        public string cuscont_tax_branch_id { get; set; }

        [StringLength(50)]
        public string tax_branch { get; set; }

        [StringLength(50)]
        public string cuscont_tax_branch { get; set; }

        [StringLength(255)]
        public string cus_name_trim { get; set; }

        [StringLength(500)]
        public string address_trim { get; set; }

        [StringLength(50)]
        public string pic_customer_name { get; set; }

        [StringLength(255)]
        public string pic_customer_path { get; set; }

        public int? id_address { get; set; }

        public int? work_id_address { get; set; }

        public int? cuscont_id_address { get; set; }

        public int? old_add_prov_id { get; set; }

        public int? old_add_tambol_id { get; set; }

        public int? old_add_amphur_id { get; set; }

        public int? old_work_provid { get; set; }

        public int? old_work_tambol_id { get; set; }

        public int? old_work_amphur_id { get; set; }

        public int? old_cuscont_add_provid { get; set; }

        public int? old_cuscont_add_tambol_id { get; set; }

        public int? old_cuscont_add_amphur_id { get; set; }

        public int? sale_user_id { get; set; }

        public int? flag_up_address { get; set; }

        [StringLength(10)]
        public string flag_cus_mobile { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(50)]
        public string chq_day_receive { get; set; }

        [StringLength(50)]
        public string day_bill_pay { get; set; }

        [StringLength(10)]
        public string rpt_tmp_sale_price_show { get; set; }

        [StringLength(10)]
        public string check_credit_total { get; set; }

        [StringLength(50)]
        public string cus_member_id { get; set; }

        public int? SendClient { get; set; }

        public int? CustomerType { get; set; }
    }
}
