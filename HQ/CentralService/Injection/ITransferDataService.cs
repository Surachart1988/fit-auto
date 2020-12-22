using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface ITransferDataService
    {
        Task<TransferDataModel> SendData(TransferDataModel model);
        TransferDataModel PrepareData(SendClientModel model);
        void TransferLog(TransferDataModel result, int userid);
        void SetSendClient(TransferDataModel model);
    }
}
