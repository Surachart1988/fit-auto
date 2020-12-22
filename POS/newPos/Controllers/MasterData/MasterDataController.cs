using CentralService.Injection;
using CentralService.Models;
using newPos.Models;
using newPos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace newPos.Controllers.MasterData
{
    public class MasterDataController : JsonResponseController
    {
        private IMasterDataModelService _service;

        public MasterDataController(IMasterDataModelService service)
        {
            _service = service;
        }

        public ActionResult Index(int menuid)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var model = new MasterDataModel
            {
                Id = menuid,
                menuHeadType = (SetmainHeadType)menuid,
                menuType = (SetmainType)menuid
            };
            switch (model.Id)
            {
                case 99:
                    _service.Get(model);
                    break;
            }

            return View(model);
        }
    }
}