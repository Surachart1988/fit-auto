namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_FilmCar_Header
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        public int? film_gen_id { get; set; }

        [StringLength(50)]
        public string film_typesale { get; set; }

        [StringLength(50)]
        public string film_code { get; set; }

        [StringLength(255)]
        public string film_name { get; set; }

        [StringLength(50)]
        public string film_startdate { get; set; }

        [StringLength(50)]
        public string film_enddate { get; set; }

        [StringLength(50)]
        public string film_cancel { get; set; }

        [StringLength(120)]
        public string film_main_pro_code { get; set; }

        public double? film_main_pro_price { get; set; }

        public int? film_startdate_report { get; set; }

        public int? film_enddate_report { get; set; }

        [StringLength(50)]
        public string film_add_date { get; set; }

        [StringLength(50)]
        public string film_add_time { get; set; }

        [StringLength(50)]
        public string film_edit_date { get; set; }

        [StringLength(50)]
        public string film_edit_time { get; set; }

        public int? film_user_add { get; set; }

        public int? film_user_edit { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
