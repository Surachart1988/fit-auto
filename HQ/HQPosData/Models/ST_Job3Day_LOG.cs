namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Job3Day_LOG
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Branch_no { get; set; }

        [StringLength(50)]
        public string Doc_no { get; set; }

        [StringLength(50)]
        public string Doc_Date { get; set; }

        [StringLength(50)]
        public string Doc_Time { get; set; }

        [StringLength(500)]
        public string Call_Memo { get; set; }

        [StringLength(100)]
        public string Call_Status { get; set; }

        [StringLength(50)]
        public string Call_Point { get; set; }

        [StringLength(50)]
        public string Miss_Call_Num { get; set; }

        [StringLength(50)]
        public string Call_Date { get; set; }

        [StringLength(50)]
        public string Call_Time { get; set; }

        [StringLength(50)]
        public string Call_User { get; set; }

        public int? Call_UserID { get; set; }

        [StringLength(50)]
        public string Call_IP { get; set; }

        public int? Call_DATE_REPORT { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
