namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_DayEnd_DocState
    {
        [Key]
        public int ds_id { get; set; }

        [StringLength(160)]
        public string doc_code { get; set; }

        [StringLength(320)]
        public string doc_no { get; set; }

        [StringLength(320)]
        public string doc_date { get; set; }

        public int? date_report { get; set; }

        [StringLength(320)]
        public string date_used { get; set; }

        [StringLength(320)]
        public string date_used_report { get; set; }

        public int? emp_id { get; set; }

        [StringLength(160)]
        public string doc_no_dayend { get; set; }
    }
}
