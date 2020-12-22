namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vote_link_customer
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(10)]
        public string cus_code { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cus_code_run { get; set; }

        [StringLength(11)]
        public string cus_type { get; set; }

        [StringLength(2)]
        public string custype_code { get; set; }

        [StringLength(2)]
        public string buss_code { get; set; }

        [StringLength(1)]
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

        public short? add_provid { get; set; }

        [StringLength(255)]
        public string add_province { get; set; }

        [StringLength(255)]
        public string add_zip { get; set; }

        [StringLength(255)]
        public string add_tel { get; set; }

        [StringLength(255)]
        public string add_mobile { get; set; }

        [StringLength(255)]
        public string add_fax { get; set; }

        [StringLength(255)]
        public string add_email { get; set; }

        [StringLength(6)]
        public string cusgroup_code { get; set; }

        [StringLength(20)]
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

        [StringLength(10)]
        public string contact_fdate { get; set; }

        [StringLength(10)]
        public string contact_ldate { get; set; }

        [StringLength(10)]
        public string cancel_date { get; set; }

        [Column(TypeName = "ntext")]
        public string behavior_memo { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string on_acccredit { get; set; }

        [StringLength(10)]
        public string cus_birth { get; set; }

        [StringLength(255)]
        public string cus_sex { get; set; }

        [StringLength(255)]
        public string discount_type { get; set; }

        [StringLength(255)]
        public string deposit_amount { get; set; }

        [StringLength(1)]
        public string af_status { get; set; }

        public double? DATE_REPORT { get; set; }
    }
}
