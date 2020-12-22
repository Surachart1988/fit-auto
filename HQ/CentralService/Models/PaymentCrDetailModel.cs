using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PaymentCrDetailModel
    {
        public int Id { get; set; }

        public string DocNo { get; set; }

        public string DocCode { get; set; }

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
    }
}
