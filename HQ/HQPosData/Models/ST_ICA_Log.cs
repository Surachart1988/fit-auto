namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ICA_Log
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_status { get; set; }

        [StringLength(50)]
        public string log_date { get; set; }

        [StringLength(50)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
