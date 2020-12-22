using CentralService.Models;
using CentralService.Models.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface ICustomerService
    {
        DTResult<CustomerVehicleModel> GetDTResult(DTParameters dtRequestModel, ISearchModel search);
        DTResult<CusCarRegModel> CarRegList(DTParameters dtRequestModel);

        DTResult<CusCarRegModel> CustomerList(DTParameters dtRequestModel);
        Task<DTResult<CustomerVehicleModel>> GetDTResultCallHqAsync(DTParameters dtRequestModel, ISearchModel search, string dealerCode);

        List<IdNameModel> GetKeySearchList();

        void CheckAndCreateCustomer(CustomerVehicleModel model, string dealerCode);

        object GetCustomer(string code, string dealerCode);

        object GetCar(string code, int provinceId, string dealerCode);

        RegisterBlueCardModel GetBranchDetail();
    }
}
