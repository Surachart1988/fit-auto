using CentralService.Injection;
using CentralService.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newHQ.Controllers.MasterData
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
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null ||
                Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = new MasterDataModel
            {
                Id = menuid,
                menuHeadType = (SetMsDataHeadType)menuid,
                menuType = (SetMsDataType)menuid
            };
            switch (model.Id)
            {
                case 99:
                    _service.Get(model);
                    break;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MasterDataModel model)
        {
            int rows = 0;
            try
            {
                switch (model.Id)
                {
                    case 99:
                        rows = _service.SettingRedeemBlueCard(model, Session["branchNo"].ToString(), "",
                            (int)Session["gbUserId"]);
                        break;
                }

                if (rows > 0)
                {
                    return Json(new
                    {
                        success = true,
                        //Message = "บันทึกข้อมูลเรียบร้อย",
                        url = Url.Action("Index", new { menuid = (int)model.Id })
                    });
                }
                else
                {
                    return Json(new { success = false, response = "something wrong!" });
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, response = e.Message });
            }
            //return RedirectToAction("Index", new { menuid = (int)model.Id });
            //return View(model);

        }
    }
}