using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public partial class SbPromotionGiveType
    {
        public SbPromotionGiveType()
        {
            SbPromotionHeader = new HashSet<ExtraPromotionModel>();
        }

        public int ProGiveTypeId { get; set; }
        public string ProGiveTypeName { get; set; }
        public string ProGiveTypeUnit { get; set; }
        public bool? Deleted { get; set; }
        public string Dealercode { get; set; }
        public string BranchNo { get; set; }

        public ICollection<ExtraPromotionModel> SbPromotionHeader { get; set; }
    }
}
