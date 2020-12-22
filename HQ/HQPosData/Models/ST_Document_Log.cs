namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Document_Log
    {
        public int id { get; set; }

        [StringLength(20)]
        public string dealercode { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(20)]
        public string doc_status { get; set; }

        public int? print_no { get; set; }

        [StringLength(20)]
        public string log_date { get; set; }

        [StringLength(20)]
        public string log_time { get; set; }

        public int? user_id { get; set; }

        [StringLength(100)]
        public string ip_address { get; set; }
    }
}
