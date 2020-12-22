namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_product_group
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string branch_no { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string pro_group_code { get; set; }

        [StringLength(255)]
        public string pro_group_name { get; set; }

        [StringLength(255)]
        public string pro_group_type { get; set; }

        [StringLength(255)]
        public string priceown_code { get; set; }

        [StringLength(255)]
        public string pro_group_date { get; set; }

        public double? pro_group_price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DOC_NO_RUN { get; set; }

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
