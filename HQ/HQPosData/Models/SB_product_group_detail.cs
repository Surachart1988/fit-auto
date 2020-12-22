namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_product_group_detail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string pro_group_code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        public int? pro_qty { get; set; }

        public double? pro_price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOC_NO_RUN { get; set; }

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
    }
}
