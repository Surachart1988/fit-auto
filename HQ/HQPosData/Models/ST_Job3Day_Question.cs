namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Job3Day_Question
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

        public int? Question_choice_id { get; set; }

        [StringLength(500)]
        public string Question_choice_value { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(255)]
        public string add_time { get; set; }

        public int? Question_UserID { get; set; }

        [StringLength(255)]
        public string Question_IP { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
