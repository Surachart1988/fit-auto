namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayCash
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        public double? cash_amt { get; set; }

        public int? user_pay_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public double? payment_cash { get; set; }

        public double? change_money { get; set; }

        public string card_remark { get; set; }
    }
}
