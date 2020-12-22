using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.SystemData;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using static HQService.HQServiceUnityExtension;


namespace HQService.Services
{
    public class BranchService : IBranchService
    {
        private HQEntities _db;
        private Mapper _mapper;
        const string BaseApiUrl = "api/POSApi";
        private DocService _docService;

        public BranchService(HQEntities conn, Mapper mapper, DocService docService)
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
            model.http_path = _b.flag_hq == "True" ? _sys.hq_url : _dm.http_path;

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

        public string GetNewCode()
        {
            string lastedCode = _db.SB_Branch.ToList().OrderByDescending(o => int.Parse(o.dealercode)).FirstOrDefault().dealercode;
            int newCode = Int32.Parse(lastedCode); newCode++;
            return newCode.ToString("D" + lastedCode.Length);
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

        public int AddUpdate(BranchModel model, ref int doc_no_run)
        {
            DateTime add_date = DateTime.Now;
            int _rowCount = 0;
            var dbModel = _mapper.Map<SB_Branch>(model);
            if (dbModel.flag_hq != "True")
                dbModel.SendClient = 1;
            dbModel.edit_date = add_date.ToString("dd/MM/yyyy");
            dbModel.edit_time = add_date.ToString("HH:mm:ss");
            try
            {
                if (dbModel.doc_no_run != 0)
                {
                    _db.Entry(dbModel).State = EntityState.Modified;
                    if (_db.SaveChanges() > 0)
                    {
                        if (dbModel.flag_hq != "True")
                        {
                            #region update sb_dealercode_master
                            var _dm = _db.SB_Dealercode_Master.FirstOrDefault(m => m.dealercode == dbModel.dealercode);
                            _dm.branch_no = dbModel.branch_no;
                            _dm.DealerName = dbModel.branch_name;
                            _dm.ip_address = model.ip_address;
                            _dm.ip_address_pub = model.ip_address_pub;
                            _dm.http_path = model.http_path ?? "";
                            _dm.flag_used = dbModel.branch_used;
                            _dm.Company_SendClient = 1;
                            _db.Entry(_dm).State = EntityState.Modified;
                            #endregion

                            if (_db.SaveChanges() > 0)
                            {
                                #region update sb_system
                                var _sys = _db.SB_System.FirstOrDefault(m => m.branch_id == dbModel.doc_no_run);
                                _sys.dealercode = dbModel.dealercode;
                                _sys.branch_no = dbModel.branch_no;
                                _sys.provid = dbModel.add_provid;
                                _sys.client_url = model.http_path ?? "";
                                _db.Entry(_sys).State = EntityState.Modified;
                                #endregion
                            }
                        }
                        else
                        {
                            var _sys = _db.SB_System.FirstOrDefault(m => m.branch_id == dbModel.doc_no_run);
                            _sys.hq_url = model.http_path ?? "";
                            _db.Entry(_sys).State = EntityState.Modified;
                        }
                        doc_no_run = dbModel.doc_no_run;
                        _rowCount = _db.SaveChanges();
                    }
                }
                else
                {
                    var hq_url = _db.SB_System.Join(_db.SB_Branch.Where(w => w.flag_hq == "True" && w.branch_used == "True"),
                    sys => sys.branch_id, pos => pos.doc_no_run,
                    (sys, pos) => new { Sys = sys, branch = pos }).FirstOrDefault().Sys.hq_url;
                    dbModel.add_date = add_date.ToString("dd/MM/yyyy");
                    dbModel.add_time = add_date.ToString("HH:mm:ss");
                    _db.SB_Branch.Add(dbModel);
                    if (_db.SaveChanges() > 0)
                    {
                        #region insert sb_system
                        var sys = new SB_System();
                        sys.branch_id = dbModel.doc_no_run;
                        sys.branch_no = dbModel.branch_no;
                        sys.dealercode = dbModel.dealercode;
                        sys.provid = dbModel.add_provid;
                        sys.hq_url = hq_url ?? "";
                        sys.client_url = model.http_path ?? "";
                        sys.formprint = "1";
                        sys.cashdw = "0";
                        sys.alert_month = 1;
                        sys.print_comp = "1";
                        sys.print_tax = "1";
                        sys.formprint_2 = "1";
                        sys.doc_select = "doc_no";
                        sys.DATE_REPORT_TYPE = "1";
                        sys.formprint_bill = "1";
                        sys.pay_rt_tmp = "True";
                        sys.pay_rt_inv = "True";
                        sys.pay_ws_tmp = "True";
                        sys.pay_ws_inv = "True";
                        sys.all_nextservices = "";
                        sys.used_edit_doc_no2 = "";
                        sys.used_edit_doc_no2_key = "";
                        sys.ROOT_PATH = "";
                        sys.used_film_option = "";
                        sys.used_dayservices_alert = 7;
                        sys.used_docno_ref_num = "";
                        sys.used_locat_barcode = 0;
                        sys.pro_name_order = "S_B_M";
                        sys.po_config_ini = "";
                        sys.print_header_footer_report = "";
                        sys.Job_Head_Technician = "";
                        sys.Job_Detail_Technician = "";
                        sys.card_port_no = "";
                        sys.default_doc = "";
                        sys.check_credit_total = "";
                        sys.check_close_job = "";
                        sys.special_promotion = "True";
                        sys.fastcash_openjob = "";
                        sys.cus_pro_price = "True";
                        sys.Used_Handheld = "";
                        sys.payment_round_digit = "1";
                        _db.SB_System.Add(sys);
                        #endregion

                        if (_db.SaveChanges() > 0)
                        {
                            #region insert sb_dealercode_master
                            var _dm = new SB_Dealercode_Master();
                            _dm.branch_no = dbModel.branch_no;
                            _dm.dealercode = dbModel.dealercode;
                            _dm.DealerName = dbModel.branch_name;
                            _dm.Dealertype = "Retail";
                            _dm.salezone_id = 0;
                            _dm.salegroup_id = 0;
                            _dm.ip_address = model.ip_address;
                            _dm.ip_address_pub = model.ip_address_pub;
                            _dm.http_path = model.http_path ?? "";
                            _dm.flag_used = dbModel.branch_used;
                            _dm.Company_SendClient = 1;
                            _db.SB_Dealercode_Master.Add(_dm);
                            #endregion
                            doc_no_run = dbModel.doc_no_run;
                            _rowCount = _db.SaveChanges();
                        }
                    }
                }
                return _rowCount;
            }
            catch (Exception ex)
            {
                return _rowCount;
            }
        }

        public int UpdateConfigs(SystemModel model)
        {
            int _rowCount = 0;
            var dbModel = _mapper.Map<SB_System>(model);

            try
            {
                _db.Entry(dbModel).State = EntityState.Modified;
                if (_db.SaveChanges() > 0)
                {
                    #region update sb_branch
                    var _b = _db.SB_Branch.FirstOrDefault(m => m.doc_no_run == dbModel.branch_id);
                    _b.SendClient = 1;
                    _db.Entry(_b).State = EntityState.Modified;
                    #endregion

                    _rowCount = _db.SaveChanges();
                }

                return _rowCount;
            }
            catch (Exception ex)
            {
                return _rowCount;
            }
        }
    }
}
