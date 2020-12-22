namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Services
    {
        [Key]
        public int DOC_NO_RUN { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(10)]
        public string car_reg { get; set; }

        [StringLength(80)]
        public string cus_code { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string prosub_code { get; set; }

        [StringLength(255)]
        public string pro_tname { get; set; }

        [StringLength(255)]
        public string prosub_name { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        public double? km_per_day { get; set; }

        [StringLength(255)]
        public string date_services { get; set; }

        [StringLength(255)]
        public string FLAG_USED { get; set; }

        [StringLength(255)]
        public string REF_DOCNO { get; set; }

        public double? NUM_ZIGZAG { get; set; }

        public double? CAR_NEXTMILE { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string Dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }
    }
}
