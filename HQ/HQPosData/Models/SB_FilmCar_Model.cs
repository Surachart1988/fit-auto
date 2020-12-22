namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_FilmCar_Model
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        public int? film_gen_id { get; set; }

        [StringLength(50)]
        public string film_code { get; set; }

        public int? film_line_no { get; set; }

        public int? film_car_model_code { get; set; }

        public int? film_car_size_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
