using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IMessageService
    {
        DTResult<MessageModel> GetDTResult(DTParameters dtRequestModel, int docType);

        List<MessageModel> GetList();

        IEnumerable<IdNameModel> GetMessageStatus();

        void Create(MessageModel model);

        string GetDocNo();
        MessageModel Get(int id);
        void Update(MessageModel model);


    }
}
