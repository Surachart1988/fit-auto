using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HQService.Services;
namespace newHQ.Controllers
{
    public class CouponApiController : ApiController
    {
    

        [HttpGet]
        public IHttpActionResult CheckCoupon(string CouponCode, string DealerCode, string DocNo)
        {
            CouponService _service = new CouponService();
            var result = _service.CheckCouponById(CouponCode, DealerCode, DocNo);
        
            return Ok(result);
        }
    }
}
