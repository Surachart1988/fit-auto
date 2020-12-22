namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_DayEnd_Head
    {
        [Key]
        public int de_id { get; set; }

        [StringLength(640)]
        public string branch_no { get; set; }

        [StringLength(320)]
        public string doc_code { get; set; }

        [StringLength(640)]
        public string doc_no { get; set; }

        [StringLength(640)]
        public string doc_date { get; set; }

        public int? date_report { get; set; }

        [StringLength(320)]
        public string doc_time { get; set; }

        public int? emp_id { get; set; }

        public int? bill_1000 { get; set; }

        public int? bill_500 { get; set; }

        public int? bill_100 { get; set; }

        public int? bill_50 { get; set; }

        public int? bill_20 { get; set; }

        public int? bill_10 { get; set; }

        public int? bill_5 { get; set; }

        public int? bill_2 { get; set; }

        public int? bill_1 { get; set; }

        public int? bill_050 { get; set; }

        public int? bill_025 { get; set; }

        public double? billtotal_1000 { get; set; }

        public double? billtotal_500 { get; set; }

        public double? billtotal_100 { get; set; }

        public double? billtotal_50 { get; set; }

        public double? billtotal_20 { get; set; }

        public double? billtotal_10 { get; set; }

        public double? billtotal_5 { get; set; }

        public double? billtotal_2 { get; set; }

        public double? billtotal_1 { get; set; }

        public double? billtotal_050 { get; set; }

        public double? billtotal_025 { get; set; }

        public double? billtotal_card { get; set; }

        public double? billtotal_chq { get; set; }

        public double? billtotal_banktrans { get; set; }

        public double? billtotal_all { get; set; }

        [StringLength(640)]
        public string doc_date_start { get; set; }

        [StringLength(640)]
        public string doc_date_end { get; set; }

        public int? doc_date_start_cal { get; set; }

        public int? doc_date_end_cal { get; set; }

        [StringLength(4000)]
        public string rec_memo { get; set; }
    }
}
