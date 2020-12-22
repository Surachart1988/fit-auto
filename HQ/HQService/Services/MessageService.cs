using CentralService;
using CentralService.Enums;
using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class MessageService : IMessageService
    {
        private HQEntities _db;
        private Mapper _mapper;
        private DocService _docService;
        private DateTime startdate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", new CultureInfo("en-US"));
        private DateTime enddate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", new CultureInfo("en-US"));

        public MessageService(HQEntities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }

        public string GetDocNo()
        {
            var lastModel = _db.MessageData.OrderByDescending(p => p.Code).FirstOrDefault();
            string lastNo = "0";
            if (lastModel != null)
                lastNo = lastModel.Code;
            return _docService.GenDocNo4("MES", lastNo);
        }

        public void Create(MessageModel model)
        {
            var dbModel = _mapper.Map<MessageData>(model);
            dbModel.SendClient = true;
            dbModel.Code = GetDocNo();
            _db.MessageData.Add(dbModel);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        public DTResult<MessageModel> GetDTResult(DTParameters dtRequestModel, int docType)
        {
            string GetSearchString = "";
            if (dtRequestModel.Search.Value != null)
            {
                GetSearchString = dtRequestModel.Search.Value.ToString();
            }
                        
            var query = _db.MessageData.Where(m => m.Status == (int)MessageStatus.เปิดใช้งาน
            && m.StartDate <= startdate
            && m.EndDate >= enddate
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
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public IEnumerable<IdNameModel> GetMessageStatus()
        {
            var list = Enum.GetValues(typeof(MessageStatus)).Cast<MessageStatus>()
                            .Select(e => new IdNameModel
                            {
                                Id = (int)e,
                                Name = e.ToString()
                            });
            return list;
        }

        public List<MessageModel> GetList()
        {
            var model = _db.MessageData.Where(m => m.Status == (int)MessageStatus.เปิดใช้งาน
            && m.StartDate <= startdate
            && m.EndDate >= enddate)

            .ToArray().Select(q => _mapper.Map<MessageModel>(q)).ToList();
            return model;
        }

        public MessageModel Get(int id)
        {
            var dbModel = _db.MessageData.FirstOrDefault(m => m.Id == id);
            var model = _mapper.Map<MessageModel>(dbModel);
            return model;
        }

        public void Update(MessageModel model)
        {
            var dbModel = _db.MessageData.FirstOrDefault(ed => ed.Id == model.Id);
            dbModel.Name = model.Name;
            dbModel.Status = (int)model.Status;
            dbModel.Content = model.Content;

            dbModel.StartDate = model.StartDate;
            dbModel.EndDate = model.EndDate;
            if (!string.IsNullOrWhiteSpace(model.FileName))
            {
                dbModel.FileName = model.FileName;
            }
            dbModel.SendClient = true;
            _db.Entry(dbModel).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
