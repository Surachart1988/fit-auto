using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
    public interface IPaymentService
    {
        int CheckEdcStatus(string docCode, string docNo, string BranchNo,string url);
        int? StartEdcCheck(string docCode, string docNo, string BranchNo);
        PaymentModel Get(string docCode, string docNo, string branchNo, string refDocno, string dpDocno, string dealerCode, int userId);
        string GetDocNo(string refDocNo);

        DTResult<ExtraDiscountIconModel> GetExtraDiscountDTResult(DTParameters dataTableRequestModel);
        ExtraDiscountIconModel GetExtraDiscount(int id);
        void CreateExtraDiscount(ExtraDiscountIconModel model);
        void UpdateExtraDiscount(ExtraDiscountIconModel model);
        void DeleteExtraDiscount(int id, string DocNo, string docCode, double money);

        void DeletePttorDiscount(int id, string BranchNo, string doc_no, double DiscountAmt);
        void AddPaymentCash(PaymentModel model, string branchNo, string dealerCode, int userId);

        List<DepositModel> GetDepositModels(string CustomerCode, string docNo);
        int AddPaymentDeposit(DepositModel model, string branchNo, string dealerCode, int userId);
        void DeletePaymentDeposit(int id);

        void CancelPaymentDeposit(PaymentModel model);

        int AddPaymentCredit(string branchNo, int userId, string dealerCode, PaymentCrDetailModel model);
        int AddPayCardLog(string branchNo, int userId, string dealerCode, PaymentCrDetailModel model);
        int UpdatePaymentCredit(PaymentCrDetailModel model);
        void DeletePaymentCredit(int id);

        int AddPaymentOther(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId);
        void DeletePaymentOther(int id);
        void DeletePaymentCash(int id);
        List<PromotionDiscountProductList> AddProductList(List<PromotionAndDiscountModal> model, string branchNo, string dealerCode, int userId);
        int CheckUsePromotionGive(List<PromotionAndDiscountModal> model, string branchNo, string dealerCode, int userId,out PromotionAndDiscountModal detail);
        int AddDiscountList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId, string CustType);
        int DeleteProductList(int id, string docCode);

        void ClearProductListTemp(string docCode, string docNo, string branchNo, string refDocno);
        //ProductModel[] GetPromotionGiveDTResult(string promotionId);

        LogEdcModel GetEdcReceive();

        void AddEdcReceive(LogEdcModel model);

        void AddCouponLog(PaymentModel model, string branchNo, string dealerCode, int userId, List<PromotionAndDiscountModal> CouponList);

        string GetCouponId(string PromotionCode);

        int CheckUseCouponDigit(string DocNo, string PromotionCode, string CouponGrp, string CouponDigit);
    }
}
