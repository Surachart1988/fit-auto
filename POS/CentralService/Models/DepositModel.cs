using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class DepositModel
    {
        public int Id { get; set; }

        public string DocNo { get; set; }

        public string DocCode { get; set; }

        public string DepositNo { get; set; }

        public string Date { get; set; }

        public string CustomerName { get; set; }

        public double Money { get; set; }

        public string Note { get; set; }
    }
}
