namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_PROSUB_NEXTSERV
    {
        public double? SCARD_TYPE { get; set; }

        [Key]
        [StringLength(50)]
        public string SUB_NEXTSERV_CODE { get; set; }

        [StringLength(255)]
        public string SUB_NEXTSERV_Name { get; set; }

        [StringLength(255)]
        public string PROGROUP_CODE { get; set; }

        public double? Km { get; set; }

        public double? Ser_day { get; set; }

        public double? LOOP { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Link1 { get; set; }

        [StringLength(255)]
        public string Link2 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(50)]
        public string Branch_no { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }
    }
}
