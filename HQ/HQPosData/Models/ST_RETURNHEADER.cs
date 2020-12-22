namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_RETURNHEADER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_no2 { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(10)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string car_reg { get; set; }

        [StringLength(50)]
        public string car_prov_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [Column(TypeName = "ntext")]
        public string comment { get; set; }

        [StringLength(50)]
        public string roadside { get; set; }

        [StringLength(10)]
        public string warranty_date { get; set; }

        [StringLength(50)]
        public string warranty_axa_id { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(10)]
        public string doc_close { get; set; }

        [StringLength(10)]
        public string doc_cancel { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }

        [StringLength(255)]
        public string car_mileage { get; set; }

        [StringLength(255)]
        public string warranty_mileage { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        public int? record_total { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(20)]
        public string doc_candate { get; set; }

        [StringLength(255)]
        public string doc_canmemo { get; set; }
    }
}
