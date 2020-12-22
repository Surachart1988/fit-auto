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
    public class HQApiController : ApiController
    {
        private IDropDownService _dropDownService;
        public HQApiController(
            IDropDownService dropDownService
            )
        {
            _dropDownService = dropDownService;
        }
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Connected" });
        }

        public IHttpActionResult GetddlAmphur(int province_id)
        {
            var data = _dropDownService.GetAmphur(province_id);
            return Json(data);
        }

        public IHttpActionResult GetddlTumbol(int amphur_id, int province_id)
        {
            var data = _dropDownService.GetTambol(amphur_id, province_id);
            return Json(data);
        }

        public IHttpActionResult GetddlZipCode(int amphur_id, int province_id)
        {
            var data = _dropDownService.GetZipCode(amphur_id, province_id);
            return Json(data);
        }

    }
}
