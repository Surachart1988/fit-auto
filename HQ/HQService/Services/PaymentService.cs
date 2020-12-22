using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HQService.HQServiceUnityExtension;

namespace HQService.Services
{
    public class PaymentService : IPaymentService
    {
        private HQEntities _db;
        private Mapper _mapper;
        private DocService _docService;

        public PaymentService(HQEntities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }

        public int AddPaymentCredit(string branchNo, int userId, PaymentCrDetailModel model)
        {
            var dbModel = new ST_PayCard
            {
                branch_no = branchNo,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                card_code = model.CardTypeCode,
                card_id = model.CreditNumber,
                card_amt = model.PaymentCr,
                installment_id = model.PaymentFormatId,
                card_remark = model.Note
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

        public PaymentModel Get(string docCode, string docNo, string branchNo, string refDocno, string dpDocno, string dealerCode, int userId)
        {
            var paymentModel = new PaymentModel();
            switch (docCode)
            {
                case "2101":
                case "2102":
                case "2103":
                case "T101":
                case "T102":
                case "T103":
                    paymentModel = _db.ST_Jobheader.Where(j => j.branch_no == branchNo && j.doc_no == refDocno)
                        .Join(_db.SB_Customer,
                            j => j.cus_code,
                            c => c.cus_code,
                            (job, customer) => new { job, customer })
                            .GroupJoin(_db.SB_BlueCard,
                            h => h.customer.cus_member_id,
                            b => b.CardNumber,
                            (head, bluecard) => new { head.job, head.customer, bluecard = bluecard.FirstOrDefault() })
                        .GroupJoin(_db.ST_Jobdetail.Where(j => j.branch_no == branchNo && j.pm_code != null && j.pm_code != ""),
                        h => h.job.doc_no,
                        d => d.doc_no,
                        (head, details) => new PaymentModel
                        {
                            DocCode = docCode,
                            DocNo = docNo,
                            RefDocNo = refDocno,
                            CustomerCode = head.job.cus_code,
                            TotalAmount = (double)head.job.job_totalamt,
                            TotalDiscount = details.Any() ? Math.Abs((double)details.Sum(d => d.pro_price)) : 0,
                            //PromotionAndDiscountModalList = details.Select(d => new PromotionAndDiscountModal
                            //{
                            //    Name = d.pro_name,
                            //    Number = d.store_qty,
                            //    Money = Math.Abs((double)d.pro_price)
                            //}).ToList()
                        }).FirstOrDefault();

                    if (!string.IsNullOrWhiteSpace(dpDocno))
                    {
                        var depositModelList = GetDepositModels(paymentModel.CustomerCode, paymentModel.DocNo);
                        var depositModel = depositModelList.FirstOrDefault(d => d.DepositNo == dpDocno);
                        if (depositModel != null)
                        {
                            depositModel.DocNo = paymentModel.DocNo;
                            depositModel.DocCode = paymentModel.DocCode;
                            depositModel.Note = "สร้างจากใบมัดจำ";
                            depositModel.Id = AddPaymentDeposit(depositModel, branchNo, dealerCode, userId);
                            paymentModel.DepositModel = depositModel;
                        }
                    }

                    var promotionModel = _db.SB_PromotionHeader.GroupJoin(
                        _db.SB_PromotionDetail,
                        h => h.pro_id,
                        d => d.pro_id,
                        (head, details) => new { head, details })
                        .Where(p => !(bool)p.head.deleted)
                        .ToArray()
                        .Where(p => Convert.ToDateTime(p.head.pro_start_date + " " + p.head.pro_start_time) > DateTime.Now
                        && DateTime.Now > Convert.ToDateTime(p.head.pro_end_date + " " + p.head.pro_end_time))
                        .Select(p => new PromotionAndDiscountModal
                        {
                            Code = p.head.pro_id,
                            Name = p.head.pro_name,
                            Type = p.head.pro_type_id.ToString(),
                            SubType = p.head.pro_give_type_id.ToString(),
                            Money = p.head.pro_price_total,
                        }).ToList();

                    paymentModel.PromotionModalList = promotionModel;

                    break;
                case "A302":
                    paymentModel = _db.ST_RDATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
                        r => new { r.doc_no, r.cus_code },
                        r => r,
                        (key, details) =>
                         new PaymentModel
                         {
                             DocNo = key.doc_no,
                             DocCode = docCode,
                             CustomerCode = key.cus_code,
                             TotalAmount = details.Any() ? (double)details.Sum(d => d.dp_price) : 0,
                         }).FirstOrDefault();
                    break;
                case "A301":
                    paymentModel = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
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
                    if(paymentModel == null)
                    {
                        paymentModel = _db.ST_RPATemp.Where(j => j.branch_no == branchNo && j.doc_no == refDocno).GroupBy(
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
                    paymentModel = _db.ST_RTATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
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
                    paymentModel = _db.ST_PPATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
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
                    paymentModel = _db.ST_PTATemp.Where(j => j.branch_no == branchNo && j.doc_no == docNo).GroupBy(
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
            }

            paymentModel.DiscountIconList = _db.SB_ExtraDiscount.Where(ex => !ex.IsDelete).ToArray().Select(extra => _mapper.Map<ExtraDiscountIconModel>(extra)).OrderBy(extra => extra.RankNo).ToList();

            return paymentModel;
        }

        public int AddPaymentOther(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId)
        {
            var dbModel = new ST_PayOther
            {
                branch_no = branchNo,
                doc_code = model.DocCode,
                doc_no = model.DocNo,
                doc_date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                user_pay_id = userId,
                //pay_id = model.Id.ToString(),
                dealercode = dealerCode,
                crd_amt = model.Money,
                pay_code = model.Code,
                crd_remark = model.Note
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

        public List<DepositModel> GetDepositModels(string CustomerCode, string docNo)
        {
            var query = _db.ST_RDAHeader.Where(r => r.cus_code == CustomerCode && r.doc_close != "True")
                .GroupJoin(_db.ST_PayDep,
                r => r.doc_no,
                p => p.ref_docno,
                (rda, pay) => new { rda, pay });

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

        public void DeletePaymentDeposit(int id)
        {
            var dbModel = _db.ST_PayDep.FirstOrDefault(p => p.doc_no_run == id);

            if (dbModel == null) return;

            _db.Entry(dbModel).State = EntityState.Deleted;
            _db.SaveChanges();
        }


        public int AddPaymentDeposit(DepositModel model, string branchNo, string dealerCode, int userId)
        {
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

        public DTResult<ExtraDiscountIconModel> GetExtraDiscountDTResult(DTParameters dtRequestModel)
        {
                        var query = _db.SB_ExtraDiscount.Where(ex => !ex.IsDelete)
                                    .GroupJoin(_db.SB_Progroup,
 /*SB_ExtraDiscount*/               ex => ex.ProgroupCode,
 /*SB_Progroup*/                    pg => pg.progroup_code,
                                    (extra, progroup) => new { extra, progroup = progroup.FirstOrDefault() })
                                    .GroupJoin(_db.SB_Custype,
                                    master => master.extra.CustypeCode,
                                    cusgroup => cusgroup.custype_code,
                                    (master, cusgroup) => new { master.extra, master.progroup, cusgroup = cusgroup.FirstOrDefault() }
                                    );

            if (!string.IsNullOrWhiteSpace(dtRequestModel.Search.Value))
            {
                query = query.Where(q =>
                    q.extra.Code.Contains(dtRequestModel.Search.Value) ||
                    q.extra.Name.Contains(dtRequestModel.Search.Value) ||
                    q.extra.RankNo.ToString().Contains(dtRequestModel.Search.Value)
                    );
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.extra.Code);
                        break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.extra.Name);
                        break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.progroup != null ? p.progroup.progroup_name : "");
                        break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.cusgroup != null ? p.cusgroup.custype_name : "");
                        break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.extra.Baht != null && p.extra.Baht > 0 ? p.extra.Baht : p.extra.Percents);
                        break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.extra.RankNo);
                        break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraDiscountMapper(q.extra, q.cusgroup, q.progroup)).ToList();

            var dtModel = new DTResult<ExtraDiscountIconModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        private ExtraDiscountIconModel ExtraDiscountMapper(SB_ExtraDiscount extra, SB_Custype cusGroup, SB_Progroup proGroup)
        {
            var m = _mapper.Map<ExtraDiscountIconModel>(extra);
            m.CustypeName = cusGroup?.custype_name;
            m.ProgroupName = proGroup?.progroup_name;
            return m;
        }

        public ExtraDiscountIconModel GetExtraDiscount(int id)
        {
            var dbModel = _db.SB_ExtraDiscount.FirstOrDefault(ed => ed.Id == id);
            var model = _mapper.Map<ExtraDiscountIconModel>(dbModel);
            return model;
        }

        public string GetDocNo()
        {
            var lastModel = _db.SB_ExtraDiscount.OrderByDescending(p => p.Code).FirstOrDefault();
            string lastNo = "0";
            if (lastModel != null)
                lastNo = lastModel.Code;
            return _docService.GenDocNo4("DIS", lastNo);
        }

        public void CreateExtraDiscount(ExtraDiscountIconModel model)
        {
            if (_db.SB_ExtraDiscount.Any())
            {
                var rankNo = _db.SB_ExtraDiscount.Max(ed => ed.RankNo);
                model.RankNo = (int)rankNo + 1;
            }
            else
                model.RankNo = 1;

            var dbModel = _mapper.Map<SB_ExtraDiscount>(model);
            dbModel.SendClient = true;
            dbModel.Code = GetDocNo();
            _db.SB_ExtraDiscount.Add(dbModel);
            _db.SaveChanges();
        }

        public void UpdateExtraDiscount(ExtraDiscountIconModel model)
        {
            var dbModel = _db.SB_ExtraDiscount.FirstOrDefault(ed => ed.Id == model.Id);
            dbModel.Name = model.Name;
            dbModel.Percents = model.Percents;
            dbModel.ProgroupCode = model.ProgroupCode;
            dbModel.Baht = model.Baht;
            dbModel.Code = model.Code;
            dbModel.CustypeCode = model.CustypeCode;
            dbModel.SendClient = true;
            _db.Entry(dbModel).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteExtraDiscount(int id)
        {
            var dbModel = _db.SB_ExtraDiscount.FirstOrDefault(ed => ed.Id == id);
            dbModel.IsDelete = true;
            _db.Entry(dbModel).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public int AddProductList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductList(int id, string docCode)
        {
            throw new NotImplementedException();
        }

        public void ClearProductListTemp(string docCode, string docNo, string branchNo, string refDocno)
        {
            throw new NotImplementedException();
        }

        public int AddDiscountList(PromotionAndDiscountModal model, string branchNo, string dealerCode, int userId)
        {
            throw new NotImplementedException();
        }

        public ProductModel[] GetPromotionGiveDTResult(string promotionId)
        {
            throw new NotImplementedException();
        }

    
    }
}
