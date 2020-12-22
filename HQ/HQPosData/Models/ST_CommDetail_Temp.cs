namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_CommDetail_Temp
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(20)]
        public string doc_no { get; set; }

        public int? user_id { get; set; }

        public int? type_commission_id { get; set; }

        public double? work_rate { get; set; }

        public double? day_of_work { get; set; }

        public double? total_rate { get; set; }

        public double? ot_rate { get; set; }

        public double? hour_of_ot { get; set; }

        public double? total_ot { get; set; }

        public double? special_rate { get; set; }

        public double? day_of_special { get; set; }

        public double? total_special { get; set; }

        public double? incentive_rate { get; set; }

        public double? bonus_rate { get; set; }

        public double? other_rate { get; set; }

        public double? total_rate_all { get; set; }

        public double? total_comm_all { get; set; }

        public int? add_user_id { get; set; }

        public double? sub_incentive { get; set; }

        public double? sub_claim { get; set; }

        public double? sub_social_insurance { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
