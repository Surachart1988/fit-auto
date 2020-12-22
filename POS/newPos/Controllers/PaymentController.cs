using CentralService.Injection;
using CentralService.Models;
using newPos.Models;
using newPos.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace newPos.Controllers
{
    public class PaymentController : JsonResponseController
    {
        private IPaymentService _service;
        private IDropDownService _dropDownService;
        private ICashDrawerService _cashDservice;
        private CallBlueCardService _blueCardService;
        private HQApiService _hqService;
        private PrintService _printService;
        private SaveDataBlueCard _saveblueCardService;

        public PaymentController()
        {

        }

        public PaymentController(ICashDrawerService cashDservice, IPaymentService service, IDropDownService dropDownService, CallBlueCardService blueCardService, HQApiService hQApiService, PrintService printService)
        {
            _service = service;
            _cashDservice = cashDservice;
            _dropDownService = dropDownService;
            _blueCardService = blueCardService;
            _hqService = hQApiService;
            _printService = printService;
        }

        public ActionResult Index(string docCode, string docNo, string refDocno, string dpDocno)
        {


            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Clear Partial Payment
            SessionManager.ClearList<PartialPaymentModel>(Session);
            // Clear Coupon Use
            SessionManager.ClearList<PromotionAndDiscountModal>(Session);
            // set Payment type
            Session["PaymentType"] = "";
            Session["PartailPayment"] = "";
            Session["BlueCardRedeem"] = "";
            var model = _service.Get(docCode, docNo, Session["branchNo"].ToString(), refDocno, dpDocno, Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
            Session["UrlHQ"] = model.UrlHqService;

            model.PaymentIconList = new List<PaymentIconModel>
            {
                new PaymentIconModel{
                    Name = "เงินสด",
                    ImgName = "icon-01.png",
                    ModalId = "cashModal",
                    PartialPaymentShow = true
                },
                new PaymentIconModel
                {
                    Name = "เครดิตการ์ด",
                    ImgName = "icon-02.png",
                    ModalId = "creditCardModal",
                    PartialPaymentShow = true
                },
                new PaymentIconModel
                {
                    Name = "เครดิต EDC",
                    ImgName = "icon-03.png",
                    ModalId = "creditEdcModal",
                    PartialPaymentShow = true
                },
                //new PaymentIconModel
                //{
                //    Name = "เงินมัดจำ",
                //    ImgName = "icon-04.png",
                //    ModalId = "depositModal",
                //    GroubId = 1
                //},
                new PaymentIconModel
                {
                    Name = "หัก ณ ที่จ่าย 3%",
                    ImgName = "icon-05.png",
                    ModalId = "deductibleModal",
                    GroubId = 1
                },
                new PaymentIconModel
                {
                    Name = "QR Code",
                    ImgName = "icon-06.png",
                    ModalId = "qrCodeModal"
                },
                //new PaymentIconModel
                //{
                //    Name = "LAZADA",
                //    ImgName = "icon-07.png",
                //    ModalId = "lazadaModal"
                //},
                new PaymentIconModel
                {
                    Name = "Redeem Blue Card",
                    ImgName = "icon-08.png",
                    ModalId = "blueCardRedeemModal",
                    GroubId = 1,
                    PartialPaymentShow = true
                },
                  new PaymentIconModel
                {
                    Name = "Partial Payment",
                    ImgName = "ICON-PartialPayment.jpg",
                    ModalId = "PartialPayment",

                },
                   new PaymentIconModel
                {
                    Name = "PTTOR",
                    ImgName = "icon-PTTOR.png",
                    ModalId = "pttorModal",

                }
                   ,
                     new PaymentIconModel
                {
                    Name = "CDS",
                    ImgName = "icon-CDS.png",
                    ModalId = "cdsModal",

                },
                     new PaymentIconModel
                     {
                         Name = "Online Payment",
                         ImgName = "OnlinePayment.png",
                         ModalId = "OnlinePayment",

                     }
            };
            model.OnlinePaymentIconList = new List<PaymentIconModel>
            {
                new PaymentIconModel{
                    Name = "Lazada",
                    ImgName = "Lazada.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.Lazada,
                    PartialPaymentShow = true
                },
                new PaymentIconModel{
                    Name = "Shopee",
                    ImgName = "Shopee.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.Shopee,
                    PartialPaymentShow = true
                },
                new PaymentIconModel{
                    Name = "Alibaba",
                    ImgName = "Alibaba.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.Alibaba,
                    PartialPaymentShow = true
                },
                new PaymentIconModel{
                    Name = "JD Central",
                    ImgName = "JD.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.JDCentral,
                    PartialPaymentShow = true
                }
                ,
                new PaymentIconModel{
                    Name = "Rabbit Pay",
                    ImgName = "LinePay.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.RabbitLinePay,
                    PartialPaymentShow = true
                }
                ,
                new PaymentIconModel{
                    Name = "Wemall",
                    ImgName = "Wemall.png",
                    ModalId = "OnlinePaymentDetailModal",
                    PaymentTypeCode = Constants.OnlinePaymentTypeCode.Wemall,
                    PartialPaymentShow = true
                }

            };
            return ViewPartial(model);
        }

        [HttpPost]
        public ActionResult Index(PaymentModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var ListModel = SessionManager.GetList<PartialPaymentModel>(Session);
            model.ListPayment = ListModel;

            if (Session["PartailPayment"].ToString() == "")
            {
                model.PaymentType = Session["PaymentType"].ToString();
                if (model.PaymentType == "")
                    model.PaymentType = Constants.PaymentType.Cash;
            }
            else
            {
                model.PaymentType = Constants.PaymentType.PartailPayment;
            }

            if (model.Cancel)
            {
                SessionManager.ClearList<PromotionAndDiscountModal>(Session);
                SessionManager.Clear<PaymentModel>(Session);
                _service.ClearProductListTemp(model.DocCode, model.DocNo, Session["branchNo"].ToString(), model.RefDocNo);
                _service.CancelPaymentDeposit(model);
            }
            else
            {
                //====================== add Data Payment =====================================
                if (!model.Cancel)
                {
                    if (Session["BlueCardRedeem"]?.ToString() == "True")
                    {
                        _blueCardService.RedeemPoints(model, (int)Session["gbUserId"]);
                        SessionManager.Set<PaymentModel>(Session, model);
                        //_saveblueCardService.InsertLogVSmart("", "Log", null);
                    }

                    if (!string.IsNullOrWhiteSpace(model?.BlueCardSaveNo))
                    {
                        // ========================== set AccumulatePoints Blue Card =========================================
                        // var description = _blueCardService.AccumulatePoints(model, (int)Session["gbUserId"]);
                        model.BlueCardTransID = _blueCardService.AccumulatePoints(model, (int)Session["gbUserId"]);
                        //_saveblueCardService.InsertLogVSmart("", "Log", null);
                        SessionManager.Set<PaymentModel>(Session, model);
                    }
                    //   _service.AddPaymentCash(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);

                    // Save Log CouponLog
                    var ListCoupon = SessionManager.GetList<PromotionAndDiscountModal>(Session);
                    _service.AddCouponLog(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"], ListCoupon);

                    try
                    {
                        if (!(model.PaymentType == "Creditcard" || model.PaymentType == "Other"))
                        {
                            if (model.PaymentType == "PartailPayment")
                            {
                                if ((bool)Session["PaymentType"])
                                    _cashDservice.OpenCashDrawer();
                            }
                            else
                            {
                                _cashDservice.OpenCashDrawer();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteLog(e.ToString());
                    }

                }
            }

            var AspFile = "";
            switch (model.DocCode)
            {
                case "2103":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_abb_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}&trans_type=&trans_no=";
                    else
                        AspFile = $"rt_abb_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}," + _service.GetDocNo(model.RefDocNo);
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
                        AspFile = $"payment_cancel.asp?link=rt_tmp_view.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_tmp_edit_pay.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    break;

                case "2101":
                case "2102":
                    if (model.Cancel)
                        AspFile = $"payment_cancel.asp?link=rt_inv_new.asp?payment=unpayment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    else
                        AspFile = $"rt_inv_new.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
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
                case "PTTOR":
                    if (model.Cancel)
                        AspFile = $"rt_pttor_view.asp?payment=unpayment&cancel=cancel&doc_no={model.DocNo}";
                    else
                        AspFile = $"rt_tmp_edit_pay.asp?payment=payment&cus_code={model.CustomerCode}&doc_no={model.DocNo}&ref_docno={model.RefDocNo}&cash_amt_real={model.TotalAmount}";
                    //AspFile = $"send_data_client_to_hq.aspx?act=PTTOR&status=Add&doc_code={ model.DocCode}&doc_no={ model.DocNo }&ref_docno={model.RefDocNo}&user_id={Session["gbUserId"]}";
                    break;
            }
            //return RedirectToAction("Index", "Home");

            return RedirectToAction("ClassicAsp", "Home", new { AspFile });
        }

        #region Other

        public ActionResult ClearProductListTemp(string docCode, string docNo, string refDocNo)
        {
            _service.ClearProductListTemp(docCode, docNo, Session["branchNo"].ToString(), refDocNo);
            SessionManager.ClearList<PartialPaymentModel>(Session);
            Session["PartailPayment"] = "";
            return SuccessRequest();
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
            var list = new SelectList(model, "Code", "Name", "dfField1");
            ViewBag.CardTypeDropDown = list;
        }

        private void PaymentFormatDropDown()
        {
            var model = _dropDownService.GetPaymentFormat();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.PaymentFormatDropDown = list;
        }

        #endregion

        #region PaymentFunc

        public ActionResult CheckCouponDigit(string DocNo, string PromotionCode, string CouponGrp, string CouponDigit)
        {
            try
            {
                var result = _service.CheckUseCouponDigit(DocNo, PromotionCode, CouponGrp, CouponDigit);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CheckPromotionGive(List<PromotionAndDiscountModal> model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            try
            {
                var result = _service.CheckUsePromotionGive(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"], out var detail);

                return Json(new { result, detail }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddProduct(List<PromotionAndDiscountModal> model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            var productLists = _service.AddProductList(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
            return Json(productLists, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeletePromotion(int id, string docCode)
        {
            var delRows = _service.DeleteProductList(id, docCode);
            return Json(delRows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDiscount(PromotionAndDiscountModal model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            var id = 0;
            if (!string.IsNullOrEmpty(model.CouponCode))
            {
                var _couponId = model.CouponId == "" ? _service.GetCouponId(model.Code) : model.CouponId;
                var couponUse = new PromotionAndDiscountModal()
                {
                    CouponId = _couponId,
                    CouponCode = model.CouponCode,
                };

                SessionManager.AddItemToList<PromotionAndDiscountModal>(Session, couponUse);
            }

            id = _service.AddDiscountList(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"], model.CusTypeCode);

            Session["PaymentType"] = Constants.PaymentType.OtherDiscount;
            return ResultRequest(id);
        }
        public ActionResult DeleteDiscount(int id, string DocNo, string docCode, double money)
        {

            if (docCode == "PTTOR" || docCode == "T101" || docCode == "T102" || docCode == "T103" || docCode == "T104")
            {
                _service.DeletePttorDiscount(id, Session["branchNo"].ToString(), DocNo, money);
            }
            else
            {
                _service.DeleteProductList(id, docCode);
            }
            return SuccessRequest();
        }

        public ActionResult AddPaymentOther(PromotionAndDiscountModal model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            var id = _service.AddPaymentOther(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);

            Session["PaymentType"] = Constants.PaymentType.OtherPayment;
            return ResultRequest(id);
        }
        public ActionResult DeletePaymentOther(int id)
        {
            _service.DeletePaymentOther(id);
            return SuccessRequest();
        }

        public ActionResult AddPaymentCash(PaymentModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            try
            {
                _service.AddPaymentCash(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
                Session["PaymentType"] = Constants.PaymentType.Cash;
            }
            catch (Exception ex)
            {

            }


            return ResultRequest("00");
        }
        public ActionResult DeletePaymentCash(int id)
        {
            _service.DeletePaymentCash(id);
            return SuccessRequest();
        }

        public ActionResult AddPaymentCredit(PaymentCrDetailModel model)
        {
            var id = _service.AddPaymentCredit(Session["branchNo"].ToString(), (int)Session["gbUserId"], Session["dealerCode"].ToString(), model);
            Session["PaymentType"] = Constants.PaymentType.Creditcard;
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
            Session["PaymentType"] = Constants.PaymentType.Deposit;
            return ResultRequest(id);
        }

        public ActionResult DeletePaymentDeposit(int id)
        {
            _service.DeletePaymentDeposit(id);
            return SuccessRequest();
        }


        public ActionResult CheckEdcStatus(string docCode, string docNo, string url)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            var id = 0;
            string returnval = "";

            id = _service.CheckEdcStatus(docCode, docNo, Session["branchNo"].ToString(), url);

            return ResultRequest(id);
        }
        public ActionResult StartEdcCheck(string docCode, string docNo)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
            }
            int? id = 0;
            id = _service.StartEdcCheck(docCode, docNo, Session["branchNo"].ToString());
            if (id >= 2)
            {
                var ListModel = SessionManager.GetList<PartialPaymentModel>(Session);
                if (ListModel.Count > 0)
                {
                    //var _paylist = ListModel.FirstOrDefault();
                    //var _payTotal = _paylist?.PaymentTotal;
                    //var _moneyTotal = ListModel.Sum(x => x.Money);
                    //if ((_payTotal - _moneyTotal) <= 0)
                    //{
                    CheckSavePartialPayment(ListModel);
                    Session["PaymentType"] = ListModel.Any(a => a.PaymentType == "CashPayment");
                    //}
                }
                else
                {
                    Session["PaymentType"] = Constants.PaymentType.Creditcard;
                }
            }

            return ResultRequest(id);
        }

        #endregion

        #region PartialPayment
        private void CheckSavePartialPayment(List<PartialPaymentModel> ListModel)
        {
            try
            {

                foreach (var item in ListModel)
                {
                    switch (item.PaymentType)
                    {
                        case "CashPayment":
                            var model = new PaymentModel()
                            {
                                DocCode = item.DocCode,
                                DocNo = item.DocNo,
                                CashAmount = item.Money,
                                ChangeMoney = item.ChangeMoney,
                                FlagPartial = true,
                                PaymentCashNote = item.Note
                            };
                            _service.AddPaymentCash(model, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
                            break;
                        case "CreditPayment":
                            var modelCr = new PaymentCrDetailModel()
                            {
                                DocCode = item.DocCode,
                                DocNo = item.DocNo,
                                CardTypeCode = item.CardTypeCode,
                                CreditNumber = item.CreditNumber,
                                PaymentCr = item.PaymentCr,
                                PaymentFormatId = item.PaymentFormatId,
                                Note = item.Note,
                                ExpiredMonth = item.ExpiredMonth,
                                ExpiredYear = item.ExpiredYear,
                                CreditType = item.CreditType,
                                ApprCode = item.ApprCode,
                                BankCode = item.BankCode,
                                ConnectType = item.ConnectType
                            };
                            _service.AddPaymentCredit(Session["branchNo"].ToString(), (int)Session["gbUserId"], Session["dealerCode"].ToString(), modelCr);
                            break;
                        case "EDCPayment":
                            var modelEdc = new PaymentCrDetailModel()
                            {
                                DocCode = item.DocCode,
                                DocNo = item.DocNo,
                                CardTypeCode = item.CardTypeCode,
                                CreditNumber = item.CreditNumber,
                                PaymentCr = item.PaymentCr,
                                PaymentFormatId = item.PaymentFormatId,
                                Note = item.Note,
                                ExpiredMonth = item.ExpiredMonth,
                                ExpiredYear = item.ExpiredYear,
                                CreditType = item.CreditType,
                                ApprCode = item.ApprCode,
                                BankCode = item.BankCode,
                                ConnectType = item.ConnectType
                            };
                            _service.AddPaymentCredit(Session["branchNo"].ToString(), (int)Session["gbUserId"], Session["dealerCode"].ToString(), modelEdc);
                            break;
                        case "BlueCardPayment":

                            // Move to Payment Action
                            //var BlueCardModel = new PaymentModel()
                            //{
                            //    BlueCardSaveMobile = item.BlueCardMobile ?? "",
                            //    BlueCardCode = item.BlueCardNo,
                            //    RefDocNo = item.DocCode,
                            //    DocNo = item.DocNo,
                            //    BlueCardMoney = (decimal)item.Money
                            //};
                            //var respModel = _blueCardService.RedeemPoints(BlueCardModel, (int)Session["gbUserId"]);

                            var paymentOtherModel = new PromotionAndDiscountModal
                            {
                                Name = item.PaymentType,
                                Code = item.BlueCardNo,
                                DocNo = item.DocNo,
                                DocCode = item.DocCode,
                                Money = (double)item.Money,
                                Note = item.Note
                            };

                            var id = _service.AddPaymentOther(paymentOtherModel, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
                            break;
                    }

                    Session["PartailPayment"] = "true";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult MaintainPartialPayment(PartialPaymentModel Model)
        {
            var _Table = "";
            bool _Success = false;
            var ListModel = SessionManager.GetList<PartialPaymentModel>(Session);
            Model.PaymentTypeName = Model.PaymentTypesList.FirstOrDefault(x => x.Value == Model.PaymentType).Name;
            Model.Remark = Model.Remark ?? Model.Note;
            if (ListModel.Count <= 4)
            {
                //if (Model.Action == "Add")
                //{
                //    ListModel.Add(Model);
                //    SessionManager.ClearList<PartialPaymentModel>(Session);
                //    SessionManager.SetList<PartialPaymentModel>(Session, ListModel);
                //}
                //else if (Model.Action == "Edit")
                //{
                ListModel.Remove(ListModel.FirstOrDefault(x => x.PaymentType == Model.PaymentType));

                ListModel.Add(Model);
                SessionManager.ClearList<PartialPaymentModel>(Session);
                SessionManager.SetList<PartialPaymentModel>(Session, ListModel);
                //}
                //else if (Model.Action == "Del")
                //{
                //    ListModel.Remove(Model);
                //    SessionManager.ClearList<PartialPaymentModel>(Session);
                //    SessionManager.SetList<PartialPaymentModel>(Session, ListModel);
                //}
                _Table = RenderRazorViewToString(this.ControllerContext, "PartialPaymentTable", ListModel);
                _Success = true;
            }
            else
            {
                _Success = false;
            }

            var _PaymentSum = ListModel.Sum(x => x.Money);
            var _PaymentTotal = ListModel.FirstOrDefault().PaymentTotal;
            var _PaymentBalance = (_PaymentTotal - _PaymentSum);
            var _Money = Model.Money;
            //try
            //{
            //    _cashDservice.OpenCashDrawer();
            //}
            //catch (Exception ex)
            //{

            //}
            return Json(new
            {
                Success = _Success
                ,
                Money = _Money
                ,
                PaymentSum = _PaymentSum
                ,
                PaymentTotal = _PaymentTotal
                ,
                PaymentBalance = _PaymentBalance
                ,
                Table = _Table
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult PartialPaymentTable()
        {
            // var SessionModel = SessionManager.GetList<PartialPaymentModel>(Session);
            SessionManager.ClearList<PartialPaymentModel>(Session);
            var SessionModel = new List<PartialPaymentModel>();
            return PartialView(SessionModel);
        }
        public ActionResult CheckSavePartialPayment()
        {
            try
            {
                bool _Success = false;
                var _Message = "";

                var ListModel = SessionManager.GetList<PartialPaymentModel>(Session);
                var _paylist = ListModel.FirstOrDefault();
                var _payTotal = _paylist?.PaymentTotal;
                var _moneyTotal = ListModel.Sum(x => x.Money);
                if ((_payTotal - _moneyTotal) <= 0)
                {
                    CheckSavePartialPayment(ListModel); //<====== เมื่อมีการแบบจ่ายแบบแบ่งจ่าย (PartialPayment) ตัวนี้จะพาไปบึนทึกลง Database
                    _Success = true; Session["PaymentType"] = ListModel.Any(a => a.PaymentType == "CashPayment");
                }
                else
                {
                    _Success = false;
                }


                return Json(new { Success = _Success, Message = _Message, _UseBlueCard = ListModel.Any(a => a.PaymentType == "BlueCardPayment") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RenderRazorViewToString(ControllerContext controllerContext, String viewName, Object model)
        {
            controllerContext.Controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        #endregion

        public void DeleteDiscountCoupon()
        {

        }
        //public ActionResult GetPromotionGiveDTResult(string promotionId)
        //{
        //    var model = _service.GetPromotionGiveDTResult(promotionId);
        //    return ResultRequest(model);
        //}
        public string[] AddText(int j, int k, string[] ListData)
        {
            string[] result = { "", "" };
            var count = 0;
            for (int i = j; i <= k; i++)
            {

                result[0] += Convert.ToChar((Convert.ToInt32(ListData[i])));

                result[1] = (i - 5).ToString();
                count++;
            }
            return result;
        }
        public ActionResult SavePaymentCardEDC(string TxtData, string DocCode, string DocNo, string PaymentFormatId, string Note)
        {
            try
            {
                var model = new PaymentCrDetailModel();
                var ListData = TxtData.Split(',');
                #region forDecodeAscii
                for (int i = 0; i < ListData.Length - 1; i++)
                {

                    if (ListData[i] == "28")
                    {
                        var start_pos_check = ListData[i + 1];
                        var end_pos_check = ListData[i + 2];

                        if (start_pos_check == "48" && end_pos_check == "50")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 39), ListData: ListData);
                            model.ResponseText = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "48")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 68), ListData: ListData);
                            model.MerchantNameAndAddress = text[0];
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "48" && end_pos_check == "51")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 5), ListData: ListData);
                            model.TransactionDate = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "48" && end_pos_check == "52")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 5), ListData: ListData);
                            model.TransactionTime = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }

                        if (start_pos_check == "48" && end_pos_check == "49")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 5), ListData: ListData);
                            model.ApprovalCode = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "54" && end_pos_check == "53")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 5), ListData: ListData);
                            model.InvoiceNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "49" && end_pos_check == "54")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 7), ListData: ListData);
                            model.TerminalID = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "49")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 14), ListData: ListData);
                            model.MerchantID = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "50")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 14), ListData: ListData);
                            model.CardIssuerName = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "51" && end_pos_check == "48")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 15), ListData: ListData);
                            model.CardNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "51" && end_pos_check == "49")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 3), ListData: ListData);
                            model.CardExpiryDateYYMM = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "53" && end_pos_check == "48")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 5), ListData: ListData);
                            model.BatchNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "51")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 11), ListData: ListData);
                            model.ReferenceNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "52")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 1), ListData: ListData);
                            model.CardIssuerID = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "68" && end_pos_check == "53")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 25), ListData: ListData);
                            model.CardHolderName = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "52" && end_pos_check == "48")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 11), ListData: ListData);
                            model.Amount = Convert.ToDecimal(text[0].Replace(" ", "")).ToString();
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "57" && end_pos_check == "54")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 11), ListData: ListData);
                            model.RedeemPoint = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "57" && end_pos_check == "55")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 11), ListData: ListData);
                            model.RedeemPoint = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "57" && end_pos_check == "56")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 11), ListData: ListData);
                            model.RedeemPointBalance = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "65" && end_pos_check == "48")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 25), ListData: ListData);
                            model.CustomerName = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "65" && end_pos_check == "49")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 41), ListData: ListData);
                            model.CustomerAddress = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "65" && end_pos_check == "50")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 12), ListData: ListData);
                            model.CustomerTAXID = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "65" && end_pos_check == "51")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 4), ListData: ListData);
                            model.CustomerBranchNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "65" && end_pos_check == "52")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 9), ListData: ListData);
                            model.CustomerCarLicense = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "84" && end_pos_check == "73")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 19), ListData: ListData);
                            model.TI = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                        if (start_pos_check == "66" && end_pos_check == "67")
                        {
                            var text = AddText(j: i + 5, k: (i + 5 + 15), ListData: ListData);
                            model.PTTBlueCardNumber = text[0].Replace(" ", "");
                            i = int.Parse(text[1]);
                        }
                    }

                }
                #endregion


                model.DocCode = DocCode;
                model.DocNo = DocNo;
                model.CardTypeCode = model.CardIssuerName;
                model.CreditType = model.CardIssuerName;
                model.CreditNumber = model.CardNumber;
                if (model.Amount == "") model.Amount = "1";
                model.Amount = (Convert.ToDouble(model.Amount) / 100).ToString();
                model.PaymentCr = Convert.ToDouble(model.Amount) / 100;
                model.PaymentFormatId = PaymentFormatId == "" ? 0 : Convert.ToInt32(PaymentFormatId);
                model.Note = Note;
                if (model.CardExpiryDateYYMM == "") model.CardExpiryDateYYMM = "0000";
                model.ExpiredYear = Convert.ToInt32(model.CardExpiryDateYYMM.Substring(0, 2));
                model.ExpiredMonth = Convert.ToInt32(model.CardExpiryDateYYMM.Substring(2, 2));
                model.ApprCode = model.ApprovalCode;
                model.BankCode = "";
                model.ConnectType = "EDC";

                model.S_ExpiredYear = model.CardExpiryDateYYMM.Substring(0, 2);
                model.S_ExpiredMonth = model.CardExpiryDateYYMM.Substring(2, 2);
                // ======================== Add To table ST_PayCard ====================================
                _service.AddPaymentCredit(Session["branchNo"].ToString(), (int)Session["gbUserId"], Session["dealerCode"].ToString(), model);

                // ======================== Add To table ST_PayCard_Log ====================================

                _service.AddPayCardLog(Session["branchNo"].ToString(), (int)Session["gbUserId"], Session["dealerCode"].ToString(), model);

                Session["PaymentType"] = Constants.PaymentType.Creditcard;

                return Json(new { data = model }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { message = "ระบบบันทึกรายการไม่สำเร็จ" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CheckCoupon(string CouponCode, string DocNo)
        {
            try
            {
                var DealerCode = Session["dealerCode"].ToString();
                var UrlHQ = Session["UrlHQ"].ToString();
                var coupon = _hqService.CheckCoupon(CouponCode, DealerCode, DocNo, UrlHQ);
                return Json(new { Coupon = coupon }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Coupon = "False" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ProcessEdc()
        {
            return View();
        }
        public ActionResult OpenEdc()
        {
            //ViewBag.Msg = ViewBag.Message; // Assigned value : "Hi, Dot Net Tricks"
            return View("CreditEdcModal");
        }
        public ActionResult GetEdcForConnect()
        {
            try
            {

                // var tmp = _service.GetEdcReceive();

                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetEdcReceive(string status = null)
        {
            try
            {
                var tmp = new LogEdcModel();
                if (status == "1")
                {
                    var count = 0;
                    while (tmp?.Status == null)
                    {
                        count++;
                        tmp = _service.GetEdcReceive();
                        if (count > 400)
                        {
                            tmp.Status = false;
                            break;
                        }
                    }
                }
                else
                {
                    tmp = _service.GetEdcReceive();
                }
                return Json(new { data = tmp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult AddEdcReceive(LogEdcModel model)
        {
            try
            {
                if (model.receive_edc != null)
                {
                    // if(model.receive_edc.Length < 700)
                }
                _service.AddEdcReceive(model);

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Fail", JsonRequestBehavior.AllowGet);
            }

        }

    }
}