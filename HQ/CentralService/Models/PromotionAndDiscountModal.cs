using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PromotionAndDiscountModal
    {
        public int? Id { get; set; }

        public string Code { get; set; }

        public string DocNo { get; set; }

        public string DocCode { get; set; }

        public string Name { get; set; }

        public double? Number { get; set; }

        public double? Money { get; set; }

        public string Note { get; set; }

        public string ReferenceNo { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }

        public string Other { get; set; }

        public string Unit { get; set; }

        public double? Discount { get; set; }

        public string ProductGiveCode { get; set; }

        public string ProductGiveName { get; set; }
    }
}
