namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_Financial_Header
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string docref_no { get; set; }

        [StringLength(50)]
        public string docref_date { get; set; }

        [StringLength(10)]
        public string doc_type { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(50)]
        public string payment_duedate { get; set; }

        [StringLength(10)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? total_amt { get; set; }

        public double? total_disamt { get; set; }

        public double? vat_amt { get; set; }

        public double? total_netamt { get; set; }

        public double? pay_cash { get; set; }

        public double? pay_card { get; set; }

        public double? pay_cashcard { get; set; }

        public double? pay_chq { get; set; }

        public double? pay_deposit { get; set; }

        public double? pay_other { get; set; }

        public double? pay_total { get; set; }

        public int? emp_code { get; set; }

        public int? DATE_REPORT { get; set; }

        public int? DOCREF_DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
