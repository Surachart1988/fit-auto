using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using CentralService.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface ICampaignService
    {
        DTResult<CampaignModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);
        CampaignModel Get(string id);

        
    }
}
