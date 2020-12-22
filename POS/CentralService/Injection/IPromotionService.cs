using CentralService.Models;

namespace CentralService.Injection
{
    public interface IPromotionService
    {
        DTResult<ExtraPromotionModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);

        void GetDealers(ExtraPromotionModel ms);
        ExtraPromotionModel Get(string id);
        void GetConditionWeek(ExtraPromotionModel ms);
        void GetConditionMonth(ExtraPromotionModel ms);
        void GetPromotionList(ExtraPromotionModel ms);
        void GetProgroupFirstGroup(ExtraPromotionModel ms);
        void GetProgroup(ExtraPromotionModel ms, string data, string hasChk);
        void GetProbrand(ExtraPromotionModel ms, string data, string hasChk);
        void GetPromodel(ExtraPromotionModel ms, string data, string hasChk);
        void GetProSize(ExtraPromotionModel ms, string data, string hasChk);
        void GetCusType(ExtraPromotionModel model);
        void GetProGiveTypeList(ExtraPromotionModel ms);
        void GetProPriceList(ExtraPromotionModel ms);
        void GetProTypeList(ExtraPromotionModel ms);
        void GetProduct(ExtraPromotionModel model,
            string productgrp,
            string progroup,
            string probrand,
            string promodel,
            string prosize, string procode);

        void GetProductGift(
            ExtraPromotionModel ms, string hasprocode);

        void GetPromotionitems(ExtraPromotionModel model);
    }
}
