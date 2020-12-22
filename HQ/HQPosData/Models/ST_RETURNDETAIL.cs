namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_RETURNDETAIL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string serial_no { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int line_no { get; set; }

        [StringLength(10)]
        public string doc_code { get; set; }

        [StringLength(10)]
        public string doc_date { get; set; }

        [StringLength(10)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(150)]
        public string pro_name { get; set; }

        public double? store_qty { get; set; }

        [StringLength(10)]
        public string claim_date { get; set; }

        [StringLength(10)]
        public string clear_date { get; set; }

        [StringLength(255)]
        public string due_date { get; set; }

        public double? claim_date_report { get; set; }

        public double? clear_date_report { get; set; }

        public double? due_date_report { get; set; }

        [Column(TypeName = "ntext")]
        public string rec_memo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string flag_net { get; set; }

        [StringLength(255)]
        public string tyre_position { get; set; }

        [StringLength(255)]
        public string rec_detail { get; set; }

        [StringLength(255)]
        public string rec_other_detail { get; set; }

        [StringLength(255)]
        public string lost_detail { get; set; }

        [StringLength(255)]
        public string lost_other_detail { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(255)]
        public string Branch_name { get; set; }

        [StringLength(50)]
        public string icard_id { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(50)]
        public string vendor_date { get; set; }

        public int? vendor_date_report { get; set; }

        [StringLength(50)]
        public string claim_close_date { get; set; }

        public int? claim_close_date_report { get; set; }

        [StringLength(50)]
        public string claim_result { get; set; }

        [StringLength(2000)]
        public string claim_detail { get; set; }
    }
}
