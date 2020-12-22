using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface ITransferService
    {
        void DropNumberStoke(string docNo, string branchNo, string docCode);

        void PushNumberStoke(string docNo, string branchNo, string docCode);
    }
}
