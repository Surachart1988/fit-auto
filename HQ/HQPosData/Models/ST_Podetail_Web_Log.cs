namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Podetail_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? line_no { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? ship_tobranch { get; set; }

        [StringLength(255)]
        public string ship_todate { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? buy_unit_code { get; set; }

        [StringLength(255)]
        public string store_unit { get; set; }

        [StringLength(255)]
        public string tran_unit { get; set; }

        public double? tran_ratio { get; set; }

        public double? tran_qty { get; set; }

        public double? store_qty { get; set; }

        public double? receive_qty { get; set; }

        public double? pro_beforevat { get; set; }

        public double? pro_includevat { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_distot { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(255)]
        public string pro_free { get; set; }

        [StringLength(255)]
        public string pro_close { get; set; }

        [StringLength(255)]
        public string cancel_date { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        public int? po_line { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        [StringLength(255)]
        public string pro_model { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        public double? average_cost { get; set; }

        public double? pro_dis_all { get; set; }

        [StringLength(10)]
        public string cancel_qty { get; set; }

        public int? cancel_user_id { get; set; }

        [StringLength(20)]
        public string cancel_qty_date { get; set; }

        [StringLength(20)]
        public string cancel_qty_time { get; set; }

        [StringLength(255)]
        public string cancel_memo { get; set; }

        [StringLength(50)]
        public string web_log_dealercode { get; set; }

        public int? web_log_user_id { get; set; }

        [StringLength(255)]
        public string web_log_date { get; set; }

        [StringLength(255)]
        public string web_log_time { get; set; }

        public int? web_log_flag_send { get; set; }

        [StringLength(255)]
        public string web_log_message { get; set; }
    }
}
