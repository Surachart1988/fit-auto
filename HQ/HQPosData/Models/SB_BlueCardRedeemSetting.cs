namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_BlueCardRedeemSetting
    {
        [Key]
        public int card_no_run { get; set; }

        public bool? BlueCard_exchange_rateby { get; set; }

        public int? BlueCard_RewardPoint { get; set; }

        public int? BlueCard_Money { get; set; }

        public int? BlueCard_MinimumRewardPoint { get; set; }

        public double? BlueCard_Ratio_Point { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }
    }
}
