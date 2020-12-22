namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_TBPoint
    {
        public int id { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string eu_status { get; set; }

        [StringLength(50)]
        public string top_status { get; set; }

        public double? price_point { get; set; }

        public double? eu_point { get; set; }

        public double? top_point { get; set; }

        [StringLength(50)]
        public string start_date { get; set; }

        [StringLength(50)]
        public string end_date { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
