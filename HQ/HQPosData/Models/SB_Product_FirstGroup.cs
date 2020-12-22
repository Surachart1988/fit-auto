namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_FirstGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_group_id { get; set; }

        public int? product_group_code { get; set; }

        [StringLength(100)]
        public string product_group_name { get; set; }
    }
}
