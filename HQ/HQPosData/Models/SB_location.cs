namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_location
    {
        [Key]
        public int locat_code { get; set; }

        [StringLength(255)]
        public string locat_name { get; set; }

        [StringLength(255)]
        public string novat_status { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string show_status { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        public int? locat_main_id { get; set; }

        public int? locat_dot_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

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
