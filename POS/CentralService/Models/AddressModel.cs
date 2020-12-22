using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            _mode = "";
            ProvinceList = new List<ProvinceModel> {
                new ProvinceModel {
                    prov_id = 0,
                    prov_name = "เลือกจังหวัด"
                } };
            AmphurList = new List<AmphurModel> {
                new AmphurModel {
                    amphur_id = 0,
                    amphur_name = "เลือกอำเภอ"
                } };
            TambolList = new List<TambolModel> {
                new TambolModel {
                    tambol_id = 0,
                    tambol_name = "เลือกตำบล"
                } };
            ZipCodeList = new List<ZipcodeModel> {
                new ZipcodeModel {
                    zip_id = "0",
                    zip_code = "เลือกรหัสไปรษณีย์"
                } };
        }
        public string _mode { get; set; }
        public int? add_provid { get; set; }
        public int? add_tumbol_id { get; set; }
        public int? add_amphur_id { get; set; }
        public string add_zip { get; set; }

        public IEnumerable<ProvinceModel> ProvinceList { get; set; }
        public IEnumerable<AmphurModel> AmphurList { get; set; }
        public IEnumerable<TambolModel> TambolList { get; set; }
        public IEnumerable<ZipcodeModel> ZipCodeList { get; set; }
    }
    public class ProvinceModel
    {
        public int prov_id { get; set; }

        public string prov_name { get; set; }
    }
    public class AmphurModel
    {
        public int amphur_id { get; set; }

        public string amphur_name { get; set; }
    }
    public class TambolModel
    {
        public int tambol_id { get; set; }

        public string tambol_name { get; set; }
    }
    public class ZipcodeModel
    {
        public string zip_id { get; set; }

        public string zip_code { get; set; }
    }
}
