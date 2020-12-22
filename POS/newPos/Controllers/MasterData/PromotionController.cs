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
    public class PromotionController : JsonResponseController
    {
        private IPromotionService _service;
        private IDropDownService _dropDownService;

        public PromotionController(IPromotionService service, IDropDownService dropDownService)
        {
            _service = service;
            _dropDownService = dropDownService;
        }

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
            var model = _service.GetlAll(dataTableRequestModel, searchModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PromotionDetail(string id = "", string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ExtraPromotionModel model = null;
            model = new ExtraPromotionModel();
            if (id != "")
            {
                model = _service.Get(id);
                if (model.pro_condition_time_id == 1)
                {
                    _service.GetConditionWeek(model);
                    model.pro_condition_time_detail = null;
                    _service.GetConditionMonth(model);
                }

                if (model.pro_condition_time_id == 2)
                {
                    _service.GetConditionMonth(model);
                    model.pro_condition_time_detail = null;
                    _service.GetConditionWeek(model);
                }

                if (model.pro_condition_time_id == 3)
                {
                    _service.GetConditionMonth(model);
                    _service.GetConditionWeek(model);
                }
            }
            else
            {
                model.pro_condition_time_id = 3; // defualt
                model.pro_group_used_id = 1; // defualt
                model.pro_give_type_id = 1; // defualt
                model.pro_type_id = 1;// defualt
                model.pro_price_id = 1;// defualt
                model.pro_discount_id = 1;// defualt
                _service.GetConditionWeek(model);
                _service.GetConditionMonth(model);
            }
            model.Mode = mode;
            _service.GetDealers(model);
            _service.GetPromotionList(model);

            model.CampaignList = _dropDownService.GetCampaign();

            return Step1ViewPartial(model);
        }

        public ActionResult ProCondition(string id = "", string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ExtraPromotionModel model = null;
            model = _service.Get(id);
            _service.GetCusType(model);
            _service.GetProTypeList(model);
            _service.GetProgroupFirstGroup(model);
            _service.GetProgroup(model, "", "");
            _service.GetProbrand(model, "", "");
            _service.GetPromodel(model, "", "");
            _service.GetProSize(model, "", "");
            _service.GetProduct(model, "", "", "", "", "", "");
            _service.GetProductGift(model, "");
            if (model.pro_group_used_id == 1)
            {
                if (!model.pro_give_same_buy)
                {
                    var giftprod = string.Join(",", model.ProdGiveList.Where(s => s.IsCheck).Select(s => s.pro_code).ToArray());
                    model.ProductsList.Where(w => giftprod.Contains(w.pro_code)).Select(s => { s.IsCheck = false; return s; }).ToList();
                }
            }

            _service.GetProGiveTypeList(model);
            _service.GetProPriceList(model);
            model.Mode = mode;
            return View(model);
        }

        private ActionResult Step1ViewPartial(object model)
        {
            return View(model);
        }

        public ActionResult GetProductitems(string id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = new ExtraPromotionModel();
            model = _service.Get(id);
            _service.GetPromotionitems(model);
            return PartialView("PromotionItems", model);
        }
    }
}