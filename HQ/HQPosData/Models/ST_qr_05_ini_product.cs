namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_qr_05_ini_product
    {
        [Key]
        public long doc_no_run { get; set; }

        [StringLength(50)]
        public string branch_no { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string ven_code { get; set; }

        [StringLength(120)]
        public string pro_code { get; set; }

        [StringLength(10)]
        public string vat_type { get; set; }

        public double? vat_rate { get; set; }

        public double? store_qty { get; set; }

        public double? pro_price { get; set; }

        public double? pro_price_vat { get; set; }

        public double? pro_price_before_vat { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
