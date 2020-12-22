namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ISB_Transfer_Data
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Transfer_ID { get; set; }

        [StringLength(255)]
        public string Source_Table { get; set; }

        [Column(TypeName = "ntext")]
        public string Source_Field { get; set; }

        [Column(TypeName = "ntext")]
        public string Source_Datatype { get; set; }

        [Column(TypeName = "ntext")]
        public string Source_Key { get; set; }

        [StringLength(255)]
        public string Destination_DB { get; set; }

        [StringLength(255)]
        public string Destination_Table { get; set; }

        [Column(TypeName = "ntext")]
        public string Destination_Field { get; set; }

        [Column(TypeName = "ntext")]
        public string Destination_Key { get; set; }

        public int? Used_Status { get; set; }

        public int? Update_Status { get; set; }

        [StringLength(10)]
        public string send_type { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
