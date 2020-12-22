using CentralService;
using CentralService.Enums;
using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class MasterDataService : IMasterDataModelService
    {
        private HQEntities _db;
        private Mapper _mapper;
        private DocService _docService;

        public MasterDataService(HQEntities conn, Mapper mapper, DocService docService)
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
                        model.BlueCardRedeemSetting.blueCard_exchange_rateby = data.BlueCard_exchange_rateby ?? false;
                        model.BlueCardRedeemSetting.blueCard_RewardPoint = data.BlueCard_RewardPoint ?? 0;
                        model.BlueCardRedeemSetting.blueCard_Money = data.BlueCard_Money ?? 0;
                        model.BlueCardRedeemSetting.blueCard_MinimumRewardPoint = data.BlueCard_MinimumRewardPoint ?? 0;
                        model.BlueCardRedeemSetting.blueCard_Ratio_Point = data.BlueCard_Ratio_Point ?? 0;
                    }
                    break;
            }
            return model;
        }

        public int SettingRedeemBlueCard(MasterDataModel model, string branchNo, string dealerCode, int userId)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var time = DateTime.Now.ToString("HH:mm:ss");
            if (model.BlueCardRedeemSetting.blueCard_exchange_rateby)
            {
                model.BlueCardRedeemSetting.blueCard_RewardPoint = 0;
                model.BlueCardRedeemSetting.blueCard_Money = 0;
                model.BlueCardRedeemSetting.blueCard_MinimumRewardPoint = 0;
                model.BlueCardRedeemSetting.blueCard_Ratio_Point = 0;
            }
            var data = _db.SB_BlueCardRedeemSetting.FirstOrDefault();
            if (data != null)
            {
                data.BlueCard_exchange_rateby = model.BlueCardRedeemSetting.blueCard_exchange_rateby;
                data.BlueCard_RewardPoint = model.BlueCardRedeemSetting.blueCard_RewardPoint;
                data.BlueCard_Money = model.BlueCardRedeemSetting.blueCard_Money;
                data.BlueCard_MinimumRewardPoint = model.BlueCardRedeemSetting.blueCard_MinimumRewardPoint;
                data.BlueCard_Ratio_Point = model.BlueCardRedeemSetting.blueCard_Ratio_Point;
                data.edit_date = date;
                data.edit_time = time;
                _db.Entry(data).State = EntityState.Modified;
            }
            else
            {
                var dbModel = new SB_BlueCardRedeemSetting
                {
                    BlueCard_exchange_rateby = model.BlueCardRedeemSetting.blueCard_exchange_rateby,
                    BlueCard_RewardPoint = model.BlueCardRedeemSetting.blueCard_RewardPoint,
                    BlueCard_Money = model.BlueCardRedeemSetting.blueCard_Money,
                    BlueCard_MinimumRewardPoint = model.BlueCardRedeemSetting.blueCard_MinimumRewardPoint,
                    BlueCard_Ratio_Point = model.BlueCardRedeemSetting.blueCard_Ratio_Point,
                    add_date = date,
                    add_time = time,
                    edit_date = date,
                    edit_time = time
                    //doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //user_pay_id = userId,
                    //dealercode = dealerCode 
                };
                _db.SB_BlueCardRedeemSetting.Add(dbModel);
            }


            return _db.SaveChanges();
        }
    }
}
