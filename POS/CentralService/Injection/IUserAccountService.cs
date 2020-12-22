
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IUserAccountService
    {
        UserSessionModel IsValid(UserAccountModel user, string password, string dealerCode);

        void CheckOpenDayEnd(out bool modelOpenBatch, out bool _endYet, out bool _endtodayYet);
        Task<string> UpdateIPAddrs(string iisName, string ipV4);
    }
}
