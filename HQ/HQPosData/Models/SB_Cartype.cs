namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Cartype
    {
        [Key]
        [StringLength(50)]
        public string cartype_code { get; set; }

        [StringLength(255)]
        public string cartype_name { get; set; }

        [StringLength(255)]
        public string rec_date { get; set; }

        [StringLength(50)]
        public string Cartype_group { get; set; }

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
