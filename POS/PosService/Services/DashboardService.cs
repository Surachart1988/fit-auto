using CentralService;
using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using Newtonsoft.Json;
using PosData.Models;
using PosService.Injection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Services
{
    public class DashboardService : IDashboardService
    {
        private Entities _db;
        private IDealerService _dealerService;

        public DashboardService(Entities conn, IDealerService dealerService)
        {
            _db = conn;
            _dealerService = dealerService;
        }

        public List<NameValueModel> GetNotificationsNumber()
        {
            var model = new List<NameValueModel>();
            var poNumber = _db.ST_Poheader.Count(p => (p.approve_status_id == 2 || p.approve_status_id == 3) && p.po_close == "0");
            model.Add(new NameValueModel { Name = "อนุมัติใบขอซื้อสินค้า", Value = poNumber });

            var rdNumber = _db.ST_Rdisc_Head.Count(p => (p.approve_status_id == 2 || p.approve_status_id == 3) && p.doc_close == "0");
            model.Add(new NameValueModel { Name = "อนุมัติใบลดหนี้/รับคืนสินค้า", Value = rdNumber });

            var dealerModel = _dealerService.GetDealerCodeName();

            var trnNumber = _db.ST_TRNHeader.Count(p => p.trn_to_status == "waiting" && p.to_dealercode == dealerModel.Code);
            model.Add(new NameValueModel { Name = "ใบโอนย้ายสินค้า", Value = trnNumber });

            var arNumber = _db.ST_Arheader.Count(p => (p.approve_status_id == 2 || p.approve_status_id == 3) && p.doc_close == "True");
            model.Add(new NameValueModel { Name = "อนุมัติใบกำกับภาษีเต็มรูป", Value = arNumber });

            var icaNumber = _db.ST_ICAHeader.Count(p => (p.approve_status_id == 2 || p.approve_status_id == 3) && p.doc_close == "True");
            model.Add(new NameValueModel { Name = "อนุมัติใบปรับปรุง", Value = icaNumber });



            return model;
        }

        public Gen_WifiModel GetWifiDetail()
        {
            var data = _db.SB_System.FirstOrDefault();
            return new Gen_WifiModel()
            {
                wifi_brand = data.hash_wifi_brand,
                wifi_branch = data.hash_wifi_branch,
                wifi_pos = data.hash_wifi_pos
            };
        }

        public void SaveHashWifi(string hashstr, out string wifihash, out string outTimes)
        {
            outTimes = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            dynamic json = JsonConvert.DeserializeObject(hashstr);
            wifihash = json["encrypt"].ToString();
            _db.Gen_Wifi.Add(new Gen_Wifi { Wifi_Date = outTimes, Wifi_Password = wifihash });

            _db.SaveChanges();
        }
    }
}
