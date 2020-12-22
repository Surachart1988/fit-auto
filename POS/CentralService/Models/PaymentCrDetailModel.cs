using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PaymentCrDetailModel
    {
        public int Id { get; set; }

        public string DocNo { get; set; }
        public string CustCode { get; set; }

        public string DocCode { get; set; }

        public double PaymentCr { get; set; }

        public string CreditNumber { get; set; }

        public int ExpiredMonth { get; set; }
        public string S_ExpiredMonth { get; set; }
        public string S_ExpiredYear { get; set; }

        public int ExpiredYear { get; set; }

        public string ApprCode { get; set; }

        public string BankCode { get; set; }

        public string CardTypeCode { get; set; }

        public int PaymentFormatId { get; set; }
        public string TypeTrans { get; set; }
        public string Note { get; set; }

        public string ConnectType { get; set; }

        public string CreditType { get; set; }
        public string dealercode { get; set; }

        public string ResponseText { get; set; }
        public string MerchantNameAndAddress { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string ApprovalCode { get; set; }

        public string InvoiceNumber { get; set; }
        public string TerminalID { get; set; }
        public string MerchantID { get; set; }
        public string CardIssuerName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDateYYMM { get; set; }
        public string BatchNumber { get; set; }
        public string CardIssuerID { get; set; }
        public string CardHolderName { get; set; }
        public string Amount { get; set; }
        public string RedeemPoint { get; set; }
        public string RedeemAmount { get; set; }
        public string RedeemPointBalance { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTAXID { get; set; }
        public string CustomerBranchNumber { get; set; }
        public string CustomerCarLicense { get; set; }
        public string TI { get; set; }
        public string PTTBlueCardNumber { get; set; }
        public string ReferenceNumber {get;set;}

    }
}
