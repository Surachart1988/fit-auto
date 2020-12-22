using CentralService.Enums;
using CentralService.Injection;
using CentralService.Models;
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
    public class MessageService : IMessageService
    {
        private Entities _db;
        private Mapper _mapper;
        private DocService _docService;

        public MessageService(Entities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }
        public void Create(MessageModel model)
        {
            throw new NotImplementedException();
        }

        public MessageModel Get(int id)
        {
            var dbModel = _db.MessageDatas.FirstOrDefault(m => m.Id == id);
            var model = _mapper.Map<MessageModel>(dbModel);
            return model;
        }

        public string GetDocNo()
        {
            throw new NotImplementedException();
        }

        public DTResult<MessageModel> GetDTResult(DTParameters dtRequestModel, int docType)
        {
            string GetSearchString = "";
            if (dtRequestModel.Search.Value != null ) {
                GetSearchString = dtRequestModel.Search.Value.ToString();
            }


            var query = _db.MessageDatas.Where(m => m.Status == (int)MessageStatus.เปิดใช้งาน
            && m.StartDate <= DateTime.Now
            && m.EndDate >= DateTime.Now
            && m.DocType == docType
            && (m.Name.Contains(GetSearchString) || m.Content.Contains(GetSearchString)) 
            );

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.StartDate);
                        break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Name);
                        break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => (MessageStatus)p.Status);
                        break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Content);
                        break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => _mapper.Map<MessageModel>(q));

            var dtModel = new DTResult<MessageModel>()
            {
                data = model.ToList(),
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public List<MessageModel> GetList()
        {
            var model = _db.MessageDatas.Where(m => m.Status == (int)MessageStatus.เปิดใช้งาน
            && m.StartDate <= DateTime.Now
            && m.EndDate >= DateTime.Now)

            .ToArray().Select(q => _mapper.Map<MessageModel>(q)).ToList();
            return model;
        }

        public IEnumerable<IdNameModel> GetMessageStatus()
        {
            throw new NotImplementedException();
        }

        public void Update(MessageModel model)
        {
            throw new NotImplementedException();
        }
    }
}
