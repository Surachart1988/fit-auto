namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CommVariable_OnProfit_JobDetail
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        public int? user_id { get; set; }

        public int? type_of_cal_id { get; set; }

        public int? type_emp_id { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        public double? percent_rate { get; set; }

        [StringLength(20)]
        public string ref_docno { get; set; }

        [StringLength(20)]
        public string ref_doc_date { get; set; }

        public double? pro_price { get; set; }

        public double? store_qty { get; set; }

        public double? comm_totalamt_emp { get; set; }

        public double? comm_percent_emp { get; set; }

        public double? comm_totalamt { get; set; }

        public int? add_user_id { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
