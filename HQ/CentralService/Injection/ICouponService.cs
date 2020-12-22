using System;
using System.Collections.Generic;
using System.Text;

namespace CentralService.Injection
{
   public interface ICouponService
    {

        string CheckCouponById(string CouponId);
    }
}
