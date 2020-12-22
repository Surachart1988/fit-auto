using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IMasterDataModelService
    {
        MasterDataModel Get(MasterDataModel model);

        //List<MessageModel> GetList();

        //IEnumerable<IdNameModel> GetMessageStatus();

        //void Create(MessageModel model);

        //string GetDocNo();
        //MessageModel Get(int id);
        //void Update(MessageModel model);


        int SettingRedeemBlueCard(MasterDataModel model, string toString, string empty, int i);
    }
}
