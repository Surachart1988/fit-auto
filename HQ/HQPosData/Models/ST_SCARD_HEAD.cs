namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_SCARD_HEAD
    {
        public int id { get; set; }

        [StringLength(10)]
        public string icard_id { get; set; }

        [StringLength(255)]
        public string DealerCode { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string Branch_Name { get; set; }

        [StringLength(255)]
        public string cus_id { get; set; }

        [StringLength(255)]
        public string cus_carid { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string card_password { get; set; }

        [StringLength(255)]
        public string add_tel { get; set; }

        [StringLength(255)]
        public string add_fax { get; set; }

        [StringLength(255)]
        public string add_name { get; set; }

        [StringLength(255)]
        public string add_road { get; set; }

        [StringLength(255)]
        public string add_tumbol { get; set; }

        [StringLength(255)]
        public string add_amphur { get; set; }

        [StringLength(255)]
        public string add_province { get; set; }

        [StringLength(255)]
        public string add_zip { get; set; }

        [StringLength(255)]
        public string car_prov_name { get; set; }

        [StringLength(255)]
        public string car_body { get; set; }

        [StringLength(255)]
        public string car_engine { get; set; }

        [StringLength(255)]
        public string car_engine_cc { get; set; }

        [StringLength(255)]
        public string car_regdate { get; set; }

        [StringLength(255)]
        public string car_type_name { get; set; }

        [StringLength(255)]
        public string car_brand_name { get; set; }

        [StringLength(255)]
        public string car_model_name { get; set; }

        [StringLength(255)]
        public string car_color { get; set; }

        [StringLength(255)]
        public string car_year { get; set; }

        [StringLength(255)]
        public string car_fdate { get; set; }

        [StringLength(255)]
        public string last_contdate { get; set; }

        [StringLength(255)]
        public string first_mileage { get; set; }

        [StringLength(255)]
        public string last_mileage { get; set; }

        [StringLength(255)]
        public string register_date { get; set; }

        [StringLength(255)]
        public string point_all { get; set; }

        [StringLength(255)]
        public string expire_date { get; set; }

        [StringLength(255)]
        public string FLAG_NET { get; set; }

        [StringLength(255)]
        public string add_mobile { get; set; }

        [StringLength(255)]
        public string add_no { get; set; }

        [StringLength(255)]
        public string cus_birth { get; set; }

        public double? car_average { get; set; }

        [StringLength(255)]
        public string CLUB_TYPE { get; set; }

        [StringLength(255)]
        public string pre_name { get; set; }

        [StringLength(255)]
        public string add_moo { get; set; }

        [StringLength(255)]
        public string add_trog { get; set; }

        [StringLength(255)]
        public string add_soi { get; set; }

        [StringLength(255)]
        public string voidno { get; set; }

        [StringLength(255)]
        public string CLUB_TYPE_NAME { get; set; }

        [StringLength(255)]
        public string WARRANTY_DATE { get; set; }

        [StringLength(255)]
        public string PRO_NAME { get; set; }

        [StringLength(255)]
        public string PRO_SERIAL1 { get; set; }

        [StringLength(255)]
        public string PRO_SERIAL2 { get; set; }

        [StringLength(255)]
        public string PRO_SERIAL3 { get; set; }

        [StringLength(255)]
        public string PRO_SERIAL4 { get; set; }

        [StringLength(255)]
        public string PRO_SERIAL5 { get; set; }

        [StringLength(255)]
        public string add_email { get; set; }

        [StringLength(50)]
        public string cus_sex { get; set; }

        [StringLength(255)]
        public string cus_buss_name { get; set; }

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

        [StringLength(50)]
        public string cus_edit_date { get; set; }

        [StringLength(50)]
        public string car_detail1 { get; set; }

        [StringLength(50)]
        public string car_detail2 { get; set; }

        [StringLength(50)]
        public string car_detail3 { get; set; }

        [StringLength(50)]
        public string car_work1 { get; set; }

        [StringLength(50)]
        public string car_work2 { get; set; }

        [StringLength(50)]
        public string car_work3 { get; set; }

        [StringLength(255)]
        public string car_work3_detail { get; set; }

        [StringLength(50)]
        public string car_work4 { get; set; }

        [StringLength(255)]
        public string car_work4_detail { get; set; }

        [StringLength(50)]
        public string car_edit_date { get; set; }

        public int? add_provid { get; set; }

        public int? add_tambol_id { get; set; }

        public int? add_amphur_id { get; set; }

        public int? work_provid { get; set; }

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

        [StringLength(255)]
        public string WARRANTY_MILEAGE { get; set; }

        [StringLength(255)]
        public string icard_first_registerdate { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }
    }
}
