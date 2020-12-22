namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_SeeCar
    {
        public int id { get; set; }

        [StringLength(255)]
        public string brand { get; set; }

        [StringLength(255)]
        public string model { get; set; }

        [StringLength(255)]
        public string version { get; set; }

        [StringLength(255)]
        public string year { get; set; }

        [StringLength(255)]
        public string f_marking { get; set; }

        [StringLength(255)]
        public string f_lb { get; set; }

        [StringLength(255)]
        public string r_marking { get; set; }

        [StringLength(255)]
        public string r_lb { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
