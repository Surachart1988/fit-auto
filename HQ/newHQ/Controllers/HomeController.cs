using CentralService.Injection;
using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers.Web.Attributes;
using newHQ.Models;
using System.Web.Http.Cors;

namespace newHQ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class HomeController : JsonResponseController
    {
        private IDashboardService _dashboardService;
        private IMessageService _messageService;
        private ICustomerService _customerService;

        public HomeController(IDashboardService dashboardService, IMessageService messageService, ICustomerService customerService)
        {
            _dashboardService = dashboardService;
            _messageService = messageService;
            _customerService = customerService;
        }


        public ActionResult Index()
        {

            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            KeySearchList();
            var model = new MenuListModel
            {
                Messages = _messageService.GetList(),
                NotificationIcons = new List<NotificationIcon>
            {
                new NotificationIcon
                {
                    Name = "สร้างลูกค้าเครดิต",
                    ImgName ="ICON-06.png",
                    GroupNo = 2,
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "bs_cust_new.asp" }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างผู้จำหน่าย",
                    ImgName ="ICON-07.png",
                    GroupNo = 2,
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "bs_supp_new.asp" }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างสินค้าและบริการ",
                    ImgName = "ICON-08.png",
                    GroupNo = 2,
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "bs_stock.asp" }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างสาขาใหม่",
                    ImgName = "ICON-09.png",
                    GroupNo = 2,
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "bs_comp_addnew.asp" }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างโปรโมชั่น",
                    ImgName = "ICON-10.png",
                    GroupNo = 2,
                    Action = new ActionLink {
                        ActionName = "Index",
                        ControllerName = "Message",
                        RouteValues = new { docType = 2 }
                    }
                },
                new NotificationIcon
                {
                    Name = "สร้างข้อมุลข่าวสาร",
                    ImgName = "ICON-11.png",
                    GroupNo = 2,
                    Action = new ActionLink {
                        ActionName = "Index",
                        ControllerName = "Message",
                        RouteValues = new { docType = 1 }
                    }

                },
                new NotificationIcon
                {
                    Name = "สร้างพนักงานใหม่",
                    ImgName = "ICON-12.png",
                    GroupNo = 2,
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "bs_edtemp.asp" }
                    }
                },
                new NotificationIcon
                {
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
                    Name = "ใบโอนย้ายสินค้า",
                    ImgName = "ICON-05.png",
                    Action = new ActionLink
                    {
                        ActionName = "ClassicAsp",
                        ControllerName = "Home",
                        RouteValues = new { AspFile = "stk_transfer_list.asp" }
                    }
                },
            }
            };

            var dashboardModels = _dashboardService.GetNotificationsNumber();

            foreach (var item in model.NotificationIcons)
            {
                var dashboardModel = dashboardModels.FirstOrDefault(d => d.Name == item.Name);
                if (dashboardModel != null)
                    item.Number = dashboardModel.Value;
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
        }

        private void KeySearchList()
        {
            var model = _customerService.GetKeySearchList();
            var list = new SelectList(model, "Id", "Name");
            ViewBag.KeySearchDropDown = list;
        }

        public ActionResult ClassicAsp(string AspFile)
        {
            if (Session["gbusername"] == null || Session["aspUrl"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.AspFile = Session["aspUrl"].ToString() + "/" + AspFile;

            return View();
        }

        public ActionResult IcardAPI(string AspFile)
        {
            ViewBag.AspFile = AspFile;
            return View();
        }

        public ActionResult GetCustomer(string customerCode)
        {
            var model = _customerService.GetCustomer(customerCode, null);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCar(string license, int provinceId)
        {
            var model = _customerService.GetCar(license, provinceId, null);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateIPV4Client(IpV4 req)
        {
            var result = _customerService.UpdateIPFromClient(req);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }


}