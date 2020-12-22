namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_PromotionDiscount
    {
        public SB_PromotionDiscount()
        {
            SB_PromotionHeader = new HashSet<SB_PromotionHeader>();
        }

        [Key]
        public int pro_discount_id { get; set; }

        [StringLength(255)]
        public string pro_discount_name { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public ICollection<SB_PromotionHeader> SB_PromotionHeader { get; set; }

    }
}
