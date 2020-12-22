using CentralService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newHQ.Models
{
    public class MessageViewModel : MessageModel
    {
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Files { get; set; }
    }
}