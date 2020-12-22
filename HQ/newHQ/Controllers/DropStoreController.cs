using CentralService.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace newHQ.Controllers
{
    public class DropStoreController : JsonResponseApiController
    {
        private ITransferService _service;

        public DropStoreController(ITransferService service)
        {
            _service = service;
        }

        public IHttpActionResult Get(string docNo, string branchNo, string docCode)
        {
            _service.DropNumberStoke(docNo, branchNo, docCode);
            return SuccessRequest();
        }
    }
}
