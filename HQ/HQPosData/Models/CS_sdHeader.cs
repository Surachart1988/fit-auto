namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_sdHeader
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(8)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string ven_code { get; set; }

        [StringLength(10)]
        public string pay_date { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [StringLength(255)]
        public string doc_ref_no1 { get; set; }

        [StringLength(10)]
        public string doc_Ref_date1 { get; set; }

        [StringLength(255)]
        public string doc_ref_no2 { get; set; }

        [StringLength(10)]
        public string doc_Ref_date2 { get; set; }

        [StringLength(1)]
        public string vate_type { get; set; }

        public double? vate_rate { get; set; }

        public double? sd_disamt { get; set; }

        public double? sd_dispercent { get; set; }

        public double? sd_distotalamt { get; set; }

        public double? sd_netamt { get; set; }

        public double? sd_vatamt { get; set; }

        public double? sd_totalamt { get; set; }

        [StringLength(500)]
        public string sd_Remark { get; set; }

        [StringLength(1)]
        public string sd_payment { get; set; }

        public double? sd_paycash { get; set; }

        public double? sd_paycard { get; set; }

        public double? sd_paydeposite { get; set; }

        public double? sd_payother { get; set; }

        public double? sd_paytot { get; set; }

        [StringLength(1)]
        public string doc_Close { get; set; }

        [StringLength(1)]
        public string doc_Cancle { get; set; }

        [StringLength(10)]
        public string doc_cancledate { get; set; }

        public double? ven_limit { get; set; }

        public double? ven_balance { get; set; }

        public int? date_report { get; set; }

        public int? detail_line { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        [StringLength(500)]
        public string sd_CcRemark { get; set; }
    }
}
