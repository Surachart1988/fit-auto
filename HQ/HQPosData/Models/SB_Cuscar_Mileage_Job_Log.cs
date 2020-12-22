namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Cuscar_Mileage_Job_Log
    {
        [Key]
        public int log_id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        public int? car_provid { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        public int? car_doc_no_run { get; set; }

        [StringLength(50)]
        public string job_doc_no { get; set; }

        public int? car_bmileage_old { get; set; }

        public int? car_bmileage_new { get; set; }

        public int? car_mileage_old { get; set; }

        public int? car_mileage_new { get; set; }

        [StringLength(20)]
        public string log_date { get; set; }

        [StringLength(20)]
        public string log_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
