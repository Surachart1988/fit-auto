using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IDocService
    {
        string GenDocNo4(string codeName, string lastNo);

        string GenDocNo7(string codeName, string lastNo);

        string GenNewDocNo5(string codeName, string branchNo,int lastNo);
    }
}
