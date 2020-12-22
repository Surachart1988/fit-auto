namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Jobdetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Line_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(255)]
        public string cus_type { get; set; }

        [StringLength(255)]
        public string cus_paytype { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string car_registration { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(255)]
        public string store_unit { get; set; }

        [StringLength(255)]
        public string tran_unit { get; set; }

        public double? tran_ratio { get; set; }

        public int? sale_unit_code { get; set; }

        public int? locat_code { get; set; }

        [StringLength(255)]
        public string location_code { get; set; }

        [StringLength(255)]
        public string io_by { get; set; }

        public double? tran_qty { get; set; }

        public double? store_qty { get; set; }

        public double? receive_qty { get; set; }

        public double? pro_costamt { get; set; }

        public double? pro_nincludevat { get; set; }

        public double? pro_price { get; set; }

        public double? pro_amtlasted { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(255)]
        public string bill_start { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [StringLength(255)]
        public string pm_code { get; set; }

        [StringLength(255)]
        public string io_type { get; set; }

        public int? ref_branchno { get; set; }

        [StringLength(255)]
        public string ref_doccode { get; set; }

        [StringLength(255)]
        public string ref_dono { get; set; }

        public double? vat_rate { get; set; }

        [StringLength(255)]
        public string date_services { get; set; }

        public double? CAR_NEXTMILEAGE { get; set; }

        public double? pro_avg_vat { get; set; }

        public double? pro_avg_novat { get; set; }

        [StringLength(10)]
        public string flag_mobile { get; set; }

        public double? pro_dis_all { get; set; }

        public int? bill_position { get; set; }

        [StringLength(50)]
        public string bill_create { get; set; }

        [StringLength(10)]
        public string film_code { get; set; }

        [StringLength(10)]
        public string film_position_code { get; set; }

        public double? pro_add_all { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(10)]
        public string FLAG_NET { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }
    }
}
