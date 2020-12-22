namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_meeting
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MEETING_ID { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        [StringLength(255)]
        public string time { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [StringLength(255)]
        public string head { get; set; }

        [StringLength(255)]
        public string detail { get; set; }

        [StringLength(255)]
        public string MEETING_STATUS { get; set; }

        [StringLength(255)]
        public string DATE2 { get; set; }

        [StringLength(255)]
        public string TIME2 { get; set; }

        public double? DATE_REPORT { get; set; }

        [StringLength(255)]
        public string car_chasis { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
