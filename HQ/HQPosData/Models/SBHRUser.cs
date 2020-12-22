namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SBHRUser")]
    public partial class SBHRUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SEmpNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string ip_address { get; set; }

        [StringLength(255)]
        public string susername { get; set; }

        [StringLength(255)]
        public string spassword { get; set; }

        [StringLength(255)]
        public string stfname { get; set; }

        [StringLength(255)]
        public string stlname { get; set; }

        [StringLength(255)]
        public string sefname { get; set; }

        [StringLength(255)]
        public string selname { get; set; }

        [StringLength(255)]
        public string clevel { get; set; }

        [StringLength(255)]
        public string dbirthday { get; set; }

        [StringLength(255)]
        public string sauthor { get; set; }

        [StringLength(255)]
        public string card_id { get; set; }

        [StringLength(255)]
        public string card_start_date { get; set; }

        [StringLength(255)]
        public string card_end_date { get; set; }

        [StringLength(255)]
        public string card_place { get; set; }

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
        public string emp_position { get; set; }

        [StringLength(255)]
        public string start_date { get; set; }

        [StringLength(255)]
        public string resign_date { get; set; }

        [StringLength(255)]
        public string emp_status { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        public int? group_id { get; set; }

        public double? sale_credit_limit { get; set; }

        [StringLength(10)]
        public string used_icard { get; set; }

        [StringLength(10)]
        public string used_pay_cancel { get; set; }

        [StringLength(10)]
        public string used_pay_confirm { get; set; }

        [StringLength(10)]
        public string used_revenue { get; set; }

        [StringLength(10)]
        public string used_rpa_save { get; set; }

        [StringLength(10)]
        public string used_product_data { get; set; }

        [StringLength(10)]
        public string used_history_sale { get; set; }

        [StringLength(10)]
        public string used_groove_price { get; set; }

        [StringLength(10)]
        public string used_movement { get; set; }

        [StringLength(10)]
        public string used_ap { get; set; }

        [StringLength(10)]
        public string used_vendor { get; set; }

        [StringLength(10)]
        public string used_product_cost { get; set; }

        [StringLength(10)]
        public string used_rpa_temp { get; set; }

        [StringLength(10)]
        public string used_price_edit { get; set; }

        [StringLength(10)]
        public string used_po_incre { get; set; }

        [StringLength(10)]
        public string used_sale_percent1_edit { get; set; }

        [StringLength(10)]
        public string used_sale_percent2_edit { get; set; }

        [StringLength(10)]
        public string used_sale_price_edit { get; set; }

        [StringLength(10)]
        public string used_pay_tmp { get; set; }

        [StringLength(10)]
        public string used_pay_ino { get; set; }

        [StringLength(10)]
        public string used_pay_tmw { get; set; }

        [StringLength(10)]
        public string used_pay_inv { get; set; }

        [StringLength(10)]
        public string used_pay_rda { get; set; }

        [StringLength(10)]
        public string used_pay_rpa { get; set; }

        [StringLength(10)]
        public string used_pay_rta { get; set; }

        [StringLength(10)]
        public string used_pay_ppa { get; set; }

        [StringLength(10)]
        public string used_pay_pta { get; set; }

        [StringLength(10)]
        public string used_sst { get; set; }

        [StringLength(10)]
        public string used_docno_ref { get; set; }

        [StringLength(10)]
        public string used_pay_cancel_spilt_bill { get; set; }

        [StringLength(10)]
        public string used_passkit { get; set; }

        [StringLength(10)]
        public string used_product_cost_r { get; set; }

        [StringLength(10)]
        public string used_product_cost_w { get; set; }

        [StringLength(10)]
        public string used_pay_abb { get; set; }

        [StringLength(20)]
        public string used_system { get; set; }

        [StringLength(255)]
        public string nickname { get; set; }

        [StringLength(10)]
        public string blood { get; set; }

        public int? add_tambol_id { get; set; }

        public int? add_amphur_id { get; set; }

        public int? add_provid { get; set; }

        public int? salezone_id { get; set; }

        public int? salegroup_id { get; set; }

        [StringLength(255)]
        public string add_mobile { get; set; }

        [StringLength(100)]
        public string user_salary { get; set; }

        [StringLength(100)]
        public string user_salary_perday { get; set; }

        [StringLength(255)]
        public string user_pic_name { get; set; }

        [StringLength(255)]
        public string user_pic_path { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        public int? add_user_id { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        public int? edit_user_id { get; set; }

        public double? sale_percent1 { get; set; }

        public double? sale_percent2 { get; set; }

        public double? sale_price { get; set; }

        public double? sale_all_bill { get; set; }

        [StringLength(10)]
        public string used_edit_car_mileage { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public int? SendClient { get; set; }

        [StringLength(20)]
        public string used_under_stock { get; set; }
    }
}
