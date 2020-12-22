namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Lineno_Update
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int auto_id { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        public int? doc_no_run { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
