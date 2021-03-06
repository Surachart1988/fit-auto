namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Tax_Income_Rate
    {
        [Key]
        public int tax_income_rate_id { get; set; }

        [StringLength(500)]
        public string tax_income_rate_name { get; set; }

        public int? tax_income_id { get; set; }

        public int? tax_type_id { get; set; }

        public double? tax_income_rate_num { get; set; }

        [StringLength(10)]
        public string flag_used { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }

        public int? SendClient { get; set; }
    }
}
