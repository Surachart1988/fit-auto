using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;

namespace PosService.Services
{
    public class VendorService : IVendorService
    {
        private Entities _db;
        private Mapper _mapper;
        public VendorService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
        }
        public VendorModel Get(string id)
        {
            var _b = _db.SB_Vendor.FirstOrDefault(m => m.ven_code == id);
            var model = _mapper.Map<VendorModel>(_b);
            return model;
        }
        public DTResult<VendorModel> GetlAll(DTParameters dtRequestModel, ISearchModel search)
        {
            var query = _db.SB_Vendor.Where(w => w.ven_code != "");

            if (!string.IsNullOrWhiteSpace(search.KeywordsSearch))
            {
                query = query.Where(w =>
                w.ven_code.Contains(search.KeywordsSearch) ||
                w.ven_name.Contains(search.KeywordsSearch) ||
                w.add_tel.Contains(search.KeywordsSearch));
            }
            if (!string.IsNullOrWhiteSpace(search.Status))
            {
                switch (search.Status)
                {
                    case "0":// // deleted = false = 0 = เปิดการใช้งาน, true = 1 = ปิดการใช้งาน
                        query = query.Where(q =>
                            q.cancel_date == "");
                        break;
                    case "1":
                        query = query.Where(q =>
                            q.cancel_date != "");
                        break;
                }

            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ven_code); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ven_name); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.add_tel); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.contact_name); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.cancel_date); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => _mapper.Map<VendorModel>(q));

            var dtModel = new DTResult<VendorModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }
    }
}
