using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PartialPaymentModel
    {
        public string PaymentType { get; set; }
        public string PaymentTypeName { get; set; }
        public double Money { get; set; }
        public double ChangeMoney { get; set; }

        public string PaymentNumberId { get; set; }
        public string Remark { get; set; }
        public bool? Active { get; set; }
        public string Action { get; set; }
        public string DocNo { get; set; }
        public string DocCode { get; set; }

        public double PaymentSum { get; set; }
        public double PaymentTotal { get; set; }
        public double PaymentBalance { get; set; }


        // credit card

        public double PaymentCr { get; set; }

        public string CreditNumber { get; set; }

        public int ExpiredMonth { get; set; }

        public int ExpiredYear { get; set; }

        public string ApprCode { get; set; }

        public string BankCode { get; set; }

        public string CardTypeCode { get; set; }

        public int PaymentFormatId { get; set; }

        public string Note { get; set; }

        public string ConnectType { get; set; }

        public string CreditType { get; set; }


        //Blue Cared
        public string BlueCardNo { get; set; }
        public string BlueCardMobile { get; set; }
        //  public string BlueCareMoney { get; set; }



        public List<SelectListItemData> PaymentTypesList { get; set; }

        public PartialPaymentModel()
        {
            PaymentTypesList = SetUpData();
        }

        public List<SelectListItemData> SetUpData()
        {
            var result = new List<SelectListItemData>();

            result.Add(new SelectListItemData
            {
                Value = "CashPayment",
                Name  = "เงินสด",
            });
            result.Add(new SelectListItemData
            {
                Value = "CreditPayment",
                Name = "เครดิตการ์ด",
            });
            result.Add(new SelectListItemData
            {
                Value = "EDCPayment",
                Name = "เครดิต EDC",
            });
            result.Add(new SelectListItemData
            {
                Value = "BlueCardPayment",
                Name = "PTT BlueCard",
            });


            return result;

        }
    }

    public class SelectListItemData
    {
        public string Value { get; set; }
        public string Name { get; set; }

        public SelectListItemData() { }
    }


}
