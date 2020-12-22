namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ST_PayCard_Log
    {
        [Key]
        public int doc_no_run { get; set; }

        [StringLength(10)]
        public string branch_no { get; set; }

        [StringLength(15)]
        public string type_trans { get; set; }

        [StringLength(50)]
        public string doc_no { get; set; }

        [StringLength(50)]
        public string temp_doc_no { get; set; }

        [StringLength(50)]
        public string doc_code { get; set; }

        [StringLength(50)]
        public string cus_code { get; set; }

        [StringLength(50)]
        public string Response_Text { get; set; }

        [StringLength(100)]
        public string Merchant_name_and_Address { get; set; }

        [StringLength(10)]
        public string Transaction_Date { get; set; }

        [StringLength(10)]
        public string Transaction_Time { get; set; }

        [StringLength(10)]
        public string Approval_Code { get; set; }

        [StringLength(10)]
        public string Invoice_Number { get; set; }

        [StringLength(10)]
        public string Terminal_ID { get; set; }

        [StringLength(20)]
        public string Merchant_ID { get; set; }

        [StringLength(20)]
        public string Card_Issuer_Name { get; set; }

        [StringLength(20)]
        public string Card_Number { get; set; }

        [StringLength(10)]
        public string Card_Expiry_Date { get; set; }

        [StringLength(10)]
        public string Batch_Number { get; set; }

        [StringLength(20)]
        public string Reference_Number { get; set; }

        [StringLength(10)]
        public string Card_Issuer_ID { get; set; }

        [StringLength(50)]
        public string Card_Holder_Name { get; set; }

        [StringLength(20)]
        public string Amount { get; set; }

        [StringLength(20)]
        public string Redeem_Point { get; set; }

        [StringLength(20)]
        public string Redeem_Amount { get; set; }

        [StringLength(20)]
        public string Redeem_Point_Balance { get; set; }

        [StringLength(50)]
        public string Customer_Name { get; set; }

        [StringLength(100)]
        public string Customer_Address { get; set; }

        [StringLength(20)]
        public string Customer_TAX_ID { get; set; }

        [StringLength(10)]
        public string Customer_Branch_Number { get; set; }

        [StringLength(20)]
        public string Customer_Car_License { get; set; }

        [StringLength(50)]
        public string TI { get; set; }

        [StringLength(20)]
        public string PTT_Blue_Card_Number { get; set; }

        public int? add_user_id { get; set; }

        [StringLength(50)]
        public string add_date { get; set; }

        [StringLength(50)]
        public string add_time { get; set; }

        [StringLength(200)]
        public string ip_address { get; set; }

        [StringLength(10)]
        public string flag_settlement { get; set; }

        public int? settlement_user_id { get; set; }

        [StringLength(20)]
        public string settlement_date { get; set; }

        [StringLength(20)]
        public string settiement_time { get; set; }

        [StringLength(50)]
        public string dealercode { get; set; }
    }
}
