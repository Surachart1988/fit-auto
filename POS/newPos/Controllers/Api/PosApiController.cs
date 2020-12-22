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
    public class PosApiController : ApiController
    {
        private IDropDownService _dropDownService;
        private IEDCService _edcServ;

        public PosApiController(
                IDropDownService dropDownService,
                IEDCService edcServ
            )
        {
            _dropDownService = dropDownService;
            _edcServ = edcServ;
        }

        public IHttpActionResult Get()
        {
            return Ok(new { result = "Connected" });
        }

        public IHttpActionResult ConnectedEDC([FromBody] string comport)
        {
            var jresult = _edcServ.PortReady(comport);
            return Json(new
            {
                jresult
            });
        }
        public IHttpActionResult GetddlProvince()
        {
            var data = _dropDownService.GetProvince();
            return Json(data);
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

        public IHttpActionResult GetddlProdGrpCode()
        {
            var data = _dropDownService.GetProdFirstGrp();
            return Json(data);
        }
        public IHttpActionResult GetddlProGrpCode(string prodgrp_code)
        {
            var data = _dropDownService.GetProGrp(prodgrp_code);
            return Json(data);
        }
        public IHttpActionResult GetddlProBrandCode(string progroupCode)
        {
            var data = _dropDownService.GetProBrand(progroupCode);
            return Json(data);
        }
        public IHttpActionResult GetddlProModelCode(string probrandCode)
        {
            var data = _dropDownService.GetProModel(probrandCode);
            return Json(data);
        }
        public IHttpActionResult GetddlProSizeCode(string promodelCode)
        {
            var data = _dropDownService.GetProSize(promodelCode);
            return Json(data);
        }
    }
}
