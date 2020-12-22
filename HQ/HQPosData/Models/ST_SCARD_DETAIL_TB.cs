namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_SCARD_DETAIL_TB
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string DealerCode { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(255)]
        public string Branch_Name { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(255)]
        public string car_reg { get; set; }

        public double? car_mileage { get; set; }

        [StringLength(255)]
        public string date_card { get; set; }

        [StringLength(255)]
        public string time_card { get; set; }

        [StringLength(255)]
        public string scard_group { get; set; }

        [StringLength(255)]
        public string progroup_name { get; set; }

        [StringLength(255)]
        public string pro_tname { get; set; }

        [StringLength(255)]
        public string pro_brand { get; set; }

        public double? qty { get; set; }

        public double? price { get; set; }

        public double? point { get; set; }

        [StringLength(255)]
        public string next_date { get; set; }

        public double? car_nextmile { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(255)]
        public string PRO_CODE { get; set; }

        [StringLength(255)]
        public string FLAG_NET { get; set; }

        [StringLength(255)]
        public string prosub_code { get; set; }

        [StringLength(255)]
        public string flag_used { get; set; }

        public int? num_zigzag { get; set; }

        [StringLength(255)]
        public string loan_bank { get; set; }

        [StringLength(255)]
        public string loan_month { get; set; }

        [StringLength(50)]
        public string TB_Status { get; set; }

        [StringLength(50)]
        public string EU_Status { get; set; }

        public double? EU_Point { get; set; }

        [StringLength(50)]
        public string TOP_Status { get; set; }

        public double? TOP_Point { get; set; }

        [StringLength(10)]
        public string flag_net_tb { get; set; }

        [StringLength(50)]
        public string Last_Update { get; set; }

        [StringLength(255)]
        public string pro_ven_code { get; set; }

        [StringLength(255)]
        public string pro_model_name { get; set; }

        [StringLength(255)]
        public string pro_size_name { get; set; }

        [StringLength(255)]
        public string car_prov_name { get; set; }

        [StringLength(255)]
        public string icard_id { get; set; }
    }
}
