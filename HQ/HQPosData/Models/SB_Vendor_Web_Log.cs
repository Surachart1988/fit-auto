namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Vendor_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [Key]
        public int ven_code_run { get; set; }

        [StringLength(255)]
        public string pre_name { get; set; }

        [StringLength(255)]
        public string ven_name { get; set; }

        [StringLength(255)]
        public string contact_name { get; set; }

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
        public string vengroup_code { get; set; }

        [StringLength(255)]
        public string vat_type { get; set; }

        [StringLength(255)]
        public string vat_code { get; set; }

        public double? ven_discount { get; set; }

        public int? ven_ship_term { get; set; }

        [StringLength(255)]
        public string ven_ct_code { get; set; }

        public int? ven_credit_term { get; set; }

        public double? ven_credit_limit { get; set; }

        public double? ven_balance { get; set; }

        [StringLength(255)]
        public string contact_fdate { get; set; }

        [StringLength(255)]
        public string contact_ldate { get; set; }

        [StringLength(255)]
        public string cancel_date { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public int? ordering_date { get; set; }

        public int? ordering_cycle { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        public double? ven_balance_cs { get; set; }

        [StringLength(50)]
        public string tax_id { get; set; }

        [StringLength(50)]
        public string tax_branch_id { get; set; }

        [StringLength(50)]
        public string tax_branch { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

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
    }
}
