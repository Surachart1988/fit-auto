namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Prov_Tambol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tambol_id { get; set; }

        public int tambol_code { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        public int amphur_id { get; set; }

        public int prov_id { get; set; }

        [StringLength(200)]
        public string tambol_name { get; set; }

        public int zone_id { get; set; }

        public string zipcode { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        public string add_date { get; set; }

        public string add_time { get; set; }

        public string edit_date { get; set; }

        public string edit_time { get; set; }
    }
}
