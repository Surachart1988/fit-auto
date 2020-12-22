namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_CLUB_TYPE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CLUB_TYPE { get; set; }

        [StringLength(100)]
        public string CLUB_TYPE_Name { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
