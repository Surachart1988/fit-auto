namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CAR_MASTER
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string CAR_BRAND { get; set; }

        [Required]
        [StringLength(255)]
        public string CAR_MODEL { get; set; }

        [Required]
        [StringLength(255)]
        public string SUB_MODEL { get; set; }

        [Required]
        [StringLength(255)]
        public string SUB_MODEL2 { get; set; }

        [Required]
        [StringLength(255)]
        public string SUB_MODEL3 { get; set; }

        [Required]
        [StringLength(255)]
        public string CAR_MODEL_TEMP { get; set; }

        [Required]
        [StringLength(255)]
        public string CAR_TYPE { get; set; }

        [Required]
        [StringLength(255)]
        public string CC { get; set; }

        [Required]
        [StringLength(4)]
        public string CAR_YEAR { get; set; }

        [Required]
        [StringLength(255)]
        public string KEYLink_TIRE { get; set; }

        [Required]
        [StringLength(255)]
        public string KEYLink_BATTERY { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
