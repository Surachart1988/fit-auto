using CentralService.Injection;
using CentralService.Models;
using newHQ.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace newHQ.Controllers
{
    public class SendClientController : JsonResponseController
    {
        private IBranchService _service;
        private ITransferDataService _tranferdata;
        public SendClientController(
            ITransferDataService tranferdata,
            IBranchService service)
        {
            _tranferdata = tranferdata;
            _service = service;
        }

        public ActionResult Index(string act)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View(new SendClientModel
            {
                act = act,
                BranchList = _service.GetDealers()
            });
        }

        [HttpPost]
        public async Task<ActionResult> Index(SendClientModel model)
        {
            if (model.BranchList.Any(a => a.IsCheck))
            {
                var dOject = _tranferdata.PrepareData(model);

                var result = await _tranferdata.SendData(dOject);

                _tranferdata.TransferLog(result, (int)Session["gbUserId"]);
                _tranferdata.SetSendClient(result);

                if (model.act.ToUpper().Contains("DETAIL"))
                {
                    var jresult = result.DealerList.First();
                    return Json(new
                    {
                        jresult.error_massage,
                        jresult.SendStatus
                    }, JsonRequestBehavior.AllowGet);
                }
                return PartialView("Success", result);
            }
            return RedirectToAction("Index");
        }
    }
}