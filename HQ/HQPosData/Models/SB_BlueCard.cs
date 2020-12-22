namespace HQPosData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SB_BlueCard
    {
        [Key]
        public int card_no_run { get; set; }

        [StringLength(50)]
        public string IDNumber { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CardNumber { get; set; }

        [StringLength(50)]
        public string MID { get; set; }

        [StringLength(50)]
        public string TID { get; set; }

        [StringLength(50)]
        public string ReponseCode { get; set; }

        [StringLength(1000)]
        public string ReponseMSG { get; set; }

        [StringLength(50)]
        public string PointsAvailable { get; set; }

        [StringLength(50)]
        public string PointAccureToday { get; set; }

        [StringLength(50)]
        public string BirthDate { get; set; }

        [StringLength(50)]
        public string CardStatus { get; set; }

        [StringLength(50)]
        public string IntegrationKey { get; set; }

        [StringLength(50)]
        public string MemberStatus { get; set; }

        [StringLength(50)]
        public string PaymentType { get; set; }

        [StringLength(50)]
        public string Redeemedpoints { get; set; }

        [StringLength(50)]
        public string TotalAmount { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string Qantity { get; set; }

        [StringLength(50)]
        public string Discount { get; set; }

        [StringLength(50)]
        public string CouponCode { get; set; }

        [StringLength(50)]
        public string PINCode { get; set; }

        [StringLength(50)]
        public string TransectionID { get; set; }

        [StringLength(50)]
        public string PointsEarnedinTranction { get; set; }

        [StringLength(50)]
        public string PointsEarnedToday { get; set; }
    }
}
