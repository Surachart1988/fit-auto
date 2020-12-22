namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Time_Sell_Product
    {
        public int id { get; set; }

        [StringLength(50)]
        public string pro_product_code { get; set; }

        [StringLength(50)]
        public string pro_product_group_code { get; set; }

        [StringLength(50)]
        public string pro_sell_week { get; set; }

        [StringLength(50)]
        public string pro_sell_day { get; set; }

        public TimeSpan? pro_sell_time_start { get; set; }

        public TimeSpan? pro_sell_time_end { get; set; }

        [StringLength(50)]
        public string probrand { get; set; }

        [StringLength(50)]
        public string promodel { get; set; }

        public int? SendClient { get; set; }
    }
}
