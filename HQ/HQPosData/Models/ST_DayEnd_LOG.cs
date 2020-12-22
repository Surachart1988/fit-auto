namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_DayEnd_LOG
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string dayend_name { get; set; }

        [StringLength(255)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string run_status { get; set; }

        [StringLength(50)]
        public string log_date { get; set; }

        [StringLength(50)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
