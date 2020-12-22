using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;

namespace CentralService.Models
{
    public class SendClientModel
    {
        public SendClientModel()
        {
            BranchList = new List<DealerMasterModel>();
        }
        public string Detail_Id { get; set; }
        public string act { get; set; }
        public List<DealerMasterModel> BranchList { get; set; }
    }
}