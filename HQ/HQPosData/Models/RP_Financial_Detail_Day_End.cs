namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RP_Financial_Detail_Day_End
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_type { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? line_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(50)]
        public string progroup_code { get; set; }

        public int? pro_brand_code { get; set; }

        public int? pro_model_code { get; set; }

        public int? pro_size_code { get; set; }

        public int? sale_unit_code { get; set; }

        public int? locat_code { get; set; }

        public double? tran_qty { get; set; }

        [StringLength(10)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_amt { get; set; }

        public double? vat_amt { get; set; }

        public double? pro_includevat { get; set; }

        public double? pro_avgcost { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        public int? io_by { get; set; }

        public int? DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
