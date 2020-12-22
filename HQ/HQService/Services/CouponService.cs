using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HQService.HQServiceUnityExtension;
using System.Data.SqlClient;


namespace HQService.Services 
{
   
  public  class CouponService 
    {
        private HQEntities _db = new HQEntities();
      //  private Mapper _mapper;
      //  private DocService _docService;

        public CouponService()
        {
          
        }
        public ResultCouponModel CheckCouponById(string CouponCode, string Dealercode, string DocNo)
        {
            ResultCouponModel model = new ResultCouponModel();
            SqlParameter _CouponCode = new SqlParameter("@coupon_code", CouponCode);
            SqlParameter _Dealercode = new SqlParameter("@dealer_code", Dealercode);
            var Coupon =  _db.Database.SqlQuery<CheckCouponModel>("SP_CheckCoupon @coupon_code, @dealer_code", new[] { _CouponCode, _Dealercode }).FirstOrDefault();

             if(Coupon != null)
            {
                model.PromotionCode = Coupon.pro_id;
                model.PromotionName = Coupon.pro_name;
                model.AllowMutiPromotion = Coupon.allow_muti_promotion;
                model.AllowMutiVoucher = Coupon.allow_muti_voucher;
                model.DiscountAmount = Coupon?.coupon_value_amount;
                model.DiscountPercen = Coupon?.coupon_value_percent;
                model.CanUseCoupon = Coupon.can_use_coupon;
                //if (Coupon.pro_price_id == 1)
                //{

                //}
                //else if(Coupon.pro_price_id == 2)
                //{

                //}else if(Coupon.pro_price_id == 3)
                //{
                //    var sum_amt = _db.ST_Jobdetail.Where(x => x.doc_no == DocNo && x.dealercode == Dealercode).Sum(x => x.pro_amt);
                //    double pro_price_total = Convert.ToDouble(Coupon.pro_price_total);
                //    if (sum_amt>= pro_price_total)
                //    {
                //        model.CanUseCoupon = "true";
                //    }
                //}
            }

            return model;
        }
    }
}
