using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace newPos.Controllers.Api
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

        public IHttpActionResult GetddlSaleUnitCode()
        {
            var data = _dropDownService.GetddlSaleUnitCode();
            return Json(data);
        }

        public async Task<IHttpActionResult> ProductList([FromBody] ProductSearchModel model, [FromUri] string cus_code, [FromUri] string cus_type)
        {
            var result = await _productService.ProductList(model, cus_code, cus_type);
            return Json(result);
        }

        public IHttpActionResult ProductDetailList([FromBody] string pro_code, [FromUri] string cus_code, [FromUri] string cus_type)
        {
            var result = _productService.ProductDetailList(pro_code, cus_code, cus_type);
            return Json(result);
        }

        public IHttpActionResult ProductSetList([FromBody] ProductSearchModel model)
        {
            var result = _productService.ProductSetList(model);
            return Json(result);
        }

        public IHttpActionResult ProductSetDetailList([FromUri] int ps_gen_id, [FromUri] string ps_code)
        {
            var result = _productService.ProductSetDetailList(ps_code, ps_gen_id);
            return Json(result);
        }
    }
}
