using CentralService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IBaseModel
    {
        string BranchNo { get; set; }

        int UserId { get; set; }

        string IpAddress { get; set; }

        string Username { get; set; }
    }
}
