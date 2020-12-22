namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CusCar_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(50)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(255)]
        public string car_regprovince { get; set; }

        [StringLength(255)]
        public string car_regdate { get; set; }

        [StringLength(255)]
        public string car_body { get; set; }

        [StringLength(255)]
        public string car_engine_cc { get; set; }

        [StringLength(255)]
        public string car_engine { get; set; }

        public int? car_brand_code { get; set; }

        [StringLength(255)]
        public string car_brand { get; set; }

        public int? car_model_code { get; set; }

        [StringLength(255)]
        public string car_model { get; set; }

        [StringLength(255)]
        public string car_color { get; set; }

        [StringLength(255)]
        public string car_year { get; set; }

        [StringLength(255)]
        public string cartype_code { get; set; }

        [StringLength(255)]
        public string labour_brand { get; set; }

        [StringLength(255)]
        public string labour_model { get; set; }

        [StringLength(255)]
        public string car_guar_code { get; set; }

        [StringLength(255)]
        public string car_guar_name { get; set; }

        [StringLength(255)]
        public string car_guar_fdate { get; set; }

        [StringLength(255)]
        public string car_guar_ldate { get; set; }

        public double? car_guar_pay { get; set; }

        [StringLength(255)]
        public string car_guar_memo { get; set; }

        [StringLength(255)]
        public string cus_patype { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string first_contdate { get; set; }

        public int? first_mileage { get; set; }

        [StringLength(255)]
        public string last_contdate { get; set; }

        public int? last_mileage { get; set; }

        [StringLength(255)]
        public string car_creditlimit { get; set; }

        [StringLength(255)]
        public string car_creditbalance { get; set; }

        [StringLength(255)]
        public string cancel_date { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public double? Car_Average { get; set; }

        [StringLength(255)]
        public string car_type1 { get; set; }

        [StringLength(255)]
        public string icard_number { get; set; }

        [StringLength(255)]
        public string ICARD_ID { get; set; }

        [StringLength(255)]
        public string CUS_ID { get; set; }

        [StringLength(255)]
        public string CUS_CARID { get; set; }

        [StringLength(255)]
        public string CARD_PASSWORD { get; set; }

        [StringLength(255)]
        public string REGISTER_DATE { get; set; }

        [StringLength(255)]
        public string EXPIRE_DATE { get; set; }

        public double? POINT_ALL { get; set; }

        public double? DATE_REPORT { get; set; }

        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(255)]
        public string CAR_REG_OLD { get; set; }

        [StringLength(255)]
        public string ICARD_ID_OLD { get; set; }

        [StringLength(50)]
        public string WARRANTY_DATE { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

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

        public int? Warranty_date_report { get; set; }

        public int? CLUB_TYPE { get; set; }

        [StringLength(255)]
        public string voidno { get; set; }

        [StringLength(255)]
        public string TB_Customer_type { get; set; }

        [StringLength(255)]
        public string TB_Customer_code { get; set; }

        [StringLength(255)]
        public string icard_first_registerdate { get; set; }

        public int? add_date_report { get; set; }

        [StringLength(50)]
        public string pic_cuscar_name { get; set; }

        [StringLength(255)]
        public string pic_cuscar_path { get; set; }

        public int? car_color_id { get; set; }

        [StringLength(100)]
        public string passkit_serial { get; set; }

        [StringLength(255)]
        public string passkit_url { get; set; }

        [StringLength(100)]
        public string passkit_passbookSerial { get; set; }

        [StringLength(100)]
        public string passkit_shareID { get; set; }

        [StringLength(100)]
        public string passkit_uniqueID { get; set; }

        [StringLength(50)]
        public string passkit_register_date { get; set; }

        [StringLength(50)]
        public string passkit_expire_date { get; set; }

        [StringLength(50)]
        public string passkit_add_date { get; set; }

        [StringLength(50)]
        public string passkit_add_time { get; set; }

        [StringLength(50)]
        public string passkit_edit_date { get; set; }

        [StringLength(50)]
        public string passkit_edit_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

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

        public int? gear_id { get; set; }
    }
}
