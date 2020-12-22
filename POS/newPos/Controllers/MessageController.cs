using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newPOS.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _service;

        public MessageController(IMessageService messageService)
        {
            _service = messageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDTResult(DTParameters dataTableRequestModel, int docType = 0)
        {
            var model = _service.GetDTResult(dataTableRequestModel, docType);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private void MessageStatusDropDown()
        {
            var model = _service.GetMessageStatus();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.MessageStatusDropDown = list;
        }
    }
}