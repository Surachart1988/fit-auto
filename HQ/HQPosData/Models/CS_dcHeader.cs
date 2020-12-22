namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_dcHeader
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string doc_no { get; set; }

        public int? doc_no_run { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(8)]
        public string doc_time { get; set; }

        [StringLength(1)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string cus_paycode { get; set; }

        [StringLength(255)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string member_code { get; set; }

        public double? cust_balance { get; set; }

        [StringLength(255)]
        public string invoice_type { get; set; }

        public double? dc_disamt { get; set; }

        public double? dc_dispercent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dc_distotalamt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dc_netamt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dc_vatamt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dc_totalamt { get; set; }

        public double? dc_payamt { get; set; }

        public double? dc_paydeposit { get; set; }

        public double? dc_paytotal { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string doc_canmemo { get; set; }

        public int? detail_line { get; set; }

        [StringLength(10)]
        public string pay_date { get; set; }

        [StringLength(255)]
        public string close_date { get; set; }

        [StringLength(255)]
        public string close_time { get; set; }

        public int? date_report { get; set; }

        [StringLength(255)]
        public string priceown_code { get; set; }

        [StringLength(1)]
        public string doc_Close { get; set; }

        [StringLength(255)]
        public string SEmp_code { get; set; }

        [StringLength(1)]
        public string vate_type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? vate_rate { get; set; }

        [StringLength(500)]
        public string dc_Remark { get; set; }

        [StringLength(10)]
        public string doc_canceldate { get; set; }

        public double? cus_limit { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        [StringLength(255)]
        public string sEmp_Sale { get; set; }

        [StringLength(1)]
        public string doc_Cancle { get; set; }

        [StringLength(255)]
        public string dc_CcRemark { get; set; }

        [StringLength(1)]
        public string NO_VAT { get; set; }
    }
}
