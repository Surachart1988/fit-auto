namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ICARD_EXPIRE
    {
        public int id { get; set; }

        [StringLength(255)]
        public string icard_id { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string register_date { get; set; }

        [StringLength(255)]
        public string expire_date { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(50)]
        public string Branch_no { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(255)]
        public string car_prov_name { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }
    }
}
