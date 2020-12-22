using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PaymentModel
    {
        public PaymentModel()
        {
            PaymentIconList = new List<PaymentIconModel>();
            DiscountIconList = new List<ExtraDiscountIconModel>();
        }

        public double TotalAmount { get; set; }

        public double TotalDiscount { get; set; }

        public double PaymentAmount { get; set; }

        public double PaymentCash { get; set; }

        public double ChangeMoney { get; set; }

        public double CashAmount { get; set; }

        public string PaymentCashNote { get; set; }

        public double PaymentCheck { get; set; }

        public double PaymentDeposit { get; set; }

        public double PaymentOther { get; set; }

        public double LastDiscount { get; set; }

        public string RefDocNo { get; set; }

        public string DocNo { get; set; }

        public string DocCode { get; set; }

        public string CustomerCode { get; set; }

        public string VenderCode { get; set; }

        public List<PaymentIconModel> PaymentIconList { get; set; }

        public List<ExtraDiscountIconModel> DiscountIconList { get; set; }

        public List<PromotionAndDiscountModal> PromotionAndDiscountModalList { get; set; }

        public List<PromotionAndDiscountModal> PromotionModalList { get; set; }

        public DepositModel DepositModel { get; set; }

        public bool Cancel { get; set; }

        public string BlueCardNo { get; set; }

        public decimal BlueCardBalancePoint { get; set; }

        public decimal BlueCardRewardPoint { get; set; }

        public string BlueCardCode { get; set; }

        public decimal BlueCardUsePoint { get; set; }

        public decimal BlueCardMoney { get; set; }

        public string BlueCardSaveNo { get; set; }

        public string BlueCardSaveMobile { get; set; }

    }

    public class PaymentIconModel
    {
        public string Name { get; set; }

        public string ImgName { get; set; }

        public string ModalId { get; set; }

        public int GroubId { get; set; }
    }
}
