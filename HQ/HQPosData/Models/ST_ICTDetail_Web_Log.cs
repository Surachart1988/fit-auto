namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_ICTDetail_Web_Log
    {
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public int? line_no { get; set; }

        [Key]
        public int doc_no_run { get; set; }

        public int? locat_code_to { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        public int? po_line { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? sale_unit_code { get; set; }

        [StringLength(255)]
        public string store_unit { get; set; }

        [StringLength(255)]
        public string tran_unit { get; set; }

        [StringLength(255)]
        public string tran_ration { get; set; }

        public int? locat_code_from { get; set; }

        public int? locat_code { get; set; }

        [StringLength(255)]
        public string location_code { get; set; }

        public double? pro_qoh { get; set; }

        public double? tran_qty { get; set; }

        public double? store_qty { get; set; }

        public double? receive_qty { get; set; }

        public double? pro_beforevat { get; set; }

        public double? pro_incluludevat { get; set; }

        public double? pro_price { get; set; }

        public double? pro_disamt { get; set; }

        public double? pro_disp1 { get; set; }

        public double? pro_disp2 { get; set; }

        public double? pro_distotamt { get; set; }

        public double? pro_amt { get; set; }

        [StringLength(255)]
        public string pro_free { get; set; }

        [StringLength(50)]
        public string doc_close { get; set; }

        [StringLength(50)]
        public string doc_cancel { get; set; }

        [StringLength(255)]
        public string doc_candate { get; set; }

        [StringLength(255)]
        public string rec_memo { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(255)]
        public string progroup_code { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        [StringLength(255)]
        public string pro_model { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(50)]
        public string web_log_send_to { get; set; }

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
