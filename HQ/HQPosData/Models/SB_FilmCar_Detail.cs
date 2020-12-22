namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_FilmCar_Detail
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        public int? film_gen_id { get; set; }

        [StringLength(50)]
        public string film_code { get; set; }

        [StringLength(120)]
        public string film_pro_code { get; set; }

        public int? film_line_no { get; set; }

        public double? film_pro_price { get; set; }

        public double? film_pro_distot { get; set; }

        public double? film_pro_incretot { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
