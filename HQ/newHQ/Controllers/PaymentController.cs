using CentralService.Injection;
using CentralService.Models;
using newHQ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newHQ.Controllers
{
    public class PaymentController : JsonResponseController
    {
        private IPaymentService _service;
        private IDropDownService _dropDownService;

        public PaymentController(IPaymentService service, IDropDownService dropDownService)
        {
            _service = service;
            _dropDownService = dropDownService;
        }
        // GET: Payment
        public ActionResult Index(string docCode, string docNo, string refDocno, string dpDocno)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var model = _service.Get(docCode, docNo, Session["branchNo"].ToString(), refDocno, dpDocno, Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
            model.PaymentIconList = new List<PaymentIconModel>
            {
                new PaymentIconModel{
                    Name = "เงินสด",
                    ImgName = "icon-01.png",
                    ModalId = "cashModal"
                },
                new PaymentIconModel
                {
                    Name = "เครดิตการ์ด",
                    ImgName = "icon-02.png",
                    ModalId = "creditCardModal"
                },
                new PaymentIconModel
                {
                    Name = "เครดิต EDC",
                    ImgName = "icon-03.png",
                    ModalId = "creditEdcModal"
                },
                new PaymentIconModel
                {
                    Name = "เงินมัดจำ",
                    ImgName = "icon-04.png",
                    ModalId = "depositModal"
                },
                new PaymentIconModel
                {
                    Name = "หัก ณ ที่จ่าย 3%",
                    ImgName = "icon-05.png",
                    ModalId = "deductibleModal"
                },
                new PaymentIconModel
                {
                    Name = "QR Code",
                    ImgName = "icon-06.png",
                    ModalId = "qrCodeModal"
                },
                new PaymentIconModel
                {
                    Name = "LAZADA",
                    ImgName = "icon-07.png",
                    ModalId = "lazadaModal"
                },
                new PaymentIconModel
                {
                    Name = "Blue Card",
                    ImgName = "icon-08.png",
                    ModalId = "blueCardModal"
                }
            };

            return ViewPartial(model);
        }

        [HttpPost]
        public ActionResult Index(PaymentModel model)
        {
            var AspFile = "";
            switch (model.DocCode)
            {
                case "2103":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_abb_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}&trans_type=&trans_no=";
                    else
                        AspFile = $"rt_abb_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    break;
                case "A301":
                    if (!string.IsNullOrWhiteSpace(model.RefDocNo))
                    {
                        if (model.Cancel)
                            AspFile = $"payment_cancel.asp?link=rt_pay_edit_pay.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                        else
                            AspFile = $"rt_pay_edit_pay.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                        break;
                    }
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_pay_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_pay_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    break;
                case "A302":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_dp_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_dp_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    break;
                case "A401":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_return_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}&trans_type=&trans_no=";
                    else
                        AspFile = $"rt_return_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    break;
                case "T101":
                case "T102":
                case "T103":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_tmp_edit_pay.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_tmp_edit_pay.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    break;

                case "2101":
                case "2102":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_inv_edit_pay.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_inv_edit_pay.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    break;
                case "9301":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=deb_pay_new.asp?payment=unpayment&ven_code={model.VenderCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"deb_pay_new.asp?payment=payment&ven_code={model.VenderCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    break;
                case "9401":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=deb_return_new.asp?payment=unpayment&ven_code={model.VenderCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"deb_return_new.asp?payment=payment&ven_code={model.VenderCode}&doc_no={model.DocNo}&ref_docno=&cash_amt_real={model.TotalAmount}";
                    break;
            }

            _service.AddPaymentCash(model, Session["branchNo"].ToString(), "", (int)Session["gbUserId"]);

            return RedirectToAction("ClassicAsp", "Home", new { AspFile });
        }


        private ActionResult ViewPartial(object model)
        {
            BankDropDown();
            CardTypeDropDown();
            PaymentFormatDropDown();
            return View(model);
        }

        private void BankDropDown()
        {
            var model = _dropDownService.GetBank();
            var list = new SelectList(model, "Code", "Name");
            ViewBag.BankDropDown = list;
        }

        private void CardTypeDropDown()
        {
            var model = _dropDownService.GetCardType();
            var list = new SelectList(model, "Code", "Name");
            ViewBag.CardTypeDropDown = list;
        }

        private void PaymentFormatDropDown()
        {
            var model = _dropDownService.GetPaymentFormat();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.PaymentFormatDropDown = list;
        }

        public ActionResult AddDiscount(PromotionAndDiscountModal model)
        {
            var id = _service.AddPaymentOther(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
            return ResultRequest(id);
        }

        public ActionResult DeleteDiscount(int id)
        {
            _service.DeletePaymentOther(id);
            return SuccessRequest();
        }

        public ActionResult AddPaymentCredit(PaymentCrDetailModel model)
        {
            var id = _service.AddPaymentCredit(Session["branchNo"].ToString(), (int)Session["gbUserId"], model);
            return ResultRequest(id);
        }

        public ActionResult UpdatePaymentCredit(PaymentCrDetailModel model)
        {
            var id = _service.UpdatePaymentCredit(model);
            return ResultRequest(id);
        }

        public ActionResult DeletePaymentCredit(int id)
        {
            _service.DeletePaymentDeposit(id);
            return SuccessRequest();
        }

        public ActionResult GetDepositModels(string CustomerCode, string docNo)
        {
            var model = _service.GetDepositModels(CustomerCode, docNo);
            return ResultRequest(model);
        }

        public ActionResult AddPaymentDeposit(DepositModel model)
        {
            var id = _service.AddPaymentDeposit(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
            return ResultRequest(id);
        }

        public ActionResult DeletePaymentDeposit(int id)
        {
            _service.DeletePaymentDeposit(id);
            return SuccessRequest();
        }

        public ActionResult List()
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        public ActionResult GetDTResult(DTParameters dataTableRequestModel)
        {
            var model = _service.GetExtraDiscountDTResult(dataTableRequestModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateDiscount()
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var model = new ExtraDiscountIconModel
            {
                Code = _service.GetDocNo()
            };

            return DiscountViewPartial(model);
        }

        [HttpPost]
        public ActionResult CreateDiscount(ExtraDiscountIconModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return DiscountViewPartial(model);
            }

            _service.CreateExtraDiscount(model);
            return RedirectToAction("List");

        }

        public ActionResult EditDiscount(int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = _service.GetExtraDiscount(id);
            return DiscountViewPartial(model);
        }

        [HttpPost]
        public ActionResult EditDiscount(ExtraDiscountIconModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return DiscountViewPartial(model);
            }

            _service.UpdateExtraDiscount(model);
            return RedirectToAction("List");
        }

        public ActionResult DeleteExtraDiscount(int id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            _service.DeleteExtraDiscount(id);
            return RedirectToAction("List");
        }

        private ActionResult DiscountViewPartial()
        {
            ProductGroupDropDown();
            CustomerGroupDropDown();
            return View();
        }

        private ActionResult DiscountViewPartial(object model)
        {
            ProductGroupDropDown();
            CustomerGroupDropDown();
            return View(model);
        }

        private void ProductGroupDropDown()
        {
            var model = _dropDownService.GetProductGroup();
            var list = new SelectList(model, "Code", "Name");
            ViewBag.ProductGroupDropDown = list;
        }

        private void CustomerGroupDropDown()
        {
            var model = _dropDownService.GetCustomerGroup();
            var list = new SelectList(model, "Code", "Name");
            ViewBag.CustomerGroupDropDown = list;
        }
    }
}