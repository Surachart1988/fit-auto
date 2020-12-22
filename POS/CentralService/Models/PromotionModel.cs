using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class PromotionModel
    {
        public int Id { get; set; }

        public string No { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }

        public double Price { get; set; }

        public string Other { get; set; }

        public string Unit { get; set; }

        public int Number { get; set; }

        public int Discount { get; set; }
    }
}
