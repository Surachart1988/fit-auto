using newHQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace newHQ.Controllers
{
    public class JsonResponseController : Controller
    {
        public ActionResult ServerError()
        {
            return Json(new ResponseModel() { Code = "02", Message = "Server error." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServerError(string code, string message)
        {
            return Json(new ResponseModel() { Code = code, Message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SuccessRequest()
        {
            return Json(new ResponseModel() { Code = "00", Message = "Success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResultRequest<T>(T model)
        {
            return Json(new ResponseModel<T>
            {
                Code = "00",
                Message = "Success",
                Data = model
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidResponse<T>(T model)
        {
            return Json(new ResponseModel<T>
            {
                Code = "01",
                Message = "Valid",
                Data = model
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidResponse(ModelStateDictionary modelStates)
        {
            var response = new ResponseModel();

            foreach (var modelState in modelStates)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    var detail = new ResponseDetail
                    {
                        Code = "01",
                        Message = error.ErrorMessage == "" ? error.Exception.Message : error.ErrorMessage
                    };

                    response.Details.Add(detail);
                }
            }

            response.Code = "01";
            response.Message = "Field is required";

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
