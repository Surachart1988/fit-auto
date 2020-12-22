using CentralService.Models;
using CentralService.Models.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IVendorService
    {
        DTResult<VendorModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);
        VendorModel Get(string id);
    }
}
