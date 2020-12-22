using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentralService.Injection;
using CentralService.Models;
using System.Web.Mvc;
using CentralService.Models.Sale;

namespace newPos.Controllers.Sale
{
    public class JobController : Controller
    {
        private IJobService _service;
        private IDropDownService _dropDownService;


        public JobController(
            IJobService service,
            IDropDownService dropDownService
            )
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
            return Json(_service.GetlAll(dataTableRequestModel, searchModel), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJOrderCode(string doc_code = "J301", string doc_no = "JEW")
        {
            return Json(_service.GetJOrderCode(doc_code, doc_no), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJobOrder(string doc_no = "")
        {
            return Json(_service.GetJobOrder(doc_no), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(string doc_no = "", string mode = "")
        {
            return View(_service.Get(doc_no));
        }

        public ActionResult AddProductJobOrder(JobTempModel model, string doc_code = "J301")
        {
            return Json(_service.AddProductJobOrder(model, doc_code), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddProductSetJobOrder(List<ProductSetDetailModel> model, string doc_no, string doc_code = "J301")
        {
            return Json(_service.AddProductSetJobOrder(model, doc_no, doc_code), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProductJobOrder(JobTempModel model)
        {
            return Json(_service.DeleteProductJobOrder(model), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(JobModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            try
            {
                string doc_no = "";
                if (ModelState.IsValid)
                {
                    if (_service.AddUpdate(model, ref doc_no) > 0)
                    {
                        return RedirectToAction("Create", new { id = doc_no, mode = "v" });
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
