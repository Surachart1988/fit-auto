using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.SystemData;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;


namespace PosService.Services
{
    public class BranchService : IBranchService
    {
        private Entities _db;
        private Mapper _mapper;
        private DocService _docService;

        public BranchService(Entities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }

        public BranchModel Get(int id)
        {
            var _b = _db.SB_Branch.FirstOrDefault(m => m.doc_no_run == id);
            var _dm = _db.SB_Dealercode_Master.FirstOrDefault(m => m.dealercode == _b.dealercode);
            var _sys = _db.SB_System.FirstOrDefault(m => m.branch_id == id);

            var model = _mapper.Map<BranchModel>(_b);
            model.ip_address = _dm?.ip_address ?? "";
            model.ip_address_pub = _dm?.ip_address_pub ?? "";
            model.http_path = _sys.hq_url ?? "";

            model.AddressModel.add_provid = model.add_provid;
            model.AddressModel.add_amphur_id = model.add_amphur_id;
            model.AddressModel.add_tumbol_id = model.add_tumbol_id;
            model.AddressModel.add_zip = model.add_zip;

            GetDealerMaster(model.DealerMasterModel, _b.dealercode);
            return model;
        }

        public void GetDealerMaster(DealerMasterModel model, string dcode)
        {
            var _b = _db.SB_Branch.FirstOrDefault(m => m.dealercode == dcode);
            var _dm = _db.SB_Dealercode_Master.FirstOrDefault(m => m.dealercode == _b.dealercode);
            var _sys = _db.SB_System.FirstOrDefault(m => m.branch_id == _b.doc_no_run);
            //var g = model.GetType();
            //var pp = g.GetProperty("DealerMasterModel");
            model.plant_no = _b.plant_no;
            model.dealercode = _dm?.dealercode ?? "";
            model.DealerName = _dm?.DealerName ?? "";
            model.http_path = _b.flag_hq == "True" ? _sys.hq_url : _dm.http_path;
        }

        public SystemModel GetConfigs(int id)
        {
            var _sys = _db.SB_System.FirstOrDefault(m => m.branch_id == id);

            var model = _mapper.Map<SystemModel>(_sys);
            return model;
        }

        public bool CheckDealers(string code, int id) =>
            _db.SB_Branch.Any(f => f.dealercode == code.Trim() && ((id != 0) ? f.doc_no_run != id : true));

        public bool CheckPlantNo(string no, int id) =>
            _db.SB_Branch.Any(f => f.plant_no == no.Trim() && ((id != 0) ? f.doc_no_run != id : true));

        public bool CheckSSCode(string sscode, int id) =>
            _db.SB_Branch.Select(s => new { SSCode = s.sold_to + s.ship_to, s.doc_no_run }).Any(f => f.SSCode == sscode.Trim() && ((id != 0) ? f.doc_no_run != id : true));

        public List<DealerMasterModel> GetDealers()
        {
            var data = _db.SB_Dealercode_Master.Where(w => w.flag_used == "True")
                .GroupJoin(_db.SB_Branch,
                    dealer => dealer.dealercode,
                    b => b.dealercode,
                    (dealer, b) => new { dealer, branch = b.FirstOrDefault() })
                .Select(s => new DealerMasterModel
                {
                    plant_no = s.branch.plant_no,
                    dealercode = s.dealer.dealercode,
                    DealerName = s.dealer.DealerName,
                    http_path = s.dealer.http_path
                }).ToList();
            return data;
        }

        public DTResult<BranchModel> GetlAll(DTParameters dtRequestModel, ISearchModel search)
        {

            var query = _db.SB_Branch.Where(w => w.branch_no != "")
                .GroupJoin(_db.SB_province,
                    b => b.add_provid,
                    p => p.add_provid,
                    (Branch, province) => new { Branch, detail = province.FirstOrDefault() });

            if (!string.IsNullOrWhiteSpace(search.KeywordsSearch))
            {
                query = query.Where(w =>
                    w.Branch.dealercode.Contains(search.KeywordsSearch) ||
                        w.Branch.plant_no.Contains(search.KeywordsSearch) ||
                            w.Branch.branch_name.Contains(search.KeywordsSearch) ||
                                w.detail.add_province.Contains(search.KeywordsSearch) ||
                                    w.Branch.sold_to.Contains(search.KeywordsSearch) ||
                                        w.Branch.ship_to.Contains(search.KeywordsSearch));
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.dealercode); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.plant_no); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.branch_name); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.detail.add_province); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.add_tel); break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.sold_to); break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Branch.ship_to); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraMapper(q.Branch, q.detail));

            var dtModel = new DTResult<BranchModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        private BranchModel ExtraMapper(SB_Branch extra, SB_province prov)
        {
            var m = _mapper.Map<BranchModel>(extra);
            m.add_province = prov.add_province;
            return m;
        }

        public int UpdateConfigs(SystemModel model)
        {
            int _rowCount = 0;
            var dbModel = _mapper.Map<SB_System>(model);

            try
            {
                _db.Entry(dbModel).State = EntityState.Modified;
                _rowCount = _db.SaveChanges();
                return _rowCount;
            }
            catch (Exception ex)
            {
                return _rowCount;
            }
        }
    }
}
