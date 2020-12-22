namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Prov_Bak_Tambol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tambol_id { get; set; }

        public int? amphur_id { get; set; }

        [StringLength(255)]
        public string tambol_name { get; set; }

        [StringLength(255)]
        public string zipcode { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
