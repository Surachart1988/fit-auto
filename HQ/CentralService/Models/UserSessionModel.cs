using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Models
{
    public class UserSessionModel
    {
        public string gbusername { get; set; }

        public string gbuser { get; set; }

        public string gblevel { get; set; }
        public string gbsempno { get; set; }
        public int gbuserId { get; set; }
        public string DealerCode { get; set; }
        public string ClientUrl { get; set; }
        public string HQUrl { get; set; }
        public string DealerName { get; set; }
        public string BranchNo { get; set; }
        public int BranchDocNoRun { get; set; }
    }
}
