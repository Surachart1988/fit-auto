using CentralService.Injection;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace newHQ.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ProductController : ApiController
    {
        private IDropDownService _dropDownService;
        private IProductService _productService;
        public ProductController(
            IDropDownService dropDownService,
            IProductService productService
            )
        {
            _dropDownService = dropDownService;
            _productService = productService;
        }

        public IHttpActionResult GetStockOnline(string pro_code, string state)
        {
            var result = _productService.GetStockOnline(pro_code, state);
            return Json(result);
        }
    }
}
