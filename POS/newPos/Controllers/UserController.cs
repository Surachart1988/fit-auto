using CentralService.Injection;
using CentralService.Models;
using PosService.Injection;
using PosService.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Security;

namespace newPos.Controllers
{
    public class UserController : Controller
    {
        private IUserAccountService _userAccountservice;
        private IDealerService _dealerService;

        public UserController(IUserAccountService userAccountservice, IDealerService dealerService)
        {
            _userAccountservice = userAccountservice;
            _dealerService = dealerService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {




            var model = _dealerService.GetDealerCodeName();
            Session["dealerCode"] = model.Code;
            Session["dealerName"] = model.Name;
            //var dealerName = model.Name.Split(' ');
            //if (dealerName.Length > 2)
            //{
            //    Session["dealerName1"] = dealerName[0] + " " + dealerName[1];
            //    Session["dealerName2"] = dealerName[2];
            //}
            //else if (dealerName.Length > 1)
            //{
            //    Session["dealerName1"] = dealerName[0];
            //    Session["dealerName2"] = dealerName[1];
            //}
            //else
            //{
            //    Session["dealerName1"] = dealerName[0];
            //}
            //  Session["version"] = "FIT V.1.0.2";
            return View();
        }
        [HttpGet]
        public ActionResult Bypass()
        {




            var model = _dealerService.GetDealerCodeName();
            Session["dealerCode"] = model.Code;
            Session["dealerName"] = model.Name;
            //var dealerName = model.Name.Split(' ');
            //if (dealerName.Length > 2)
            //{
            //    Session["dealerName1"] = dealerName[0] + " " + dealerName[1];
            //    Session["dealerName2"] = dealerName[2];
            //}
            //else if (dealerName.Length > 1)
            //{
            //    Session["dealerName1"] = dealerName[0];
            //    Session["dealerName2"] = dealerName[1];
            //}
            //else
            //{
            //    Session["dealerName1"] = dealerName[0];
            //}
            //  Session["version"] = "FIT V.1.0.2";
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Bypass(FormCollection data)
        {
            string IpV4 = "";
            try
            {
                //IpV4 = Dns.GetHostEntry(Dns.GetHostName()).AddressList[5].ToString();
                if (data.Count > 0)
                {
                    var result = await _userAccountservice.UpdateIPAddrs(data.GetValues("iisName").First(), data.GetValues("ipAdvs").First());
                    if (result == null)
                    {
                        ModelState.AddModelError("error", "เกิดข้อมผิดพลาดระบบไม่พบ API ดังกล่าว"); return View();
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "ข้อมูลไม่ถูกต้องกรุณาตรวจสอบอีกครั้ง");
                }
                return View();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                ModelState.AddModelError("error", IpV4 + "ip ไม่ถูกต้อง");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(UserAccountModel user)
        {
            bool debug = true;
            try
            {
                if (ModelState.IsValid)
                {
                    var model2 = _dealerService.GetDealerCodeName();
                    var model = _userAccountservice.IsValid(user, Helpers.MyHelpers.Base64Encode(user.Password), model2.Code);
                    //var OpenBatch = _userAccountservice.CheckOpenDayEnd();
                    if (model != null)
                    {

                        FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                        Session["gbuser"] = model.gbuser;
                        Session["gblevel"] = model.gblevel;
                        Session["gbsempno"] = model.gbsempno;
                        Session["gbusername"] = model.gbusername;
                        Session["gbUserId"] = model.gbuserId;
                        Session["gbIpAddress"] = user.IpAddress;
                        Session["aspUrl"] = model.ClientUrl;
                        Session["aspHQUrl"] = model.HQUrl;
                        if (debug)
                        {
                            Session["netHQUrl"] = "http://localhost:10000/";
                        }
                        else
                        {
                            Session["netHQUrl"] = $"{new Uri(model.HQUrl).Scheme}://{new Uri(model.HQUrl).Authority}/FIT_HQ/";
                        }
                        Session["branchNo"] = model.BranchNo;
                        Session["branchID"] = model.BranchDocNoRun;
                        //Session["OpenBatch"] = OpenBatch.ToString();


                        var currentUrl = Request.Url.AbsoluteUri.Replace("User/Login", "");


                        if (model.check_expire_user == "True")
                        {
                            DateTime current_date = DateTime.Now;

                            string Str_today = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime Dtoday = DateTime.ParseExact(Str_today, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            DateTime compare_date = DateTime.ParseExact(model.user_expire_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            if (compare_date < Dtoday)
                            {
                                ModelState.AddModelError("", "ผู้ใช้นี้หมดอายุการใช้งาน");
                                return View(user);
                            }
                        }

                        if (Helpers.MyHelpers.Base64Encode(user.Password) == Helpers.MyHelpers.Base64Encode("1234"))
                        {
                            currentUrl = currentUrl + "Home/ClassicAsp?AspFile=bs_edtemp.asp^act=edit,user_id=" + model.gbuserId + ",change_password=yes";
                            return Redirect($"{model.ClientUrl}/login.asp?state=login&doc_no_run={model.BranchDocNoRun}&UserName={ user.UserName }&Password={ user.Password }&Pageback={currentUrl}");
                        }
                        else
                        {
                            return Redirect($"{model.ClientUrl}/login.asp?state=login&doc_no_run={model.BranchDocNoRun}&UserName={ user.UserName }&Password={ user.Password }&Pageback={currentUrl}");
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "รหัสเข้าใช้งาน หรือรหัสผ่าน ไม่ถูกต้อง");
                    }
                }
                return View(user);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                ModelState.AddModelError("", "รหัสเข้าใช้งาน หรือรหัสผ่าน ไม่ถูกต้อง");
                return View(user);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); //ทำให้ Clear Session ทั้ง MVC
            return RedirectToAction("Login", "User");
            //return Redirect($"{Session["aspUrl"]}/logoff.asp?act=yes");

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