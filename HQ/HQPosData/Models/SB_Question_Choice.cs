namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Question_Choice
    {
        [Key]
        public int question_choice_id { get; set; }

        public int? question_detail_id { get; set; }

        [StringLength(500)]
        public string question_choice { get; set; }

        [StringLength(255)]
        public string question_choice_name { get; set; }

        [StringLength(255)]
        public string question_choice_type { get; set; }

        [StringLength(255)]
        public string question_choice_value { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
