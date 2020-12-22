namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CarGlass_Temp
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string car_reg { get; set; }

        public int? car_provid { get; set; }

        [StringLength(120)]
        public string main_pro_code { get; set; }

        [StringLength(120)]
        public string sub_pro_code { get; set; }

        public int? unit_buy { get; set; }

        public int? num_of_services { get; set; }

        [StringLength(50)]
        public string doc_no_buy { get; set; }

        [StringLength(50)]
        public string doc_no_used { get; set; }

        [StringLength(50)]
        public string date_buy { get; set; }

        [StringLength(50)]
        public string time_buy { get; set; }

        [StringLength(50)]
        public string start_date { get; set; }

        [StringLength(50)]
        public string expire_date { get; set; }

        [StringLength(50)]
        public string day_used { get; set; }

        [StringLength(50)]
        public string date_used { get; set; }

        [StringLength(50)]
        public string time_used { get; set; }

        public int? date_buy_report { get; set; }

        public int? start_date_report { get; set; }

        public int? expire_date_report { get; set; }

        public int? date_used_report { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
