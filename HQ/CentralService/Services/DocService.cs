using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Services
{
    public class DocService : IDocService
    {
        public string GenDocNo4(string codeName, string lastNo)
        {
            if (lastNo.Length > codeName.Length)
                lastNo = lastNo.Substring(codeName.Length);
            CheckLastNumber(lastNo, out string month, out string year, out int number);
            return String.Format("{0}{1}{2}{3}", codeName, year, month, number.ToString("000#"));
        }

        public string GenDocNo7(string codeName, string lastNo)
        {
            CheckLastNumber(lastNo, out string month, out string year, out int number);
            return String.Format("{0}{1}{2}{3}", codeName, year, month, number.ToString("000000#"));
        }

        public string GenNewDocNo5(string codeName, string branchNo, int lastNo)
        {
            return $@"{codeName}{branchNo}-{String.Format((++lastNo).ToString("0000#"))}";
        }

        private void CheckLastNumber(string lastNo, out string month, out string year, out int number)
        {
            month = DateTime.Now.Month.ToString("0#");
            year = DateTime.Now.Year.ToString().Substring(2, 2);
            number = 1;
            if (lastNo != null && lastNo.Length > 4)
            {
                var lastNoYear = lastNo.Substring(0, 2);
                var lastNoMonth = lastNo.Substring(2, 2);
                if (year == lastNoYear && month == lastNoMonth)
                    number = int.Parse(lastNo.Substring(4)) + 1;
            }
        }
    }
}
