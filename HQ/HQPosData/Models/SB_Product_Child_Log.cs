namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Product_Child_Log
    {
        public int id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string log_detail { get; set; }

        [StringLength(120)]
        public string old_root_pro_code { get; set; }

        [StringLength(120)]
        public string old_child_pro_code { get; set; }

        public int? old_child_unit_code { get; set; }

        public double? old_child_qty { get; set; }

        public int? doc_no_run_log { get; set; }

        [StringLength(50)]
        public string log_date { get; set; }

        [StringLength(50)]
        public string log_time { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string add_date { get; set; }

        [StringLength(20)]
        public string add_time { get; set; }

        [StringLength(20)]
        public string edit_date { get; set; }

        [StringLength(20)]
        public string edit_time { get; set; }
    }
}
