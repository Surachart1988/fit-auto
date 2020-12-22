using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newHQ.Controllers.MasterData
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

        public ActionResult Create(string id = "", string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = new CampaignModel();
            if (id != "")
            {
                
                model = _service.Get(id);
                model.Mode = mode;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CampaignModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            try
            {
                string campaign_id = "edit";
                string delete = "true";
                if (ModelState.IsValid)
                {
                    if (_service.AddUpdate(model, campaign_id) > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "error");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        public ActionResult Delete(CampaignModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            return Json(_service.Delete(model.campaign_id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult checkNameCampaign(string campaign_name, string id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isExit = _service.checkNameCampaign(campaign_name, id);
            return Json(new
            {
                Message = isExit == true ? $"ชื่อแคมเปญ {campaign_name} นี้มีการใช้งานแล้ว" : "",
                Data = isExit
            }, JsonRequestBehavior.AllowGet);
        }
    }
}