namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_RDADetail
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string dp_name { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public double? dp_price { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string emp_code { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOC_NO_RUN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
