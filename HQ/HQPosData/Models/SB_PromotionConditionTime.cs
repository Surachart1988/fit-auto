namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_PromotionConditionTime
    {
        public SB_PromotionConditionTime()
        {
            SbPromotionHeader = new HashSet<SB_PromotionHeader>();
        }
        [Key]
        public int pro_condition_time_id { get; set; }

        [StringLength(255)]
        public string pro_condition_time_name { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public ICollection<SB_PromotionHeader> SbPromotionHeader { get; set; }
    }
}
