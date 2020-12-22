namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Car_reg
    {
        public int id { get; set; }

        [StringLength(255)]
        public string flag_net { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_province { get; set; }

        [StringLength(255)]
        public string car_reg_new { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(50)]
        public string Branch_no { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(255)]
        public string car_prov_name_new { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }
    }
}
