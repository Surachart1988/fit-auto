namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_FilmCarModel
    {
        [Key]
        [Column(Order = 0)]
        public int doc_no_run { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int car_model_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int position_code { get; set; }

        public double? position_qty { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string edit_date { get; set; }

        [StringLength(50)]
        public string edit_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
