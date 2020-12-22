namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_Claim_Online
    {
        public int id { get; set; }

        [StringLength(255)]
        public string icard_id { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        [StringLength(255)]
        public string car_prov_name { get; set; }

        [StringLength(255)]
        public string car_brand_name { get; set; }

        [StringLength(255)]
        public string car_model_name { get; set; }

        [StringLength(255)]
        public string car_color { get; set; }

        [StringLength(255)]
        public string pre_name { get; set; }

        [StringLength(255)]
        public string cus_name { get; set; }

        [StringLength(255)]
        public string add_name { get; set; }

        [StringLength(255)]
        public string add_no { get; set; }

        [StringLength(255)]
        public string add_moo { get; set; }

        [StringLength(255)]
        public string add_trog { get; set; }

        [StringLength(255)]
        public string add_soi { get; set; }

        [StringLength(255)]
        public string add_road { get; set; }

        [StringLength(255)]
        public string add_tambol { get; set; }

        [StringLength(255)]
        public string add_amphur { get; set; }

        [StringLength(255)]
        public string add_provname { get; set; }

        [StringLength(255)]
        public string add_zip { get; set; }

        [StringLength(255)]
        public string add_tel { get; set; }

        [StringLength(255)]
        public string pro_name { get; set; }

        [StringLength(255)]
        public string pro_serial1 { get; set; }

        [StringLength(255)]
        public string pro_serial2 { get; set; }

        [StringLength(255)]
        public string pro_serial3 { get; set; }

        [StringLength(255)]
        public string pro_serial4 { get; set; }

        [StringLength(255)]
        public string pro_serial5 { get; set; }

        [StringLength(255)]
        public string void_no { get; set; }

        [StringLength(255)]
        public string warranty_date { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }
    }
}
