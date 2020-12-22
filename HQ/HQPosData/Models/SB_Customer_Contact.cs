namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Customer_Contact
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string cus_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string cuscont_code { get; set; }

        [StringLength(255)]
        public string cuscont_prename { get; set; }

        [StringLength(255)]
        public string cuscont_name { get; set; }

        [StringLength(255)]
        public string cuscont_name_eng { get; set; }

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

        [StringLength(10)]
        public string flag_delete { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }

        [StringLength(10)]
        public string flag_net_tb { get; set; }

        [StringLength(50)]
        public string last_update { get; set; }

        [StringLength(50)]
        public string cuscont_tax_id { get; set; }

        [StringLength(50)]
        public string cuscont_tax_branch_id { get; set; }

        [StringLength(50)]
        public string cuscont_tax_branch { get; set; }

        public int? cuscont_id_address { get; set; }

        [StringLength(10)]
        public string send_master { get; set; }
    }
}
