namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Prheader_Approve
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOC_NO_RUN { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string ref_branchno { get; set; }

        [StringLength(255)]
        public string ref_doccode { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(255)]
        public string car_engine { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string cus_addr_1 { get; set; }

        [StringLength(255)]
        public string cus_addr_2 { get; set; }

        [StringLength(255)]
        public string cus_province { get; set; }

        [StringLength(255)]
        public string cus_zip { get; set; }

        [StringLength(255)]
        public string car_brand { get; set; }

        [StringLength(255)]
        public string car_model { get; set; }

        [StringLength(255)]
        public string car_color { get; set; }

        public double? car_mileage { get; set; }

        public double? credit_term { get; set; }

        [StringLength(255)]
        public string due_date { get; set; }

        [StringLength(255)]
        public string vat_type { get; set; }

        public double? vat_rateprod { get; set; }

        public double? vat_rateserv { get; set; }

        public double? disc_percent { get; set; }

        public double? disc_bath { get; set; }

        public double? amt_discount { get; set; }

        public double? amt_sumprod { get; set; }

        public double? amt_sumserv { get; set; }

        public double? amt_netamt { get; set; }

        public double? amt_vatprod { get; set; }

        public double? amt_vatserv { get; set; }

        public float? amt_totalprod { get; set; }

        public double? amt_totalserv { get; set; }

        public double? grand_total { get; set; }

        public int? last_line { get; set; }

        public int? print_no { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(255)]
        public string priceown_code { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        public int? create_user_id { get; set; }

        [StringLength(50)]
        public string app_docno { get; set; }

        [StringLength(10)]
        public string approve_pro_price { get; set; }

        [StringLength(10)]
        public string admin_pro_price { get; set; }

        [StringLength(255)]
        public string admin_pro_price_memo { get; set; }

        public int? APP_DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
