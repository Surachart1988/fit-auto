namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Proprice_Update
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int auto_id { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(50)]
        public string proprice_date { get; set; }

        [StringLength(50)]
        public string cus_groupcode { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
