namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TCS_location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locat_code { get; set; }

        [StringLength(255)]
        public string locat_name { get; set; }

        [StringLength(255)]
        public string novat_status { get; set; }

        [StringLength(255)]
        public string AF_Status { get; set; }

        [StringLength(255)]
        public string show_status { get; set; }

        [StringLength(10)]
        public string BRANCH_NO { get; set; }
    }
}
