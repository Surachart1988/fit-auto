namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transfer_Data
    {
        [Key]
        public int Transfer_ID { get; set; }

        [StringLength(255)]
        public string Source_Table { get; set; }

        [Column(TypeName = "ntext")]
        public string Source_Field { get; set; }

        [Column(TypeName = "ntext")]
        public string Source_Key { get; set; }

        [StringLength(255)]
        public string Destination_Table { get; set; }

        [Column(TypeName = "ntext")]
        public string Destination_Field { get; set; }

        [Column(TypeName = "ntext")]
        public string Destination_Key { get; set; }

        [StringLength(255)]
        public string WebService_Function { get; set; }

        [StringLength(50)]
        public string Data_Type { get; set; }

        [StringLength(255)]
        public string Log_Table { get; set; }

        [Column(TypeName = "ntext")]
        public string Log_Field { get; set; }
    }
}
