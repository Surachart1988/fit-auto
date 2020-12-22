
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
        UserSessionModel IsValid(UserAccountModel user,string password);
    }
}
