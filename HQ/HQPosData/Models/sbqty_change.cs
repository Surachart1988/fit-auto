namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sbqty_change
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int change_id { get; set; }

        [StringLength(255)]
        public string fstoreid { get; set; }

        [StringLength(255)]
        public string ssecno { get; set; }

        [StringLength(255)]
        public string date_change { get; set; }

        [StringLength(255)]
        public string date_change_since { get; set; }

        public int? old_qty { get; set; }

        public int? new_qty { get; set; }

        [StringLength(255)]
        public string remark { get; set; }

        [StringLength(255)]
        public string sempno { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
