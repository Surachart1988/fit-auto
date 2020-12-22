using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.SystemData;
using System;
using System.Web.Mvc;

namespace newPos.Controllers.SystemData
{
    public class BranchController : Controller
    {
        private IBranchService _service;
        private IDropDownService _dropDownService;


        public BranchController(
            IBranchService service,
            IDropDownService dropDownService
            )
        {
            _service = service;
            _dropDownService = dropDownService;
        }

        // GET: Branch
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
            return Json(_service.GetlAll(dataTableRequestModel, searchModel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int id = 0, string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = new BranchModel();
            model = _service.Get(id);
            model.Mode = mode;
            model.AddressModel._mode = mode;
            model.AddressModel.ProvinceList = _dropDownService.GetProvince();
            model.AddressModel.AmphurList = _dropDownService.GetAmphur(model.AddressModel.add_provid);
            model.AddressModel.TambolList = _dropDownService.GetTambol(model.AddressModel.add_amphur_id, model.AddressModel.add_provid);
            model.AddressModel.ZipCodeList = _dropDownService.GetZipCode(model.AddressModel.add_amphur_id, model.AddressModel.add_provid);
            return View(model);
        }

        public ActionResult Configs(int id = 0)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            SystemModel model = _service.GetConfigs(id);
            model.PrinterList = _dropDownService.GetPrinterCom();
            model.LocatList = _dropDownService.GetLocation();
            return View(model);
        }

        [HttpPost]
        public ActionResult Configs(SystemModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (_service.UpdateConfigs(model) > 0)
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

        public ActionResult checkDealerCode(string dealercode, int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isExit = _service.CheckDealers(dealercode, id);
            return Json(new
            {
                Message = isExit == true ? $"รหัสสาขา {dealercode} นี้มีการใช้งานแล้ว" : "",
                Data = isExit
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult checkPlantNo(string plant_no, int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isExit = _service.CheckPlantNo(plant_no, id);
            return Json(new
            {
                Message = isExit == true ? $"เลข PLANT No. {plant_no} นี้มีการใช้งานแล้ว" : "",
                Data = isExit
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult checkSOLDTO(string sold_to, string ship_to, int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isExit = _service.CheckSSCode(sold_to + ship_to, id);
            return Json(new
            {
                Message = isExit == true ? $"เลข SOLD_TO {sold_to} นี้มีการใช้งานแล้ว" : "",
                Data = isExit
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult checkSHIPTO(string sold_to, string ship_to, int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var isExit = _service.CheckSSCode(sold_to + ship_to, id);
            return Json(new
            {
                Message = isExit == true ? $"เลข SHIP_TO {ship_to} นี้มีการใช้งานแล้ว" : "",
                Data = isExit
            }, JsonRequestBehavior.AllowGet);
        }
    }
}