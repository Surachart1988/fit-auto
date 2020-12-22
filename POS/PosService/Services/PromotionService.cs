using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;


namespace PosService.Services
{
    public class PromotionService : IPromotionService
    {
        private Entities _db;
        private Mapper _mapper;
        private DocService _docService;

        public PromotionService(Entities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }
        public DTResult<ExtraPromotionModel> GetlAll(DTParameters dtRequestModel, ISearchModel search)
        {
            var query = _db.SB_PromotionHeader
                .GroupJoin(_db.SB_PromotionDetail,
                    h => h.pro_id,
                    d => d.pro_id,
                    (header, detail) => new { header, prodetail = detail.FirstOrDefault() })
                .GroupJoin(_db.SB_PromotionGroupUsed,
                    h1 => h1.header.pro_group_used_id,
                    d2 => d2.pro_group_used_id,
                    (header1, detail2) => new { header1.header, header1.prodetail, progrpusd = detail2.FirstOrDefault() })
                .GroupJoin(_db.SB_PromotionType,
                    h2 => h2.header.pro_type_id,
                    d3 => d3.pro_type_id,
                    (header2, detail3) => new { header2.header, header2.prodetail, header2.progrpusd, protype = detail3.FirstOrDefault() })
                .GroupJoin(_db.SB_PromotionConditionTime,
                    h3 => h3.header.pro_condition_time_id,
                    d4 => d4.pro_condition_time_id,
                    (header3, detail4) => new { header3.header, header3.prodetail, header3.progrpusd, header3.protype, proconditime = detail4.FirstOrDefault() })
                .GroupJoin(_db.SB_PromotionDiscount,
                    h4 => h4.header.pro_discount_id,
                    d5 => d5.pro_discount_id,
                    (header4, detail5) => new { header4.header, header4.prodetail, header4.progrpusd, header4.protype, header4.proconditime, prodiscoun = detail5.FirstOrDefault() })
                .GroupJoin(_db.SB_PromotionGiveType,
                    h5 => h5.header.pro_give_type_id,
                    d6 => d6.pro_give_type_id,
                    (header5, detail6) => new { header5.header, header5.prodetail, header5.progrpusd, header5.protype, header5.proconditime, header5.prodiscoun, progivetype = detail6.FirstOrDefault() })
                ;

            if (!string.IsNullOrWhiteSpace(search.KeywordsSearch))
            {
                query = query.Where(q =>
                    q.header.pro_name.Contains(search.KeywordsSearch)
                    );
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.header.pro_name);
                        break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.header.pro_start_date);
                        break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.header.pro_end_date);
                        break;
                }
            }

            var countTotal = query.Count();

            var model = query.ToArray().Select(s =>
            {
                return new ExtraPromotionModel
                {
                    pro_id = s.header.pro_id,
                    pro_name = s.header.pro_name,
                    pro_start_date = s.header.pro_start_date,
                    pro_start_time = s.header.pro_start_time,
                    pro_end_date = s.header.pro_end_date,
                    pro_end_time = s.header.pro_end_time,
                    pro_start = DateTime.ParseExact(s.header.pro_start_date + " " + (s.header.pro_start_time == "" ? "00:00:00" : s.header.pro_start_time), "dd/MM/yyyy HH:mm:ss", null),
                    allow_promotion = s.header.allow_promotion ?? false,
                    deleted = s.header.deleted,
                    count_give_product = 1,
                    used_promotion = DateTime.ParseExact(s.header.pro_start_date + " " + (s.header.pro_start_time == "" ? "00:00:00" : s.header.pro_start_time), "dd/MM/yyyy HH:mm:ss", null) > DateTime.Now ? "No" : "Yes",
                    check_expired =
                    (s.header.pro_end_date == "" ? "No" : (DateTime.Now >=
                   DateTime.ParseExact(s.header.pro_end_date + " " + (s.header.pro_end_time == "" ? "00:00:00" : s.header.pro_end_time)
                       , "dd/MM/yyyy HH:mm:ss", null) ? "Yes" : "No"))
                };
            });
            if (search.StartDate != null || search.EndDate != null)
            {
                if (!string.IsNullOrEmpty(search.StartDate) && !string.IsNullOrEmpty(search.EndDate))
                {
                    model = model.Where(q =>
                        DateTime.ParseExact(q.pro_start_date, "dd/MM/yyyy", null) >= DateTime.ParseExact(search.StartDate, "dd/MM/yyyy", null) &&
                        DateTime.ParseExact(q.pro_end_date, "dd/MM/yyyy", null) <= DateTime.ParseExact(search.EndDate, "dd/MM/yyyy", null)
                    );
                }
                else if (!string.IsNullOrEmpty(search.StartDate))
                {
                    model = model.Where(q =>
                        DateTime.ParseExact(q.pro_start_date, "dd/MM/yyyy", null) >= DateTime.ParseExact(search.StartDate, "dd/MM/yyyy", null) &&
                        DateTime.ParseExact(q.pro_start_date, "dd/MM/yyyy", null) <= DateTime.ParseExact(search.StartDate, "dd/MM/yyyy", null)
                    );
                }
            }
            if (!string.IsNullOrWhiteSpace(search.Status))
            {
                #region backup
                /*
                if (status == "true")
                {
                where += " AND a.allow_promotion = 1 AND a.deleted = 0 AND a.used_promotion = 'Yes' AND a.check_expired = 'No'";
                }
                else if (status == "false")
                {
                where += " AND a.allow_promotion = 0 AND a.deleted = 0 AND a.used_promotion = 'Yes' AND a.check_expired = 'No'";
                }
                else if (status == "notused")
                {
                where += " AND a.deleted = 0 AND a.used_promotion = 'No' AND a.check_expired = 'No'";
                }
                }
                else if (status == "expired")
                {
                where += " AND a.check_expired = 'Yes' AND a.deleted = 0";
                }
                else if (status == "cancel")
                {
                where += " AND a.deleted = 1";
                }
                */
                #endregion

                switch (search.Status)
                {
                    case "true":// // deleted = false = 0 = เปิดการใช้งาน, true = 1 = ปิดการใช้งาน
                        model = model.Where(q =>
                            q.allow_promotion && q.deleted == false && q.used_promotion == "Yes" && q.check_expired == "No");
                        break;
                    case "false":
                        model = model.Where(q =>
                            !q.allow_promotion && q.deleted == false && q.used_promotion == "Yes" && q.check_expired == "No");
                        break;
                    case "notused":
                        model = model.Where(q =>
                            q.deleted == false && q.used_promotion == "No" && q.check_expired == "No");
                        break;
                    case "expired":
                        model = model.Where(q =>
                            q.deleted == false && q.check_expired == "Yes");
                        break;
                    case "cancel":
                        model = model.Where(q =>
                             q.deleted == true);
                        break;
                }

            }

            model = model.OrderByDescending(o => o.allow_promotion && o.deleted == false && o.used_promotion == "Yes" && o.check_expired == "No").Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var dtModel = new DTResult<ExtraPromotionModel>()
            {

                data = model.ToList(),
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }
        public ExtraPromotionModel Get(string id)
        {
            var dbModel = _db.SB_PromotionHeader.FirstOrDefault(ed => ed.pro_id == id);
            var dbdetail = _db.SB_PromotionDetail.Where(ed => ed.pro_id == id).ToList();
            var model = _mapper.Map<ExtraPromotionModel>(dbModel);


            //model.SbPromotionDetail = new List<SbPromotionDetail>();
            //model.SbPromotionDetail.Add(new SbPromotionDetail { status_give_product = false });
            var promotionModel = _db.SB_PromotionHeader.GroupJoin(
                    _db.SB_PromotionDetail,
                    h => h.pro_id,
                    d => d.pro_id,
                    (head, details) => new { head, details })
                .Where(p => !(bool)p.head.deleted)
                .ToArray()
                .Where(p => p.head.pro_id == id);
            var list = promotionModel.Select(s => s.details);

            var newQuestion = _mapper.Map<ExtraPromotionModel, SB_PromotionHeader>(model);

            if (model.pro_condition_time_id == 1)
            {
                model.ProConditionWeekStart = model.pro_condition_time_start;
                model.ProConditionWeekTimeEnd = model.pro_condition_time_end;
            }
            if (model.pro_condition_time_id == 2)
            {
                model.ProConditionMonthStart = model.pro_condition_time_start;
                model.ProConditionMonthEnd = model.pro_condition_time_end;
            }

            model.pro_discount_unit_id = model.pro_discount_unit == "%" ? 0 : 1;

            // ขงแถม
            //if (model.pro_discount_id == 2)
            //{
            //    model.pro_discount_num2 = model.pro_discount_num;
            //    model.pro_discount_rate2 = model.pro_discount_rate;
            //    model.pro_discount_unit2 = model.pro_discount_unit;
            //    model.pro_discount_num = 0;
            //    model.pro_discount_rate = 0;
            //    model.pro_discount_unit = "";
            //}
            // Coupon
            if (model.pro_group_used_id == 4)
            {
                var cp = _db.SB_CouponDetail.Where(ed => ed.coupon_group_id == model.coupon_id);
                if (cp.Any())
                {
                    if (cp.Count() == 1)
                    {
                        //if (model.group_coupon_id == 0) model.group_coupon_id = 1;
                        model.coupon_group_id = cp.FirstOrDefault()?.coupon_group_id;
                        model.coupon_code = cp.FirstOrDefault()?.coupon_code;
                        model.coupon_name = cp.FirstOrDefault()?.coupon_name;
                        model.coupon_value_amount = cp.FirstOrDefault()?.coupon_value_amount;
                        model.coupon_value_percent = cp.FirstOrDefault()?.coupon_value_percent;
                    }
                    else
                    {
                        //if (model.group_coupon_id == 0) model.group_coupon_id = 2;
                        model.coupon_code2 = cp.FirstOrDefault()?.coupon_group_id;
                        model.SBCouponDetail = cp.Select(s => new SBCouponDetail
                        {
                            coupon_group_id = s.coupon_group_id,
                            coupon_code = s.coupon_code ?? "",
                            coupon_name = s.coupon_name ?? "",
                            coupon_value_amount = s.coupon_value_amount ?? 0,
                            coupon_value_percent = s.coupon_value_percent ?? 0,
                            coupon_status = s.coupon_status,
                            deleted = s.deleted
                        }).ToList();
                    }
                }
            }
            var pd = _db.SB_Product.ToList();
            if (model.pro_group_used_id == 5 || model.pro_group_used_id == 6)
            {
                model.SBPromotionDisDetail = model.SbPromotionDetail.Select(s => new SbPromotionDetailDisc
                {
                    pro_code = s.pro_code,
                    pro_name = pd.Where(w => w.pro_code == s.pro_code).First().pro_tname,
                    pro_price_detail = pd.Where(w => w.pro_code == s.pro_code).First().lasted_cost ?? 0,
                    pro_discount_rate_special = float.Parse(s.pro_discount_rate_special.ToString())
                }).ToList();
            }
            if (model.pro_group_used_id == 6)
            {
                model.SBProCouponDetailEmp = _db.SB_PromotionCouponDetailEmp.Where(w => w.pro_id == model.pro_id).Select(s => new SB_ProCouponDetailEmp
                {
                    coupon_code = s.coupon_code
                }).ToList();
            }
            return model;
        }

        public void GetPromotionitems(ExtraPromotionModel ms)
        {
            //string sql = string.Format(@"

            //            SELECT        pro_id,pro_brand_code, pro_brand, pro_model_code, pro_model, pro_code, pro_tname, pro_size_code, size_name,pro_discount
            //            FROM            (SELECT        Product_Detail.pro_brand_code, Product_Detail.pro_brand, Product_Detail.pro_model_code, Product_Detail.pro_model, Product_Detail.pro_code, Product_Detail.pro_tname, Product_Detail.pro_size_code, 
            //                                     Product_Detail.size_name, SB_PromotionHeader.pro_id,(CAST(SB_PromotionDetail.pro_discount_rate_special as nvarchar) + ' ' + SB_PromotionDetail.pro_discount_unit_special) as pro_discount
            //            FROM            SB_PromotionDetail INNER JOIN
            //                                     SB_PromotionHeader ON SB_PromotionDetail.pro_id = SB_PromotionHeader.pro_id INNER JOIN
            //                                         (SELECT        SB_Probrand.pro_brand_code, SB_Probrand.pro_brand, SB_Promodel.pro_model_code, SB_Promodel.pro_model, SB_Product.pro_code, SB_Product.pro_tname, SB_ProSize.pro_size_code, 
            //                                                                     SB_ProSize.size_name
            //                                           FROM            SB_Probrand INNER JOIN
            //                                                                     SB_Promodel ON SB_Probrand.pro_brand_code = SB_Promodel.pro_brand_code INNER JOIN
            //                                                                     SB_Product ON SB_Promodel.pro_model_code = SB_Product.pro_model_code LEFT OUTER JOIN
            //                                                                     SB_ProSize ON SB_Product.pro_size_code = SB_ProSize.pro_size_code) AS Product_Detail ON SB_PromotionDetail.pro_brand_code = Product_Detail.pro_brand_code AND 
            //                                     SB_PromotionDetail.pro_model_code = Product_Detail.pro_model_code AND SB_PromotionDetail.pro_code = Product_Detail.pro_code AND SB_PromotionDetail.pro_size_code = Product_Detail.pro_size_code) 
            //                                     AS FinalTB
            //            WHERE pro_id = '{0}'
            //            GROUP BY pro_id,pro_brand_code, pro_brand, pro_model_code, pro_model, pro_code, pro_tname, pro_size_code, size_name,pro_discount
            //    ", id);
            var data = ""; string where = "";

            where = "";
            string progift = "";
            if (ms.SbPromotionDetail.Any(s => s.progroup_code == "0" && s.pro_brand_code == "0" && s.pro_model_code == "0" && s.pro_size_code == "0"))
            {
                progift = ms.SbPromotionDetail.FirstOrDefault(s =>
                        s.progroup_code == "0" && s.pro_brand_code == "0" && s.pro_model_code == "0" &&
                        s.pro_size_code == "0")
                    ?.pro_code;
                ms.SbPromotionDetail.RemoveAll(s =>
                    s.progroup_code == "0" && s.pro_brand_code == "0" && s.pro_model_code == "0" && s.pro_size_code == "0");
            }

            string productgrp = string.Join(",", ms.SbPromotionDetail.Select(s => s.product_group_code).ToArray());// /*กลุ่มสินค้า */	  
            string progroup = string.Join(",", ms.SbPromotionDetail.Select(s => s.progroup_code).ToArray());// /*ประเภทสินค้า */	  
            string probrand = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_brand_code).ToArray());// /*ยี่ห้อสินค้า */	
            string promodel = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_model_code).ToArray());// /*รุ่นสินค้าสินค้า */	
            string prosize = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_size_code).ToArray());// /*ขนาดสินค้า */	  

            var _brand = _db.SB_Probrand.ToList();
            var _modal = _db.SB_Promodel.ToList();
            var _size = _db.SB_ProSize.ToList();

            if (ms.pro_group_used_id == 5 || ms.pro_group_used_id == 6)
            {
                where += " AND pro_code in ('" + string.Join("','", ms.SBPromotionDisDetail.Select(s => s.pro_code).ToArray()) + "')";
            }
            else
            {
                if (productgrp == "0" && progroup == "0" && probrand == "0" && promodel == "0" && prosize == "0")
                {

                }
                else
                {
                    if (!string.IsNullOrEmpty(productgrp))
                    {               // /*กลุ่มสินค้า */	  
                        where += " AND progroup_code in (SELECT progroup_code FROM SB_Progroup WHERE product_group_code in (" + productgrp + ")) ";
                    }
                    if (!string.IsNullOrEmpty(progroup))
                    {               // /*ประเภทสินค้า */	  
                        if (ms.SbPromotionDetail.Any(s => s.progroup_code == "0"))
                        {
                            GetProgroup(ms, "", "");
                            where += " AND progroup_code in (" + string.Join(",", ms.temp_progroupList.Select(s => s.progroup_code).ToArray()) + ") ";
                        }
                        else
                        {
                            where += " AND progroup_code in (" + progroup + ") ";
                        }
                    }
                    if (!string.IsNullOrEmpty(probrand))
                    {               // /*ยี่ห้อสินค้า */	  
                        if (ms.SbPromotionDetail.Any(s => s.pro_brand_code == "0"))
                        {
                            GetProbrand(ms, "", "");
                            where += " AND (  pro_brand_code in (" + string.Join(",", ms.temp_probrandList.Select(s => s.pro_brand_code).ToArray()) + ")) ";
                        }
                        else
                        {
                            where += " AND (  pro_brand_code in (" + probrand + ")) ";
                        }
                    }
                    if (!string.IsNullOrEmpty(promodel))
                    {               // /*รุ่นสินค้าสินค้า */	  
                        if (ms.SbPromotionDetail.Any(s => s.pro_model_code == "0"))
                        {
                            GetPromodel(ms, "", "");
                            where += " AND (  pro_model_code in (" + string.Join(",", ms.temp_PromodelList.Select(s => s.pro_model_code).ToArray()) + ")) ";
                        }
                        else
                        {
                            where += " AND (  pro_model_code in (" + promodel + ")) ";
                        }
                    }
                    if (!string.IsNullOrEmpty(prosize))
                    {               // /*ขนาดสินค้า */	  
                        if (ms.SbPromotionDetail.Any(s => s.pro_size_code == "0"))
                        {
                            GetProSize(ms, "", "");
                            where += " AND (  pro_size_code in (" + string.Join(",", ms.temp_ProSizeList.Select(s => s.pro_size_code).ToArray()) + ")) ";
                        }
                        else
                        {
                            where += " AND (  pro_size_code in (" + prosize + ")) ";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(progift))
                {               // /*กลุ่มสินค้า */	  
                    where += " OR pro_code = '" + progift + "'";
                }
            }

            string sql = @"
    SELECT pro_brand_code,pro_model_code,pro_code,pro_tname,pro_size_code FROM SB_Product 
	WHERE 1=1 
    {0}
    AND stock_status = '0'
	ORDER BY pro_tname";
            if (ms.pro_group_used_id == 5 || ms.pro_group_used_id == 6)
            {
                ms.PromotionItems = _db.Database.SqlQuery<PromotionItem>(string.Format(sql, where))
                .Select(s => new PromotionItem
                {
                    pro_brand = _brand.FirstOrDefault(_ => _.pro_brand_code == s.pro_brand_code)?.pro_brand,
                    pro_model = _modal.FirstOrDefault(_ => _.pro_model_code == s.pro_model_code)?.pro_model,
                    pro_code = s.pro_code,
                    pro_tname = s.pro_tname,
                    size_name = _size.FirstOrDefault(_ => _.pro_size_code == s.pro_size_code)?.size_name,
                    pro_discount = ms.SBPromotionDisDetail.FirstOrDefault(_ => _.pro_code == s.pro_code).pro_discount_rate_special + ""
                }).ToList();
                ms.title_price_view = "ราคาส่วนลด";
            }
            else if(ms.pro_group_used_id == 2 || ms.pro_group_used_id == 3)
            {
                ms.PromotionItems = _db.Database.SqlQuery<PromotionItem>(string.Format(sql, where))
                .Select(s => new PromotionItem
                {
                    pro_brand = _brand.FirstOrDefault(_ => _.pro_brand_code == s.pro_brand_code)?.pro_brand,
                    pro_model = _modal.FirstOrDefault(_ => _.pro_model_code == s.pro_model_code)?.pro_model,
                    pro_code = s.pro_code,
                    pro_tname = s.pro_tname,
                    size_name = _size.FirstOrDefault(_ => _.pro_size_code == s.pro_size_code)?.size_name,
                    pro_discount = ms.pro_type_detail + (ms.pro_type_id == 1 ? " %" : "") + ""
                }).ToList();
                ms.title_price_view = (ms.pro_type_id == 1 ? "ส่วนลด" : "ราคาส่วนลด");
            }
            else if (ms.pro_group_used_id == 4)
            {
                string pro_discount = "0";
                ms.title_price_view = "ส่วนลด";
                if (ms.coupon_value_percent > 0)
                {
                    pro_discount = ms.coupon_value_percent + " %";
                    ms.title_price_view = "ส่วนลด";
                }
                else if (ms.coupon_value_amount > 0)
                {
                    pro_discount = ms.coupon_value_amount + "";
                    ms.title_price_view = "ราคาส่วนลด";
                }
                else if (ms.coupon_code2 != null)
                {
                    pro_discount = ms.coupon_code2;
                    ms.title_price_view = "กลุ่มส่วนลด";
                }
                ms.PromotionItems = _db.Database.SqlQuery<PromotionItem>(string.Format(sql, where))
                .Select(s => new PromotionItem
                {
                    pro_brand = _brand.FirstOrDefault(_ => _.pro_brand_code == s.pro_brand_code)?.pro_brand,
                    pro_model = _modal.FirstOrDefault(_ => _.pro_model_code == s.pro_model_code)?.pro_model,
                    pro_code = s.pro_code,
                    pro_tname = s.pro_tname,
                    size_name = _size.FirstOrDefault(_ => _.pro_size_code == s.pro_size_code)?.size_name,
                    pro_discount = pro_discount
                }).ToList();
            }
            else
            {
                ms.PromotionItems = _db.Database.SqlQuery<PromotionItem>(string.Format(sql, where))
                .Select(s => new PromotionItem
                {
                    pro_brand = _brand.FirstOrDefault(_ => _.pro_brand_code == s.pro_brand_code)?.pro_brand,
                    pro_model = _modal.FirstOrDefault(_ => _.pro_model_code == s.pro_model_code)?.pro_model,
                    pro_code = s.pro_code,
                    pro_tname = s.pro_tname,
                    size_name = _size.FirstOrDefault(_ => _.pro_size_code == s.pro_size_code)?.size_name,
                    pro_discount = ms.pro_discount_rate + ""
                }).ToList();
                ms.title_price_view = "ส่วนลด";
            }
            //return _db.Database.SqlQuery<PromotionItem>(sql).ToList();
        }

        //Step1
        public void GetPromotionList(ExtraPromotionModel ms)
        {
            if (ms.PromotionList == null) ms.PromotionList = new List<PromotionList>();
            HashSet<string> hasAllowMutiProdetail = new HashSet<string>();
            if (ms.allow_muti_promotion_detail != null)
                hasAllowMutiProdetail = new HashSet<string>(ms.allow_muti_promotion_detail.Split(','));

            ms.PromotionList = _db.Database.SqlQuery<PromotionList>("SP_Promotion_AllowMuti").Where(w => w.pro_id != ms.pro_id).Select(s => new PromotionList
            {
                pro_id = s.pro_id,
                pro_name = s.pro_name,
                IsCheck = hasAllowMutiProdetail.Contains(s.pro_id)
            }).ToList();
        }
        public void GetDealers(ExtraPromotionModel ms)
        {
            if (ms.Dealers == null) ms.Dealers = new List<DealercodeModel>();
            HashSet<string> hasBranchNoList = new HashSet<string>();
            if (ms.branch_no_list != null)
                hasBranchNoList = new HashSet<string>(ms.branch_no_list.Split(','));

            string sql = @"select dealer.dealercode deal_dealercode, *
                            from SB_Dealercode_Master dealer 
                            left join SB_Branch branch on dealer.dealercode = branch.dealercode
                            where flag_used = 'True' 
                            order by dealer.dealercode";

            ms.Dealers = _db.Database.SqlQuery<DealercodeModel>(sql).Select(s => new DealercodeModel
            {
                plant_no = s.plant_no,
                dealercode = s.dealercode,
                DealerName = s.DealerName,
                IsCheck = hasBranchNoList.Contains(s.dealercode)
            }).ToList();

            //ms.Dealers = _db.SB_Dealercode_Master
            //    .Select(s => new DealercodeModel
            //    {
            //        DealerCode = s.dealercode,
            //        DealerName = s.DealerName,
            //        IsCheck = hasBranchNoList.Contains(s.dealercode)
            //    }).ToList();

        }
        public void GetConditionMonth(ExtraPromotionModel ms)
        {
            HashSet<string> hasProConditionTimeDetail = new HashSet<string>();
            if (ms.pro_condition_time_detail != null)
                hasProConditionTimeDetail = new HashSet<string>(ms.pro_condition_time_detail.Split(','));

            if (ms.ConditionMonth == null) ms.ConditionMonth = new List<ConditionMonth>();
            var LenMount = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            ms.ConditionMonth = (from n in Enumerable.Range(1, LenMount)
                                 select new ConditionMonth
                                 {
                                     Id = (int)n,
                                     Name = n.ToString(),
                                     IsSelected = hasProConditionTimeDetail.Contains(n.ToString())
                                 }).ToList();
        }
        public void GetConditionWeek(ExtraPromotionModel ms)
        {
            HashSet<string> hasProConditionTimeDetail = new HashSet<string>();
            if (ms.pro_condition_time_detail != null)
                hasProConditionTimeDetail = new HashSet<string>(ms.pro_condition_time_detail.Split(','));

            if (ms.ConditionWeek == null) ms.ConditionWeek = new List<ConditionWeek>();

            //var hasweek = new HashSet<string>(ms.ProConditionTimeDetail.Split(','));
            //string[] hasweek = ms.ProConditionTimeDetail.Split(',').ToArray<string>();
            ms.ConditionWeek = (from _days d in Enum.GetValues(typeof(_days))
                                select new ConditionWeek
                                {
                                    Id = (int)d,
                                    Name = d.ToString(),
                                    //IsSelected = hasProConditionTimeDetail.Contains((int)d)
                                    //IsCheck = hasweek.Contains(d.ToString().Substring(0, 3))
                                }).ToList();
            ms.ConditionWeek.Where(w => hasProConditionTimeDetail.Contains(w.Id.ToString())).Select(s => { s.IsSelected = true; return s; }).ToList();
        }

        //Step 3
        public void GetCusType(ExtraPromotionModel ms)
        {
            HashSet<string> hasProGroupUsedDetail = new HashSet<string>();
            if (ms.pro_group_used_detail != null)
                hasProGroupUsedDetail = new HashSet<string>(ms.pro_group_used_detail.Split(','));

            if (ms.ProGrpUsedDetailsList == null)
            {
                ms.ProGrpUsedDetailsList = new List<ProGrpUsedDetail>
                {
                    new ProGrpUsedDetail
                    {
                        custype_code = "",
                        custype_name = "ลูกค้าทุกประเภท"
                    }
                };
            }
            ms.ProGrpUsedDetailsList.AddRange(_db.SB_Custype.Select(s => new ProGrpUsedDetail
            {
                custype_code = s.custype_code,
                custype_name = s.custype_name,
                IsCheck = hasProGroupUsedDetail.Contains(s.custype_code)
            }));
            //ms.ProGrpUsedDetailsList = _db.SB_Custype.Select(s => new ProGrpUsedDetail
            //{
            //    custype_code = s.custype_code,
            //    custype_name = s.custype_name,
            //    IsCheck = hasProGroupUsedDetail.Contains(s.custype_code)
            //}).ToList();
        }
        //กลุ่มสินค้า
        public void GetProgroupFirstGroup(ExtraPromotionModel ms)
        {
            var data = "";
            if (ms.SbPromotionDetail != null)
            {
                data = ms.SbPromotionDetail.Select(s => s.product_group_code).FirstOrDefault();
            }

            HashSet<string> hasProduct_group_code = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProduct_group_code = new HashSet<string>(data.Split(','));

            if (ms.prodfirstgroupList == null) ms.prodfirstgroupList = new List<ProdFirstGrpModel>();
            ms.prodfirstgroupList = _db.SB_Product_FirstGroup.OrderBy(o => o.product_group_id).Select(s => new ProdFirstGrpModel
            {
                product_group_code = s.product_group_code.ToString(),
                product_group_name = s.product_group_name,
                IsCheck = hasProduct_group_code.Contains(s.product_group_code.ToString())
            }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.product_group_code).Contains("0"))
                {
                    ms.temp_prodgroupList = _db.SB_Product_FirstGroup.OrderBy(o => o.product_group_id).Select(s => new ProdFirstGrpModel
                    {
                        product_group_code = s.product_group_code.ToString(),
                        product_group_name = s.product_group_name
                    }).ToList();
                }
        }
        //ประเภทสินค้า :
        public void GetProgroup(ExtraPromotionModel ms, string arrchk, string hasChk)
        {
            var data = "";
            string where = "";
            if (!string.IsNullOrEmpty(arrchk))
            {
                where += " AND product_group_code in ( " + arrchk + " ) ";
            }

            string sql = "select * from SB_Progroup where 1=1 {0} ";
            if (ms.SbPromotionDetail != null)
            {
                data = ms.SbPromotionDetail.Select(s => s.progroup_code).FirstOrDefault();
            }
            HashSet<string> hasProgroup_code = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProgroup_code = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasChk))
                hasProgroup_code.UnionWith(new HashSet<string>(hasChk.Split(',')));

            if (ms.progroupList == null) ms.progroupList = new List<ProGrpListModel>();
            ms.progroupList = _db.Database.SqlQuery<ProGrpListModel>(string.Format(sql, where)).Select(s => new ProGrpListModel
            {
                progroup_code = s.progroup_code,
                progroup_name = s.progroup_name,
                IsCheck = hasProgroup_code.Contains(s.progroup_code)
            }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.progroup_code).Contains("0"))
                {
                    if (ms.SbPromotionDetail.Any(s => s.product_group_code == "0"))
                    {
                        ms.temp_progroupList = _db.Database.SqlQuery<ProGrpListModel>(string.Format(sql, " AND product_group_code in ( " + string.Join(",", ms.temp_prodgroupList.Select(s => s.product_group_code).ToArray()) + " ) ")).Select(s => new ProGrpListModel
                        {
                            progroup_code = s.progroup_code,
                            progroup_name = s.progroup_name
                        }).ToList();
                    }
                    else
                    {
                        ms.temp_progroupList = _db.Database.SqlQuery<ProGrpListModel>(string.Format(sql, " AND product_group_code in ( " + string.Join(",", ms.SbPromotionDetail.Select(s => s.product_group_code).ToArray()) + " ) ")).Select(s => new ProGrpListModel
                        {
                            progroup_code = s.progroup_code,
                            progroup_name = s.progroup_name
                        }).ToList();
                    }
                }
        }
        //ยี่ห้อสินค้า :
        public void GetProbrand(ExtraPromotionModel ms, string arrchk, string hasChk)
        {
            var data = "";
            string where = "";
            if (!string.IsNullOrEmpty(arrchk))
            {
                where += " AND a.progroup_code in ( " + arrchk + " ) --ประเภทสินค้า";
            }
            string sql = @"SELECT CONVERT(nvarchar,a.pro_brand_code) as pro_brand_code, a.pro_brand FROM SB_Probrand AS a	
                                LEFT JOIN SB_Progroup AS b ON a.progroup_code = b.progroup_code
								where 1=1 {0}
                                ORDER BY a.pro_brand";
            if (ms.SbPromotionDetail != null)
            {
                data = ms.SbPromotionDetail.Select(s => s.pro_brand_code).FirstOrDefault();
                //data = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_brand_code).ToArray());
            }
            HashSet<string> hasProBrandCode = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProBrandCode = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasChk))
                hasProBrandCode.UnionWith(new HashSet<string>(hasChk.Split(',')));

            if (ms.probrandList == null) ms.probrandList = new List<ProBrandListModel>();
            ms.probrandList = _db.Database.SqlQuery<ProBrandListModel>(string.Format(sql, where)).Select(s => new ProBrandListModel
            {
                pro_brand_code = s.pro_brand_code,
                pro_brand = s.pro_brand,
                IsCheck = hasProBrandCode.Contains(s.pro_brand_code.ToString())
            }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.pro_brand_code).Contains("0"))
                {
                    if (ms.SbPromotionDetail.Select(s => s.progroup_code).Contains("0") && ms.temp_progroupList.Select(s => s.progroup_code).Any())
                    {
                        where = " AND a.progroup_code in ( " + string.Join(",", ms.temp_progroupList.Select(s => s.progroup_code).ToArray()) + " ) ";
                    }
                    else
                    {
                        where = " AND a.progroup_code in ( " + string.Join(",", ms.SbPromotionDetail.Select(s => s.progroup_code).ToArray()) + " ) ";
                    }
                    ms.temp_probrandList = _db.Database.SqlQuery<ProBrandListModel>(string.Format(sql, where)).Select(s => new ProBrandListModel
                    {
                        pro_brand_code = s.pro_brand_code,
                        pro_brand = s.pro_brand
                    }).ToList();
                }
        }
        //รุ่นสินค้าสินค้า :
        public void GetPromodel(ExtraPromotionModel ms, string arrchk, string hasChk)
        {
            var data = "";
            string where = "";
            if (!string.IsNullOrEmpty(arrchk))
            {
                where += " AND a.pro_brand_code in ( " + arrchk + " ) --ยี่ห้อสินค้า";
            }
            string sql = @"SELECT CONVERT(nvarchar,a.pro_model_code) as pro_model_code, a.pro_model FROM SB_Promodel AS a	
                                LEFT JOIN SB_Probrand AS b ON a.pro_brand_code = b.pro_brand_code
								where 1=1 {0}
                                ORDER BY a.pro_model";
            if (ms.SbPromotionDetail != null)
            {
                data = ms.SbPromotionDetail.Select(s => s.pro_model_code).FirstOrDefault();
                //data = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_model_code).ToArray());
            }
            HashSet<string> hasProModelCode = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProModelCode = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasChk))
                hasProModelCode.UnionWith(new HashSet<string>(hasChk.Split(',')));

            if (ms.PromodelList == null) ms.PromodelList = new List<PromodelModel>();
            ms.PromodelList = _db.Database.SqlQuery<PromodelModel>(string.Format(sql, where)).Select(s => new PromodelModel
            {
                pro_model_code = s.pro_model_code,
                pro_model = s.pro_model,
                IsCheck = hasProModelCode.Contains(s.pro_model_code.ToString())
            }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.pro_model_code).Contains("0"))
                {
                    if (ms.SbPromotionDetail.Select(s => s.pro_brand_code).Contains("0") && ms.temp_probrandList.Select(s => s.pro_brand_code).Any())
                    {
                        where = " AND a.pro_brand_code in ( " + string.Join(",", ms.temp_probrandList.Select(s => s.pro_brand_code).ToArray()) + " ) ";
                    }
                    else
                    {
                        where = " AND a.pro_brand_code in ( " + string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_brand_code).ToArray()) + " ) ";
                    }
                    ms.temp_PromodelList = _db.Database.SqlQuery<PromodelModel>(string.Format(sql, where)).Select(s => new PromodelModel
                    {
                        pro_model_code = s.pro_model_code,
                        pro_model = s.pro_model
                    }).ToList();
                }
        }
        //ขนาดสินค้า :
        public void GetProSize(ExtraPromotionModel ms, string arrchk, string hasChk)
        {
            var data = "";
            string where = "";
            if (!string.IsNullOrEmpty(arrchk))
            {
                where += " AND a.pro_model_code in ( " + arrchk + " ) --รุ่นสินค้าสินค้า";
            }
            string sql = @"SELECT DISTINCT CONVERT(nvarchar,b.pro_size_code) as pro_size_code, b.size_name FROM SB_Product AS a LEFT JOIN SB_ProSize AS b ON a.pro_size_code = b.pro_size_code
								WHERE a.pro_size_code IS NOT NULL AND b.pro_size_code IS NOT NULL
								{0}
								ORDER BY b.size_name";
            if (ms.SbPromotionDetail != null)
            {
                data = ms.SbPromotionDetail.Select(s => s.pro_size_code).FirstOrDefault();
                //data = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_size_code).ToArray());
            }
            HashSet<string> hasProSizeCode = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProSizeCode = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasChk))
                hasProSizeCode.UnionWith(new HashSet<string>(hasChk.Split(',')));

            if (ms.ProSizeList == null) ms.ProSizeList = new List<ProSizeModel>();
            ms.ProSizeList = _db.Database.SqlQuery<ProSizeModel>(string.Format(sql, where)).Select(s => new ProSizeModel
            {
                pro_size_code = s.pro_size_code,
                size_name = s.size_name,
                IsCheck = hasProSizeCode.Contains(s.pro_size_code.ToString())
            }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.pro_size_code).Contains("0"))
                {
                    if (ms.SbPromotionDetail.Select(s => s.pro_model_code).Contains("0"))
                    {
                        where = " AND a.pro_model_code in ( " + string.Join(",", ms.temp_PromodelList.Select(s => s.pro_model_code).ToArray()) + " ) ";
                    }
                    else
                    {
                        where = " AND a.pro_model_code in ( " + string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_model_code).ToArray()) + " ) ";
                    }
                    ms.temp_ProSizeList = _db.Database.SqlQuery<ProSizeModel>(string.Format(sql, where)).Select(s => new ProSizeModel
                    {
                        pro_size_code = s.pro_size_code,
                        size_name = s.size_name
                    }).ToList();
                }
        }
        //ค้นหาสินค้า : 
        public void GetProduct(
            ExtraPromotionModel ms,
            string productgrp,
            string progroup,
            string probrand,
            string promodel,
            string prosize, string hasprocode)
        {
            var data = ""; string where = "";
            if (!string.IsNullOrEmpty(productgrp))
            {               // /*กลุ่มสินค้า */	  
                where += " AND progroup_code in (SELECT progroup_code FROM SB_Progroup WHERE product_group_code in (" + productgrp + ")) ";
            }
            if (!string.IsNullOrEmpty(progroup))
            {               // /*ประเภทสินค้า */	  
                            //where += " AND progroup_code in (" + progroup + ") ";
                where += " and SB_Product.progroup_code in ('" + string.Join("','", progroup.Split(',')) + "')";
            }
            if (!string.IsNullOrEmpty(probrand))
            {               // /*ยี่ห้อสินค้า */	  
                //where += " AND (  pro_brand_code in (" + probrand + ")) ";
                where += " and SB_Product.pro_brand_code in (" + probrand + ")";
            }
            if (!string.IsNullOrEmpty(promodel))
            {               // /*รุ่นสินค้าสินค้า */	  
                            //where += " AND (  pro_model_code in (" + promodel + ")) ";
                where += " and SB_Product.pro_model_code in (" + promodel + ")";
            }
            if (!string.IsNullOrEmpty(prosize))
            {               // /*ขนาดสินค้า */	  
                            // where += " AND (  pro_size_code in (" + prosize + ")) ";
                where += " and SB_Product.pro_size_code in (" + prosize + ")";
            }
            string sql = @"
    SELECT pro_code, pro_tname 
FROM SB_Product 
INNER JOIN SB_Progroup ON SB_Product.progroup_code =SB_Progroup.progroup_code 
Left Join SB_Product_FirstGroup ON SB_Progroup.product_group_code = SB_Product_FirstGroup.product_group_code 
Left JOIN SB_Probrand ON SB_Probrand.pro_brand_code = SB_Product.pro_brand_code 
Left JOIN SB_Promodel ON SB_Promodel.pro_model_code = SB_Product.pro_model_code 
Left JOIN  SB_ProSize	ON SB_ProSize.pro_size_code = SB_Product.pro_size_code
WHERE 1=1 and SB_Product.type_of_product = '01' 
    {0}
and
    (SB_Product.cancel_date is null or SB_Product.cancel_date = '') 
and 
    SB_Product.stock_status = '0' 
ORDER BY SB_Product.pro_code";
            if (ms.pro_group_used_id == 1 || ms.pro_group_used_id == 2)
            {
                if (ms.SbPromotionDetail != null)
                {// status_give_product == true  ไม่เอาของแถม
                    data = string.Join(",", ms.SbPromotionDetail.Where(w => w.status_give_product == true).Select(s => s.pro_code).ToArray());
                }
            }
            else
            {
                if (ms.SbPromotionDetail != null)
                {
                    data = ms.SbPromotionDetail.Select(s => s.pro_code).FirstOrDefault();
                }
            }

            string Inject = "";
            HashSet<string> hasProCode = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProCode = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasprocode))
                hasProCode.UnionWith(new HashSet<string>(hasprocode.Split(',')));

            if (ms.ProductsList == null) ms.ProductsList = new List<ProductsModel>();

            ms.ProductsList = _db.Database.SqlQuery<ProductsModel>(string.Format(sql, where))
                .Select(s => new ProductsModel
                {
                    pro_tname = s.pro_tname,
                    pro_code = s.pro_code,
                    IsCheck = hasProCode.Contains(s.pro_code)
                }).ToList();

            if (ms.SbPromotionDetail != null)
                if (ms.SbPromotionDetail.Select(s => s.pro_code).Contains("0"))
                {
                    where = "";
                    productgrp = string.Join(",", ms.SbPromotionDetail.Select(s => s.product_group_code).Distinct().ToArray());
                    progroup = string.Join(",", ms.SbPromotionDetail.Select(s => s.progroup_code).Distinct().ToArray());
                    probrand = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_brand_code).Distinct().ToArray());
                    promodel = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_model_code).Distinct().ToArray());
                    prosize = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_size_code).Distinct().ToArray());
                    if (productgrp == "0" && progroup == "0" && probrand == "0" && promodel == "0" && prosize == "0")
                    {

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(productgrp))
                        {               // /*กลุ่มสินค้า */	  
                            //where += " AND progroup_code in (SELECT progroup_code FROM SB_Progroup WHERE product_group_code in (" + productgrp + ")) ";
                            where += " and SB_Product_FirstGroup.product_group_code in (" + productgrp + ") ";
                        }
                        if (!string.IsNullOrEmpty(progroup))
                        {               // /*ประเภทสินค้า */	  
                            if (ms.SbPromotionDetail.Select(s => s.progroup_code).Contains("0") && ms.temp_progroupList.Select(s => s.progroup_code).Any())
                            {
                                //where += " AND progroup_code in (" + string.Join(",", ms.temp_progroupList.Select(s => s.progroup_code).ToArray()) + ") ";
                                where += " and SB_Product.progroup_code in (" + string.Join(",", ms.temp_progroupList.Select(s => s.progroup_code).Distinct().ToArray()) + ") ";
                            }
                            else
                            {
                                //where += " AND progroup_code in (" + progroup + ") ";
                                where += " and SB_Product.progroup_code in ('" + string.Join("','", progroup.Split(',')) + "')";
                            }
                        }
                        if (!string.IsNullOrEmpty(probrand))
                        {               // /*ยี่ห้อสินค้า */	  
                            if (ms.SbPromotionDetail.Select(s => s.pro_brand_code).Contains("0") && ms.temp_probrandList.Select(s => s.pro_brand_code).Any())
                            {
                                //where += " AND (  pro_brand_code in (" + string.Join(",", ms.temp_probrandList.Select(s => s.pro_brand_code).ToArray()) + ")) ";
                                where += " and SB_Product.pro_brand_code in (" + string.Join(",", ms.temp_probrandList.Select(s => s.pro_brand_code).Distinct().ToArray()) + ") ";
                            }
                            else
                            {
                                //where += " AND (  pro_brand_code in (" + probrand + ")) ";
                                where += " and SB_Product.pro_brand_code in (" + probrand + ")";
                            }
                        }
                        if (!string.IsNullOrEmpty(promodel))
                        {               // /*รุ่นสินค้าสินค้า */	  
                            if (ms.SbPromotionDetail.Select(s => s.pro_model_code).Contains("0") && ms.temp_PromodelList.Select(s => s.pro_model_code).Any())
                            {
                                //where += " AND (  pro_model_code in (" + string.Join(",", ms.temp_PromodelList.Select(s => s.pro_model_code).ToArray()) + ")) ";
                                where += " and SB_Product.pro_model_code in (" + string.Join(",", ms.temp_PromodelList.Select(s => s.pro_model_code).Distinct().ToArray()) + ") ";
                            }
                            else
                            {
                                //where += " AND (  pro_model_code in (" + promodel + ")) ";
                                where += " and SB_Product.pro_model_code in (" + promodel + ")";
                            }
                        }
                        if (!string.IsNullOrEmpty(prosize))
                        {               // /*ขนาดสินค้า */	  
                            if (ms.SbPromotionDetail.Select(s => s.pro_size_code).Contains("0") && ms.temp_ProSizeList.Select(s => s.pro_size_code).Any())
                            {
                                //where += " AND (  pro_size_code in (" + string.Join(",", ms.temp_ProSizeList.Select(s => s.pro_size_code).ToArray()) + ")) ";
                                where += " and SB_Product.pro_size_code  in (" + string.Join(",", ms.temp_ProSizeList.Select(s => s.pro_size_code).Distinct().ToArray()) + ") ";
                            }
                            else
                            {
                                //where += " AND (  pro_size_code in (" + prosize + ")) ";
                                where += " and SB_Product.pro_size_code in (" + prosize + ")";
                            }
                        }
                    }

                    ms.temp_ProductsList = _db.Database.SqlQuery<ProductsModel>(string.Format(sql, where))
                        .Select(s => new ProductsModel
                        {
                            pro_tname = s.pro_tname,
                            pro_code = s.pro_code
                        }).ToList();
                }
        }
        public void GetProductGift(
            ExtraPromotionModel ms, string hasprocode)
        {
            var data = ""; string where = "";
            string sql = @"
    SELECT pro_code, pro_tname FROM SB_Product 
	WHERE 1=1 
    {0}
    AND stock_status = '0'
	ORDER BY pro_tname";
            if (ms.pro_group_used_id == 1 || ms.pro_group_used_id == 2)
            {
                if (ms.SbPromotionDetail != null)
                {// status_give_product == false  ของแถม
                    data = string.Join(",", ms.SbPromotionDetail.Where(w => w.status_give_product == false).Select(s => s.pro_code).ToArray());
                }
            }
            else
            {
                if (ms.SbPromotionDetail != null)
                {
                    data = string.Join(",", ms.SbPromotionDetail.Select(s => s.pro_code).ToArray());
                }
            }

            string Inject = "";
            HashSet<string> hasProCode = new HashSet<string>();
            if (!string.IsNullOrEmpty(data))
                hasProCode = new HashSet<string>(data.Split(','));
            if (!string.IsNullOrEmpty(hasprocode))
                hasProCode.UnionWith(new HashSet<string>(hasprocode.Split(',')));

            if (ms.ProdGiveList == null) ms.ProdGiveList = new List<ProductsModel>();

            ms.ProdGiveList = _db.Database.SqlQuery<ProductsModel>(string.Format(sql, where))
                .Select(s => new ProductsModel
                {
                    pro_tname = s.pro_tname,
                    pro_code = s.pro_code,
                    IsCheck = hasProCode.Contains(s.pro_code)
                }).ToList();
        }
        public void GetProGiveTypeList(ExtraPromotionModel ms)
        {
            if (ms.ProGiveTypeList == null) ms.ProGiveTypeList = new List<ProGiveTypeList>();
            ms.ProGiveTypeList = _db.SB_PromotionGiveType.Where(w => w.deleted == false).Select(s => new ProGiveTypeList
            {
                pro_give_type_id = s.pro_give_type_id,
                pro_give_type_name = s.pro_give_type_name,
                pro_give_type_unit = s.pro_give_type_unit
            }).ToList();
        }
        public void GetProPriceList(ExtraPromotionModel ms)
        {
            if (ms.ProPriceModelList == null) ms.ProPriceModelList = new List<ProPriceModel>();
            ms.ProPriceModelList = _db.SB_PromotionPrice.Where(w => w.deleted == false).Select(s => new ProPriceModel
            {
                pro_price_id = s.pro_price_id,
                pro_price_name = s.pro_price_name
            }).ToList();
        }
        public void GetProTypeList(ExtraPromotionModel ms)
        {
            if (ms.ProTypeList == null) ms.ProTypeList = new List<ProTypeList>();
            ms.ProTypeList = _db.SB_PromotionType.Where(w => w.deleted == false).Select(s => new ProTypeList
            {
                pro_type_id = s.pro_type_id,
                pro_type_name = s.pro_type_name
            }).ToList();
            if (ms.pro_group_used_id == 3)
                ms.ProTypeList = ms.ProTypeList.Where(w => w.pro_type_id == 1).ToList();
        }

    }
}
