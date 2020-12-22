namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_log
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string user_name { get; set; }

        [StringLength(255)]
        public string user_date { get; set; }

        [StringLength(255)]
        public string user_time { get; set; }

        [StringLength(255)]
        public string menu_number { get; set; }

        [StringLength(255)]
        public string menu_type { get; set; }

        [StringLength(255)]
        public string menu_name { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
