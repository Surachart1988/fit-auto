namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Cash_Drawer
    {
        [Key]
        [StringLength(15)]
        public string Cash_Drawer_Code { get; set; }

        [StringLength(50)]
        public string bankacc_code { get; set; }

        [StringLength(10)]
        public string Cash_Drawer_Date { get; set; }

        [StringLength(10)]
        public string Cash_Drawer_Time { get; set; }

        [StringLength(50)]
        public string DealerCode { get; set; }

        [StringLength(10)]
        public string SempNo { get; set; }

        public double? Cash_Drawer_Balace { get; set; }

        public int? Cash_Drawer_Type_ID { get; set; }

        [StringLength(150)]
        public string Cash_Drawer_Detail { get; set; }

        [StringLength(50)]
        public string Cash_Drawer_Doc_Ref { get; set; }

        public double? Cash_Drawer_Amount { get; set; }

        [StringLength(255)]
        public string Cash_Drawer_Remark { get; set; }
    }
}
