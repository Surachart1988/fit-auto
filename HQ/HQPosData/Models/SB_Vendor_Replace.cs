namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Vendor_Replace
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(120)]
        public string ven_code_old { get; set; }

        [StringLength(120)]
        public string ven_code_new { get; set; }

        [StringLength(50)]
        public string transfer_option { get; set; }

        [StringLength(50)]
        public string sUserName { get; set; }

        [StringLength(100)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string doc_date { get; set; }

        [StringLength(50)]
        public string doc_time { get; set; }

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
