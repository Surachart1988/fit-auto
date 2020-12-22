using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class CampaignService : ICampaignService
    {
        private HQEntities _db;
        private Mapper _mapper;
        //private DocService _docService;
        public CampaignService(HQEntities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
            //_docService = docService;

        }

        public int AddUpdate(CampaignModel model, string campaign_id)
        {
            DateTime add_date = DateTime.Now;
            var dbModel = _mapper.Map<SB_Campaign>(model);
            int _rowCount = 0;
            dbModel.campaign_edit_date = add_date.ToString("dd/MM/yyyy");
            dbModel.campaign_edit_time = add_date.ToString("HH:mm:ss");
            dbModel.SendClient = 1;
            try
            {
                if (!String.IsNullOrWhiteSpace(dbModel.campaign_id))
                {
                    dbModel.dealercode = "";
                    dbModel.branch_no = "";
                    _db.Entry(dbModel).State = EntityState.Modified;
                    _rowCount = _db.SaveChanges();
                }
                else
                {
                    var _camid = _db.Database.SqlQuery<string>("SP_Campaign_NewID").First();
                    dbModel.campaign_id = _camid;
                    dbModel.campaign_add_date = add_date.ToString("dd/MM/yyyy");
                    dbModel.campaign_add_time = add_date.ToString("HH:mm:ss");
                    dbModel.dealercode = "";
                    dbModel.branch_no = "";
                    dbModel.deleted = false;
                    dbModel.SendClient = 1;
                    _db.SB_Campaign.Add(dbModel);
                    _rowCount = _db.SaveChanges();
                }
                return _rowCount;
            }
            catch (Exception ex)
            {
                return _rowCount;
            }
        }


        public CampaignModel Get(string id)
        {
            var _b = _db.SB_Campaign.FirstOrDefault(m => m.campaign_id == id);
            var model = _mapper.Map<CentralService.Models.MasterData.Campaign.CampaignModel>(_b);
            return model;
        }



        //public string GetNewCode()
        //{
        //    string lastedCode = _db.SB_Campaign.ToList().OrderByDescending(o => int.Parse(o.campaign_id)).FirstOrDefault().campaign_id;
        //    int newCode = Int32.Parse(lastedCode); newCode++;
        //    return newCode.ToString("D" + lastedCode.Length);
        //}
        public DTResult<CampaignModel> GetlAll(DTParameters dtRequestModel, ISearchModel search)
        {

            var query = _db.SB_Campaign.Where(w => w.campaign_id != "");

            if (!string.IsNullOrWhiteSpace(search.KeywordsSearch))
            {
                query = query.Where(w =>
                w.campaign_name.Contains(search.KeywordsSearch));

            }
            if (!string.IsNullOrWhiteSpace(search.Status))
            {
                switch (search.Status)
                {
                    case "0":// // deleted = false = 0 = เปิดการใช้งาน, true = 1 = ปิดการใช้งาน
                        query = query.Where(q =>
                            q.deleted == false);
                        break;
                    case "1":
                        query = query.Where(q =>
                            q.deleted == true);
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
                        query = DatatableTools.SortDatetable(query, sort, p => p.campaign_id); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.campaign_name); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.deleted); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => _mapper.Map<CentralService.Models.MasterData.Campaign.CampaignModel>(q));

            var dtModel = new DTResult<CentralService.Models.MasterData.Campaign.CampaignModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }
        public int Delete(string id)
        {
            int rows = 0;
            string format_date = "dd/MM/yyyy", format_time = "HH:mm:ss";
            DateTime edit_date = DateTime.Now;
            var dbModel = _db.SB_Campaign.FirstOrDefault(p => p.campaign_id == id);
            if (dbModel != null)
            {
                dbModel.deleted = true;
                dbModel.campaign_edit_date = edit_date.ToString(format_date);
                dbModel.campaign_edit_time = edit_date.ToString(format_time);
                dbModel.SendClient = 1;
                _db.Entry(dbModel).State = EntityState.Modified;
                return _db.SaveChanges();
            }
            else
            {
                return rows;
            }
        }
        public bool checkNameCampaign(string campaign_name, string id) =>
        _db.SB_Campaign.Any(f => f.campaign_name == campaign_name.Trim() && ((id != "") ? f.campaign_id != id : true));

    }
}
