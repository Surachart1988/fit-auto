using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class CustomerVehicleModel : IVehicleModel
    {
        public string CustomerName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string License { get; set; }
        public string VehicleProvince { get; set; }
        public int? VehicleProvinceId { get; set; }
        public string Brand { get; set; }
        public string Generation { get; set; }
        public string SubGeneration { get; set; }
        public string Color { get; set; }
        public string VehicleType { get; set; }
        public int? Mileage { get; set; }
        public int? LastMileage { get; set; }
        public double AveMileage { get; set; }
        public string LastContdate { get; set; }
        public DateTime? VehicleRegisterDate { get; set; }
        public string VehicleNote { get; set; }
        public string MemberId { get; set; }
        public string Chassis { get; set; }

        public string TypeName { get; set; }
        public string CustomerCode { get; set; }
        public string BlueCard { get; set; }
    }
}
