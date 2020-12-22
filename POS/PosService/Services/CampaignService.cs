
using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;

namespace PosService.Services
{
    public class CampaignService : ICampaignService
    {
        private Entities _db;
        private Mapper _mapper;
        //private DocService _docService;
        public CampaignService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
            //_docService = docService;

        }

       

        public CampaignModel Get(string id)
        {
            var _b = _db.SB_Campaign.FirstOrDefault(m => m.campaign_id == id);
            var model = _mapper.Map<CampaignModel>(_b);
            return model;
        }




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
            var model = query.ToArray().Select(q => _mapper.Map<CampaignModel>(q));

            var dtModel = new DTResult<CampaignModel>()
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
