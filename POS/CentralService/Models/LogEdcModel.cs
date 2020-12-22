using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Models
{
 public   class LogEdcModel
    {
        public LogEdcModel()
        {

        }
        public string receive_edc { get; set; }
        public string DocNo { get; set; }
        public string Amount { get; set; }
        public string ProCode { get; set; }
        public string PortNo { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
