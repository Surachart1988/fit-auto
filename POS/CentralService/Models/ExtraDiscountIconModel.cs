using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Models
{
    public class ExtraDiscountIconModel
    {

        public int Id { get; set; }

        [Display(Name = "ลำดับที่")]
        public int RankNo { get; set; }

        [Display(Name = "รหัส")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "ชื่อ")]
        public string Name { get; set; }

        public string ImgName { get; set; }

        public Nullable<double> Percents { get; set; }

        [Display(Name = "ส่วนลด")]
        public Nullable<double> Baht { get; set; }

        [Display(Name = "กลุ่มสินค้า")]
        public string ProgroupCode { get; set; }

        [Display(Name = "กลุ่มลูกค้า")]
        public string CustypeCode { get; set; }

        [Display(Name = "กลุ่มสินค้า")]
        public string ProgroupName { get; set; }

        [Display(Name = "กลุ่มลูกค้า")]
        public string CustypeName { get; set; }

        [Display(Name = "ต้องใส่รหัสเพื่อเรียกใช้งาน")]
        public Nullable<Boolean> RequestPass { get; set; }

        public string PassDigit { get; set; }

        public string CouponId { get; set; }

        public int pro_group_type_used { get; set; }
    }
}
