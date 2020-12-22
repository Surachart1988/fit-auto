using CentralService;
using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQService.Services
{
    public class DashboardService : IDashboardService
    {
        private HQEntities _db;

        public DashboardService(HQEntities conn)
        {
            _db = conn;
        }

        public List<NameValueModel> GetNotificationsNumber()
        {
            var model = new List<NameValueModel>();

            var poNumber = _db.ST_Poheader.Count(p => p.approve_status_id == 1 && p.po_cancel != "1");
            model.Add(new NameValueModel { Name = "อนุมัติใบขอซื้อสินค้า", Value = poNumber });

            var rdNumber = _db.ST_Rdisc_Head.Count(p => p.approve_status_id == 1);
            model.Add(new NameValueModel { Name = "อนุมัติใบลดหนี้/รับคืนสินค้า", Value = rdNumber });

            var trnNumber = _db.ST_TRNHeader.Count(p => p.trn_to_status == "waiting");
            model.Add(new NameValueModel { Name = "ใบโอนย้ายสินค้า", Value = trnNumber });

            var arNumber = _db.ST_Arheader.Count(p => p.approve_status_id == 1);
            model.Add(new NameValueModel { Name = "อนุมัติใบกำกับภาษีเต็มรูป", Value = arNumber });

            var icaNumber = _db.ST_ICAHeader.Count(p => p.approve_status_id == 1);
            model.Add(new NameValueModel { Name = "อนุมัติใบปรับปรุง", Value = icaNumber });

            return model;
        }
    }
}
