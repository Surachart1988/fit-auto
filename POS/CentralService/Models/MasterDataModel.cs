using CentralService.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public class MasterDataModel
    {
        public MasterDataModel()
        {
            BlueCardRedeemSetting = new BlueCardRedeemSettingModel();
        }
        public int Id { get; set; }

        public bool canSearch { get; set; }
        public bool canCrate { get; set; }
        public bool canPagelist { get; set; }

        public SetmainHeadType menuHeadType { get; set; }
        public SetmainType menuType { get; set; }

        public BlueCardRedeemSettingModel BlueCardRedeemSetting { get; set; }

    }

    public class BlueCardRedeemSettingModel
    {
        public bool blueCard_exchange_rateby { get; set; }

        public double blueCard_Ratio_Point { get; set; }

        public int blueCard_RewardPoint { get; set; }

        public int blueCard_Money { get; set; }

        public int blueCard_MinimumRewardPoint { get; set; }
    }
    public enum SetmainHeadType
    {
        การเงิน = 99
    }
    public enum SetmainType
    {
        [Display(Name = "กำหนดข้อมูล BlueCard")]
        กำหนดข้อมูลBlueCard = 99
    }
}
