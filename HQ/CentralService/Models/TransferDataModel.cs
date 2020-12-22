using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;

namespace CentralService.Models
{
    public class TransferDataModel
    {
        public TransferDataModel()
        {
            DealerList = new List<TransferDetail>();
        }
        public string Type { get; set; }
        public List<TransferDetail> DealerList { get; set; }
    }
    public class TransferDetail : DealerMasterModel
    {
        public DataSet Soure { get; set; }
        public string DesSoure { get; set; }
        public bool SendStatus { get; set; }
        public string error_massage { get; set; }
        public string id_send_client { get; set; }

    }
}