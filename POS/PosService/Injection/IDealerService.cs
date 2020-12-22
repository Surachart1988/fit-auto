using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosService.Injection
{
    public interface IDealerService
    {
        CodeNameModel GetDealerCodeName();
    }
}
