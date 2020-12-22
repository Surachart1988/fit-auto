using CentralService.Models;
using CentralService.Models.SystemData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace CentralService.Injection
{
    public interface IBranchService
    {
        DTResult<BranchModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);
        List<DealerMasterModel> GetDealers();
        BranchModel Get(int id);
        SystemModel GetConfigs(int id);
        bool CheckDealers(string code, int id);
        bool CheckPlantNo(string no, int id);
        bool CheckSSCode(string sscode, int id);
        int UpdateConfigs(SystemModel modal);
    }
}
