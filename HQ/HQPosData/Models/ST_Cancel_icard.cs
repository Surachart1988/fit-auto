namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Cancel_icard
    {
        public int id { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string branch_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(50)]
        public string register_date { get; set; }

        [StringLength(50)]
        public string expire_date { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(255)]
        public string car_prov_name { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cancel_name { get; set; }

        [StringLength(255)]
        public string other_detail { get; set; }

        [StringLength(50)]
        public string cancel_date { get; set; }

        [StringLength(50)]
        public string cancel_time { get; set; }

        public int? cancel_user_id { get; set; }

        [StringLength(255)]
        public string ip_address { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }

        [StringLength(50)]
        public string last_update { get; set; }
    }
}
