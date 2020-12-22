namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_HQ
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(255)]
        public string com_name { get; set; }

        [StringLength(255)]
        public string zone_code { get; set; }

        [StringLength(255)]
        public string add_name { get; set; }

        [StringLength(255)]
        public string add_no { get; set; }

        [StringLength(255)]
        public string add_moo { get; set; }

        [StringLength(255)]
        public string add_trog { get; set; }

        [StringLength(255)]
        public string add_soi { get; set; }

        [StringLength(255)]
        public string add_road { get; set; }

        public int? add_tumbol_id { get; set; }

        [StringLength(255)]
        public string add_tumbol { get; set; }

        public int? add_amphur_id { get; set; }

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
        public string tax_number { get; set; }

        [StringLength(255)]
        public string manager_code { get; set; }

        [StringLength(255)]
        public string branch_manager { get; set; }

        [StringLength(255)]
        public string create_product { get; set; }

        [StringLength(255)]
        public string rec_date { get; set; }

        [StringLength(255)]
        public string com_engname { get; set; }

        [StringLength(255)]
        public string add_engname { get; set; }

        [StringLength(255)]
        public string add_engno { get; set; }

        [StringLength(255)]
        public string add_engmoo { get; set; }

        [StringLength(255)]
        public string add_engtrog { get; set; }

        [StringLength(255)]
        public string add_engsoi { get; set; }

        [StringLength(255)]
        public string add_engroad { get; set; }

        [StringLength(255)]
        public string add_engtumbol { get; set; }

        [StringLength(255)]
        public string add_engamphur { get; set; }

        [StringLength(255)]
        public string add_engprovince { get; set; }

        [StringLength(255)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string dealer_type { get; set; }

        [StringLength(255)]
        public string vat_default { get; set; }

        [StringLength(255)]
        public string authorise_password { get; set; }

        [StringLength(255)]
        public string e_mail { get; set; }

        [StringLength(255)]
        public string web_site { get; set; }

        public int? client_limit { get; set; }

        [StringLength(50)]
        public string tax_branch_id { get; set; }

        [StringLength(50)]
        public string tax_branch { get; set; }

        [StringLength(255)]
        public string license_key { get; set; }

        [StringLength(10)]
        public string Vat_DB { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        [StringLength(10)]
        public string branch_used { get; set; }

        public int? salezone_id { get; set; }

        public int? salegroup_id { get; set; }

        [StringLength(10)]
        public string flag_hq { get; set; }

        public int? SendClient { get; set; }
    }
}
