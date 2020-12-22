
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
        int AddUpdate(CampaignModel model,string campaign_id);
        CampaignModel Get(string id);
        int Delete(string id);
        bool checkNameCampaign(string campaign_name, string id);
    }
}
