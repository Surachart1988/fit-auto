namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Car_Transfer
    {
        public int id { get; set; }

        [StringLength(255)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_province { get; set; }

        [StringLength(255)]
        public string cus_code_old { get; set; }

        [StringLength(255)]
        public string cus_code_new { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }
    }
}
