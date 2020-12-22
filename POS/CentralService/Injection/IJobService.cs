using CentralService.Models;
using CentralService.Models.Sale;
using System.Collections.Generic;

namespace CentralService.Injection
{
    public interface IJobService
    {
        DTResult<JobModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);
        int AddUpdate(JobModel model, ref string doc_no);
        object GetJobOrder(string doc_no);
        object GetJOrderCode(string doc_code, string doc_no);
        int AddProductJobOrder(JobTempModel model, string doc_code);
        int DeleteProductJobOrder(JobTempModel model /*string pro_code, string doc_no*/);
        int AddProductSetJobOrder(List<ProductSetDetailModel> model, string doc_no, string doc_code);
        JobModel Get(string doc_no);
    }
}
