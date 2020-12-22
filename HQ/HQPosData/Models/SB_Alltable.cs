namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Alltable
    {
        [Key]
        public int table_id { get; set; }

        [StringLength(150)]
        public string table_name { get; set; }
    }
}
