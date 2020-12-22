using CentralService.Models;
using PosData.Models;
using PosService.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosService.Services
{
    public class DealerService : IDealerService
    {
        private Entities _db;

        public DealerService(Entities conn)
        {
            _db = conn;
        }

        public CodeNameModel GetDealerCodeName()
        {
           
            var result = new CodeNameModel();

            var temp = _db.SB_Branch.FirstOrDefault();
            result.Code = temp?.dealercode;
            result.Name = temp?.branch_name;

            //return _db.SB_System
            //    .Join(_db.SB_Dealercode_Master,
            //    s => s.dealercode,
            //    d => d.dealercode,
            //    (master, dealer) => new CodeNameModel { Code = master.dealercode, Name = dealer.DealerName }).FirstOrDefault();
            return result;
        }
    }
}
