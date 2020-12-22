using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newPos.Controllers.MasterData
{
    public class VendorController : Controller
    {
        private IVendorService _service;
        private IDropDownService _dropDownService;
        public VendorController(
                IVendorService service,
                IDropDownService dropDownService
           )
        {
            _service = service;
            _dropDownService = dropDownService;
        }
        // GET: Vendor
        public ActionResult Index()
        {
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
            DateTime datenow = DateTime.Now;
            var model = new VendorModel();
            model.vender_type = "1";
            if (id != "")
            {
                model = _service.Get(id);
                model.Mode = mode;
            }
            if (model.ven_balance == null)
            {
                model.ven_balance = 0.00;
            }
            model.VattypeList = _dropDownService.GetVattype();
            model.BvatList = _dropDownService.GetBvat();
            return View(model);
        }
    }
}