namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_Dealercode_Master
    {
        [Key]
        [StringLength(50)]
        public string dealercode { get; set; }

        [StringLength(500)]
        public string DealerName { get; set; }

        [StringLength(50)]
        public string Dealertype { get; set; }

        [StringLength(50)]
        public string ip_address { get; set; }

        [StringLength(50)]
        public string ip_address_pub { get; set; }

        [StringLength(500)]
        public string http_path { get; set; }

        public int? salezone_id { get; set; }

        public int? salegroup_id { get; set; }

        [StringLength(20)]
        public string branch_no { get; set; }

        [StringLength(250)]
        public string http_client_webservices { get; set; }

        [StringLength(10)]
        public string flag_used { get; set; }

        public int? Product_SendClient { get; set; }

        public int? Customer_SendClient { get; set; }

        public int? Vendor_SendClient { get; set; }

        public int? Proprice_SendClient { get; set; }

        public int? HRUser_SendClient { get; set; }

        public int? Progroup_SendClient { get; set; }

        public int? Probrand_SendClient { get; set; }

        public int? Promodel_SendClient { get; set; }

        public int? Prosize_SendClient { get; set; }

        public int? Location_SendClient { get; set; }

        public int? Location_Dot_SendClient { get; set; }

        public int? Priceown_SendClient { get; set; }

        public int? ProTypeUsed_SendClient { get; set; }

        public int? Cartype_SendClient { get; set; }

        public int? Carbrand_SendClient { get; set; }

        public int? Carmodel_SendClient { get; set; }

        public int? Unitname_SendClient { get; set; }

        public int? CarColor_SendClient { get; set; }

        public int? Autocheck_SendClient { get; set; }

        public int? Custype_SendClient { get; set; }

        public int? Busstype_SendClient { get; set; }

        public int? Contentup_SendClient { get; set; }

        public int? Vote_SendClient { get; set; }

        public int? Day3_SendClient { get; set; }

        public int? Question_SendClient { get; set; }

        public int? JobStatus_SendClient { get; set; }

        public int? Textreport_SendClient { get; set; }

        public int? Bank_SendClient { get; set; }

        public int? Cardtype_SendClient { get; set; }

        public int? Paytype_SendClient { get; set; }

        public int? Installment_SendClient { get; set; }

        public int? Bvat_SendClient { get; set; }

        public int? Svat_SendClient { get; set; }

        public int? TaxCondition_SendClient { get; set; }

        public int? Taxtype_SendClient { get; set; }

        public int? Taxmoney_SendClient { get; set; }

        public int? Taxincome_SendClient { get; set; }

        public int? Taxincomerate_SendClient { get; set; }

        public int? Authengroup_SendClient { get; set; }

        public int? Company_SendClient { get; set; }

        public int? Proset_SendClient { get; set; }

        public int? Checklist_SendClient { get; set; }

        public int? Promotion_SendClient { get; set; }

        public int? CarGear_SendClient { get; set; }

        public int? ExtraDiscount_SendClient { get; set; }
    }
}
