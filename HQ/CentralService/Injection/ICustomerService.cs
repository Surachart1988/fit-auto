using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface ICustomerService
    {
        DTResult<CustomerVehicleModel> GetDTResult(DTParameters dtRequestModel, ISearchModel search);
        DTResult<CustomerVehicleModel> GetDTResultCallHq(DTParameters dtRequestModel, ISearchModel search, string dealerCode);

        List<IdNameModel> GetKeySearchList();

        void CheckAndCreateCustomer(CustomerVehicleModel model, string dealerCode);

        object GetCustomer(string code, string dealerCode);

        object GetCar(string code, int provinceId, string dealerCode);
        int UpdateIPFromClient(IpV4 req);
    }
}
