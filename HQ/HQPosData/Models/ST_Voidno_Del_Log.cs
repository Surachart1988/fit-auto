namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Voidno_Del_Log
    {
        public int id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(100)]
        public string voidno { get; set; }

        [StringLength(50)]
        public string warranty_date { get; set; }

        [StringLength(50)]
        public string delete_date { get; set; }

        [StringLength(50)]
        public string delete_time { get; set; }

        [StringLength(150)]
        public string sUserName { get; set; }

        [StringLength(100)]
        public string ip_address { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }
    }
}
