﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public partial class SbPromotionDiscount
    {
        public SbPromotionDiscount()
        {
            SbPromotionHeader = new HashSet<ExtraPromotionModel>();
        }

        public int ProDiscountId { get; set; }
        public string ProDiscountName { get; set; }
        public bool? Deleted { get; set; }
        public string Dealercode { get; set; }
        public string BranchNo { get; set; }

        public ICollection<ExtraPromotionModel> SbPromotionHeader { get; set; }
    }
}
