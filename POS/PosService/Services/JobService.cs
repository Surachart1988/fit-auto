using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.Sale;
using CentralService.Models.SystemData;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static PosService.PosServiceUnityExtension;


namespace PosService.Services
{
    public class JobService : IJobService
    {
        private Entities _db;
        private Mapper _mapper;
        private DocService _docService;

        public JobService(Entities conn, Mapper mapper, DocService docService)
        {
            _db = conn;
            _mapper = mapper;
            _docService = docService;
        }

        public JobModel Get(string doc_no)
        {
            var model = new JobModel();
            if (doc_no != "")
            {
                var _j = _db.ST_Jobheader.FirstOrDefault(w => w.doc_no == doc_no);
                model = _mapper.Map<JobModel>(_j);
            }

            model.PaymentRoundDigit = _db.SB_System.FirstOrDefault()?.payment_round_digit;
            return model;
        }

        public DTResult<JobModel> GetlAll(DTParameters dtRequestModel, ISearchModel search)
        {
            var datenow = DateTime.Now.ToString("dd/MM/yyyy");
            var query = _db.ST_Jobheader.Where(w => w.doc_code == "J301")
                        .GroupJoin(_db.ST_Jobdetail,
                            j => j.doc_no,
                            d => d.doc_no,
                            (j, detail) => new { j, Qty = detail.Sum(s => s.store_qty) })
                            .GroupJoin(_db.ST_Arheader.Where(w => w.doc_close == "True"),
                                _ => _.j.doc_no,
                                arh => arh.ref_docno,
                                (j, ar) => new { j.j, j.Qty })
                                    .Join(_db.SB_Customer,
                                        _ => _.j.cus_code,
                                        c => c.cus_code,
                                        (jh, c) => new { jobheader = jh.j, customer = c, jh.Qty }
                  );
            switch (search.Status)
            {
                case "all":

                    break;
                case "cancel":
                    query = query.Where(w =>
                    (w.jobheader.doc_cancel == "True" || w.jobheader.doc_cancel == null || w.jobheader.doc_cancel == ""));
                    break;
                case "close":
                    query = query.Where(w =>
                    (w.jobheader.doc_close == "True" || w.jobheader.doc_close == null || w.jobheader.doc_close == ""));
                    break;
                default:
                    query = query.Where(w => w.jobheader.doc_date == datenow &&
                    (w.jobheader.doc_close == "False" || w.jobheader.doc_close == null || w.jobheader.doc_close == "") &&
                    (w.jobheader.doc_cancel == "False" || w.jobheader.doc_cancel == null || w.jobheader.doc_cancel == "")
                    );
                    break;
            }
            if (!string.IsNullOrWhiteSpace(search.KeywordsSearch))
            {
                query = query.Where(w =>
                    w.jobheader.doc_no.Contains(search.KeywordsSearch) ||
                        w.jobheader.cus_code.Contains(search.KeywordsSearch) ||
                            w.jobheader.car_reg.Contains(search.KeywordsSearch) ||
                                w.jobheader.quo_ref_docno.Contains(search.KeywordsSearch) ||
                                    w.jobheader.cus_code.Contains(search.KeywordsSearch) ||
                                        w.customer.add_tel.Contains(search.KeywordsSearch) ||
                                            w.customer.add_mobile.Contains(search.KeywordsSearch) ||
                                                w.customer.cus_name.Contains(search.KeywordsSearch));
            }
            if (!string.IsNullOrEmpty(search.StartDate) && !string.IsNullOrEmpty(search.EndDate))
            {
                // Todo 
                // and ( a.date_report >= 20200701 and a.date_report <= 20200731 ) 
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.doc_no); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.doc_date); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.cus_code); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.customer.cus_name); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.car_reg); break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Qty); break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.job_amt); break;
                    case 7:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.doc_close); break;
                    case 8:
                        query = DatatableTools.SortDatetable(query, sort, p => p.jobheader.doc_cancel); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraMapper(q.jobheader, q.customer, q.Qty));
            var dtModel = new DTResult<JobModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public object GetJOrderCode(string doc_code, string doc_no)
        {
            string j0CD = "";
            var temp_list = _db.ST_Docno.Where(w => w.doc_no.Contains(doc_no) && w.doc_code == doc_code);
            if (temp_list.Count() > 0)
            {
                var lated = temp_list.Select(s => new { s.doc_no, odoc_no = s.doc_no.Substring(3, 8) }).OrderByDescending(o => o.odoc_no).FirstOrDefault();
                int newCode = Int32.Parse(lated.odoc_no); newCode++;
                j0CD = $"{doc_no}{newCode.ToString("D" + lated.odoc_no.Length)}";
            }
            else
            {
                j0CD = $"{doc_no}0000001";
            }
            if (!string.IsNullOrEmpty(j0CD))
            {
                _db.ST_Docno.Add(new ST_Docno { doc_no = j0CD, doc_code = doc_code });
                _db.SaveChanges();
            }
            return j0CD;
        }

        public int AddProductJobOrder(JobTempModel model, string doc_code)
        {
            int runno = 1;
            ST_Jobtemp product;
            if (model.mode == "edit")
            {
                if (model.dot_id != 0)
                {
                    product = _db.ST_Jobtemp.FirstOrDefault(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.dot_id == model.dot_id && w.ps_code == model.ps_code);
                }
                else
                {
                    product = _db.ST_Jobtemp.FirstOrDefault(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.ps_code == model.ps_code);
                }
                product.store_qty = model.store_qty;
                product.pro_price = model.pro_price;
                product.pro_amt = product.store_qty * model.pro_price;
                product.io_by = model.io_by;
                _db.Entry(product).State = EntityState.Modified;
            }
            else
            {
                IQueryable<ST_Jobtemp> productlist = null;
                if (model.dot_id != null)
                {
                    productlist = _db.ST_Jobtemp.Where(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.dot_id == model.dot_id && w.ps_code == 0);
                }
                else
                {
                    productlist = _db.ST_Jobtemp.Where(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.ps_code == 0);
                }

                //if (_db.ST_Jobtemp.Any(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.ps_code == 0))
                if (productlist.Any())
                {
                    product = productlist.FirstOrDefault();//w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.ps_code == 0
                    product.store_qty = product.store_qty + model.store_qty;
                    product.pro_price = model.pro_price;
                    product.pro_amt = product.store_qty * model.pro_price;
                    product.io_by = model.io_by;
                    _db.Entry(product).State = EntityState.Modified;
                }
                else
                {
                    if (_db.ST_Jobtemp.Any(w => w.doc_no == model.doc_no))
                    {
                        runno = _db.ST_Jobtemp.Where(w => w.doc_no == model.doc_no).OrderByDescending(o => o.line_no).FirstOrDefault().line_no ?? 0; runno++;
                    }

                    _db.ST_Jobtemp.Add(new ST_Jobtemp
                    {
                        line_no = runno,
                        doc_no = model.doc_no,
                        doc_code = doc_code,
                        pro_code = model.pro_code,
                        dot_id = model.dot_id ?? 0,
                        pro_name = model.pro_name,
                        sale_unit_code = model.sale_unit_code,
                        locat_code = model.locat_code,
                        store_qty = model.store_qty,
                        pro_price = model.pro_price,
                        pro_amt = model.store_qty * model.pro_price,
                        io_by = model.io_by,
                        ps_code = model.ps_code ?? 0,
                    });
                }
            }

            return _db.SaveChanges();
        }

        public int AddProductSetJobOrder(List<ProductSetDetailModel> model, string doc_no, string doc_code)
        {
            int runno = 1, sucess = 0;
            ST_Jobtemp product;
            var ps_head = model.FirstOrDefault();
            var _jobtemp = _db.ST_Jobtemp.Where(w => w.doc_no == doc_no);
            if (!_jobtemp.Any())
            {
                _db.ST_Jobtemp.Add(new ST_Jobtemp
                {
                    line_no = runno,
                    doc_no = doc_no,
                    doc_code = doc_code,
                    pro_code = $"PS{ps_head.ps_code}",
                    pro_name = _db.SB_Product_Set_Head.FirstOrDefault(f => f.ps_code == ps_head.ps_code).ps_name ?? "",
                    sale_unit_code = 53,
                    locat_code = ps_head.ps_locat_code,
                    //store_qty = 0,
                    //pro_price = 0,
                    //pro_amt = 0,
                    //io_by = "",
                    ps_code = 0,
                });
                sucess += _db.SaveChanges();
            }
            else
            {
                var chkps_head = _jobtemp.Select(s => new { s.doc_no, opro_code = s.pro_code.Substring(2, s.pro_code.Length) }).Where(w => w.opro_code == ps_head.ps_code && w.doc_no == doc_no);
                if (!chkps_head.Any())
                {
                    var oLine = _jobtemp.OrderByDescending(o => o.line_no).FirstOrDefault().line_no; oLine++;
                    _db.ST_Jobtemp.Add(new ST_Jobtemp
                    {
                        line_no = oLine,
                        doc_no = doc_no,
                        doc_code = doc_code,
                        pro_code = $"PS{ps_head.ps_code}",
                        pro_name = _db.SB_Product_Set_Head.FirstOrDefault(f => f.ps_code == ps_head.ps_code).ps_name ?? "",
                        sale_unit_code = 53,
                        locat_code = ps_head.ps_locat_code,
                        //store_qty = 0,
                        //pro_price = 0,
                        //pro_amt = 0,
                        //io_by = "",
                        ps_code = 0,
                    });
                    sucess = _db.SaveChanges();
                }
            }

            foreach (var items in model)
            {
                var _dot_id = items.ddlobj?.FirstOrDefault(f => f.is_selected)?.dot_id ?? 0;
                IQueryable<ST_Jobtemp> productlist = null;
                if (_dot_id != 0)
                {
                    productlist = _db.ST_Jobtemp.Where(w => w.doc_no == doc_no && w.pro_code == items.ps_pro_code && w.dot_id == _dot_id && w.ps_code == items.doc_no_run);
                }
                else
                {
                    productlist = _db.ST_Jobtemp.Where(w => w.doc_no == doc_no && w.pro_code == items.ps_pro_code && w.ps_code == items.doc_no_run);
                }

                if (productlist.Any())
                {
                    product = productlist.FirstOrDefault();//_db.ST_Jobtemp.FirstOrDefault(w => w.doc_no == doc_no && w.pro_code == items.ps_pro_code && w.ps_code == items.doc_no_run);
                    product.store_qty = product.store_qty + items.ps_qty;
                    product.pro_price = items.ps_price;
                    product.pro_amt = product.store_qty * items.ps_price;
                    //product.io_by = "";
                    _db.Entry(product).State = EntityState.Modified;
                }
                else
                {
                    if (_db.ST_Jobtemp.Any(w => w.doc_no == doc_no))
                    {
                        runno = _db.ST_Jobtemp.Where(w => w.doc_no == doc_no).OrderByDescending(o => o.line_no).FirstOrDefault().line_no ?? 0; runno++;
                    }

                    _db.ST_Jobtemp.Add(new ST_Jobtemp
                    {
                        line_no = runno,
                        doc_no = doc_no,
                        doc_code = doc_code,
                        pro_code = items.ps_pro_code,
                        dot_id = _dot_id,
                        pro_name = items.pro_name,
                        sale_unit_code = _db.SB_Product.FirstOrDefault(f => f.pro_code == items.ps_pro_code).sale_unit_code,
                        locat_code = items.ps_locat_code,
                        store_qty = items.ps_qty,
                        pro_price = items.ps_price,
                        pro_amt = items.ps_qty * items.ps_price,
                        //io_by = items.io_by,
                        ps_code = items.doc_no_run,
                    });
                }
                sucess += _db.SaveChanges();
            }

            return sucess;
        }

        public int DeleteProductJobOrder(JobTempModel model)
        {
            IQueryable<ST_Jobtemp> productlist = null;
            if (model.pro_code.Contains("PS"))
            {
                var ps_head = model.pro_code.Substring(2);
                var ps_detail = _db.SB_Product_Set_Detail.Where(w => w.ps_code == ps_head);
                foreach (var items in ps_detail)
                {
                    var psList = _db.ST_Jobtemp.Where(f => f.doc_no == model.doc_no && f.pro_code == items.ps_pro_code && f.ps_code == items.doc_no_run);
                    foreach (var rows in psList)
                    {
                        _db.Entry(rows).State = EntityState.Deleted;
                    }

                }
            }
            //ST_Jobtemp product;
            if (model.dot_id > 0)
            {
                productlist = _db.ST_Jobtemp.Where(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.dot_id == model.dot_id && w.ps_code == model.ps_code);
            }
            else
            {
                productlist = _db.ST_Jobtemp.Where(w => w.doc_no == model.doc_no && w.pro_code == model.pro_code && w.ps_code == model.ps_code);
            }
            if (productlist.Any())
            {
                var test = productlist.FirstOrDefault();
                _db.Entry(test).State = EntityState.Deleted;
            }


            return _db.SaveChanges();
        }

        public object GetJobOrder(string doc_no)
        {
            return _db.ST_Jobtemp.Where(w => w.doc_no == doc_no)
                       .GroupJoin(_db.SB_Product,
                       _ => _.pro_code,
                       prod => prod.pro_code,
                       (master, product) => new { JOrder = master, Product = product.FirstOrDefault() })

                       .GroupJoin(_db.SB_Prolocation,
                       _ => _.JOrder.pro_code,
                       prolocat => prolocat.pro_code,
                       (master, prolocat) => new { master.JOrder, master.Product, Prolocat = prolocat.FirstOrDefault() })
                           .GroupJoin(_db.SB_location,
                           _ => _.Prolocat.locat_code,
                           locat => locat.locat_code,
                           (master, locat) => new { master.JOrder, master.Product, master.Prolocat, locat = locat.FirstOrDefault() })

                   .GroupJoin(_db.SB_Prolocation_dot,
                   _ => _.JOrder.dot_id,
                   prolocatdot => prolocatdot.dot_id,
                   (master, prolocatdot) => new { master.JOrder, master.Product, master.Prolocat, master.locat, Prolocatdot = prolocatdot.FirstOrDefault() })

                   .GroupJoin(_db.SB_Location_DOT,
                   _ => _.JOrder.dot_id,
                   locatdot => locatdot.dot_id,
                   (master, locatdot) => new { master.JOrder, master.Product, master.Prolocat, master.locat, master.Prolocatdot, locatdot = locatdot.FirstOrDefault() })

               .GroupJoin(_db.SB_UnitName,
                _ => _.JOrder.sale_unit_code,
                u => u.unit_code,
                (master, unit) => new { master.JOrder, master.Product, master.Prolocat, master.locat, master.Prolocatdot, master.locatdot, unit = unit.FirstOrDefault() })
                .ToArray()
                .Select(s => MapperJobOrder(s.JOrder, s.Product, s.Prolocat, s.locat, s.Prolocatdot, s.locatdot, s.unit));
        }

        private JobTempModel MapperJobOrder(ST_Jobtemp job, SB_Product product, SB_Prolocation prolocat, SB_location locat, SB_Prolocation_dot prolocatdot,
            SB_Location_DOT locatD, SB_UnitName unit)
        {
            var m = _mapper.Map<JobTempModel>(job);
            m.locat_name = locat?.locat_name ?? "";
            m.locat_dot_name = locatD?.dot_name ?? "-";
            m.sale_unit_name = unit.unit_name;

            m.pro_tname = job.pro_name;
            m.dot_name = locatD?.dot_name ?? "";
            m.pro_ohqty = product?.pro_ohqty;
            m.pro_stock = product?.pro_stock ?? "";
            m.pro_qty = prolocatdot?.pro_qty; //dot stock
            m.pro_price_retail = job?.pro_price;
            return m;
        }

        private JobModel ExtraMapper(ST_Jobheader model, SB_Customer customer, double? qty)
        {
            var m = _mapper.Map<JobModel>(model);
            m.cus_name = customer.cus_name;
            m.Qty = qty ?? 0;
            return m;
        }

        public int AddUpdate(JobModel model, ref string doc_no)
        {
            DateTime add_date = DateTime.Now;
            int _rowCount = 0;

            try
            {
                if (model.doc_no != "")
                {

                }
                else
                {

                }
                return _rowCount;
            }
            catch (Exception ex)
            {
                return _rowCount;
            }
        }


    }
}
