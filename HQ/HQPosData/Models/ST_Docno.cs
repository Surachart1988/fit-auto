namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Docno
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
