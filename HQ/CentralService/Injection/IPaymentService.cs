using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IPaymentService
    {
        PaymentModel Get(string docCode, string docNo, string branchNo, string refDocno, string dpDocno, string dealerCode, int userId);
        string GetDocNo();

        DTResult<ExtraDiscountIconModel> GetExtraDiscountDTResult(DTParameters dataTableRequestModel);
        ExtraDiscountIconModel GetExtraDiscount(int id);
        void CreateExtraDiscount(ExtraDiscountIconModel model);
        void UpdateExtraDiscount(ExtraDiscountIconModel model);
        void DeleteExtraDiscount(int id);
        void AddPaymentCash(PaymentModel model, string branchNo, string dealerCode, int userId);

        List<DepositModel> GetDepositModels(string CustomerCode, string docNo);
        int AddPaymentDeposit(DepositModel model, string branchNo, string dealerCode, int userId);
        void DeletePaymentDeposit(int id);

        int AddPaymentCredit(string branchNo, int userId, PaymentCrDetailModel model);
        int UpdatePaymentCredit(PaymentCrDetailModel model);
        void DeletePaymentCredit(int id);

        int AddPaymentOther(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId);
        void DeletePaymentOther(int id);

        int AddProductList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId);
        int AddDiscountList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId);
        void DeleteProductList(int id,string docCode);

        void ClearProductListTemp(string docCode, string docNo, string branchNo, string refDocno);
        ProductModel[] GetPromotionGiveDTResult(string promotionId);

       
    }
}
