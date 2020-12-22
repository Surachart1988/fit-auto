namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Barcode_Print
    {
        [Key]
        public int doc_no_run { get; set; }

        public int? random_id { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? pro_qty { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
