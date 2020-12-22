using CentralService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IProductListModel
    {
        List<ProductModel> Products { get; set; }

        [Display(Name = "ส่วนลดรวม")]
        double TotalDiscount { get; set; }

        [Display(Name = "ส่วนลดท้ายบิล")]
        double? LastDiscount { get; set; }

        [Display(Name = "ส่วนลดท้ายบิล")]
        double? LastDiscountPer { get; set; }

        [Display(Name = "รวมเงิน")]
        double TotalPrice { get; set; }

        [Display(Name = "ภาษีมูลค่าเพิ่ม")]
        double TaxPrice { get; set; }

        [Display(Name = "รวมยอดสุทธิ")]
        double Amount { get; set; }

        [Display(Name = "หมายเหตุ")]
        string Note { get; set; }

        [Display(Name = "เหตุผล")]
        string Reason { get; set; }

    }
}
