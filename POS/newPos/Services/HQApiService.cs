using newPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace newPos.Services
{
    public class HQApiService
    {
        public HQApiService()
        {

        }
        public ResultCouponModel CheckCoupon(string CouponCode, string DealerCode,string DocNo,string RootURL)
        {
            try
            {
                //    var PathGenRealized = AppSetting.PathGenRealized;
                CouponCode = CouponCode == "" ? "0" : CouponCode;
                string apiURL = RootURL + "/api/CouponApi/CheckCoupon?CouponCode=" + CouponCode + "&DealerCode=" + DealerCode + "&DocNo=" + DocNo;
                HttpClient client = new HttpClient();
                var stringContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.GetAsync(apiURL).Result;
           //     string responseString = response.Content.ReadAsStringAsync();
                var returnData = response.Content.ReadAsAsync<ResultCouponModel>().Result;
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}