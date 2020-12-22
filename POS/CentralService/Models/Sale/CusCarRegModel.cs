using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models.Sale
{
    public class CusCarRegModel
    {
        public string car_reg { get; set; }
        public string cus_code { get; set; }
        public int car_provid { get; set; }
        public int car_brand_code { get; set; }
        public int car_model_code { get; set; }
        public string car_color { get; set; }
        public string car_chasis { get; set; }
        public string icard_id { get; set; }
        public string first_contdate { get; set; }
        public string last_contdate { get; set; }
        public int first_mileage { get; set; }
        public int last_mileage { get; set; }

        public string cus_name { get; set; }
        public string add_mobile { get; set; }
        public string add_tel { get; set; }
        public string add_province { get; set; }
        public string car_brand { get; set; }
        public string car_model { get; set; }

        //public string cus_code { get; set; }
        public string pre_name { get; set; }
        //public string cus_name { get; set; }
        //public string add_tel { get; set; }
        //public string add_mobile { get; set; }
        public double credit_limit { get; set; }
        public double credit_bal { get; set; }
        public string custype_code { get; set; }
        public string custype_pay { get; set; }
        public string custype_name { get; set; }
    }
}
