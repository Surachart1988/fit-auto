using CentralService.Injection;
using CentralService.Models;
using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newHQ.Controllers.MasterData
{
    public class PromotionController : JsonResponseController
    {
        private IPromotionService _service;
        private IDropDownService _dropDownService;
        private IExcelMgmtService _excelMgMtService;
        private IBranchService _servBranch;

        public PromotionController(
            IPromotionService service,
            IBranchService servBranch,
            IDropDownService dropDownService,
            IExcelMgmtService excelMgMtService)
        {
            _service = service;
            _servBranch = servBranch;
            _dropDownService = dropDownService;
            _excelMgMtService = excelMgMtService;

        }

        // GET: Promotion
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
            TempData["data"] = null;
            var model = _service.GetlAll(dataTableRequestModel, searchModel);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreatePromotion(string id = "", string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ExtraPromotionModel model = new ExtraPromotionModel();
            //model.allow_promotion = true;
            //model.pro_start_time = Convert.ToDateTime("07:00").ToString("HH:mm:ss");
            //model.pro_end_time = Convert.ToDateTime("20:00").ToString("HH:mm:ss");
            //model.pro_give_free_amount = 1;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
            }
            else
            {
                if (id != "")
                {
                    model = _service.Get(id);
                    switch (model.pro_condition_time_id)
                    {
                        case 1:
                            _service.GetConditionWeek(model);
                            model.pro_condition_time_detail = null;
                            _service.GetConditionMonth(model);
                            break;
                        case 2:
                            _service.GetConditionMonth(model);
                            model.pro_condition_time_detail = null;
                            _service.GetConditionWeek(model);
                            break;
                        case 3:
                            _service.GetConditionMonth(model);
                            _service.GetConditionWeek(model);
                            break;
                    }
                }
                else
                {
                    //model.pro_condition_time_id = 3; // defualt
                    //model.pro_group_used_id = 1; // defualt
                    //model.pro_give_type_id = 1; // defualt
                    //model.pro_type_id = 1;// defualt
                    //model.pro_price_id = 1;// defualt
                    //model.pro_discount_id = 1;// defualt
                    //model.pro_price_total = 1;
                    _service.GetConditionWeek(model);
                    _service.GetConditionMonth(model);
                }
                model.Mode = mode;
                _service.GetDealers(model, _servBranch.GetDealers());
                _service.GetPromotionList(model);

                //2
                _service.GetPromotionGroupUsed(model);

                //3
                _service.GetCusType(model);
                _service.GetProgroupFirstGroup(model);
                _service.GetProgroup(model, "", "");
                _service.GetProbrand(model, "", "");
                _service.GetPromodel(model, "", "");
                _service.GetProSize(model, "", "");
                _service.GetProduct(model, "", "", "", "", "", "");

                _service.GetProGiveTypeList(model);
                _service.GetProPriceList(model);
            }
            model.CampaignList = _dropDownService.GetCampaign();
            if (mode == "") TempData["data"] = model;
            return Step1ViewPartial(model);
        }
        public ActionResult CreatePromotion2()
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
            }
            else
            {

                return RedirectToAction("Index");
            }

            TempData["data"] = model;
            return View(model);
        }
        public ActionResult CreatePromotion3(string id = "", string mode = "")
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ExtraPromotionModel model = null;
            if (mode == "c")
            {
                model = _service.Get(id);
                _service.GetCusType(model);
                _service.GetProTypeList(model);
                _service.GetProgroupFirstGroup(model);
                _service.GetProgroup(model, "", "");
                _service.GetProbrand(model, "", "");
                _service.GetPromodel(model, "", "");
                _service.GetProSize(model, "", "");
                _service.GetProduct(model, "", "", "", "", "", "");
                _service.GetProductGift(model, "");
                if (model.pro_group_used_id == 1)
                {
                    if (!model.pro_give_same_buy)
                    {
                        var giftprod = string.Join(",", model.ProdGiveList.Where(s => s.IsCheck).Select(s => s.pro_code).ToArray());
                        model.ProductsList.Where(w => giftprod.Contains(w.pro_code)).Select(s => { s.IsCheck = false; return s; }).ToList();
                    }
                }
                if (model.pro_group_used_id == 5 || model.pro_group_used_id == 6)
                {
                    model.ddlProdFirstGrpList = _dropDownService.GetProdFirstGrp();
                    model.ddlProGrpList = _dropDownService.GetProGrp("");
                    model.ddlProBrandList = _dropDownService.GetProBrand("");
                    model.ddlProModelList = _dropDownService.GetProModel("");
                    model.ddlProSizeList = _dropDownService.GetProSize("");
                }
                _service.GetProGiveTypeList(model);
                _service.GetProPriceList(model);
                model.Mode = mode;
            }
            else
            {
                if (TempData["data"] != null)
                {
                    model = (ExtraPromotionModel)TempData["data"];
                    if (model.pro_group_used_id == 2 || model.pro_group_used_id == 3 || model.pro_group_used_id == 5
                    ) //// โปรโมชั่นส่วนลดราคา,โปรโมชั่นส่วนลดพนักงาน,โปรโมชั่นส่วนลดบัตรกำนัน,
                    {
                        _service.GetProTypeList(model);
                    }
                    if (model.pro_group_used_id == 1) // โปรโมชั่นของแถม
                    {
                        _service.GetProductGift(model, "");
                    }

                    if (model.pro_group_used_id == 5 || model.pro_group_used_id == 6)
                    {
                        model.ddlProdFirstGrpList = _dropDownService.GetProdFirstGrp();
                        model.ddlProGrpList = _dropDownService.GetProGrp("");
                        model.ddlProBrandList = _dropDownService.GetProBrand("");
                        model.ddlProModelList = _dropDownService.GetProModel("");
                        model.ddlProSizeList = _dropDownService.GetProSize("");
                    }
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }

            if (mode == "") TempData["data"] = model;
            return View(model);
        }

        private ActionResult Step1ViewPartial(object model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePromotion(ExtraPromotionModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            //if (!ModelState.IsValid)
            //{

            var merge = (ExtraPromotionModel)TempData["data"];
            merge.campaign_id = model.campaign_id;
            merge.pro_name = model.pro_name;
            merge.pro_start_date = model.pro_start_date;
            merge.pro_end_date = model.pro_end_date;
            merge.pro_start_time = model.pro_start_time;
            merge.pro_end_time = model.pro_end_time;
            merge.pro_condition_time_id = model.pro_condition_time_id;
            merge.ConditionWeek = model.ConditionWeek;
            merge.pro_condition_time_start = model.pro_condition_time_start;
            merge.pro_condition_time_end = model.pro_condition_time_end;
            merge.ConditionMonth = model.ConditionMonth;
            merge.ProConditionWeekStart = model.ProConditionWeekStart;
            merge.ProConditionWeekTimeEnd = model.ProConditionWeekTimeEnd;
            merge.ProConditionMonthStart = model.ProConditionMonthStart;
            merge.ProConditionMonthEnd = model.ProConditionMonthEnd;
            merge.Dealers = model.Dealers;
            merge.allow_muti_promotion = model.allow_muti_promotion;
            merge.PromotionList = model.PromotionList;
            merge.allow_promotion = model.allow_promotion;

            TempData["data"] = merge;
            //    return Step1ViewPartial(model);
            //}
            return RedirectToAction("CreatePromotion2");
        }
        [HttpPost]
        public ActionResult CreatePromotion2(ExtraPromotionModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            //if (!ModelState.IsValid)
            //{
            var merge = (ExtraPromotionModel)TempData["data"];
            merge.pro_group_used_id = model.pro_group_used_id;
            TempData["data"] = merge;
            //    return Step1ViewPartial(model);
            //}
            return RedirectToAction("CreatePromotion3");

        }
        [HttpPost]
        public ActionResult CreatePromotion3(ExtraPromotionModel model)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            //if (!ModelState.IsValid)
            //{
            string oldCoupon_id = "";
            var merge = (ExtraPromotionModel)TempData["data"];
            if (model.pro_type_id == 0) model.pro_type_id = 1;

            if (model.ProGrpUsedDetailsList == null)
                model.ProGrpUsedDetailsList = new List<ProGrpUsedDetail>();

            merge.ProGrpUsedDetailsList = model.ProGrpUsedDetailsList;
            merge.pro_give_type_id = model.pro_give_type_id;
            merge.pro_give_type_detail = model.pro_give_type_detail;
            merge.pro_give_product_same = model.pro_give_product_same;

            merge.pro_price_id = model.pro_price_id;
            merge.pro_price_total = model.pro_price_total;

            merge.pro_type_id = model.pro_type_id;
            merge.pro_type_detail = model.pro_type_detail;

            // ของแถม
            if (merge.pro_group_used_id == 1)
            {
                merge.pro_type_id = 3;
                merge.pro_give_same_buy = model.pro_give_same_buy;

                merge.pro_discount_id = 1;
                merge.pro_discount_num = model.pro_discount_num;
                merge.pro_discount_rate = model.pro_discount_rate;
                merge.pro_discount_unit = model.pro_discount_unit_id == 0 ? "%" : "บาท";

                merge.pro_give_free_amount = model.pro_give_free_amount;
                //else
                //{
                //    merge.pro_discount_num = model.pro_discount_num2;
                //    merge.pro_discount_rate = model.pro_discount_rate2;
                //    merge.pro_discount_unit = model.pro_discount_unit2;
                //}
            }
            else
            {
                merge.pro_discount_id = 1;   // defualt
                merge.pro_discount_num = 0;  // defualt
                merge.pro_discount_rate = 0; // defualt
                merge.pro_discount_unit = model.pro_group_used_id == 3 ? "%" : ""; // defualt
                merge.pro_give_free_amount = 0;
            }
            // คูปอง
            if (merge.pro_group_used_id == 4)
            {
                //merge.pro_type_id = 0;
                merge.group_coupon_id = model.group_coupon_id;
                switch (model.group_coupon_id)
                {
                    case 0:
                    case 1:
                        merge.coupon_code = model.coupon_code;
                        merge.coupon_value_amount = model.coupon_value_amount ?? 0;
                        merge.coupon_value_percent = model.coupon_value_percent;
                        break;
                    case 2:
                        oldCoupon_id = merge.coupon_id;
                        merge.coupon_id = model.coupon_code2;
                        break;
                }
                //if (model.group_coupon_id == 1)
                //{
                //    merge.coupon_code = model.coupon_code;
                //    merge.coupon_value_amount = model.coupon_value_amount ?? 0;
                //    merge.coupon_value_percent = model.coupon_value_percent;
                //}
                //else if (model.group_coupon_id == 2)
                //{
                //    merge.coupon_id = model.coupon_code2;
                //}
                merge.coupon_name = merge.pro_name;
            }
            else
            {
                merge.group_coupon_id = 1;   // defualt
            }

            _service.AddUpdate(merge, oldCoupon_id ?? "");

            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var result = _service.Delete(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductitems(string id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = new ExtraPromotionModel();
            model = _service.Get(id);
            _service.GetPromotionitems(model);
            return PartialView("ViewPromotion", model);
        }
        public ActionResult ViewCondition(string id)
        {
            if (Session["gbusername"] == null || Session["branchNo"] == null || Session["dealerCode"] == null || Session["gbUserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var model = _service.Get(id);
            model.Dealers = new List<DealerMasterModel>();
            return Step1ViewPartial(model);
        }
        public ActionResult GetProdgroup(string data, string hasChk)
        {
            //if (model.progroupList == null)
            //    _service.GetProgroup(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProdFirstGroup(model, data, hasChk);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView("_ModalProductGroup", model);
        }
        public ActionResult GetProgroup(string data, string hasChk)
        {
            //if (model.progroupList == null)
            //    _service.GetProgroup(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProgroup(model, data, hasChk);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        public ActionResult GetProbrand(string data, string hasChk)
        {
            //if (model.probrandList == null)
            //    _service.GetProbrand(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProbrand(model, data, hasChk);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        public ActionResult GetPromodel(string data, string hasChk)
        {
            //if (model.PromodelList == null)
            //    _service.GetPromodel(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetPromodel(model, data, hasChk);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        public ActionResult GetProSize(string data, string hasChk)
        {
            //if (model.ProSizeList == null)
            //    _service.GetProSize(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProSize(model, data, hasChk);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        public ActionResult GetProduct(
            string productgrp,
            string progroup,
            string probrand,
            string promodel,
            string prosize,
            string procode
            )
        {
            //if (model.ProductsList == null)
            //    _service.GetProduct(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProduct(model, productgrp, progroup, probrand, promodel, prosize, procode);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        public ActionResult GetProductGift(string procode)
        {
            //if (model.ProductsList == null)
            //    _service.GetProduct(model);
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                _service.GetProductGift(model, procode);
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView(model);
        }
        [HttpPost]
        public void SaveData(string data, string _type)
        {
            var merge = (ExtraPromotionModel)TempData["data"];
            HashSet<string> _container = new HashSet<string>();
            _container = new HashSet<string>(data.Split(','));
            switch (_type)
            {
                case "productgrp"://กลุ่มสินค้า :

                    merge.prodfirstgroupList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.prodfirstgroupList.Where(w => _container.Contains(w.product_group_code)).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "progroup"://ประเภทสินค้า :
                    merge.progroupList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.progroupList.Where(w => _container.Contains(w.progroup_code)).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "probrand"://ยี่ห้อสินค้า :
                    merge.probrandList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.probrandList.Where(w => _container.Contains(w.pro_brand_code.ToString())).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "promodel"://รุ่นสินค้าสินค้า :
                    merge.PromodelList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.PromodelList.Where(w => _container.Contains(w.pro_model_code.ToString())).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "prosize"://ขนาดสินค้า :
                    merge.ProSizeList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.ProSizeList.Where(w => _container.Contains(w.pro_size_code.ToString())).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "procode":
                    merge.ProductsList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.ProductsList.Where(w => _container.Contains(w.pro_code)).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
                case "progivecode":
                    merge.ProdGiveList.Select(s => { s.IsCheck = false; return s; }).ToList();
                    merge.ProdGiveList.Where(w => _container.Contains(w.pro_code)).Select(s => { s.IsCheck = true; return s; }).ToList(); break;
            }

            TempData["data"] = merge;
        }

        [HttpPost]
        public ActionResult GetSkuData(string data, string _type)
        {
            var merge = (ExtraPromotionModel)TempData["data"];
            HashSet<string> _container = new HashSet<string>();
            _container = new HashSet<string>(data.Split(','));
            var result = new Skudetail();
            if (_container.Count == 1)
            {
                result = _service.GetSkudetail(_container.First(), merge);
            }

            TempData["data"] = merge;
            return Json(new
            {
                Skudetail = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ImportCoupon()
        {
            int noOfCol = 0;
            int noOfRow = 0;
            string code = "";
            ExtraPromotionModel model = null;
            try
            {
                if (TempData["data"] != null)
                {
                    model = (ExtraPromotionModel)TempData["data"];
                    if (model.SBCouponDetail.Count > 0 && string.IsNullOrEmpty(model.pro_id))
                    {
                        throw new OperationCanceledException("777");
                    }
                    HttpFileCollectionBase file = Request.Files;
                    string _couponCode = "";
                    if (Request.Files.Count > 0)
                    {
                        var data = Request.Form;
                        _couponCode = data["_code"].Trim();
                    }
                    ExcelPackage package = new ExcelPackage(Request.InputStream);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    var tmp = new List<SBCouponDetail>();
                    SBCouponDetail sbCouponDetail = null;

                    for (int row = 2; row <= rows; row++)
                    {
                        sbCouponDetail = new SBCouponDetail
                        {
                            coupon_group_id = _couponCode,
                            coupon_name = model.pro_name,//worksheet.Cells[row, 2].Value.ToString(),
                            coupon_code = worksheet.Cells[row, 3].Value.ToString(),
                            coupon_value_amount = decimal.Parse(worksheet.Cells[row, 4].Text),
                            coupon_value_percent = decimal.Parse(worksheet.Cells[row, 5].Text),
                            coupon_status = true,
                            deleted = false
                        };
                        tmp.Add(sbCouponDetail);
                    }
                    if (tmp.Any(a => a.coupon_value_amount > 0) && tmp.Any(a => a.coupon_value_percent > 0))
                    {
                        code = "333";
                        throw new Exception("UsedTwoWayDiscount");
                    }
                    if (tmp.Count > 0)
                    {
                        //if (string.IsNullOrEmpty(model.pro_id))
                        //{
                        //    if (_service.checkDuplicateCoupon("", string.Join(",", tmp.Select(s => s.coupon_code).ToArray()), out code))
                        //    {
                        //        throw new Exception("DuplicateCoupon");
                        //    }
                        //}
                        //else
                        //{
                        //    _service.checkDuplicateCoupon(model.pro_id, string.Join(",", tmp.Select(s => s.coupon_code).ToArray()), out code);
                        //    ViewBag.DuplicatedCoupon = code;
                        //}

                        if (!_service.checkDuplicateCoupon(_couponCode, tmp, out var detail))
                        {
                            code = detail.coupon_code;
                            throw new Exception("DuplicateCoupon");
                            //ViewBag.DuplicatedCoupon = code;
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("null");
                    }
                    model.SBCouponDetail = new List<SBCouponDetail>(tmp);
                    model.coupon_code2 = _couponCode;
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }
            catch (FormatException e)
            {
                return new HttpStatusCodeResult(400, "444");
                throw;
            }
            catch (NullReferenceException e)
            {
                return new HttpStatusCodeResult(400, "666");
                throw;
            }
            catch (OperationCanceledException e)
            {
                return new HttpStatusCodeResult(400, "777");
                throw;
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, code);
                throw;
            }
            finally
            {
                TempData["data"] = model;
            }

            return PartialView("_ViewCoupon", model);
        }

        public ActionResult ImportProCouponEmp()
        {
            int noOfCol = 0;
            int noOfRow = 0;
            string code = "";
            ExtraPromotionModel model = null;
            try
            {
                if (TempData["data"] != null)
                {
                    model = (ExtraPromotionModel)TempData["data"];
                    if (model.SBProCouponDetailEmp.Count > 0)
                    {
                        throw new OperationCanceledException("777");
                    }
                    HttpFileCollectionBase file = Request.Files;
                    if (Request.Files.Count > 0)
                    {
                        var data = Request.Form;

                    }
                    ExcelPackage package = new ExcelPackage(Request.InputStream);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int rows = worksheet.Dimension.Rows;
                    int columns = worksheet.Dimension.Columns;
                    var tmp = new List<SB_ProCouponDetailEmp>();
                    SB_ProCouponDetailEmp sbCouponDetailEmp = null;

                    for (int row = 2; row <= rows; row++)
                    {
                        sbCouponDetailEmp = new SB_ProCouponDetailEmp
                        {
                            coupon_code = worksheet.Cells[row, 1].Value.ToString()
                        };
                        tmp.Add(sbCouponDetailEmp);
                    }
                    if (tmp.Count > 0)
                    {
                        model.SBProCouponDetailEmp = new List<SB_ProCouponDetailEmp>(tmp);
                    }
                    else
                    {
                        throw new NullReferenceException("null");
                    }
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }
            catch (FormatException e)
            {
                return new HttpStatusCodeResult(400, "444");
                throw;
            }
            catch (NullReferenceException e)
            {
                return new HttpStatusCodeResult(400, "666");
                throw;
            }
            catch (OperationCanceledException e)
            {
                return new HttpStatusCodeResult(400, "777");
                throw;
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, code);
                throw;
            }
            finally
            {
                TempData["data"] = model;
            }

            return PartialView("_ViewProCouponEmp", model);
        }
        public ActionResult GetDataPromotionDiscountPrice()
        {
            int noOfCol = 0;
            int noOfRow = 0;
            string msg = "";
            ExtraPromotionModel model = null;

            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;
            return PartialView("_ViewPromotion", model);
        }
        public ActionResult ImportPromotion()
        {
            object obj;
            string msg = "";
            ExtraPromotionModel model = null;
            try
            {
                if (TempData["data"] != null)
                {
                    model = (ExtraPromotionModel)TempData["data"];
                    //if (model.SBPromotionDisDetail.Count > 0)
                    //{
                    //    throw new OperationCanceledException("777");
                    //}
                    HttpFileCollectionBase file = Request.Files;
                    DataTable failDT = new DataTable();
                    if (Request.Files.Count > 0)
                    {
                        var data = Request.Form;
                        //_couponCode = data["_code"].Trim();
                    }
                    model.Excel_Mgmt = new ExcelMgmtModel();
                    failDT.Columns.AddRange(new DataColumn[] {
                        new DataColumn("รหัสสินค้า", typeof(string)),
                        new DataColumn("ชื่อสินค้า", typeof(string)),
                        new DataColumn("ราคาขายปลีก",typeof(string)),
                        new DataColumn("ราคาขายโปรโมชั่น",typeof(string))
                    });
                    DataTable dt = new DataTable();
                    string sMsgLossColumn = "";
                    string[] arrayColumn = { "รหัสสินค้า", "ชื่อสินค้า", "ราคาขายปลีก", "ราคาขายโปรโมชั่น" };
                    using (var package = new ExcelPackage(Request.InputStream))
                    {
                        ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();
                        var row = sheet.Dimension.Start.Row;
                        foreach (var startRowCell in sheet.Cells[row, sheet.Dimension.Start.Column, 1, sheet.Dimension.End.Column])
                            dt.Columns.Add(startRowCell.Text); //sMsgLossColumn += "," + startRowCell.Text;
                    }
                    if (arrayColumn.Length == dt.Columns.Count)
                    {
                        foreach (string scolname in arrayColumn)
                            if (dt.Columns.IndexOf(scolname) == -1) sMsgLossColumn += "," + scolname;

                        if (string.IsNullOrEmpty(sMsgLossColumn))
                        {
                            _excelMgMtService.ImportPromotionDiscountPrice(failDT, model, Request.InputStream);

                        }
                        else
                        {
                            msg = "333"; throw new Exception("IsValidTemplate");
                        }
                    }
                    else
                    {
                        msg = "333"; throw new Exception("IsValidTemplate");
                    }
                    //if (model.SBPromotionDisDetail.Count == 0)
                    //{
                    //    throw new NullReferenceException("null");
                    //}
                    obj = new
                    {
                        status = model.Excel_Mgmt.FailImport,
                        model.Excel_Mgmt.TotalRecords,
                        model.Excel_Mgmt.SuccessImport,
                        model.Excel_Mgmt.FailImport
                    };

                    #region .Bak
                    //ExcelPackage package = new ExcelPackage(Request.InputStream);
                    //ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    //int rows = worksheet.Dimension.Rows;
                    //int columns = worksheet.Dimension.Columns;
                    //var tmp = new List<SbPromotionDetailDisc>();
                    //SbPromotionDetailDisc sbPromotionDetailDics = null;

                    //for (int row = 2; row <= rows; row++)
                    //{
                    //    var procode = worksheet.Cells[row, 1].Value.ToString();
                    //    var skuproprice = worksheet.Cells[row, 3].Text == "" ? 0 : float.Parse(worksheet.Cells[row, 3].Text);
                    //    var discount_rate = worksheet.Cells[row, 4].Text == "" ? 0 : float.Parse(worksheet.Cells[row, 4].Text);
                    //    if (discount_rate >= skuproprice)
                    //    {
                    //        msg = procode + " " + worksheet.Cells[row, 2].Value.ToString();
                    //        throw new Exception("ErrorPromotionPrice");
                    //    }
                    //    sbPromotionDetailDics = new SbPromotionDetailDisc
                    //    {
                    //        pro_code = procode,
                    //        pro_name = worksheet.Cells[row, 2].Value.ToString(),
                    //        pro_price_detail = skuproprice,
                    //        pro_discount_rate_special = discount_rate
                    //    };
                    //    tmp.Add(sbPromotionDetailDics);
                    //}
                    //if (tmp.Count > 0)
                    //{
                    //    model.SBPromotionDisDetail = new List<SbPromotionDetailDisc>(tmp);
                    //}
                    //else
                    //{
                    //    throw new NullReferenceException("null");
                    //}
                    #endregion
                }
                else
                {

                    return RedirectToAction("Index");
                }
            }
            catch (FormatException e)
            {
                return new HttpStatusCodeResult(400, "444");
            }
            catch (NullReferenceException e)
            {
                return new HttpStatusCodeResult(400, "666");
            }
            catch (OperationCanceledException e)
            {
                return new HttpStatusCodeResult(400, "777");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, msg);
            }
            finally
            {
                TempData["data"] = model;
            }


            return Json(new { obj });
            //return PartialView("_ViewPromotion", model);
        }

        public ActionResult Getddlprogroup(string prodgrp_code)
        {
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                model.ddlProGrpList = _dropDownService.GetProGrp(prodgrp_code);

                model.product_group_code = prodgrp_code;
                model.progroup_code = "";
                model.pro_brand_code = "";
                model.pro_model_code = "";
                model.pro_size_code = "";
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;


            return PartialView("_ViewProGrp", model);
        }
        public ActionResult Getddlprobrand(string progroup_code)
        {
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                model.ddlProBrandList = _dropDownService.GetProBrand(progroup_code);
                model.progroup_code = progroup_code;
                model.pro_brand_code = "";
                model.pro_model_code = "";
                model.pro_size_code = "";
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;


            return PartialView("_ViewProBrand", model);
        }
        public ActionResult Getddlpromodel(string probrand_code)
        {
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                model.ddlProModelList = _dropDownService.GetProModel(probrand_code);
                model.pro_brand_code = probrand_code;
                model.pro_model_code = "";
                model.pro_size_code = "";
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;


            return PartialView("_ViewProModel", model);
        }
        public ActionResult Getddlprosize(string promodel_code)
        {
            ExtraPromotionModel model = null;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                model.ddlProSizeList = _dropDownService.GetProSize(promodel_code);
                model.pro_model_code = promodel_code;
                model.pro_size_code = "";
            }
            else
            {

                return RedirectToAction("Index");
            }
            TempData["data"] = model;


            return PartialView("_ViewProSize", model);
        }
        public JsonResult ExportToExcelSheet()
        {
            var fileName = "";
            var errorMessage = "";
            ExtraPromotionModel model = null;

            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];

                DataTable dt = new DataTable();
                dt = model.Excel_Mgmt.failDTGlobal.Copy();
                dt.TableName = "Fail_Update";
                fileName = "TemplatePromotion_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xlsx";

                //save the file to server temp folder
                var folder = Server.MapPath("~/Temp_Data/Promotion");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string fullPath = Path.Combine(Server.MapPath("~/Temp_Data/Promotion"), fileName);
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "$sheet1");
                        using (var exportData = new MemoryStream())
                        {
                            wb.SaveAs(exportData);

                            FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                            exportData.WriteTo(file);
                            file.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
            else
            {


            }
            TempData["data"] = model;
            //return the Excel file name
            return Json(new { fileName = fileName, errorMessage = errorMessage });


        }
        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download, 
        //I will explain it later
        public ActionResult Download(string file)
        {
            //get the temp folder and file path in server
            string fullPath = Path.Combine(Server.MapPath("~/Temp_Data/Promotion"), file);

            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        [HttpPost]
        public JsonResult ExportExcel(string prosize_code)
        {
            ExtraPromotionModel model = null;
            model = (ExtraPromotionModel)TempData["data"];
            //Get the data we want to export.
            DataTable dt = new DataTable();
            var errorMessage = "";
            if (!string.IsNullOrEmpty(prosize_code))
            {
                model.pro_size_code = prosize_code;
            }
            else
            {
                model.pro_size_code = "";
            }
            _service.Getdata_TemplatePromotion(dt, model);

            dt.TableName = "TemplatePromotion";
            var fileName = "TemplatePromotion_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xlsx";

            //save the file to server temp folder
            var folder = Server.MapPath("~/Temp_Data/Promotion");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fullPath = Path.Combine(Server.MapPath("~/Temp_Data/Promotion"), fileName);
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "$sheet1");
                    using (var exportData = new MemoryStream())
                    {
                        wb.SaveAs(exportData);

                        FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                        exportData.WriteTo(file);
                        file.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            TempData["data"] = model;
            //return the Excel file name
            return Json(new { fileName = fileName, errorMessage = errorMessage });
        }
        //public void DownloadAttachment()
        //{
        //    ExtraPromotionModel model = null;
        //    model = (ExtraPromotionModel)TempData["data"];
        //    //Get the data we want to export.
        //    DataTable dt = new DataTable();
        //    _service.Getdata_TemplatePromotion(dt, model);

        //    dt.TableName = "TemplatePromotion";

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt, "Customers");

        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
        //        using (MemoryStream MyMemoryStream = new MemoryStream())
        //        {
        //            wb.SaveAs(MyMemoryStream);
        //            MyMemoryStream.WriteTo(Response.OutputStream);
        //            Response.Flush();
        //            Response.End();
        //        }
        //    }
        //}
        //public ActionResult ExportToExcelSheet()
        //{
        //    ExtraPromotionModel model = null;
        //    FileContentResult robj;
        //    model = (ExtraPromotionModel)TempData["data"];
        //    //Get the data we want to export.
        //    DataTable dt = new DataTable();
        //    _service.Getdata_TemplatePromotion(dt, model);

        //    dt.TableName = "TemplatePromotion";

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt);
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            wb.SaveAs(stream);
        //            //return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TemplatePromotion.xlsx");
        //            var bytesdata = File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TemplatePromotion.xlsx");
        //            robj = bytesdata;
        //        }
        //    }
        //    return Json(robj, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult ExportToExcelSheet()
        //{
        //    ExtraPromotionModel model = null;
        //    if (TempData["data"] != null)
        //    {
        //        model = (ExtraPromotionModel)TempData["data"];
        //        //Get the data we want to export.
        //        DataTable dt = new DataTable();
        //        _service.Getdata_TemplatePromotion(dt, model);

        //        dt.TableName = "TemplatePromotion";

        //        using (XLWorkbook wb = new XLWorkbook())
        //        {
        //            wb.Worksheets.Add(dt);
        //            HttpContext.Response.Clear();
        //            HttpContext.Response.Buffer = true;
        //            HttpContext.Response.Charset = "";
        //            HttpContext.Response.ContentType =
        //                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            HttpContext.Response.AddHeader("content-disposition",
        //                "attachment;filename=\"TemplatePromotion.xlsx\"");

        //            using (MemoryStream MyMemoryStream = new MemoryStream())
        //            {
        //                wb.SaveAs(MyMemoryStream);
        //                MyMemoryStream.WriteTo(HttpContext.Response.OutputStream);
        //                HttpContext.Response.Flush();
        //                HttpContext.Response.End();

        //            }

        //        }
        //    }
        //    return View("CreatePromotion3");
        //}

        public ActionResult DeleteDisCountPromotionItems(string id)
        {
            ExtraPromotionModel model = null;
            int del;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                if (model.SBPromotionDisDetail.Count > 0)
                {
                    del = model.SBPromotionDisDetail.RemoveAll(x => x.pro_code == id);
                }
                else { del = 0; }
            }
            else
            {

                return RedirectToAction("Index");
            }

            TempData["data"] = model;

            return Json(new { res = del }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditDisCountPromotionItems(string id, double price)
        {
            ExtraPromotionModel model = null;
            int edit;
            if (TempData["data"] != null)
            {
                model = (ExtraPromotionModel)TempData["data"];
                if (model.SBPromotionDisDetail.Count > 0)
                {
                    model.SBPromotionDisDetail.Where(w => w.pro_code == id).Select(s => { s.pro_discount_rate_special = price; return s; }).ToList(); edit = 1;
                }
                else { edit = 0; }
            }
            else
            {

                return RedirectToAction("Index");
            }

            TempData["data"] = model;

            return Json(new { res = edit }, JsonRequestBehavior.AllowGet);
        }
    }
}