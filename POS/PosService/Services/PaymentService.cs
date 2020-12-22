using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.Utilities;
using static PosService.PosServiceUnityExtension;

namespace PosService.Services
{
    public class PaymentService : IPaymentService
    {
        private Entities _db;
        private Mapper _mapper;

        public PaymentService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
        }

        #region PaymentCredit
        public int AddPaymentCredit(string branchNo, int userId, string dealercode, PaymentCrDetailModel model)
        {
            // int? ApprCode = null;
            // int? BankCode = null;
            var dbModel = new ST_PayCard
            {
                branch_no = branchNo,
                dealercode = dealercode,
                user_pay_id = userId,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                card_code = model.CardTypeCode,
                card_id = model.CreditNumber,
                card_amt = model.PaymentCr,
                installment_id = model.PaymentFormatId,
                card_remark = model.Note,
                expired_month = model.ExpiredMonth,
                expired_year = model.ExpiredYear,
                credit_type = model?.CreditType,
                appr_code = model.ApprCode,
                bank_code = model.BankCode,
                connect_type = model.ConnectType
            };

            _db.ST_PayCard.Add(dbModel);
            _db.SaveChanges();

            return dbModel.doc_no_run;
        }
        public int UpdatePaymentCredit(PaymentCrDetailModel model)
        {
            var dbModel = _db.ST_PayCard.FirstOrDefault(p => p.doc_no_run == model.Id);

            dbModel.card_code = model.CardTypeCode;
            dbModel.card_id = model.CreditNumber;
            dbModel.card_amt = model.PaymentCr;
            dbModel.installment_id = model.PaymentFormatId;
            dbModel.card_remark = model.Note;

            _db.Entry(dbModel).State = EntityState.Modified;
            _db.SaveChanges();

            return dbModel.doc_no_run;
        }
        public void DeletePaymentCredit(int id)
        {
            var dbModel = _db.ST_PayCard.FirstOrDefault(p => p.doc_no_run == id);

            if (dbModel == null) return;

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        #endregion

        #region PaymentOther
        public int AddPaymentOther(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId)
        {
            var dbModel = new ST_PayOther
            {
                branch_no = branchNo,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                user_pay_id = userId,
                //pay_id = model.Id,
                dealercode = dealerCode,
                crd_amt = model.Money,
                pay_code = model.Code,
                crd_remark = model.Note,
                pay_ref_code = model.OnlinePaymentRefNo

            };
            _db.ST_PayOther.Add(dbModel);
            _db.SaveChanges();

            return dbModel.doc_no_run;
        }
        public void DeletePaymentOther(int id)
        {
            var dbModel = _db.ST_PayOther.FirstOrDefault(p => p.doc_no_run == id);

            if (dbModel == null) return;

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        #endregion

        #region PaymentCash
        public void AddPaymentCash(PaymentModel model, string branchNo, string dealerCode, int userId)
        {
            var dbModel = new ST_PayCash
            {
                branch_no = branchNo,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                user_pay_id = userId,
                dealercode = dealerCode,
                cash_amt = model.CashAmount,
                change_money = model.ChangeMoney,
                payment_cash = model.ChangeMoney + model.CashAmount
            };

            _db.ST_PayCash.Add(dbModel);
            _db.SaveChanges();
        }
        public void DeletePaymentCash(int id)
        {
            var dbModel = _db.ST_PayCash.FirstOrDefault(p => p.doc_no_run == id);

            if (dbModel == null) return;

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        #endregion

        #region PaymentDeposit
        public void CancelPaymentDeposit(PaymentModel model)
        {
            var dbModel = _db.ST_PayDep.FirstOrDefault(p => p.doc_no == model.DocNo);

            if (dbModel == null) return;

            var query = _db.ST_RDAHeader.FirstOrDefault(r => r.doc_no == dbModel.ref_docno && r.branch_no == dbModel.branch_no);
            if (query == null) return;

            query.doc_close = "False";
            _db.Entry(query).State = EntityState.Modified;
            _db.SaveChanges();

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }
        public List<DepositModel> GetDepositModels(string CustomerCode, string docNo)
        {
            var query = _db.ST_RDAHeader.Where(r => r.cus_code == CustomerCode && r.doc_close != "True")
                .GroupJoin(_db.ST_PayDep,
                    r => r.doc_no,
                    p => p.ref_docno,
                    (rda, pay) => new { rda, pay });

            //var test = _db.ST_RDAHeader.Where(r => r.cus_code == CustomerCode && r.doc_close != "True").ToList();

            var model = query.Where(q => !q.pay.Any()).Join(_db.SB_Customer,
                q => q.rda.cus_code,
                c => c.cus_code,
                (q, c) =>
                    new DepositModel
                    {
                        CustomerName = c.cus_name,
                        Date = q.rda.doc_date,
                        DepositNo = q.rda.doc_no,
                        Money = (double)q.rda.ar_totalamt
                    }).ToList();

            return model;
        }
        public int AddPaymentDeposit(DepositModel model, string branchNo, string dealerCode, int userId)
        {
            var query = _db.ST_RDAHeader.FirstOrDefault(r => r.doc_no == model.DepositNo && r.branch_no == branchNo);
            if (query == null) return 0;

            query.doc_close = "True";
            _db.Entry(query).State = EntityState.Modified;
            _db.SaveChanges();

            var dbModel = new ST_PayDep
            {
                branch_no = branchNo,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                user_pay_id = userId,
                dealercode = dealerCode,
                dep_payamt = model.Money,
                ref_docno = model.DepositNo,
                dep_pay_remark = model.Note
            };

            _db.ST_PayDep.Add(dbModel);
            _db.SaveChanges();




            return dbModel.doc_no_run;
        }
        public void DeletePaymentDeposit(int id)
        {
            var dbModel = _db.ST_PayDep.FirstOrDefault(p => p.doc_no_run == id);

            if (dbModel == null) return;

            var query = _db.ST_RDAHeader.FirstOrDefault(r => r.doc_no == dbModel.ref_docno && r.branch_no == dbModel.branch_no);
            if (query == null) return;

            query.doc_close = "False";
            _db.Entry(query).State = EntityState.Modified;
            _db.SaveChanges();

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        #endregion

        #region ExtraDiscount

        public ExtraDiscountIconModel GetExtraDiscount(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateExtraDiscount(ExtraDiscountIconModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateExtraDiscount(ExtraDiscountIconModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteExtraDiscount(int id, string DocNo, string docCode, double DiscountAmt)
        {
            try
            {
                var dbArHeader = _db.ST_Arheader.FirstOrDefault(j => j.doc_no == DocNo);
                double? CurrTotalAmt = dbArHeader.ar_totalamt;
                double? NewTotalAmt = CurrTotalAmt + DiscountAmt;
                double? NewVatAmt = NewTotalAmt * 7 / 100;
                double? NewNetAmt = NewTotalAmt - NewVatAmt;
                //double? ArNewVatAmt = 
                dbArHeader.ar_amt = NewTotalAmt;
                dbArHeader.ar_vatamt = NewVatAmt;
                dbArHeader.ar_netamt = NewNetAmt;
                dbArHeader.ar_totalamt = NewTotalAmt;

                var dbArDetail = _db.ST_Ardetail.Where(x => x.doc_no_run == id).ToList();
                _db.Entry(dbArDetail).State = EntityState.Deleted;
                _db.Entry(dbArHeader).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.ToString());
                throw ex;
            }

        }

        #endregion

        #region Edc
        public int CheckEdcStatus(string docCode, string docNo, string BranchNo, string url)
        {
            var dbModel = _db.ST_Arheader.FirstOrDefault(p => p.doc_no == docNo);
            var dbModel2 = _db.ST_Jobheader.FirstOrDefault(p => p.doc_no == docNo);
            int result = 0;
            if (dbModel != null)
            {
                var model = _db.ST_Arheader.FirstOrDefault(r => r.doc_no == docNo && r.branch_no == BranchNo);
                if (model.flag_edc_check == 1)
                {
                    result = 2;
                }
                else
                {
                    model.flag_edc_check = 1;
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                    result = 1;
                }

            }
            else
            {
                var model = _db.ST_Jobheader.FirstOrDefault(r => r.doc_no == docNo && r.branch_no == BranchNo);
                if (model.flag_edc_check == 1)
                {
                    result = 2;
                }
                else
                {
                    model.flag_edc_check = 1;
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                    result = 1;
                }

                //  var xx = _db.ST_Jobheader.FirstOrDefault(r => r.doc_no == docNo && r.branch_no == BranchNo);

            }
            if (result == 1)
            {
                //ProcessStartInfo info = new ProcessStartInfo("cmd", @"cd c:\");
                //info.WorkingDirectory = @"C:\";

                //info.Arguments = url;
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                //info.CreateNoWindow = true;
                //info.FileName = @"C:\FIT_RP_CONN\ie_handler.bat"; // or C:\Program Files (x86)\itms\foo.cmd with no info.Arguments 
                //info.UseShellExecute = false;
                //info.RedirectStandardOutput = true;
                //using (Process process = Process.Start(info))
                //{
                //    using (StreamReader reader = process.StandardOutput)
                //    {
                //        Console.WriteLine(reader.ReadToEnd());
                //    }
                //}

                //ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", @"cd c:\");

                //procStartInfo.WorkingDirectory = @"C:\";

                //procStartInfo.Arguments = "\"" + @"C:\Program Files (x86)\Internet Explorer" + "\"";

                //procStartInfo.RedirectStandardOutput = true;
                //procStartInfo.RedirectStandardInput = true;
                //procStartInfo.UseShellExecute = false;

                //Process proc = new Process();
                //proc.StartInfo = procStartInfo;
                //Process p = Process.Start(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe", url);


            }
            return result;


        }
        public int? StartEdcCheck(string docCode, string docNo, string BranchNo)
        {



            var HeadModel1 = _db.ST_Arheader.FirstOrDefault(j => j.doc_no == docNo && j.branch_no == BranchNo);
            var HeadModel2 = _db.ST_Jobheader.FirstOrDefault(j => j.doc_no == docNo && j.branch_no == BranchNo);
            int? result = 0;
            if (HeadModel1 != null)
            {
                result = HeadModel1.flag_edc_check;
            }
            else
            {
                result = HeadModel2.flag_edc_check;
            }

            return result;

        }
        public LogEdcModel GetEdcReceive()
        {
            Entities db = new Entities();
            // var test = tmp.ST_LogEdc.SqlQuery("select * from ST_LogEdc order by edc_log_id desc").FirstOrDefault();
            var m = db.ST_LogEdc.SqlQuery("select * from ST_LogEdc order by edc_log_id desc").FirstOrDefault();

            //var m = _db.ST_LogEdc.OrderByDescending(x=>x.edc_log_id).FirstOrDefault();

            LogEdcModel model = new LogEdcModel()
            {
                receive_edc = m?.receive_edc,
                PortNo = m?.PortNo,
                Amount = m?.Amount,
                ProCode = m?.ProCode,
                Status = m?.Status,
                DocNo = m?.DocNo
            };


            return model;
        }
        public void AddEdcReceive(LogEdcModel model)
        {
            var ST_LogEdc = _db.ST_LogEdc.FirstOrDefault(x => x.DocNo == model.DocNo && x.Amount == model.Amount && x.ProCode == model.ProCode);
            // var ST_LogEdc = 

            if (ST_LogEdc == null)
            {
                _db.ST_LogEdc.Add(new ST_LogEdc
                {
                    receive_edc = model?.receive_edc,
                    PortNo = model?.PortNo,
                    Amount = model?.Amount,
                    ProCode = model?.ProCode,
                    Status = model?.Status,
                    DocNo = model?.DocNo
                });
            }
            else
            {
                ST_LogEdc.receive_edc = model.receive_edc;
                ST_LogEdc.Status = model.Status;
                _db.Entry(ST_LogEdc).State = EntityState.Modified;
            }

            _db.SaveChanges();

        }
        #endregion

        #region PromotionProduct

        private List<PromotionAndDiscountModal> PromotionAndDiscountModals(string refDocno)
        {
            var PromotionList = _db.SP_Get_PromotionByDocNo(refDocno).ToList()
                .Where(x => x.pro_group_used_id == 1 || x.pro_group_used_id == 2 || x.pro_group_used_id == 5)
                .Select(x => new PromotionAndDiscountModal
                {
                    Code = x.promotion_code,
                    DocNo = refDocno,
                    Name = x.promotion_name,
                    //  Number = Convert.ToDouble(x.promotion_num) ,
                    Number = Convert.ToDouble(x.promotion_num),
                    ProductBalance = x.promotion_count_balance?.ToString("N2"),
                    ProductGiveCode = x.promotion_give_code,
                    ProductGiveName = x.promotion_give,
                    Money = Convert.ToDouble(x.Promotion_discount_baht),
                    Type = x.pro_type_name,
                    ProdectDetail = x.promotion_detail,
                    Active = x.promotion_active,
                    FlagUseShared = x.flag_use_shared,
                    FlagUse = false,
                    PromotionType = x.pro_type_id.ToString(),
                    Discount = x.promotion_discount,
                    Product_Ref_Code = x.promotion_detail_code,
                    group_used_detail = x.pro_group_used_detail,
                    give_same_buy = x.pro_give_same_buy ?? true,
                    pmd_pro_code = x.promotion_pro_code,
                    pro_group_type_used = x.pro_group_used_id ?? 0
                }).ToList();

            return PromotionList;
        }
        private List<PromotionAndDiscountModal> GetAllowedPromotionAndDiscountModals(string refDocno, string pro_id)
        {
            var PromotionList = _db.SP_Get_AllowedPromotionByDocNo(refDocno, pro_id).ToList()
                //.Where(x => x.pro_group_used_id == 1 || x.pro_group_used_id == 2 || x.pro_group_used_id == 5)
                .Select(x => new PromotionAndDiscountModal
                {
                    Code = x.promotion_code,
                    DocNo = refDocno,
                    Name = x.promotion_name,
                    //  Number = Convert.ToDouble(x.promotion_num) ,
                    Number = Convert.ToDouble(x.promotion_num),
                    ProductBalance = x.promotion_count_balance?.ToString("N2"),
                    ProductGiveCode = x.promotion_give_code,
                    ProductGiveName = x.promotion_give,
                    Money = Convert.ToDouble(x.Promotion_discount_baht),
                    Type = x.pro_type_name,
                    ProdectDetail = x.promotion_detail,
                    Active = x.promotion_active,
                    FlagUseShared = x.flag_use_shared,
                    FlagUse = false,
                    PromotionType = x.pro_type_id.ToString(),
                    Discount = x.promotion_discount,
                    Product_Ref_Code = x.promotion_detail_code,
                    group_used_detail = x.pro_group_used_detail,
                    give_same_buy = x.pro_give_same_buy ?? true,
                    pmd_pro_code = x.promotion_pro_code,
                    pro_group_type_used = x.pro_group_used_id ?? 0
                }).ToList();

            return PromotionList;
        }
        private List<ExtraDiscountIconModel> GetAllowedDiscountEmployeeModals(string refDocno, string pro_id)
        {
            var DDDE = _db.SP_Get_AllowedPromotionByDocNo(refDocno, pro_id).ToList()
                //.Where(x => x.pro_group_used_id == 3)
                .GroupBy(
                r => new { r.promotion_code, r.promotion_name, r.promotion_detail_code, r.Promotion_discount_baht },
                r => r, (key, detail) => new { key, obj = detail });

            var DiscountEmpolyee = DDDE.GroupBy(
                    r => new { r.key.promotion_code, r.key.promotion_name },
                    r => r, (key, detail) => new { key, _detail = detail.FirstOrDefault(), obj = detail })
                .Select(s => new ExtraDiscountIconModel
                {
                    Code = s.key.promotion_code,
                    // CouponId = x.coupon_group_id,
                    Name = s.key.promotion_name,
                    Percents = Convert.ToDouble(s._detail.obj.FirstOrDefault().promotion_discount ?? 0),
                    Baht = Convert.ToDouble(s.obj.Sum(_ => _.key.Promotion_discount_baht) ?? 0),//Convert.ToDouble(s._detail.Promotion_discount_baht ?? 0),
                    //ProgroupCode = x.progroup_code,
                    //CustypeCode = x.custype_code,
                    //RequestPass = true,
                    CustypeCode = s._detail.obj.FirstOrDefault()?.pro_group_used_detail,
                    RequestPass = false
                    // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
                    // PassDigit = x.coupon_code
                }).ToList();
            return DiscountEmpolyee;
        }
        private List<ExtraDiscountIconModel> GetAllowedDiscountCouponModals(string refDocno, string pro_id)
        {
            var DiscountIconList = _db.SP_GetAllowedCoupon(refDocno, pro_id).GroupBy(
                    r => new { r.pro_id, r.coupon_group_id, r.pro_name },
                    r => r, (key, detail) => new { key, _detail = detail, other = detail.FirstOrDefault() })
                .Select(s => new ExtraDiscountIconModel
                {
                    Code = s.key.pro_id,
                    CouponId = s.key.coupon_group_id,
                    Name = s.key.pro_name,
                    Percents = Convert.ToDouble(s.other.coupon_value_percent.Value),
                    Baht = s.other.coupon_code != null ? Convert.ToDouble(s._detail.Where(w => w.coupon_code == s.other.coupon_code).Sum(_ => _.coupon_value_amount))
                    : Convert.ToDouble(s._detail.Sum(_ => _.coupon_value_amount)),
                    //ProgroupCode = x.progroup_code,
                    CustypeCode = s.other.custype_code,
                    RequestPass = s.other.coupon_code != null,
                }).ToList();
            return DiscountIconList;
        }
        public List<PromotionDiscountProductList> AddProductList(List<PromotionAndDiscountModal> model, string branchNo, string dealerCode, int userId)
        {
            List<PromotionDiscountProductList> pdp = new List<PromotionDiscountProductList>();
            List<ST_Jobdetail> ListJobDetail = null;
            using (var _db = new Entities())
            {
                ListJobDetail = new List<ST_Jobdetail>();
                var _ref = model.First().ReferenceNo;
                var _jd = _db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == _ref).OrderBy(o => o.Line_no).ToList();
                //int lastline = _jd.OrderByDescending(j => j.Line_no).FirstOrDefault()?.Line_no ?? 0;

                List<String> preferences = new List<String>();
                preferences.AddRange(_jd.Select(s => s.pro_code));
                _jd = _jd.Select(s =>
                {
                    s.tmp_Product_Ref_Code = s.pro_code;
                    return s;
                }).ToList();
                ListJobDetail.AddRange(_jd);

                foreach (var i in model)
                {
                    switch (i.DocCode)
                    {
                        case "PTTOR":
                        case "T101":
                        case "T102":
                        case "T103":
                        case "2101":
                        case "2102":
                        case "2103":
                            var dbJob = _db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == i.ReferenceNo && j.pro_code == i.Code).OrderByDescending(j => j.Line_no).FirstOrDefault();

                            var ProductGive = new SB_Product();
                            if (dbJob != null)
                            {
                                ProductGive = _db.SB_Product.FirstOrDefault(x => x.pro_code == dbJob.pro_code);
                                ProductGive.locat_code = dbJob.locat_code ?? ProductGive.locat_code;
                            }

                            if (!i.give_same_buy && i.PromotionType == Constants.PromotionType.PromotionGive)
                            {
                                ProductGive = _db.SB_Product.FirstOrDefault(x => x.pro_code == i.Code);
                                if (ProductGive != null)
                                {
                                    ProductGive.locat_code = ListJobDetail.OrderBy(x => x.Line_no).FirstOrDefault()?.locat_code ?? 431;
                                }
                            }

                            var obj_dot = _db.SB_Prolocation_dot.FirstOrDefault(w => w.pro_code == i.Code);
                            //var CheckLineNo = _db.ST_Jobdetail.FirstOrDefault(j =>
                            //    j.branch_no == branchNo && j.doc_no == i.ReferenceNo &&
                            //    j.pro_code == i.Product_Ref_Code);
                            var objProhead = _db.SB_PromotionHeader.FirstOrDefault(x => x.pro_id == i.tmp_Code);
                            var dbModelJob = new ST_Jobdetail
                            {
                                pro_name = i.Name,
                                pro_code = objProhead.pro_group_used_id == 2 ? i.tmp_Code : i.Code,
                                doc_no = i.ReferenceNo,
                                doc_code = i.DocCode,
                                dot_id = obj_dot != null ? obj_dot?.dot_id : null,
                                branch_no = branchNo,
                                dealercode = dealerCode,
                                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                doc_time = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture),
                                bill_position = 0,
                                store_qty = i.Number,
                                pro_price = i.Money, //giveSameBuy ? i.Money : Math.Abs((double)i.Money),
                                pro_disp1 = 0,
                                pro_disp2 = 0,
                                pro_disamt = 0,
                                pro_dis_all = 0,
                                pro_distotamt = 0,
                                pro_amt = i.Money * i.Number,
                                cus_code = dbJob?.cus_code,
                                car_registration = dbJob?.car_registration,
                                //    Line_no = dbJob?.Line_no + 1,
                                Line_no = 99,
                                locat_code = i.PromotionType == Constants.PromotionType.PromotionGive
                                    ? ProductGive?.locat_code
                                    : null,
                                sale_unit_code = i.PromotionType == Constants.PromotionType.PromotionGive
                                    ? ProductGive?.sale_unit_code
                                    : null,
                                Isnew = true,
                                pro_same_buy = i.give_same_buy,
                                pro_type = i.PromotionType,

                                tmp_No = i.tmp_No,
                                tmp_Code = i.tmp_Code,
                                tmp_Name = i.tmp_Name,
                                tmp_Type = i.tmp_Type,
                                tmp_ProductDetail = i.tmp_ProductDetail,
                                tmp_ProductGiveName = i.tmp_ProductGiveName,
                                tmp_Number = i.tmp_Number,
                                tmp_Money = i.tmp_Money,
                                tmp_ProductGiveCode = i.tmp_ProductGiveCode,
                                tmp_PromotionType = i.tmp_PromotionType,
                                tmp_Discount = i.tmp_Discount,
                                tmp_CouponId = i.tmp_CouponId,
                                tmp_CouponCode = i.tmp_CouponCode,
                                tmp_CouponCalType = i.tmp_CouponCalType,
                                tmp_Product_Ref_Code = i.tmp_Product_Ref_Code,
                                tmp_give_same_buy = i.tmp_give_same_buy,
                                tmp_pro_id = objProhead.pro_id
                            };

                            ListJobDetail.Add(dbModelJob);
                            //idResp = dbModelJob.doc_no_run;
                            break;
                    }
                }
                var _db2 = new Entities();
                _db2.ST_Jobdetail.RemoveRange(_db2.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == _ref).ToList());
                _db2.SaveChanges();
                var line = 1;

                ListJobDetail = ListJobDetail.OrderBy(d => { var index = preferences.IndexOf(d.tmp_Product_Ref_Code); return index == -1 ? int.MaxValue : index; })
                    .Select(s => { s.Line_no = line++; return s; }).ToList();

                var _db1 = new Entities();
                foreach (var rows in ListJobDetail)
                {
                    _db1.ST_Jobdetail.Add(rows);
                    _db1.SaveChanges();
                }
            }


            //ListJobDetail = ListJobDetail.Where(w => w.Isnew).OrderBy(x => x.Line_no).ToList();
            //.Where(w => w.Isnew)
            pdp = ListJobDetail.OrderBy(x => x.Line_no).Select(_ => new PromotionDiscountProductList
            {
                Name = _.pro_name,
                Number = _.store_qty,
                Money = _.pro_price,
                Id = _.Isnew == true ? _.doc_no_run : (int?)null,
                give_same_buy = _.pro_same_buy,
                PromotionType = _.pro_type,

                tmp_No = _.tmp_No,
                tmp_Code = _.tmp_Code,
                tmp_Name = _.tmp_Name,
                tmp_Type = _.tmp_Type,
                tmp_ProductDetail = _.tmp_ProductDetail,
                tmp_ProductGiveName = _.tmp_ProductGiveName,
                tmp_Number = _.tmp_Number,
                tmp_Money = _.tmp_Money,
                tmp_ProductGiveCode = _.tmp_ProductGiveCode,
                tmp_PromotionType = _.tmp_PromotionType,
                tmp_Discount = _.tmp_Discount,
                tmp_CouponId = _.tmp_CouponId,
                tmp_CouponCode = _.tmp_CouponCode,
                tmp_CouponCalType = _.tmp_CouponCalType,
                tmp_Product_Ref_Code = _.tmp_Product_Ref_Code,
                tmp_give_same_buy = _.tmp_give_same_buy
            }).ToList();

            return pdp;
        }
        public int CheckUsePromotionGive(List<PromotionAndDiscountModal> model, string branchNo, string dealerCode, int userId, out PromotionAndDiscountModal detail)
        {
            int stack = 0;
            string TempPromotion = "";
            detail = new PromotionAndDiscountModal();
            foreach (var i in model)
            {
                var oBjHead = _db.SB_PromotionHeader.FirstOrDefault(x => x.pro_id == i.tmp_Code);
                if (oBjHead.pro_group_used_id == 1)
                {
                    var objQoh = _db.SB_Prolocation.FirstOrDefault(w => w.pro_code == i.Code);
                    if (objQoh != null)
                    {
                        if (objQoh.pro_qoh > 1)
                        {
                            var total = (objQoh.pro_qoh > i.Number ? (objQoh.pro_qoh - i.Number) : (i.Number - objQoh.pro_qoh));
                            if (total <= 1)
                            {
                                stack++; detail = i; break;
                            }
                            else
                            {
                                TempPromotion += "," + oBjHead.pro_id;
                            }
                        }
                        else
                        {
                            stack++; detail = i; break;
                        }
                    }
                    else
                    {
                        stack++; detail = i; break;
                    }
                }
                else
                {
                    TempPromotion += "," + oBjHead.pro_id;
                }
            }

            if (stack == 0)
            {
                var _ref = model.First().ReferenceNo;

                var _jd = _db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == _ref && j.tmp_pro_id != null)
                            .GroupJoin(_db.SB_PromotionHeader, h => h.tmp_pro_id, d => d.pro_id, (header, promotion) => new { header, prodetail = promotion.FirstOrDefault() })
                                    .Where(w => w.prodetail.pro_group_used_id == 1 || w.prodetail.pro_group_used_id == 2 || w.prodetail.pro_group_used_id == 5)
                                    .OrderBy(o => o.header.Line_no);

                //var mapuse = model.Where(w => TempPromotion.Contains(w.tmp_Code));
                var _jdmodel = model.Where(w => TempPromotion != "" ? TempPromotion.Remove(0, 1).Contains(w.tmp_Code) : false)
                            //model.Where(w => TempPromotion.Remove(0, 1).Contains(w.tmp_Code))
                            .GroupJoin(_db.SB_PromotionHeader, h => h.tmp_Code, d => d.pro_id, (header, promotion) => new { header, prodetail = promotion.FirstOrDefault() });//.Where(w => w.prodetail.pro_group_used_id == 1);
                var tmp_test001 = _jd.ToList();
                var tmp_test002 = _jdmodel.ToList();
                if (_jd.Count() > 0)
                {
                    foreach (var i in _jdmodel)
                    {
                        if (!_jd.Any(w => w.prodetail.allow_muti_promotion_detail.Contains(i.header.tmp_Code)))
                        {
                            stack = 2; detail = i.header; break;
                        }
                    }
                }

                if (stack != 2)
                {
                    foreach (var rows in _jdmodel)
                    {
                        var checkOther = _jdmodel.Where(a => a.header.tmp_Code != rows.header.tmp_Code);
                        var test003 = checkOther.ToList();
                        if (checkOther.Count() > 0)
                        {
                            if (!checkOther.Any(w => w.prodetail.allow_muti_promotion_detail.Contains(rows.header.tmp_Code)))
                            {
                                stack = 2; detail = rows.header; break;
                            }
                        }
                        //if (!fa.Any(w => w.prodetail.allow_muti_promotion_detail.Contains(rows.header.tmp_Code)))

                    }
                }
            }

            return stack;
        }
        public int DeleteProductList(int id, string docCode)
        {
            var job = new ST_Jobdetail();

            switch (docCode)
            {
                case "2101":
                case "2102":
                case "PTTOR":
                case "2103":

                case "T101":
                case "T102":
                case "T103":
                    job = _db.ST_Jobdetail.FirstOrDefault(j => j.doc_no_run == id);
                    if (job != null)
                    {
                        _db.Entry(job).State = EntityState.Deleted;
                    }

                    break;

                //var dbModelJob = _db.ST_Jobdetail.FirstOrDefault(j => j.doc_no_run == id);
                //refDocno = dbModelJob?.doc_no;
                //_db.Entry(dbModelJob).State = EntityState.Deleted;
                //break;
                case "A302":
                    //var dbModelRDA = _db.ST_RDATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "A301":
                    //var dbModelRPA = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "A401":
                    //var dbModelRTA = _db.ST_RTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "9301":
                    //var dbModelPPA = _db.ST_PPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "9401":
                    //var dbModelPTA = _db.ST_PTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
            }

            return _db.SaveChanges();
        }

        #endregion

        #region Coupon

        public void AddCouponLog(PaymentModel model, string branchNo, string dealerCode, int userId, List<PromotionAndDiscountModal> CouponList)
        {
            foreach (var item in CouponList.ToList())
            {
                var _dbCouponStatus = _db.SB_CouponDetail.FirstOrDefault(w => w.coupon_group_id == item.CouponId && w.coupon_code == item.CouponCode);
                if (_dbCouponStatus != null)
                {
                    _dbCouponStatus.coupon_status = false;
                    _db.Entry(_dbCouponStatus).State = EntityState.Modified;
                }

                var dbModel = new ST_Coupon_Create_Log
                {
                    branch_no = branchNo,
                    doc_no = model.DocNo,
                    doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    sUserName = userId.ToString(),
                    dealercode = dealerCode,
                    coupon_id = item.CouponId,
                    coupon_code = item.CouponCode,
                };
                _db.ST_Coupon_Create_Log.Add(dbModel);
            }

            _db.SaveChanges();
        }
        public string GetCouponId(string PromotionCode)
        {
            var CouponId = _db.SB_PromotionHeader.FirstOrDefault(x => x.pro_id == PromotionCode)?.coupon_id;
            return CouponId;
        }
        public int CheckUseCouponDigit(string DocNo, string PromotionCode, string CouponGrp, string CouponDigit)
        {
            int result;
            var PromotionHead = _db.SB_PromotionHeader.FirstOrDefault(w => w.pro_id == PromotionCode);
            if (PromotionHead.pro_group_used_id == 6)
            {
                var couponEmp = _db.SB_PromotionCouponDetailEmp.Any(w => w.coupon_code == CouponDigit);
                if (couponEmp)
                {
                    result = 1;

                }
                else
                {
                    result = 500;

                }
            }
            else
            {

                result = _db.SP_CheckCouponDigit(PromotionCode, DocNo).FirstOrDefault() ?? 0;
                if (result > 0)
                {

                    switch (PromotionHead.group_coupon_id)
                    {
                        case 0:
                            var _coupon0 = _db.SB_CouponDetail.FirstOrDefault(w => w.coupon_group_id == CouponGrp);
                            if (_coupon0 == null) result = 500;
                            break;
                        case 1:
                            var _coupon1 = _db.SB_CouponDetail.FirstOrDefault(w => w.coupon_group_id == CouponGrp);
                            if (_coupon1 != null)
                            {
                                string cc = new String(_coupon1.coupon_code.Where(Char.IsDigit).ToArray());
                                int.TryParse(cc, out var digitlen);
                                if (digitlen != CouponDigit.Length)
                                {
                                    result++; result++;
                                }
                            }
                            else
                            {
                                result = 500;
                            }
                            break;
                        case 2:
                            var _couponDetail = _db.SB_CouponDetail.FirstOrDefault(w => w.coupon_group_id == CouponGrp && w.coupon_code == CouponDigit);
                            if (_couponDetail != null)
                            {
                                if (!_couponDetail.coupon_status ?? false)
                                {
                                    result++;
                                }
                            }
                            else
                            {
                                result = 500;
                            }
                            break;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Discount

        public void DeletePttorDiscount(int id, string BranchNo, string doc_no, double DiscountAmt)
        {

            var dbArHeader = _db.ST_Arheader.FirstOrDefault(j => j.branch_no == BranchNo && j.doc_no == doc_no);

            double? CurrTotalAmt = dbArHeader.ar_totalamt;
            double? NewTotalAmt = CurrTotalAmt + DiscountAmt;
            double? NewVatAmt = NewTotalAmt * 7 / 100;
            double? NewNetAmt = NewTotalAmt - NewVatAmt;
            //double? ArNewVatAmt = 
            dbArHeader.ar_amt = NewTotalAmt;
            dbArHeader.ar_vatamt = NewVatAmt;
            dbArHeader.ar_netamt = NewNetAmt;
            dbArHeader.ar_totalamt = NewTotalAmt;

            var dbArDetail = _db.ST_Ardetail.Where(x => x.doc_no_run == id).FirstOrDefault();
            _db.Entry(dbArDetail).State = EntityState.Deleted;
            _db.Entry(dbArHeader).State = EntityState.Modified;
            _db.SaveChanges();

            //      throw new NotImplementedException();
        }

        public int AddDiscountList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId, string CustType)
        {
            int idResp = 0;
            switch (model.DocCode)
            {
                case "T101":
                case "T102":
                case "T103":
                #region.bak
                //var dbAr = _db.ST_Ardetail.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo).OrderByDescending(j => j.line_no).First();
                //var dbModelAr = new ST_Ardetail
                //{
                //    pro_name = model.Name,
                //    pro_code = model.Code,
                //    doc_no = model.ReferenceNo,
                //    doc_code = model.DocCode,
                //    pro_price = model.Money,
                //    branch_no = branchNo,
                //    dealercode = dealerCode,
                //    doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                //    doc_time = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture),
                //    bill_position = 0,
                //    store_qty = 1,
                //    pro_amt = model.Money,
                //    cus_code = dbAr.cus_code,
                //    car_reg = dbAr.car_reg,
                //    line_no = dbAr.line_no + 1
                //};

                //_db.ST_Ardetail.Add(dbModelAr);
                //_db.SaveChanges();
                //idResp = dbModelAr.doc_no_run;
                //break;
                #endregion
                case "PTTOR":
                #region  .bak
                //var dbArHeader = _db.ST_Arheader.FirstOrDefault(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                //var dbCustomer = _db.SB_Customer.FirstOrDefault(c => c.cus_code == dbArHeader.cus_code);
                //int CountDetailRow = _db.ST_Ardetail.Count(d => d.branch_no == branchNo && d.doc_no == model.DocNo);
                //string CustTypeCode = dbCustomer.custype_code;
                //string SaveTextCode = "";
                //string SaveTextName = "";
                ////if (CustTypeCode == "02")
                ////{
                ////    SaveTextCode = "CDSDISC";
                ////    SaveTextName = "ส่วนลด ลูกค้า Credit Sale";
                ////}
                ////else
                ////{
                ////    SaveTextCode = "EXTRADISC";
                ////    SaveTextName = "ส่วนลดอื่นๆ";
                ////}
                //SaveTextCode = "EXTRADISC";
                //SaveTextName = model.Name;
                //double? CurrTotalAmt = dbArHeader.ar_totalamt;
                //double? NewTotalAmt = CurrTotalAmt - model.Money;
                //double? NewVatAmt = NewTotalAmt * 7 / 100;
                //double? NewNetAmt = NewTotalAmt - NewVatAmt;

                //double? detTotalAmt = model.Money * -1;
                //double? detVatAmt = detTotalAmt * 7 / 100 * -1;
                //double? detAmt = detTotalAmt + detVatAmt;
                //dbArHeader.ar_amt = NewTotalAmt;
                //dbArHeader.ar_vatamt = NewVatAmt;
                //dbArHeader.ar_netamt = NewNetAmt;
                //dbArHeader.ar_totalamt = NewTotalAmt;
                //var dbArDetail = new ST_Ardetail
                //{
                //    pro_name = SaveTextName,
                //    pro_code = SaveTextCode,
                //    doc_no = model.DocNo,
                //    doc_code = model.DocCode,

                //    branch_no = branchNo,
                //    dealercode = dealerCode,
                //    doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                //    doc_time = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture),
                //    bill_position = 0,
                //    store_qty = 1,
                //    line_no = CountDetailRow + 1,
                //    pm_code = model.ProductGiveCode,
                //    pro_price = detTotalAmt,
                //    pro_vat = 0,
                //    pro_amt = detTotalAmt,
                //    pro_disp1 = 0,
                //    pro_disp2 = 0,
                //    pro_disamt = 0,
                //    pro_dis_all = 0,
                //    pro_distotamt = 0



                //};

                //_db.ST_Ardetail.Add(dbArDetail);

                //_db.Entry(dbArHeader).State = EntityState.Modified;
                //_db.SaveChanges();
                //idResp = dbArDetail.doc_no_run;
                #endregion

                #region .bak old
                //var dbArHead = _db.ST_Arheader.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo).First();

                //if (model.ProductGiveCode != null)
                //{
                //    var giveModel = _db.SB_PromotionDetail.First(p => p.doc_no_run == model.Id);
                //    model.Code = giveModel.pro_code_show;
                //}
                //var dbModelArDetail = new ST_Ardetail
                //{
                //    pro_name = model.Name,
                //    pro_code = model.Code,
                //    doc_no = model.ReferenceNo,
                //    doc_code = model.DocCode,

                //    branch_no = branchNo,
                //    dealercode = dealerCode,
                //    doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                //    doc_time = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture),
                //    bill_position = 0,
                //    store_qty = 1,

                //    pm_code = model.ProductGiveCode,
                //    pro_price = -model.Money,
                //    pro_disp1 = 0,
                //    pro_disp2 = 0,
                //    pro_disamt = model.Money,
                //    pro_dis_all = model.Money,
                //    pro_distotamt = model.Money,
                //    pro_amt = -model.Money,
                //    cus_code = dbArDetail.cus_code,
                //    car_registration = dbArDetail.car_registration,
                //    line_no = dbArDetail.line_no + 1
                //};

                //_db.ST_Ardetail.Add(dbModelArDetail);
                //_db.SaveChanges();
                //  idResp = dbModelArDetail.doc_no_run;
                #endregion

                //break;
                case "2101":
                case "2102":
                case "2103":

                    var dbJob = _db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == model.ReferenceNo).OrderByDescending(j => j.Line_no).First();
                    if (model.ProductGiveCode != null)
                    {
                        var giveModel = _db.SB_PromotionDetail.First(p => p.doc_no_run == model.Id);
                        model.Code = giveModel.pro_code_show;
                    }
                    var dbModelJob = new ST_Jobdetail
                    {
                        pro_name = model.Name,
                        pro_code = model.Code,
                        doc_no = model.ReferenceNo,
                        doc_code = model.DocCode,

                        branch_no = branchNo,
                        dealercode = dealerCode,
                        doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        doc_time = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture),
                        bill_position = 0,
                        store_qty = 1,

                        pm_code = model.ProductGiveCode,
                        pro_price = -model.Money,
                        pro_disp1 = 0,
                        pro_disp2 = 0,
                        pro_disamt = model.Money,
                        pro_dis_all = model.Money,
                        pro_distotamt = model.Money,
                        pro_amt = -model.Money,
                        cus_code = dbJob.cus_code,
                        car_registration = dbJob.car_registration,
                        Line_no = dbJob.Line_no + 1
                    };

                    _db.ST_Jobdetail.Add(dbModelJob);
                    _db.SaveChanges();
                    idResp = dbModelJob.doc_no_run;
                    break;
                case "A302":
                    var dbModelRDA = _db.ST_RDATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "A301":
                    var dbModelRPA = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "A401":
                    var dbModelRTA = _db.ST_RTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "9301":
                    var dbModelPPA = _db.ST_PPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "9401":
                    var dbModelPTA = _db.ST_PTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
            }

            return idResp;
        }

        #endregion

        #region Other

        public void ClearProductListTemp(string docCode, string docNo, string branchNo, string refDocno)
        {
            var promotionModel = new List<PromotionAndDiscountModal>();
            switch (docCode)
            {
                case "2101":
                case "2102":
                case "2103":
                case "T101":
                case "T102":
                case "PTTOR":
                case "T103":
                    promotionModel = _db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.doc_no == refDocno && j.locat_code == null)
                        .Select(d => new PromotionAndDiscountModal
                        {
                            Name = d.pro_name,
                            Number = d.store_qty,
                            Money = (double)d.pro_price,
                            Id = d.doc_no_run
                        }).ToList();
                    break;
                case "A302":
                    //var dbModelRDA = _db.ST_RDATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "A301":
                    //var dbModelRPA = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "A401":
                    //var dbModelRTA = _db.ST_RTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);

                    break;
                case "9301":
                    //var dbModelPPA = _db.ST_PPATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
                case "9401":
                    //var dbModelPTA = _db.ST_PTATemp.Where(j => j.branch_no == branchNo && j.doc_no == model.DocNo);
                    break;
            }

            if (promotionModel != null && promotionModel.Any())
            {
                foreach (var item in promotionModel)
                {
                    DeleteProductList((int)item.Id, docCode);
                }
            }
        }

        #endregion

        public PaymentModel Get(string docCode, string docNo, string branchNo, string refDocno, string dpDocno, string dealerCode, int userId)
        {

            //reset flag edc = 0 
            var dbModel = _db.ST_Arheader.FirstOrDefault(p => p.doc_no == docNo);
            var dbModel2 = _db.ST_Jobheader.FirstOrDefault(p => p.doc_no == docNo);
            int resultEdc = 0;

            if (dbModel != null)
            {
                var model = _db.ST_Arheader.FirstOrDefault(r => r.doc_no == docNo && r.branch_no == branchNo);
                if (model != null && model.flag_edc_check == 1)
                {
                    model.flag_edc_check = 0;
                    _db.Entry(model).State = EntityState.Modified;
                    resultEdc = _db.SaveChanges();
                }
            }
            else
            {
                var model = _db.ST_Jobheader.FirstOrDefault(r => r.doc_no == refDocno && r.branch_no == branchNo);
                if (model != null && model.flag_edc_check == 1)
                {
                    model.flag_edc_check = 0;
                    _db.Entry(model).State = EntityState.Modified;
                    resultEdc = _db.SaveChanges();
                }



            }
            //=====================
            var paymentModels = new PaymentModel();
            switch (docCode)
            {
                case "2101":
                case "2102":
                case "2103":
                case "T101":
                case "T102":

                case "T103":

                    paymentModels = _db.ST_Jobheader.Where(j => j.doc_no == refDocno)
                        .Join(_db.SB_Customer,
                            j => j.cus_code,
                            c => c.cus_code,
                            (job, customer) => new { job, customer })
                        .GroupJoin(_db.ST_Jobdetail.OrderBy(d => d.Line_no), h => h.job.doc_no, d => d.doc_no,
                        (head, details) => new PaymentModel
                        {

                            DocCode = docCode,
                            DocNo = docNo,
                            RefDocNo = refDocno,
                            CustomerCode = head.job.cus_code,
                            CustTypeCode = head.customer.custype_code,
                            TotalAmount = (double)head.job.job_totalamt,
                            //BlueCardNo = head.bluecard != null ? head.bluecard.CardNumber : null,
                            //BlueCardBalancePoint = head.bluecard != null ? head.bluecard.PointsAvailable : null,
                            //BlueCardRewardPoint = head.bluecard != null ? head.bluecard.PointAccureToday : null,
                            TotalDiscount = details.Where(d => d.pm_code != null && d.pm_code != "").Any() ? (double)details.Where(d => d.pm_code != null && d.pm_code != "").Sum(d => d.pro_price) : 0,

                            PromotionAndDiscountModalList = details.Select(d => new PromotionAndDiscountModal
                            {
                                Code = d.pro_code,
                                Name = d.pro_name,
                                Number = d.store_qty,
                                Money = (double)d.pro_price,
                                Id = d.locat_code == null ? d.doc_no_run : (int?)null,

                                //tmp_No = i.tmp_No,
                                //tmp_Code = i.tmp_Code,
                                //tmp_Name = i.tmp_Name,
                                //tmp_Type = i.tmp_Type,
                                //tmp_ProductDetail = i.tmp_ProductDetail,
                                //tmp_ProductGiveName = i.tmp_ProductGiveName,
                                //tmp_Number = i.tmp_Number,
                                //tmp_Money = i.tmp_Money,
                                //tmp_ProductGiveCode = i.tmp_ProductGiveCode,
                                //tmp_PromotionType = i.tmp_PromotionType,
                                //tmp_Discount = i.tmp_Discount,
                                //tmp_CouponId = i.tmp_CouponId,
                                //tmp_CouponCode = i.tmp_CouponCode,
                                //tmp_CouponCalType = i.tmp_CouponCalType,
                                //tmp_Product_Ref_Code = i.tmp_Product_Ref_Code,
                                //tmp_give_same_buy = i.tmp_give_same_buy
                                //GroupCode = d.product
                            })

                            .ToList()
                        }).FirstOrDefault();

                    if (paymentModels == null)
                    {
                        break;
                    }

                    var jobDiscount = _db.ST_Jobheader.Where(j => j.branch_no == branchNo && j.doc_no == refDocno).Select(j => j.job_discountamt).First();

                    if (jobDiscount > 0)
                    {

                        //var discountModal = new PromotionAndDiscountModal
                        //{
                        //    Name = "ส่วนลด(รายบรรทัด)รวม",
                        //    Number = 1,
                        //    Money = (double)jobDiscount
                        //};

                        //paymentModel.PromotionAndDiscountModalList.Add(discountModal);
                        //paymentModel.TotalDiscount += (double)jobDiscount;
                    }



                    if (!string.IsNullOrWhiteSpace(dpDocno))
                    {
                        var depositModelList = GetDepositModels(paymentModels.CustomerCode, paymentModels.DocNo);
                        var depositModel = depositModelList.FirstOrDefault(d => d.DepositNo == dpDocno);
                        if (depositModel != null)
                        {
                            //depositModel.DocNo = paymentModels.DocNo;
                            //depositModel.DocCode = paymentModels.DocCode;
                            //depositModel.Note = "สร้างจากใบมัดจำ";
                            //depositModel.Id = AddPaymentDeposit(depositModel, branchNo, dealerCode, userId);
                            //paymentModels.DepositModel = depositModel;
                        }
                    }

                    var customerModel = _db.SB_Customer.First(c => c.cus_code == paymentModels.CustomerCode);
                    var customerGroup = customerModel.cus_type;
                    if (!string.IsNullOrWhiteSpace(customerGroup))
                    {
                        customerGroup = customerGroup.Split(',').LastOrDefault().Any() ? customerGroup.Split(',').LastOrDefault() : customerGroup;
                    }
                    else
                    {
                        customerGroup = "01";
                    }

                    var paymentProductList = paymentModels.PromotionAndDiscountModalList.Select(p => p.Code);
                    var productList = _db.SB_Product.Where(p => paymentProductList.Contains(p.pro_code)).ToArray();
                    var dayOfWeek = (int)DateTime.Now.DayOfWeek + 1;





                    break;
                case "A302":
                    paymentModels = _db.ST_RDATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.cus_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             CustomerCode = key.cus_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.dp_price) : 0,
                             PromotionAndDiscountModalList = details.Select(d => new PromotionAndDiscountModal
                             {
                                 //Name = d.dp_name,
                                 Name = "ชำระเงินมัดจำสินค้า",
                                 Number = d.dep_qty,
                                 Money = d.dp_price > 0 ? (double)(d.dp_price / d.dep_qty) : 0,
                             }).ToList()
                         }).FirstOrDefault();
                    break;
                case "A301":
                    paymentModels = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.cus_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             CustomerCode = key.cus_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.money_total) : 0,
                         }).FirstOrDefault();
                    if (paymentModels == null)
                    {
                        paymentModels = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == refDocno).GroupBy(
                        r => new { r.doc_no, r.cus_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = docNo,
                             DocCode = docCode,
                             CustomerCode = key.cus_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.money_total) : 0,
                         }).FirstOrDefault();
                    }
                    break;
                case "A401":
                    paymentModels = _db.ST_RTATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.cus_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             CustomerCode = key.cus_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.money_total) : 0,
                         }).FirstOrDefault();
                    break;
                case "9301":
                    paymentModels = _db.ST_PPATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.ven_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             VenderCode = key.ven_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.money_total) : 0,
                         }).FirstOrDefault();
                    break;
                case "9401":
                    paymentModels = _db.ST_PTATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.ven_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             VenderCode = key.ven_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.money_total) : 0,
                         }).FirstOrDefault();
                    break;
                case "PTTOR":
                    paymentModels = _db.ST_Arheader.Where(j => j.doc_no == docNo)
                      .Join(_db.SB_Customer,
                          j => j.cus_code,
                          c => c.cus_code,
                          (job, customer) => new { job, customer })
                      .GroupJoin(_db.ST_Ardetail.OrderBy(d => d.line_no),
                      h => h.job.doc_no,
                      d => d.doc_no,
                      (head, details) => new PaymentModel
                      {
                          DocCode = docCode,
                          DocNo = docNo,
                          RefDocNo = head.job.ref_docno,
                          CustomerCode = head.job.cus_code,
                          CustTypeCode = head.customer.custype_code,
                          TotalAmount = (double)head.job.ar_amt,
                          TotalDiscount = details.Where(d => d.pm_code != null && d.pm_code != "").Any() ? (double)details.Where(d => d.pm_code != null && d.pm_code != "").Sum(d => d.pro_price) : 0,
                          PromotionAndDiscountModalList = details.Select(d => new PromotionAndDiscountModal
                          {
                              Code = d.pro_code,
                              Name = d.pro_name,
                              Number = d.store_qty,
                              Money = (double)d.pro_price,
                              Id = d.locat_code == null ? d.doc_no_run : (int?)null
                          }).ToList()
                      }).FirstOrDefault();
                    if (paymentModels == null)
                    {
                        break;
                    }

                    var ArDisCount = _db.ST_Arheader.Where(j => j.branch_no == branchNo && j.doc_no == docNo).Select(j => j.ar_disamt).First();

                    if (ArDisCount > 0)
                    {

                        //var discountModal = new PromotionAndDiscountModal
                        //{
                        //    Name = "ส่วนลด(รายบรรทัด)รวม",
                        //    Number = 1,
                        //    Money = (double)jobDiscount
                        //};

                        //paymentModel.PromotionAndDiscountModalList.Add(discountModal);
                        //paymentModel.TotalDiscount += (double)jobDiscount;
                    }



                    if (!string.IsNullOrWhiteSpace(dpDocno))
                    {
                        var depositModelList = GetDepositModels(paymentModels.CustomerCode, paymentModels.DocNo);
                        var depositModel = depositModelList.FirstOrDefault(d => d.DepositNo == dpDocno);
                        if (depositModel != null)
                        {
                            //depositModel.DocNo = paymentModels.DocNo;
                            //depositModel.DocCode = paymentModels.DocCode;
                            //depositModel.Note = "สร้างจากใบมัดจำ";
                            //depositModel.Id = AddPaymentDeposit(depositModel, branchNo, dealerCode, userId);
                            //paymentModels.DepositModel = depositModel;
                        }
                    }

                    var customerModelPttor = _db.SB_Customer.First(c => c.cus_code == paymentModels.CustomerCode);
                    var customerGroupPttor = customerModelPttor.cus_type;
                    if (!string.IsNullOrWhiteSpace(customerGroupPttor))
                    {
                        customerGroupPttor = customerGroupPttor.Split(',').LastOrDefault().Any() ? customerGroupPttor.Split(',').LastOrDefault() : customerGroupPttor;
                    }
                    else
                    {
                        customerGroupPttor = "01";
                    }

                    var paymentProductListPttor = paymentModels.PromotionAndDiscountModalList.Select(p => p.Code);
                    var productListPttor = _db.SB_Product.Where(p => paymentProductListPttor.Contains(p.pro_code)).ToArray();
                    var dayOfWeekPttor = (int)DateTime.Now.DayOfWeek + 1;


                    // =============================== EDIT SELECT Promotion =========================================
                    //paymentModels.PromotionModalList = new List<PromotionAndDiscountModal>();
                    //var PromotionListPttor = _db.SP_Get_PromotionByDocNo(refDocno).ToList()
                    //                     .Select(x => new PromotionAndDiscountModal
                    //                     {
                    //                         Code = x.promotion_code,
                    //                         DocNo = refDocno,
                    //                         Name = x.promotion_name,
                    //                         Number = Convert.ToDouble(x.promotion_num),
                    //                         ProductBalance = x.promotion_count_balance?.ToString("N2"),
                    //                         ProductGiveCode = x.promotion_give_code,
                    //                         ProductGiveName = x.promotion_give,
                    //                         Money = Convert.ToDouble(x.promotion_price),
                    //                         Type = x.pro_type_name,
                    //                         ProdectDetail = x.promotion_detail,
                    //                         Active = x.promotion_active,
                    //                         FlagUseShared = x.flag_use_shared,
                    //                         FlagUse = false,
                    //                         PromotionType = "3" // โปรโมชั่นของแถม
                    //                     }).ToList();
                    //paymentModels.PromotionModalList.AddRange(PromotionListPttor);

                    //==================================== END ===============================================


                    break;
            }
            //var DiscountIconList = _db.SB_ExtraDiscount.Where(ex => ex.IsDelete == false).OrderBy(ex => ex.RankNo).ToArray()
            //    .Select(x => new ExtraDiscountIconModel
            //    {
            //        RankNo = x.RankNo ?? 0,
            //        Code = x.Code,
            //        Name = x.Name,
            //        Percents = x.Percents,
            //        Baht = x.Baht,
            //        ProgroupCode = x.ProgroupCode,
            //        CustypeCode = x.CustypeCode
            //    }).ToList();

            // =============================== EDIT SELECT Promotion =========================================
            paymentModels.PromotionModalList = new List<PromotionAndDiscountModal>();
            List<PromotionAndDiscountModal> tmpPromotionList = new List<PromotionAndDiscountModal>();
            var PromotionList = PromotionAndDiscountModals(refDocno);

            if (!string.IsNullOrEmpty(paymentModels.CustTypeCode))
                if (PromotionList.Count > 0)
                    PromotionList = PromotionList.Where(w => w.group_used_detail.Split(',').Contains(paymentModels.CustTypeCode)).ToList();

            var _detail = _db.SB_PromotionDetail.GroupBy(
                d => new { d.pro_id, d.pro_code },
                r => r, (key, detail) => new { key });

            var _main = PromotionList
                .GroupJoin(_detail,
                    h => h.Code,
                    d => d.key.pro_id,
                    (header, detail) => new { header, prodetail = detail.FirstOrDefault() });

            if (_main.Any(a => a.prodetail.key.pro_code != "0"))
            {
                tmpPromotionList = PromotionList.Where(w => w.ProductGiveCode == w.pmd_pro_code).ToList();
            }
            if (PromotionList.Any(a => a.pro_group_type_used == 5))
            {
                PromotionList = PromotionList.Where(w => w.pmd_pro_code == "0").ToList();
            }

            if (tmpPromotionList.Count > 0) { PromotionList.AddRange(tmpPromotionList); }

            //==================================== END ===============================================

            // ========================= Discount Employee ============================================
            var DDDE = _db.SP_Get_PromotionByDocNo(refDocno).ToList().Where(x => x.pro_group_used_id == 3).GroupBy(
                r => new { r.promotion_code, r.promotion_name, r.promotion_detail_code, r.Promotion_discount_baht },
                r => r, (key, detail) => new { key, obj = detail });

            var DiscountEmpolyee = DDDE.GroupBy(
                    r => new { r.key.promotion_code, r.key.promotion_name },
                    r => r, (key, detail) => new { key, _detail = detail.FirstOrDefault(), obj = detail })
                .Select(s => new ExtraDiscountIconModel
                {
                    Code = s.key.promotion_code,
                    // CouponId = x.coupon_group_id,
                    Name = s.key.promotion_name,
                    Percents = Convert.ToDouble(s._detail.obj.FirstOrDefault().promotion_discount ?? 0),
                    Baht = Convert.ToDouble(s.obj.Sum(_ => _.key.Promotion_discount_baht) ?? 0),//Convert.ToDouble(s._detail.Promotion_discount_baht ?? 0),
                    //ProgroupCode = x.progroup_code,
                    //CustypeCode = x.custype_code,
                    //RequestPass = true,
                    CustypeCode = s._detail.obj.FirstOrDefault()?.pro_group_used_detail,
                    RequestPass = false
                    // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
                    // PassDigit = x.coupon_code
                }).ToList();
            #region .bak
            //var DiscountEmpolyee = _db.SP_Get_PromotionByDocNo(refDocno).ToList().Where(x => x.pro_group_used_id == 3).GroupBy(
            //r => new { r.promotion_code, r.promotion_name, r.promotion_detail_code },
            //r => r, (key, detail) => new { key, _detail = detail.FirstOrDefault(), obj = detail })
            //    .Select(s => new ExtraDiscountIconModel
            //    {
            //        Code = s.key.promotion_code,
            //        // CouponId = x.coupon_group_id,
            //        Name = s.key.promotion_name,
            //        Percents = Convert.ToDouble(s._detail.promotion_discount ?? 0),
            //        Baht = Convert.ToDouble(s.obj.Sum(d => d.Promotion_discount_baht ?? 0)),//Convert.ToDouble(s._detail.Promotion_discount_baht ?? 0),
            //        //ProgroupCode = x.progroup_code,
            //        //CustypeCode = x.custype_code,
            //        //RequestPass = true,
            //        RequestPass = false
            //        // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
            //        // PassDigit = x.coupon_code
            //    });
            //if (!string.IsNullOrEmpty(paymentModels.CustTypeCode) && paymentModels.CustTypeCode != "03")
            //    DiscountEmpolyee = new List<ExtraDiscountIconModel>();
            //.GroupBy(g => new { g.promotion_code, g.promotion_name, g.promotion_discount, g.Promotion_discount_baht })
            //.Select(x => new ExtraDiscountIconModel
            //{
            //    Code = x.Key.promotion_code,
            //    // CouponId = x.coupon_group_id,
            //    Name = x.Key.promotion_name,
            //    Percents = Convert.ToDouble(x.Key.promotion_discount ?? 0),
            //    Baht = Convert.ToDouble(x.Key.Promotion_discount_baht ?? 0),
            //    //ProgroupCode = x.progroup_code,
            //    //CustypeCode = x.custype_code,
            //    //RequestPass = true,
            //    RequestPass = false
            //    // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
            //    // PassDigit = x.coupon_code
            //}).ToList();

            // ========================= End  ============================================

            //var Voucherscard = _db.SP_Get_PromotionByDocNo(refDocno).ToList().Where(x => x.pro_group_used_id == 5)
            //    .GroupBy(g => new { g.promotion_code, g.promotion_name, g.promotion_discount, g.Promotion_discount_baht })
            //    .Select(x => new ExtraDiscountIconModel
            //    {
            //        Code = x.Key.promotion_code,
            //        // CouponId = x.coupon_group_id,
            //        Name = x.Key.promotion_name,
            //        Percents = Convert.ToDouble(x.Key.promotion_discount ?? 0),
            //        Baht = Convert.ToDouble(x.Key.Promotion_discount_baht ?? 0),
            //        //ProgroupCode = x.progroup_code,
            //        //CustypeCode = x.custype_code,
            //        //RequestPass = true,
            //        RequestPass = false
            //        // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
            //        // PassDigit = x.coupon_code
            //    }).ToList();
            //paymentModels.DiscountIconList.AddRange(Voucherscard);
            #endregion

            var proDisEMP = _db.SP_Get_PromotionByDocNo(refDocno).ToList().Where(x => x.pro_group_used_id == 6 && x.promotion_give_code == x.promotion_pro_code).GroupBy(
                r => new { r.promotion_code, r.promotion_name, r.promotion_detail_code, r.Promotion_discount_baht, r.pro_group_used_id },
                r => r, (key, detail) => new { key, obj = detail });

            var ProDiscountEmpolyee = proDisEMP.GroupBy(
                    r => new { r.key.promotion_code, r.key.promotion_name, r.key.pro_group_used_id },
                    r => r, (key, detail) => new { key, _detail = detail.FirstOrDefault(), obj = detail })
                .Select(s => new ExtraDiscountIconModel
                {
                    Code = s.key.promotion_code,
                    // CouponId = x.coupon_group_id,
                    Name = s.key.promotion_name,
                    Percents = Convert.ToDouble(s._detail.obj.FirstOrDefault().promotion_discount ?? 0),
                    Baht = Convert.ToDouble(s.obj.Sum(_ => _.key.Promotion_discount_baht) ?? 0),//Convert.ToDouble(s._detail.Promotion_discount_baht ?? 0),
                    //ProgroupCode = x.progroup_code,
                    //CustypeCode = x.custype_code,
                    //RequestPass = true,
                    CustypeCode = s._detail.obj.FirstOrDefault()?.pro_group_used_detail,
                    RequestPass = true,
                    pro_group_type_used = s.key.pro_group_used_id ?? 0
                }).ToList();

            // ========================= Coupon Show ============================================
            var DiscountIconList = _db.SP_GetCoupon(refDocno).GroupBy(
                    r => new { r.pro_id, r.coupon_group_id, r.pro_name },
                    r => r, (key, detail) => new { key, _detail = detail, other = detail.FirstOrDefault() })
                .Select(s => new ExtraDiscountIconModel
                {
                    Code = s.key.pro_id,
                    CouponId = s.key.coupon_group_id,
                    Name = s.key.pro_name,
                    Percents = Convert.ToDouble(s.other.coupon_value_percent.Value),
                    Baht = s.other.coupon_code != null ? Convert.ToDouble(s._detail.Where(w => w.coupon_code == s.other.coupon_code).Sum(_ => _.coupon_value_amount))
                    : Convert.ToDouble(s._detail.Sum(_ => _.coupon_value_amount)),
                    //ProgroupCode = x.progroup_code,
                    CustypeCode = s.other.custype_code,
                    RequestPass = s.other.coupon_code != null,
                }).ToList();
            #region .bak
            //var DiscountIconList = _db.SP_GetCoupon(refDocno)
            //    .GroupBy(g => new { g.pro_id, g.coupon_group_id, g.pro_name, g.coupon_value_percent, g.coupon_value_amount })
            //    .Select(x => new ExtraDiscountIconModel
            //    {
            //        Code = x.Key.pro_id,
            //        CouponId = x.Key.coupon_group_id,
            //        Name = x.Key.pro_name,
            //        Percents = Convert.ToDouble(x.Key.coupon_value_percent.Value),
            //        Baht = Convert.ToDouble(x.Key.coupon_value_amount.Value),
            //        //ProgroupCode = x.progroup_code,
            //        //CustypeCode = x.custype_code,
            //        RequestPass = true,
            //        //RequestPass = x.Key.coupon_code != "" && x.Key.coupon_code != null ? true : false,
            //        // x.pro_give_type_id == 1 ? Convert.ToDouble(x.store_qty)/ Convert.ToDouble(x.pro_give_type_detail)* Convert.ToDouble(x.promotion_num) : Convert.ToDouble(x.promotion_num),
            //        //PassDigit = x.coupon_code
            //    }).ToList().Distinct();
            // DiscountIconList.AddRange(DiscountIconList);
            #endregion
            if (!string.IsNullOrEmpty(paymentModels.CustTypeCode))
                if (DiscountIconList.Any())
                    DiscountIconList = DiscountIconList.Where(w => w.CustypeCode.Split(',').Contains(paymentModels.CustTypeCode)).ToList();

            //   paymentModels.DiscountIconList = _db.SB_ExtraDiscount.Where(ex => !ex.IsDelete).OrderBy(ex => ex.RankNo).ToArray().Select(extra => _mapper.Map<ExtraDiscountIconModel>(extra)).OrderBy(extra => extra.RankNo).ToList();
            paymentModels.PortNoEDC = _db.SB_System.FirstOrDefault(x => x.branch_no == branchNo)?.card_port_no;
            paymentModels.PaymentRoundDigit = _db.SB_System.FirstOrDefault(x => x.branch_no == branchNo)?.payment_round_digit;
            paymentModels.UrlHqService = _db.SB_System.FirstOrDefault(x => x.branch_no == branchNo)?.URL_FIT_HQ;

            // pro_condition_time_id = 1 รอบสัปดาห์
            var getdayOweek = (int)DateTime.Now.DayOfWeek;
            // pro_condition_time_id = 2 รอบเดือน
            //  1-31
            var getdayOmount = DateTime.Now.Day;

            if (PromotionList.Count > 0)
            {
                List<PromotionAndDiscountModal> tmp_Promo = new List<PromotionAndDiscountModal>();
                var Promo_CondiTimes = PromotionList
               .GroupJoin(_db.SB_PromotionHeader,
                   h => h.Code,
                   d => d.pro_id,
                   (header, detail) => new { header, prodetail = detail.FirstOrDefault() });

                if (Promo_CondiTimes.Any(w => w.prodetail.pro_condition_time_id == 3))
                {
                    var pro_id = string.Join(",", Promo_CondiTimes.Where(a => a.prodetail.pro_condition_time_id == 3).Select(s => s.prodetail.pro_id).ToArray());
                    tmp_Promo.AddRange(PromotionList.Where(w => pro_id.Contains(w.Code)).ToList());
                }

                foreach (var _rows in Promo_CondiTimes)
                {
                    // TimeSpan now = DateTime.Now.TimeOfDay;
                    TimeSpan start = TimeSpan.Parse(_rows.prodetail.pro_condition_time_start); TimeSpan end = TimeSpan.Parse(_rows.prodetail.pro_condition_time_end);
                    TimeSpan _now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    switch (_rows.prodetail.pro_condition_time_id)
                    {
                        case 1:
                            tmp_Promo.AddRange(PromotionList.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOweek.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                        case 2:
                            tmp_Promo.AddRange(PromotionList.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOmount.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                    }
                }
                if (tmp_Promo.Count > 0) { PromotionList = tmp_Promo; }
            }
            if (DiscountIconList.Count > 0)
            {
                List<ExtraDiscountIconModel> tmp_disCo = new List<ExtraDiscountIconModel>();
                var disCo_CondiTimes = DiscountIconList
               .GroupJoin(_db.SB_PromotionHeader,
                   h => h.Code,
                   d => d.pro_id,
                   (header, detail) => new { header, prodetail = detail.FirstOrDefault() });

                if (disCo_CondiTimes.Any(w => w.prodetail.pro_condition_time_id == 3))
                {
                    var pro_id = string.Join(",", disCo_CondiTimes.Where(a => a.prodetail.pro_condition_time_id == 3).Select(s => s.prodetail.pro_id).ToArray());
                    tmp_disCo.AddRange(DiscountIconList.Where(w => pro_id.Contains(w.Code)).ToList());
                }
                foreach (var _rows in disCo_CondiTimes)
                {
                    // TimeSpan now = DateTime.Now.TimeOfDay;
                    TimeSpan start = TimeSpan.Parse(_rows.prodetail.pro_condition_time_start); TimeSpan end = TimeSpan.Parse(_rows.prodetail.pro_condition_time_end);
                    TimeSpan _now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    switch (_rows.prodetail.pro_condition_time_id)
                    {
                        case 1:
                            tmp_disCo.AddRange(DiscountIconList.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOweek.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                        case 2:
                            tmp_disCo.AddRange(DiscountIconList.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOmount.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                    }
                }
                if (tmp_disCo.Count > 0) { DiscountIconList = tmp_disCo; }
            }
            if (ProDiscountEmpolyee.Count > 0)
            {
                List<ExtraDiscountIconModel> tmp_ProDisEmp = new List<ExtraDiscountIconModel>();
                var ProDisEmp_CondiTimes = ProDiscountEmpolyee
               .GroupJoin(_db.SB_PromotionHeader,
                   h => h.Code,
                   d => d.pro_id,
                   (header, detail) => new { header, prodetail = detail.FirstOrDefault() });

                if (ProDisEmp_CondiTimes.Any(w => w.prodetail.pro_condition_time_id == 3))
                {
                    var pro_id = string.Join(",", ProDisEmp_CondiTimes.Where(a => a.prodetail.pro_condition_time_id == 3).Select(s => s.prodetail.pro_id).ToArray());
                    tmp_ProDisEmp.AddRange(ProDiscountEmpolyee.Where(w => pro_id.Contains(w.Code)).ToList());
                }
                foreach (var _rows in ProDisEmp_CondiTimes)
                {
                    // TimeSpan now = DateTime.Now.TimeOfDay;
                    TimeSpan start = TimeSpan.Parse(_rows.prodetail.pro_condition_time_start); TimeSpan end = TimeSpan.Parse(_rows.prodetail.pro_condition_time_end);
                    TimeSpan _now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    switch (_rows.prodetail.pro_condition_time_id)
                    {
                        case 1:
                            tmp_ProDisEmp.AddRange(ProDiscountEmpolyee.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOweek.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                        case 2:
                            tmp_ProDisEmp.AddRange(ProDiscountEmpolyee.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOmount.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                    }
                }
                if (tmp_ProDisEmp.Count > 0) { ProDiscountEmpolyee = tmp_ProDisEmp; }
            }
            if (DiscountEmpolyee.Count > 0)
            {
                List<ExtraDiscountIconModel> tmp_DisEmp = new List<ExtraDiscountIconModel>();
                var DisEmp_CondiTimes = DiscountEmpolyee
               .GroupJoin(_db.SB_PromotionHeader,
                   h => h.Code,
                   d => d.pro_id,
                   (header, detail) => new { header, prodetail = detail.FirstOrDefault() });

                if (DisEmp_CondiTimes.Any(w => w.prodetail.pro_condition_time_id == 3))
                {
                    var pro_id = string.Join(",", DisEmp_CondiTimes.Where(a => a.prodetail.pro_condition_time_id == 3).Select(s => s.prodetail.pro_id).ToArray());
                    tmp_DisEmp.AddRange(DiscountEmpolyee.Where(w => pro_id.Contains(w.Code)).ToList());
                }
                foreach (var _rows in DisEmp_CondiTimes)
                {
                    // TimeSpan now = DateTime.Now.TimeOfDay;
                    TimeSpan start = TimeSpan.Parse(_rows.prodetail.pro_condition_time_start); TimeSpan end = TimeSpan.Parse(_rows.prodetail.pro_condition_time_end);
                    TimeSpan _now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    switch (_rows.prodetail.pro_condition_time_id)
                    {
                        case 1:
                            tmp_DisEmp.AddRange(DiscountEmpolyee.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOweek.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                        case 2:
                            tmp_DisEmp.AddRange(DiscountEmpolyee.
                                                Where(w => w.Code == _rows.prodetail.pro_id
                                                    && _rows.prodetail.pro_condition_time_detail.Split(',').Contains(getdayOmount.ToString())
                                                        && (_now >= start && _now <= end)
                                                    ).ToList());
                            break;
                    }
                }
                if (tmp_DisEmp.Count > 0) { DiscountEmpolyee = tmp_DisEmp; }
            }

            CheckAllowedPromotion(PromotionList, DiscountIconList, ProDiscountEmpolyee, DiscountEmpolyee, refDocno);

            paymentModels.PromotionModalList.AddRange(PromotionList);
            paymentModels.DiscountIconList.AddRange(DiscountIconList);
            paymentModels.DiscountIconList.AddRange(ProDiscountEmpolyee);
            paymentModels.DiscountIconList.AddRange(DiscountEmpolyee);

            //Add PayCard 
            var PayCardList = new List<CodeNameModel> {
                new CodeNameModel {
                    Code = "",
                    Name = "เลือกชนิดบัตร",
                    dfField1 = "-"
                } };


            PayCardList.AddRange(_db.SB_CardType.Select(p => new CodeNameModel
            {
                Code = p.card_code,
                Name = p.card_name,
                dfField1 = p.bank_code ?? "-"
            }));
            ////
            paymentModels.PayCardList = PayCardList.ToList();
            return paymentModels;
        }

        private void CheckAllowedPromotion(List<PromotionAndDiscountModal> promotionList, List<ExtraDiscountIconModel> discountIconList, List<ExtraDiscountIconModel> proDiscountEmpolyee, List<ExtraDiscountIconModel> discountEmpolyee, string refDocno)
        {
            List<string> allowedTemp = new List<string>();
            if (promotionList.Count > 0)
            {
                var objProlist = promotionList.GroupJoin(_db.SB_PromotionHeader, h => h.Code, d => d.pro_id, (header, detail) => new { header, prodetail = detail.FirstOrDefault() })
                    .Where(w => w.prodetail.allow_muti_promotion == true);
                foreach (var _rows in objProlist)
                    allowedTemp.AddRange(_rows.prodetail.allow_muti_promotion_detail.Split(','));
            }
            if (discountEmpolyee.Count > 0)
            {
                var objProlist = discountEmpolyee.GroupJoin(_db.SB_PromotionHeader, h => h.Code, d => d.pro_id, (header, detail) => new { header, prodetail = detail.FirstOrDefault() })
                    .Where(w => w.prodetail.allow_muti_promotion == true);
                foreach (var _rows in objProlist)
                    allowedTemp.AddRange(_rows.prodetail.allow_muti_promotion_detail.Split(','));
            }
            if (discountIconList.Count > 0)
            {
                var objProlist = discountIconList.GroupJoin(_db.SB_PromotionHeader, h => h.Code, d => d.pro_id, (header, detail) => new { header, prodetail = detail.FirstOrDefault() })
                    .Where(w => w.prodetail.allow_muti_promotion == true);
                foreach (var _rows in objProlist)
                    allowedTemp.AddRange(_rows.prodetail.allow_muti_promotion_detail.Split(','));
            }
            if (proDiscountEmpolyee.Count > 0)
            {
                var objProlist = proDiscountEmpolyee.GroupJoin(_db.SB_PromotionHeader, h => h.Code, d => d.pro_id, (header, detail) => new { header, prodetail = detail.FirstOrDefault() })
                    .Where(w => w.prodetail.allow_muti_promotion == true);
                foreach (var _rows in objProlist)
                    allowedTemp.AddRange(_rows.prodetail.allow_muti_promotion_detail.Split(','));
            }

            var prodetail = allowedTemp.GroupBy(g => new { g }, r => r, (key, detail) => new { key })
                                        .GroupJoin(_db.SB_PromotionHeader, h => h.key.g, d => d.pro_id, (header, detail) => new { header, prodetail = detail.FirstOrDefault() });
            //var tmp_test001 = prodetail.ToList();
            foreach (var items in prodetail)
            {
                if (
                    !(
                        promotionList.Any(a => a.Code == items.prodetail.pro_id) || discountEmpolyee.Any(a => a.Code == items.prodetail.pro_id) ||
                        discountIconList.Any(a => a.Code == items.prodetail.pro_id) || proDiscountEmpolyee.Any(a => a.Code == items.prodetail.pro_id)
                        )
                    )
                {
                    switch (items.prodetail.pro_group_used_id)
                    {
                        case 1:
                        case 2:
                        case 5:
                            // =============================== โปรโมชั่นของแถม/แลกซื้อ,โปรโมชั่นส่วนลดราคา,โปรโมชั่นส่วนลดราคา(import) =============================== pro_group_used_id == 1 || pro_group_used_id == 2 || pro_group_used_id == 5
                            //var tmp_test002 = GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id);
                            if (items.prodetail.pro_group_used_id == 5)
                            {
                                var tmp_promotiondisproitems = GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id);
                                //var temp_test999 = tmp_promotiondisproitems.Where(w => w.pmd_pro_code == w.ProductGiveCode);
                                promotionList.AddRange(tmp_promotiondisproitems.Where(w => w.pmd_pro_code == w.ProductGiveCode));
                            }
                            else
                            {
                                promotionList.AddRange(GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id));
                            }
                            break;
                        case 3:
                            // =============================== โปรโมชั่นส่วนลดพนักงาน ============================= pro_group_used_id == 3
                            //var tmp_test003 = GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id);
                            discountEmpolyee.AddRange(GetAllowedDiscountEmployeeModals(refDocno, items.prodetail.pro_id));
                            break;
                        case 4:
                            // =============================== โปรโมชั่นส่วนลดคูปอง/บัตรกำนัล ================================== pro_group_used_id == 4
                            //var tmp_test004 = GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id);
                            discountIconList.AddRange(GetAllowedDiscountCouponModals(refDocno, items.prodetail.pro_id));
                            break;
                        case 6:
                            // =============================== โปรโมชั่นส่วนลดพนักงาน(import) ================================== pro_group_used_id == 6
                            //var tmp_test005 = GetAllowedPromotionAndDiscountModals(refDocno, items.prodetail.pro_id);
                            proDiscountEmpolyee.AddRange(GetAllowedDiscountEmployeeModals(refDocno, items.prodetail.pro_id));
                            break;

                    }

                }
            }
        }

        public string GetDocNo(string refDocNo)
        {
            return _db.ST_RDAHeader.FirstOrDefault(w => w.doc_job_ref == refDocNo)?.doc_no;
        }

        ///====================================================>  ????????????
        public int AddPayCardLog(string branchNo, int userId, string dealercode, PaymentCrDetailModel model)
        {
            var dbModel = new ST_PayCard_Log
            {
                branch_no = branchNo
              ,
                type_trans = model.TypeTrans
              ,
                doc_no = model.DocNo
              ,
                temp_doc_no = model.DocNo
              ,
                doc_code = model.DocCode
              ,
                cus_code = model.CustCode
              ,
                Response_Text = model.ResponseText
              ,
                Merchant_name_and_Address = model.MerchantNameAndAddress
              ,
                Transaction_Date = model.TransactionDate
              ,
                Transaction_Time = model.TransactionTime
              ,
                Approval_Code = model.ApprovalCode
              ,
                Invoice_Number = model.InvoiceNumber
              ,
                Terminal_ID = model.TerminalID
              ,
                Merchant_ID = model.MerchantID
              ,
                Card_Issuer_Name = model.CardIssuerName
              ,
                Card_Number = model.CardNumber
              ,
                Card_Expiry_Date = model.CardExpiryDateYYMM
              ,
                Batch_Number = model.BatchNumber
              ,
                Reference_Number = model.ReferenceNumber
              ,
                Card_Issuer_ID = model.CardIssuerID
              ,
                Card_Holder_Name = model.CardHolderName
              ,
                Amount = model.Amount
              ,
                Redeem_Point = model.RedeemPoint
              ,
                Redeem_Amount = model.RedeemAmount
              ,
                Redeem_Point_Balance = model.RedeemPointBalance
              ,
                Customer_Name = model.CustomerName
              ,
                Customer_Address = model.CustomerAddress
              ,
                Customer_TAX_ID = model.CustomerTAXID
              ,
                Customer_Branch_Number = model.CustomerBranchNumber
              ,
                Customer_Car_License = model.CustomerCarLicense
              ,
                TI = model.TI
              ,
                PTT_Blue_Card_Number = model.PTTBlueCardNumber
              ,
                add_user_id = userId
              ,
                add_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
              ,
                add_time = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)
              ,
                dealercode = dealercode
            };

            _db.ST_PayCard_Log.Add(dbModel);
            _db.SaveChanges();

            return dbModel.doc_no_run;
        }
        public DTResult<ExtraDiscountIconModel> GetExtraDiscountDTResult(DTParameters dataTableRequestModel)
        {
            throw new NotImplementedException();
        }
        private DateTime? CashDatetime(string datetime)
        {
            DateTime temp;
            if (DateTime.TryParse(datetime, out temp))
            {
                return temp;
            }
            else
            {
                return null;
            }
        }
        private void SavePaydoc(string branchNo, string docCode, string docNo, int userId, string dealerCode, double money, string note, string refDocNo)
        {
            var model = _db.ST_Paydoc.FirstOrDefault(p =>
                p.branch_no == branchNo &&
                p.doc_code == docCode &&
                p.doc_no == docNo &&
                p.dealercode == dealerCode
            );
            var dbModel = new ST_Paydoc
            {
                branch_no = branchNo,
                doc_code = docCode,
                doc_no = docNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                user_pay_id = userId,
                dealercode = dealerCode,
                doc_payamt = money,
                rf_docno = refDocNo,
                rec_memo = note
            };

            _db.ST_Paydoc.Add(dbModel);
            _db.SaveChanges();
        }
        //public ProductModel[] GetPromotionGiveDTResult(string promotionId)
        //{
        //    var promotionModel = _db.SB_PromotionDetail.Where(p => p.pro_id == promotionId && (bool)p.status_give_product).ToArray();

        //    var query = _db.SB_Product.GroupJoin(_db.SB_Progroup,
        //            q => q.progroup_code,
        //            pg => pg.progroup_code,
        //            (p, pg) => new { Product = p, Type = pg.FirstOrDefault() })
        //            .GroupJoin(_db.SB_Probrand,
        //            q => q.Product.pro_brand_code,
        //            pb => pb.pro_brand_code,
        //            (q, pb) => new { q.Product, q.Type, Brand = pb.FirstOrDefault() })
        //            .GroupJoin(_db.SB_Promodel,
        //            q => q.Product.pro_model_code,
        //            pm => pm.pro_model_code,
        //            (q, pm) => new { q.Product, q.Type, q.Brand, Modal = pm.FirstOrDefault() })
        //            .GroupJoin(_db.SB_ProSize,
        //            q => q.Product.pro_size_code,
        //            ps => ps.pro_size_code,
        //            (q, ps) => new { q.Product, q.Type, q.Brand, q.Modal, Size = ps.FirstOrDefault() })
        //            .GroupJoin(_db.SB_Prolocation,
        //                    pro => pro.Product.pro_code,
        //                    pl => pl.pro_code,
        //                    (master, pl) => new { master, pl })
        //                    .SelectMany(
        //                     x => x.pl.DefaultIfEmpty(),
        //                     (master, ProductLocal) => new
        //                     {
        //                         master.master.Product,
        //                         master.master.Type,
        //                         master.master.Brand,
        //                         master.master.Modal,
        //                         master.master.Size,
        //                         ProductLocal
        //                     })
        //                     .GroupJoin(_db.SB_location,
        //                     master => master.ProductLocal.locat_code,
        //                     l => l.locat_code,
        //                     (master, location) => new
        //                     {
        //                         master.Product,
        //                         master.Type,
        //                         master.Brand,
        //                         master.Modal,
        //                         master.Size,
        //                         master.ProductLocal,
        //                         location = location.FirstOrDefault()
        //                     }).ToArray();
        //    var model = query.Where(pl => promotionModel.Any(d => (d.pro_code != "" && pl.Product.pro_code == d.pro_code)
        //      //|| (d.pro_size_code > 0 && pl.Product.pro_size_code == d.pro_size_code)
        //      //|| (d.pro_size_code == 0 && d.pro_model_code > 0 && pl.Product.pro_model_code == d.pro_model_code)
        //      //|| (d.pro_model_code == 0 && d.pro_brand_code != "" && pl.Product.pro_brand_code.ToString() == d.pro_brand_code)
        //      || (d.pro_brand_code == "" && d.progroup_code != "" && pl.Product.progroup_code == d.progroup_code)))
        //      .Select(q => new ProductModel
        //      {
        //          Id = q.Product.Pro_Code_Run,
        //          Code = q.Product.pro_code,
        //          Name = q.Product.pro_ename,
        //          StockCurrent = q.ProductLocal?.pro_qoh,
        //          Type = q.Type != null && !string.IsNullOrWhiteSpace(q.Type.progroup_name) ? q.Type.progroup_name : "-",
        //          Brand = q.Brand != null && !string.IsNullOrWhiteSpace(q.Brand.pro_brand) ? q.Brand.pro_brand : "-",
        //          Gen = q.Modal != null && !string.IsNullOrWhiteSpace(q.Modal.pro_model) ? q.Modal.pro_model : "-",
        //          Size = q.Size != null && !string.IsNullOrWhiteSpace(q.Size.size_name) ? q.Size.size_name : "-",
        //          Unit = (int)q.Product.sale_unit_code,
        //          Price = q.Product.pro_price_retail,
        //          StoreName = q.location?.locat_name,
        //          Store = q.location?.locat_code
        //      }).ToArray();

        //    return model;
        //}
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
