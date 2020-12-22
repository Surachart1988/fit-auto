namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Campaign
    {
        [Key]
        [StringLength(10)]
        public string campaign_id { get; set; }

        [StringLength(255)]
        public string campaign_name { get; set; }

        [StringLength(50)]
        public string campaign_add_date { get; set; }

        [StringLength(50)]
        public string campaign_edit_date { get; set; }

        [StringLength(20)]
        public string campaign_add_time { get; set; }

        [StringLength(20)]
        public string campaign_edit_time { get; set; }

        public bool? deleted { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
        public int SendClient { get; set; }
    }
}
