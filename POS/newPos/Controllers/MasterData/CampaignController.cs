using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData;
using CentralService.Models.MasterData.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newPos.Controllers.MasterData
{
    public class CampaignController : Controller
    {
        private ICampaignService _service;
        public CampaignController(
                ICampaignService service
           )
        {
            _service = service;
        }
        // GET: Campaign
        public ActionResult Index()
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }
        
        public ActionResult GetAll(DTParameters dataTableRequestModel, SearchModel searchModel)
        {
            TempData["data"] = null;
            var model = _service.GetlAll(dataTableRequestModel, searchModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }   
    }
}