﻿using CentralService.Injection;
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
    public class PushStoreController : JsonResponseApiController
    {
        private ITransferService _service;

        public PushStoreController(ITransferService service)
        {
            _service = service;
        }

        public IHttpActionResult Get(string docNo, string branchNo, string docCode)
        {
            _service.PushNumberStoke(docNo, branchNo, docCode);
            return SuccessRequest();
        }
    }
}
