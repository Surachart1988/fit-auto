using CentralService.Injection;
using CentralService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace newPos.Controllers.Api
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TransfersController : ApiController
    {
        private ITransferDataService _tranferdata;

        public TransfersController(
            ITransferDataService tranferdata
            )
        {
            _tranferdata = tranferdata;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        public IHttpActionResult Post(TransferDetail token)
        {
            var result = _tranferdata.GetData(token);
            _tranferdata.TransferLog(result);

            var response = new HttpResponseMessage { StatusCode = HttpStatusCode.Created };
            return ResponseMessage(response);
        }

        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
