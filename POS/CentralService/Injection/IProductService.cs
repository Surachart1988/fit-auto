using CentralService.Models;
using CentralService.Models.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Injection
{
    public interface IProductService
    {
        Task<DTResult<ProductModel>> ProductList(ProductSearchModel dtRequestModel, string cus_code, string cus_type);

        DTResult<ProductSetModel> ProductSetList(ProductSearchModel dtRequestModel);
        object ProductSetDetailList(string ps_code, int ps_gen_id);
        object ProductDetailList(string pro_code, string cus_code, string cus_type);
    }
}
