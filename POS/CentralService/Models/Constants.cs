using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
   public class Constants
    {
        public struct  Payment
        {
            public const string PartialPaymentModel = "PartialPaymentModel";
        }
        public struct PartialPaymentType
        {
            public const string PaymentTypeName = "PartialPaymentModel";
        }
        public struct PromotionType
        {
            public const string PromotionGive = "3";
            public const string PromotionCoupon = "4";
            public const string PromotionDiscountPercent = "1";
            public const string PromotionDiscountBaht = "2";

        }

        public struct TransactionStatusTypeID
        {
            public const int Commit = 2;
            public const int Reversal = 5;

        }
        public struct TenderTypeID
        {
            public const int Cash = 1;
            public const int Creditcard = 2;
            public const int BlueCard = 3;
            public const int Coupon = 4;
            public const int Fleet = 5;
            public const int Unknown = 6;
            public const int Voucher = 7;
            public const int OtherDiscount = 100;

        }
        public struct TenderCode
        {
            public const string Cash = "956900001";
            public const string Creditcard = "956900000";
            public const string BlueCard = "956900004";
            public const string Coupon = "956900005";
            public const string Fleet = "956900002";
            public const string Unknown = "956900003";
            public const string Voucher = "956900006";
            public const string OtherDiscount = "0000";
        }
        public struct PaymentType
        {
            public const string Cash = "Cash";
            public const string Creditcard = "Creditcard";
            public const string BlueCard = "BlueCard";
            public const string Coupon = "Coupon";
            public const string Fleet = "Fleet";
            public const string Unknown = "Unknown";
            public const string Voucher = "Voucher";
            public const string OtherDiscount = "Discount";
            public const string OtherPayment = "Other";
            public const string PartailPayment = "PartailPayment"; 
            public const string Deposit = "Deposit";
        }
        public struct DocCode
        {
            // ใบรับมัดจำลูกค้า
            public const string Deposit = "A302";
        }
        public struct BlueCardTypeCheck
        {
            public const string ThaiID = "ThaiID";
            public const string PhoneNumber = "PhoneNumber";
            public const string BlueCardCode = "BlueCardCode";
        }
        public struct CallTypeBlueCard
        {
            public const string Send = "Send";
            public const string Response = "Response";
          
        }
        public struct OnlinePaymentTypeCode
        {
            public const string Lazada = "lazada";
            public const string Shopee = "shopee";
            public const string RabbitLinePay = "rabbitlinepay";
            public const string Alibaba = "alibaba";
            public const string Wemall = "wemall";
            public const string JDCentral = "jdcentral";
        }

    }
}
