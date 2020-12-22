using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralService.Models;

namespace CentralService.Injection
{
    public interface ITransferDataService
    {
        TransferDataModel GetData(TransferDetail model);
        void TransferLog(TransferDataModel result);
    }
}
