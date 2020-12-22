namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_ExtraDiscount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double? Percents { get; set; }

        [StringLength(10)]
        public string ProgroupCode { get; set; }

        [StringLength(10)]
        public string CustypeCode { get; set; }

        public int? RankNo { get; set; }

        public double? Baht { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public bool SendClient { get; set; }

        public bool IsDelete { get; set; }
    }
}
