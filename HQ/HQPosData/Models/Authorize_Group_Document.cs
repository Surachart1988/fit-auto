namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Authorize_Group_Document
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Group_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Doc_id { get; set; }

        [StringLength(10)]
        public string create_per { get; set; }

        [StringLength(10)]
        public string edit_per { get; set; }

        [StringLength(10)]
        public string view_per { get; set; }

        [StringLength(10)]
        public string delete_per { get; set; }

        [StringLength(10)]
        public string approve_per { get; set; }

        [StringLength(10)]
        public string print_per { get; set; }

        [StringLength(10)]
        public string export_per { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
