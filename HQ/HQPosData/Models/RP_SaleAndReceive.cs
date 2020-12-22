namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_SaleAndReceive
    {
        [Key]
        public int doc_no_run { get; set; }

        public double? sum_sale_netamt_novat { get; set; }

        public double? sum_sale_vatamt { get; set; }

        public double? sum_sale_payment { get; set; }

        public double? sum_sale_disamt { get; set; }

        public double? sumday_sale_money_pay { get; set; }

        public double? sum_sale_paycash { get; set; }

        public double? sum_sale_paycard { get; set; }

        public double? sum_sale_paychq { get; set; }

        public double? sum_sale_payother { get; set; }

        public double? sum_sale_paydeposit { get; set; }

        public double? sum_sale_paypledge { get; set; }

        public double? sum_sale_payadd { get; set; }

        public double? sum_sale_paytot_rpa { get; set; }

        public double? sum_sale_disamt_rpa { get; set; }

        public double? sum_sale_directdebit { get; set; }

        public double? sum_buy_netamt_novat { get; set; }

        public double? sum_buy_vatamt { get; set; }

        public double? sum_buy_paycash { get; set; }

        public double? sum_buy_paycard { get; set; }

        public double? sum_buy_paychq { get; set; }

        public double? sum_buy_payother { get; set; }

        public double? sum_buy_pay_ppa { get; set; }

        public double? sum_buy_money_pay { get; set; }

        public double? sum_buy_disall { get; set; }

        public double? sum_buy_payadd { get; set; }

        public double? sum_day_paytot_rpa { get; set; }

        public double? sum_rta { get; set; }

        public double? sum_pta { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
