namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_AbbTemp
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(20)]
        public string doc_date { get; set; }

        [StringLength(20)]
        public string doc_time { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? line_no { get; set; }

        [StringLength(20)]
        public string cus_type { get; set; }

        [StringLength(20)]
        public string cus_paytype { get; set; }

        [StringLength(20)]
        public string cus_code { get; set; }

        [StringLength(120)]
        public string car_reg { get; set; }

        public int? car_mileage { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? sale_unit_code { get; set; }

        [StringLength(120)]
        public string store_unit { get; set; }

        [StringLength(120)]
        public string tran_unit { get; set; }

        public int? tran_ratio { get; set; }

        public int? locat_code { get; set; }

        [StringLength(120)]
        public string location_code { get; set; }

        [StringLength(255)]
        public string io_by { get; set; }

        [StringLength(50)]
        public string tax_invabb { get; set; }

        public double? tran_qty { get; set; }

        public double? store_qty { get; set; }

        public double? receive_qty { get; set; }

        public double? pro_costamt { get; set; }

        public double? pro_includevat { get; set; }

        public double? pro_vat { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(10)]
        public string doc_close { get; set; }

        [StringLength(10)]
        public string doc_cancel { get; set; }

        [StringLength(500)]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        [StringLength(255)]
        public string pro_model { get; set; }

        [StringLength(50)]
        public string pm_code { get; set; }

        [StringLength(50)]
        public string io_type { get; set; }

        [StringLength(50)]
        public string emp_code { get; set; }

        public double? vat_rate { get; set; }

        [StringLength(50)]
        public string ps_code { get; set; }

        public double? pro_dis_all { get; set; }

        [StringLength(50)]
        public string film_code { get; set; }

        [StringLength(50)]
        public string film_position_code { get; set; }

        public double? pro_add_all { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
