using CentralService.Injection;
using CentralService.Models;
using newPos.BlueCardService;
using newPos.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace newPos.Controllers
{
    public class BlueCardController : JsonResponseController
    {
        private CallBlueCardService _service;
        private IPaymentService _paymentService;
        private SaveDataBlueCard _saveDataBlueCard;
        public BlueCardController(CallBlueCardService service, IPaymentService paymentService, SaveDataBlueCard saveDataBlueCard)
        {
            _service = service;
            _paymentService = paymentService;
            _saveDataBlueCard = saveDataBlueCard;

        }

        // GET: BlueCard
        public ActionResult Index()
        {
            return View();
        }
        // ตรวจสอบหมายเลขโทรศัพท์ที่ลงทะเบียนไว้
        public ActionResult Get(string phoneNumber)
        {
            try
            {
                var cardNo = _service.GetCardNo(phoneNumber);

                if (string.IsNullOrWhiteSpace(cardNo))
                {
                    return ServerError("404", "ไม่พบเบอร์โทรนี้ในระบบ กรุณาใชับัตรเพื่อสะสมคะแนน และแจ้งลูกค้าติดต่อ 1365");
                }
                else
                {
                    return ResultRequest(cardNo);
                }
            }
            catch (Exception ex)
            {
                return ServerError("404", "ไม่สามารถเชื่อมต่อ Blue Card Service ได้");
            }
        }
        public ActionResult GetCardActivated(string cardnumber)
        {
            try
            {
                var desc = _service.CheckCardIsActivated(cardnumber);

                if (!string.IsNullOrWhiteSpace(desc))
                {
                    return ServerError("404", desc);
                }
                else
                {
                    return ResultRequest(cardnumber);
                }
            }
            catch (Exception ex)
            {
                return ServerError("404", "ไม่สามารถเชื่อมต่อ Blue Card Service ได้");
            }
        }
        // ดูคะแนน
        public ActionResult GetPointBalance(string phoneNumber, string cardNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cardNo))
                    cardNo = _service.GetCardNo(phoneNumber);

                var respModel = _service.GetPointBalance(phoneNumber, cardNo);

                if (!string.IsNullOrWhiteSpace(respModel.SystemData.Description))
                {
                    return ServerError("500", respModel.SystemData.Description);
                }
                else
                {
                    var result = new object();
                    var redeemConfig = _service.GetRedeemSetting();
                    if (redeemConfig != null)
                    {

                        result = new
                        {
                            cardNo,
                            //ExRateby = redeemConfig.BlueCard_exchange_rateby,
                            pointBalance = respModel.CustomData.Point_Balance,
                            MinRedeemPoint = redeemConfig.BlueCard_exchange_rateby ? respModel.CustomData.MIN_Redeem_Point : redeemConfig.BlueCard_MinimumRewardPoint,
                            RatioPoint = redeemConfig.BlueCard_exchange_rateby ? respModel.CustomData.Ratio_Point : (ValueType)redeemConfig.BlueCard_Ratio_Point,
                            //BlueCard_RewardPoint = redeemConfig.BlueCard_RewardPoint,
                            //BlueCard_Money = redeemConfig.BlueCard_Money
                        };
                    }
                    else
                    {
                        result = new
                        {
                            cardNo,
                            //ExRateby = false,
                            pointBalance = respModel.CustomData.Point_Balance,
                            MinRedeemPoint = respModel.CustomData.MIN_Redeem_Point,
                            RatioPoint = respModel.CustomData.Ratio_Point,
                            //BlueCard_RewardPoint = 0,
                            //BlueCard_Money = 0
                        };
                    }
                    //Session["BlueCardRedeem"] = "True";
                    return ResultRequest(result);
                }
            }
            catch (Exception ex)
            {
                return ServerError("404", "ไม่สามารถเชื่อมต่อ Blue Card Service ได้");
            }

        }
        // ใช้แต้มแลก
        public ActionResult RedeemPoints(PaymentModel model, string paymentType, string note)
        {
            try
            {
                if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
                {
                    return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
                }

                //var respModel = _service.RedeemPoints(model, (int)Session["gbUserId"]);

                //if (!string.IsNullOrWhiteSpace(respModel.SystemData.Description))
                //{
                //    return ServerError("500", respModel.SystemData.Description);
                //}
                //else
                //{
                var paymentOtherModel = new PromotionAndDiscountModal
                {
                    Name = paymentType,
                    Code = model.BlueCardNo,
                    DocNo = model.DocNo,
                    DocCode = model.DocCode,
                    Money = (double)model.BlueCardMoney,
                    Note = note
                };

                // var id = _paymentService.AddPaymentOther(paymentOtherModel, Session["branchNo"].ToString(), Session["dealerCode"].ToString(), (int)Session["gbUserId"]);
                Session["PaymentType"] = Constants.PaymentType.BlueCard;
                Session["BlueCardRedeem"] = "True";


                return ResultRequest("1");
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return Json(new { Code = "500", Message = "ไม่สามารถบันทึกรายการ Blue Card ได้" }, JsonRequestBehavior.AllowGet);
            }
        }
        // สมัคร blue Card
        public ActionResult RegisterBlueCard(RegisterBlueCardModel viewModel)
        {
            try
            {
                if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
                {
                    return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
                }
                viewModel.MoblieNumber = viewModel.MoblieNumber.Replace("-", "");
                viewModel.ThaiIDCard = viewModel.ThaiIDCard.Replace("-", "");
                viewModel.CardNumber = viewModel.CardNumber.Replace("-", "");

                var respModel = _service.PostRegisterBlueCard(viewModel);

                if (!string.IsNullOrWhiteSpace(respModel.SystemData.Description))
                {
                    return ServerError("500", respModel.SystemData.Description);
                }
                else
                {
                    return Json(new { Code = "00", Message = "Success" }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                // throw ex;
                return Json(new { Success = false, Message = "ตรวจสอบการเชื่อมต่อ VPN " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // บันทึก เปิด-ปิด batch blue Card สิ้นวัน 
        public ActionResult OpenOrClodeBatchBlueCardDayEnd(bool FlageOpen, decimal MoneyDefault = 0)
        {
            try
            {
                var code = "";
                if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
                {
                    return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
                }
                var gbUserId = Convert.ToInt32(Session["gbUserId"] ?? 0);
                var _Message = "";


                if (FlageOpen)
                {
                    // get LastBatch Blue ard
                    //  _service.GetDataSystemBlueCard(gbUserId);
                    _Message = _service.OpenBatchBlueCard(gbUserId, MoneyDefault);

                }
                else
                {
                    _Message = _service.VerifyDayEndPOS(gbUserId);
                    // Update Stored Close Batch Blue Card
                    if (string.IsNullOrEmpty(_Message))
                    {
                        _Message = _service.TrytoOpenNewBatch(gbUserId);
                    }
                }

                // ถ้ามี massage แสดงว่าไม่ผ่าน ถ้าผ่าน code = 00
                code = _Message == "" ? "00" : "";

                return Json(new { Code = code, Message = _Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Code = "", Message = "กรุณาตรวจสอบ VPN Blue Card" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ClodeBatchBlueCardDayEnd(bool FlageOpen, string userId, decimal MoneyDefault = 0)
        {
            try
            {
                var code = "";
                var gbUserId = Convert.ToInt32(userId);
                var _Message = "";


                if (FlageOpen)
                {
                    // get LastBatch Blue ard
                    //  _service.GetDataSystemBlueCard(gbUserId);
                    _Message = _service.OpenBatchBlueCard(gbUserId, MoneyDefault);

                }
                else
                {
                    _Message = _service.VerifyDayEndPOS(gbUserId);
                    // Update Stored Close Batch Blue Card

                }

                // ถ้ามี massage แสดงว่าไม่ผ่าน ถ้าผ่าน code = 00
                code = _Message == "" ? "00" : "";

                return Json(new { Code = code, Message = _Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Code = "", Message = "กรุณาตรวจสอบ VPN Blue Card" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CheckRegisterBlueCard(string TypeCheck, string IDCheck, string ThaiID = "")
        {
            var Success = false;
            var Message = "";
            IDCheck = IDCheck.Replace("-", "");
            try
            {
                var response = new POSUI();
                if (TypeCheck == Constants.BlueCardTypeCheck.ThaiID)
                {
                    response = _service.CheckDupCitizenID(IDCheck);
                    if (response?.SystemData?.ReturnCode == "00")
                    {
                        Success = true;
                    }
                    else
                    {
                        Message = response?.SystemData?.Description;
                    }
                }
                else if (TypeCheck == Constants.BlueCardTypeCheck.BlueCardCode)
                {
                    response = _service.CheckDupCardNo(IDCheck);
                    if (response?.SystemData?.ReturnCode != "00")
                    {
                        Success = true;
                    }
                    else
                    {
                        Message = "บัตรนี้มีการเปิดใช้แล้ว";
                    }

                }
                else if (TypeCheck == Constants.BlueCardTypeCheck.PhoneNumber)
                {
                    response = _service.CheckDupPhoneNo(IDCheck, ThaiID);
                    if (response?.SystemData?.ReturnCode == "00")
                    {
                        Success = true;
                    }
                    else
                    {
                        Message = response?.SystemData?.Description;
                    }
                }


                return Json(new { Success, Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success, Message = "ไม่สามารถเชื่อต่อ Blue Card ได้" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ReSendOrderBlueCard()
        {
            try
            {
                var code = "";
                if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
                {
                    return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
                }
                var gbUserId = Convert.ToInt32(Session["gbUserId"] ?? 0);
                var _Message = "";

                _Message = _service.ReSendOrderBlueCard();
                var _CountNotSuccess = _service.GetCountTransationNotSuccess((int)Session["gbUserId"]);
                // ถ้ามี massage แสดงว่าไม่ผ่าน ถ้าผ่าน code = 00
                code = _Message == "" ? "00" : "";

                return Json(new { Code = code, Message = _Message, CountNotSuccess = _CountNotSuccess }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Code = "", Message = "กรุณาตรวจสอบ VPN Blue Card" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TryToConnectBlueCardGateWay()
        {
            try
            {
                var code = "";
                if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
                {
                    return ServerError("403", "Session Timeout:กดเพื่อเข้าระบบใหม่");
                }
                var gbUserId = Convert.ToInt32(Session["gbUserId"] ?? 0);
                var _Message = "";

                _Message = _service.TestSendData();
                code = _Message == "" ? "00" : "";

                return Json(new { Code = code, Message = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Code = "", Message = "กรุณาตรวจสอบ VPN Blue Card" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}