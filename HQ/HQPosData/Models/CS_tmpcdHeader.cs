namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS_tmpcdHeader
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string No_ref { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string SEmpNo { get; set; }

        [StringLength(255)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(8)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string cus_code { get; set; }

        [StringLength(10)]
        public string pay_date { get; set; }

        [StringLength(1)]
        public string vate_type { get; set; }

        public double? vate_rate { get; set; }

        public double? cd_disamt { get; set; }

        public double? cd_dispercent { get; set; }

        public double? cd_distotalamt { get; set; }

        public double? cd_netamt { get; set; }

        public double? cd_vatamt { get; set; }

        public double? cd_totalamt { get; set; }

        [StringLength(500)]
        public string cd_Remark { get; set; }

        [StringLength(1)]
        public string cd_payment { get; set; }

        public double? cd_paycash { get; set; }

        public double? cd_paycard { get; set; }

        public double? cd_paydeposite { get; set; }

        public double? cd_payother { get; set; }

        public double? cd_paytot { get; set; }

        [StringLength(1)]
        public string doc_Close { get; set; }

        [StringLength(1)]
        public string doc_Cancle { get; set; }

        [StringLength(10)]
        public string doc_cancledate { get; set; }

        public double? cus_limit { get; set; }

        public double? cus_balance { get; set; }

        public int? date_report { get; set; }

        public int? detail_line { get; set; }

        [StringLength(255)]
        public string doc_no2 { get; set; }

        [StringLength(20)]
        public string doc_inv_clam { get; set; }

        [StringLength(20)]
        public string doc_ref_no { get; set; }

        [StringLength(255)]
        public string csRemCancle { get; set; }
    }
}
