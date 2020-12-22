namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CST_Create
    {
        [Key]
        [Column(Order = 0)]
        public int doc_no_run { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int random_id { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string date_create { get; set; }

        [StringLength(50)]
        public string time_create { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public double? average_cost { get; set; }

        [StringLength(50)]
        public string CST_Docno { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
