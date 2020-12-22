namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_SERVICES_CHECK
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public double? num_odd { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
