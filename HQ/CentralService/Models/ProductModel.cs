using CentralService.Enums;
using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Models
{
    public class ProductModel
    {

        public int Id { get; set; }

        [Display(Name = "รหัสสินค้า")]
        public string Code { get; set; }

        [Display(Name = "รหัสผู้ผลิต")]
        public string ProducerCode { get; set; }

        [Display(Name = "ชื่อสินค้า")]
        public string Name { get; set; }

        [Display(Name = "ชื่อสินค้า2")]
        public string Name2 { get; set; }

        [Display(Name = "ที่ตั้ง")]
        public string Address { get; set; }

        [Display(Name = "หน่วย")]
        public int Unit { get; set; }

        [Display(Name = "จำนวน")]
        public double? Number { get; set; }

        [Display(Name = "ราคา")]
        public double? Price { get; set; }

        [Display(Name = "จำนวนเงิน")]
        public double? Amount { get; set; }

        [Display(Name = "ลดเงิน")]
        public double? DiscountAmount { get; set; }

        [Display(Name = "ลด %")]
        public double? Discount1 { get; set; }

        [Display(Name = "ลด %2")]
        public double? Discount2 { get; set; }

        [Display(Name = "ภาษี")]
        public double? Tax { get; set; }

        [Display(Name = "ประเภทสินค้า")]
        public string Type { get; set; }

        [Display(Name = "ยี่ห้อสินค้า")]
        public string Brand { get; set; }

        [Display(Name = "รุ่นสินค้า")]
        public string Gen { get; set; }

        [Display(Name = "ขนาดสินค้า")]
        public string Size { get; set; }

        [Display(Name = "ที่เก็บ")]
        public int? Store { get; set; }

        [Display(Name = "ที่เก็บ")]
        public string StoreName { get; set; }

        [Display(Name = "รหัสพนักงาน")]
        public virtual string StaffCode { get; set; }

        [Display(Name = "ชื่อพนักงาน")]
        public virtual string StaffName { get; set; }

        #region Stock manage

        [Display(Name = "ในสต็อก")]
        public double? StockCurrent { get; set; }

        [Display(Name = "นับได้")]
        public double? StockReal { get; set; }

        [Display(Name = "จำนวนที่ปรับ")]
        public double? StockDiffrent { get; set; }

        [Display(Name = "เหตุผล")]
        public string Reason { get; set; }

        #endregion

        #region Po

        [Display(Name = "ที่ได้รับแล้ว")]
        public double? PoNumber { get; set; }

        [Display(Name = "ที่รับ")]
        public double? PrNumber { get; set; }

        #endregion

        #region ReValue

        [Display(Name = "ราคาใหม่")]
        public double? RePrice { get; set; }

        [Display(Name = "ราคาที่ปรับ")]
        public double? AdjustablePrice { get; set; }

        #endregion
    }

    public class ProductIsValid
    {
        public string StoreIsValid { get; set; }

        public string NumberIsValid { get; set; }
    }
}
