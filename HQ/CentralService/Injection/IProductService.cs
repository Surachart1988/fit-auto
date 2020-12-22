using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IProductService
    {
        object GetStockOnline(string pro_code, string state);
    }
}
