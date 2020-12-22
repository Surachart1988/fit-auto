using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;

namespace PosService.Services
{
    public class MasterDataService : IMasterDataModelService
    {
        private Entities _db;
        private Mapper _mapper;
        private DocService _docService;

        public MasterDataService(Entities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }

        public MasterDataModel Get(MasterDataModel model)
        {
            switch (model.Id)
            {
                case 99:
                    var data = _db.SB_BlueCardRedeemSetting.FirstOrDefault();
                    if (data != null)
                    {
                        model.BlueCardRedeemSetting.blueCard_exchange_rateby = data.BlueCard_exchange_rateby;
                        model.BlueCardRedeemSetting.blueCard_RewardPoint = data.BlueCard_RewardPoint ?? 0;
                        model.BlueCardRedeemSetting.blueCard_Money = data.BlueCard_Money ?? 0;
                        model.BlueCardRedeemSetting.blueCard_MinimumRewardPoint = data.BlueCard_MinimumRewardPoint ?? 0;
                        model.BlueCardRedeemSetting.blueCard_Ratio_Point = data.BlueCard_Ratio_Point ?? 0;
                    }
                    break;
            }
            return model;
        }
    }
}
