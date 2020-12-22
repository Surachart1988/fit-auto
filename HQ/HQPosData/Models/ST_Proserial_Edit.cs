namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Proserial_Edit
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_serial_new { get; set; }

        [StringLength(255)]
        public string pro_serial_old { get; set; }

        [StringLength(255)]
        public string rec_memo_new { get; set; }

        [StringLength(255)]
        public string rec_memo_old { get; set; }

        [StringLength(255)]
        public string edit_date { get; set; }

        [StringLength(255)]
        public string edit_time { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }
    }
}
