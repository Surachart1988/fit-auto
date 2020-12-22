using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CentralService.Injection
{
    public interface IVehicleModel
    {
        [Display(Name = "ลูกค้า")]
        string CustomerName { get; set; }

        [Display(Name = "เบอร์โทร")]
        string Tel { get; set; }

        [Display(Name = "เบอร์มือถือ")]
        string Mobile { get; set; }

        [Display(Name = "ทะเบียน")]
        string License { get; set; }

        [Display(Name = "จังหวัด")]
        string VehicleProvince { get; set; }

        int? VehicleProvinceId { get; set; }

        [Display(Name = "ยี่ห้อ")]
        string Brand { get; set; }

        [Display(Name = "รุ่น")]
        string Generation { get; set; }

        [Display(Name = "รุ่นย่อย")]
        string SubGeneration { get; set; }

        [Display(Name = "สี")]
        string Color { get; set; }

        [Display(Name = "ประเภท")]
        string VehicleType { get; set; }

        [Display(Name = "เลขไมล์ปัจจุบัน")]
        int? Mileage { get; set; }

        [Display(Name = "เลขไมล์ครั้งก่อน")]
        int? LastMileage { get; set; }

        [Display(Name = "เลขไมล์เฉลี่ย")]
        double AveMileage { get; set; }

        [Display(Name = "ติดต่อครั้งก่อน"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        string LastContdate { get; set; }

        [Display(Name = "วันที่จดทะเบียน")]
        [DataType(DataType.Text), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        DateTime? VehicleRegisterDate { get; set; }

        [Display(Name = "หมายเหตุ")]
        string VehicleNote { get; set; }

        string Chassis { get; set; }
    }
}
