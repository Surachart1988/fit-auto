using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CentralService.Injection;
using CentralService.Models;
using newPos.Models;
using newPos.Services;

namespace newPos.Controllers
{
    public class HomeController : JsonResponseController
    {
        private IDashboardService _dashboardService;
        private IMessageService _messageService;
        private IUserAccountService _userAccountservice;
        private ICustomerService _customerService;
        private CallBlueCardService _BlueCardService;
        private PrintService _printService;
        private ICashDrawerService _cashDservice;
        public HomeController(IUserAccountService userAccountservice, IDashboardService dashboardService, IMessageService messageService, ICustomerService customerService, CallBlueCardService service, PrintService printService, ICashDrawerService cashDservice)
        {
            _userAccountservice = userAccountservice;
            _dashboardService = dashboardService;
            _messageService = messageService;
            _customerService = customerService;
            _BlueCardService = service;
            _printService = printService;
            _cashDservice = cashDservice;
        }

        public ActionResult Index()
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            KeySearchList();
            _userAccountservice.CheckOpenDayEnd(out var _Openbatch, out var _endOldYet, out var _endtodayYet);

            var model = new MenuListModel
            {
                Messages = _messageService.GetList(),
                NotificationIcons = new List<NotificationIcon>
            {
                new NotificationIcon
                {
                    Name = "สร้างใบสั่งซ่อม",
                    ImgName ="ICON-13.png",
                    Action = new ActionLink
                    {
                        ActionName = (_endtodayYet ? "Index": "ClassicAsp"),
                        ControllerName = "Home",
                        RouteValues = new { AspFile = (_endtodayYet ? "": "startjob_rt_new.asp?reset=yes")  }
                    }
                },
                //new NotificationIcon
                //{
                //    Name = "สร้างใบตรวจเช็คสภาพ",
                //    ImgName ="ICON-14.png",
                //    Action = new ActionLink
                //    {
                //        ActionName = "ClassicAsp",
                //        ControllerName = "Home",
                //        RouteValues = new { AspFile = "bs_checklist.asp" }
                //    }
                //},
                new NotificationIcon
                {
                    Name = "สร้างลูกค้า",
                    ImgName = "ICON-15.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = $"bs_cust_new_client.asp?status_add=AddCus&branch_no={Session["branchNo"]}&page_back=bs_cust.asp&act=add&user_id={Session["gbUserId"]}&dealercode={Session["dealerCode"]}" }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างรถยนต์",
                    ImgName = "ICON-16.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "list_select_cust_create_car.asp" }
                    }
                },
                  new NotificationIcon
                {
                    Name = "Free Wi-Fi",
                    ImgName = "ICON_WIFI.png",
                    Action = new ActionLink
                    {
                        ActionName = "Genwifi",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "" }//gen_wifi.asp?dealercode="+Session["dealerCode"]
                    }
                },
                    new NotificationIcon
                {
                    Name = "Blue Card",
                    ImgName = "BlueCard.png",
                    Action = new ActionLink
                    {
                        ActionName = "BlueCard",
                        ControllerName = "",
                        RouteValues = new { AspFile = "" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "อนุมัติใบขอซื้อสินค้า",
                    ImgName = "ICON-01.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "pc_pr_list.asp" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "อนุมัติใบลดหนี้/รับคืนสินค้า",
                    ImgName = "ICON-02.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "rt_disc_list.asp" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "อนุมัติใบกำกับภาษีเต็มรูป",
                    ImgName = "ICON-17.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "rt_inv_list.asp" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "อนุมัติใบปรับปรุง",
                    ImgName = "ICON-04.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "stk_update_list.asp" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "ใบโอนย้ายสินค้า",
                    ImgName = "ICON-05.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "stk_transfer_list.asp" }
                    }
                },
                new NotificationIcon
                {
                    GroupNo = 2,
                    Name = "ยกเลิกใบกำกับภาษีเต็มรูป",
                    ImgName = "ICON-Inv_cancel.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "rt_inv_cancel_list.asp" }
                    }
                }
                }
            };

            var dashboardModels = _dashboardService.GetNotificationsNumber();

            foreach (var item in model.NotificationIcons)
            {
                var dashboardModel = dashboardModels.FirstOrDefault(d => d.Name == item.Name);
                if (dashboardModel != null)
                    item.Number = dashboardModel.Value;
            }
            model.EndOldBatch = _endOldYet.ToString();
            model.OpenBatch = _Openbatch.ToString();
            model.CloseBatchToday = _endtodayYet.ToString();
            model.BlueCardModel = _customerService.GetBranchDetail();
            model.WifiModel = _dashboardService.GetWifiDetail();
            ViewBag.CountNotSuccess = _BlueCardService.GetCountTransationNotSuccess((int)Session["gbUserId"]);



            // Save BlueCard หลังจากปริ้นใบเสร็จ ABB
            var TmpPayment = SessionManager.Get<PaymentModel>(Session);
            if (TmpPayment != null && TmpPayment?.BlueCardSaveNo != null && TmpPayment.BlueCardTransID != null)
            {
                TmpPayment.DocNo = _BlueCardService.GetDocNo_By_Refdocno(TmpPayment.RefDocNo);

                //Comfirm CommitTransPOS
                var retPosCommit = _BlueCardService.CommitTransPOS(_Trans_ID: TmpPayment.BlueCardTransID, _Invoice_ID: TmpPayment.DocNo, userId: (int)Session["gbUserId"]);

                // Print Redeem BlueCard
                if (Session["BlueCardRedeem"]?.ToString() == "True")
                {
                    PrintRedeemBlueCard(TmpPayment);
                    Session["BlueCardRedeem"] = null;
                }
                SessionManager.Clear<PaymentModel>(Session);
            }

            return View(model);
        }

        public ActionResult GetNotifications()
        {
            var model = _dashboardService.GetNotificationsNumber();
            return ResultRequest(model);
        }

        public ActionResult GetDTResult(DTParameters dataTableRequestModel, SearchModel searchModel)
        {
            var model = _customerService.GetDTResult(dataTableRequestModel, searchModel);
            return Json(model, JsonRequestBehavior.AllowGet);
            //return new JsonpResult
            //{
            //    Data = model
            //};
        }
        public async Task<ActionResult> GetDTResultToHqAsync(DTParameters dataTableRequestModel, SearchModel searchModel)
        {
            try
            {
                var model = await _customerService.GetDTResultCallHqAsync(dataTableRequestModel, searchModel, Session["dealerCode"].ToString());
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult CheckClientCustomerVehicle(string License)
        //{
        //    try
        //    {
        //        _customerService.CheckAndCreateCustomer(model, Session["dealerCode"].ToString());
        //        return SuccessRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ServerError("500", ex.Message);
        //    }
        //}

        public ActionResult CheckCustomerCarData(CustomerVehicleModel model)
        {
            try
            {
                _customerService.CheckAndCreateCustomer(model, Session["dealerCode"].ToString());
                return SuccessRequest();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return ServerError("500", ex.Message);
            }
        }

        private void KeySearchList()
        {
            var model = _customerService.GetKeySearchList();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.KeySearchDropDown = list;
        }

        public ActionResult ClassicAsp(string AspFile)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            AspFile = AspFile.Replace("^", "?");
            AspFile = AspFile.Replace(",", "&");

            ViewBag.AspFile = Session["aspUrl"] + "/" + AspFile;
            if (AspFile.Contains("rt_abb_new") && !AspFile.Contains("payment_cancel"))
            {
                string DocNo = AspFile.Substring(AspFile.LastIndexOf("&") + 1);
                if (!string.IsNullOrEmpty(DocNo))
                    ViewBag.AspFile2 = Session["aspUrl"] + "/" + $"rt_dp_set_paid.asp?act=paid&doc_no={DocNo}";
            }

            return View();
        }

        public ActionResult ClassicAspHQ(string AspFile)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.AspFile = Session["aspHQUrl"] + "/" + AspFile;

            return View("ClassicAsp");
        }

        public ActionResult IcardAPI(string AspFile)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.AspFile = AspFile;

            return View();
        }

        public void PrintRedeemBlueCard(PaymentModel model)
        {
            try
            {
                var reportModel = new ReportModels
                {
                    ReportName = "redeem.rpt",
                    ref_docno = model.RefDocNo,
                    doc_no = model.DocNo
                };
                reportModel.MapUrlPrint = Server.MapPath("~/report/" + reportModel.ReportName);
                _printService.PrintSlipAuto(reportModel);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
            }
        }

        public ActionResult Genwifi(string hashpwd)
        {
            try
            {
                if (string.IsNullOrEmpty(hashpwd)) throw new Exception();

                _dashboardService.SaveHashWifi(hashpwd, out string wifihash, out var _time);
                var reportModel = new ReportModels
                {
                    ReportName = "gen_wifi.rpt",
                    wifi_password = wifihash,
                    print_time = _time
                };
                reportModel.MapUrlPrint = Server.MapPath("~/report/" + reportModel.ReportName);
                _printService.PrintSlipAuto(reportModel);

                return Json(new { Code = "00", Message = hashpwd }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                return Json(new { Code = "500", Message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        public void PrintSlipPettyCash()
        {
            try
            {
                var reportModel = new ReportModels
                {
                    ReportName = "petty_cash.rpt"
                };
                reportModel.MapUrlPrint = Server.MapPath("~/report/" + reportModel.ReportName);
                _printService.PrintSlipAuto(reportModel);
                _cashDservice.OpenCashDrawer();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
            }
        }
    }
}