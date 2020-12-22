namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Authorize_Approve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Approve_id { get; set; }

        public int Doc_id { get; set; }

        [StringLength(255)]
        public string Approve_name_th { get; set; }

        [StringLength(255)]
        public string Approve_name_en { get; set; }

        [StringLength(50)]
        public string Approve_table { get; set; }

        [StringLength(50)]
        public string Approve_field { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
