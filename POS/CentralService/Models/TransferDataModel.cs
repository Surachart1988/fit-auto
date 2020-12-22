using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CentralService.Models
{
    public class TransferDataModel
    {
        public TransferDataModel()
        {
            DealerList = new List<TransferDetail>();
            UpdateList = new List<UpdateDetail>();
        }
        public string Type { get; set; }
        public List<TransferDetail> DealerList { get; set; }
        public List<UpdateDetail> UpdateList { get; set; }
    }
    public class TransferDetail : DealercodeModel
    {
        public string Actfrom { get; set; }
        public DataSet Soure { get; set; }
        public string DesSoure { get; set; }
        public bool SendStatus { get; set; }
        public string error_massage { get; set; }
        public string id_send_client { get; set; }

    }
    public class UpdateDetail
    {
        public string SoureTable { get; set; }
        public int Rows { get; set; }
        public string Schema { get; set; }
        public bool Status { get; set; }
        public string Error_Massage { get; set; }
    }
}
