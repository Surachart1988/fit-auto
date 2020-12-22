namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_ProSize
    {
        [Key]
        public int pro_size_code { get; set; }

        [StringLength(255)]
        public string size_name { get; set; }

        [StringLength(255)]
        public string pro_size { get; set; }

        [StringLength(255)]
        public string size1 { get; set; }

        [StringLength(255)]
        public string size2 { get; set; }

        [StringLength(255)]
        public string size3 { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        public int? SendClient { get; set; }
    }
}
