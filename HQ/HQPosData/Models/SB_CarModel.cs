namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CarModel
    {
        [Key]
        public int car_model_code { get; set; }

        public int? car_brand_code { get; set; }

        [StringLength(255)]
        public string car_brand { get; set; }

        [StringLength(255)]
        public string car_model { get; set; }

        [StringLength(255)]
        public string rec_date { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int? SendClient { get; set; }
    }
}
