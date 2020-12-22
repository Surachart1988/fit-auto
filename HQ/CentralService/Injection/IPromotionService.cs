using CentralService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace CentralService.Injection
{
    public interface IPromotionService
    {
        DTResult<ExtraPromotionModel> GetlAll(DTParameters dataTableRequestModel, ISearchModel search);
        void AddUpdate(ExtraPromotionModel model, string coupon_code);
        void GetDealers(ExtraPromotionModel ms, List<DealerMasterModel> lists);
        ExtraPromotionModel Get(string id);
        void GetConditionWeek(ExtraPromotionModel ms);
        void GetConditionMonth(ExtraPromotionModel ms);
        void GetPromotionList(ExtraPromotionModel ms);
        void GetPromotionGroupUsed(ExtraPromotionModel ms);
        void GetProgroupFirstGroup(ExtraPromotionModel ms);
        void GetProgroup(ExtraPromotionModel ms, string data, string hasChk);
        void GetProbrand(ExtraPromotionModel ms, string data, string hasChk);
        void GetPromodel(ExtraPromotionModel ms, string data, string hasChk);
        void GetProSize(ExtraPromotionModel ms, string data, string hasChk);
        //void GetProduct(ExtraPromotionModel ms);
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

        bool checkDuplicateCoupon(string _couponGrpCode, List<SBCouponDetail> model,out SBCouponDetail code);
        object Delete(string id);
        void GetPromotionitems(ExtraPromotionModel model);
        void Getdata_TemplatePromotion(DataTable dt, ExtraPromotionModel model);
        Skudetail GetSkudetail(string container, ExtraPromotionModel merge);
        void GetProdFirstGroup(ExtraPromotionModel model, string data, string hasChk);
    }
}
