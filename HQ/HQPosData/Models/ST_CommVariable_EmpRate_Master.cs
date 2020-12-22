namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CommVariable_EmpRate_Master
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        public int? user_id { get; set; }

        public int? type_emp_id { get; set; }

        public double? percent_rate { get; set; }

        [StringLength(20)]
        public string update_date { get; set; }

        [StringLength(20)]
        public string update_time { get; set; }

        public int? type_of_cal_id { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}