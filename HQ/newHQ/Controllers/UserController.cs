using CentralService.Injection;
using CentralService.Models;
using HQPosData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Security;

namespace newHQ.Controllers
{
    public class UserController : Controller
    {
        private IUserAccountService _userAccountservice;

        public UserController(IUserAccountService userAccountservice)
        {
            _userAccountservice = userAccountservice;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
           // Session["version"] = "FIT V.1.0.2";
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccountModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = _userAccountservice.IsValid(user, Helpers.MyHelpers.Base64Encode(user.Password));
                    if (model != null)
                    {
                        System.Web.HttpContext.Current.Session["gbusername"] = model.gbusername;
                        System.Web.HttpContext.Current.Session["gbuser"] = model.gbuser;
                        System.Web.HttpContext.Current.Session["gblevel"] = model.gblevel;
                        System.Web.HttpContext.Current.Session["gbsempno"] = model.gbsempno;
                        FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);

                        Session["gbusername"] = model.gbusername;
                        Session["branchNo"] = model.BranchNo;
                        Session["gbUserId"] = model.gbuserId;
                        Session["gbIpAddress"] = user.IpAddress;
                        Session["dealerCode"] = model.DealerCode;
                        Session["dealerName"] = model.DealerName;
                        Session["aspUrl"] = model.HQUrl;

                        var url = RedirectToAction("Index", "Home");
                        var currentUrl = Request.Url.AbsoluteUri.Replace("User/Login", "");
                        return Redirect($"{model.HQUrl}/login.asp?state=login&UserName={ user.UserName }&Password={ user.Password }&Pageback={currentUrl}");
                    }
                    else
                    {
                        ModelState.AddModelError("", "รหัสเข้าใช้งาน หรือรหัสผ่าน ไม่ถูกต้อง");
                    }
                }
                return View(user);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "รหัสเข้าใช้งาน หรือรหัสผ่าน ไม่ถูกต้อง");
                return View(user);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}