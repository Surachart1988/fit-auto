using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System.Linq;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class ProductService : IProductService
    {
        private HQEntities _db;
        private Mapper _mapper;
        private DocService _docService;
        public ProductService(HQEntities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }
        public object GetStockOnline(string pro_code, string state)
        {
            var query = _db.SB_Product_Qty
                .Join(_db.SB_Dealercode_Master,
                _ => _.dealercode,
                dm => dm.dealercode,
                (pq, dm) => new { ProdQty = pq, dealer = dm })
                .Where(w => w.ProdQty.pro_code == pro_code)
                .Select(s => new
                {
                    s.dealer.dealercode,
                    s.dealer.DealerName,
                    s.ProdQty.pro_ohqty, // oh

                    s.ProdQty.pro_poqty, // po
                    s.ProdQty.pro_otqty, // ot
                    s.ProdQty.pro_accqty // pro_accqty
                });
            return query;
        }
    }
}
