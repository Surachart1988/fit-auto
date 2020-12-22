namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Cash_Drawer_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cash_Drawer_Type_ID { get; set; }

        [StringLength(50)]
        public string Cash_Drawer_Type_Name { get; set; }
    }
}
