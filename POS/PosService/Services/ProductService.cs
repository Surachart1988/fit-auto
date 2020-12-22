using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.Sale;
using CentralService.Services;
using PosData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static PosService.PosServiceUnityExtension;

namespace PosService.Services
{
    public class ProductService : IProductService
    {
        private Entities _db;
        private Mapper _mapper;
        public ProductService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
        }
        public async Task<DTResult<ProductModel>> ProductList(ProductSearchModel dtRequestModel, string cus_code, string cus_type)
        {
            //var _SBProlocation = _db.SB_Prolocation
            //            .Join(_db.SB_location.Where(w => w.novat_status == "1"),
            //            _ => _.locat_code,
            //            locat => locat.locat_code,
            //            (pdlocat, locat) => new { location = pdlocat });
            var query = _db.SB_Product.Where(w => w.cancel_date == null || w.cancel_date == "") //(ev_list_select_product_job.cancel_date is null or ev_list_select_product_job.cancel_date = '') 
                        .Join(_db.SB_Progroup,
                        _ => _.progroup_code,
                        pdgroup => pdgroup.progroup_code,
                        (master, grp) => new { Product = master, ProductGrpCode = grp })
                            .GroupJoin(_db.SB_Product_FirstGroup,
                            _ => _.ProductGrpCode.product_group_code,
                            _grp => _grp.product_group_code,
                            (master, fgrp) => new { master.Product, master.ProductGrpCode, ProductGrp = fgrp })
                                .GroupJoin(_db.SB_Probrand,
                                _ => _.Product.pro_brand_code,
                                pdbrand => pdbrand.pro_brand_code,
                                (master, brand) => new { master.Product, master.ProductGrpCode, master.ProductGrp, ProductBrand = brand.FirstOrDefault() })
                                    .GroupJoin(_db.SB_Promodel,
                                    _ => _.Product.pro_model_code,
                                    pdmodel => pdmodel.pro_model_code,
                                    (master, models) => new { master.Product, master.ProductGrpCode, master.ProductGrp, master.ProductBrand, ProductModel = models.FirstOrDefault() })
                                        .GroupJoin(_db.SB_ProSize,
                                        _ => _.Product.pro_size_code,
                                        pdsize => pdsize.pro_size_code,
                                        (master, size) => new { master.Product, master.ProductGrpCode, master.ProductGrp, master.ProductBrand, master.ProductModel, ProductSize = size.FirstOrDefault() }
                                        //.GroupJoin(_SBProlocation,
                                        //_ => _.Product.pro_code,
                                        //pl => pl.location.pro_code,
                                        //(master, loc) => new
                                        //{
                                        //    master.Product,
                                        //    master.ProductGrpCode,
                                        //    master.ProductGrp,
                                        //    master.ProductBrand,
                                        //    master.ProductModel,
                                        //    master.ProductSize,
                                        //    ProductQty = loc.Sum(s => s.location.pro_qoh)
                                        //}
                                        );
            /*

             */
            //(dtRequestModel.pro_status != "" && w.Product.stock_status.Contains(dtRequestModel.pro_status))

            //var Allresult = query.ToList();
            if (!string.IsNullOrEmpty(dtRequestModel.keysearch))
            {
                query = query.Where(w =>
w.Product.pro_code.Contains(dtRequestModel.keysearch) ||
    w.Product.Part_No.Contains(dtRequestModel.keysearch) ||
        w.Product.pro_tname.Contains(dtRequestModel.keysearch) ||
            w.Product.rec_memo.Contains(dtRequestModel.keysearch) ||
                w.ProductGrp.FirstOrDefault().product_group_name.Contains(dtRequestModel.keysearch) ||
                    w.ProductGrpCode.progroup_name.Contains(dtRequestModel.keysearch) ||
                        w.ProductBrand.pro_brand.Contains(dtRequestModel.keysearch) ||
                            w.ProductModel.pro_model.Contains(dtRequestModel.keysearch) ||
                                w.ProductSize.size_name.Contains(dtRequestModel.keysearch));
            }
            //var searchresult = query.ToList();
            if (dtRequestModel.pro_size_code > 0)
            {
                query = query.Where(w =>
    (dtRequestModel.product_group_code > 0 ? w.ProductGrpCode.product_group_code == dtRequestModel.product_group_code : false) &&
    (dtRequestModel.progroup_code != "" ? w.ProductGrpCode.progroup_code == dtRequestModel.progroup_code : false) &&
    (dtRequestModel.pro_brand_code > 0 ? w.ProductBrand.pro_brand_code == dtRequestModel.pro_brand_code : false) &&
    (dtRequestModel.pro_model_code > 0 ? w.ProductModel.pro_model_code == dtRequestModel.pro_model_code : false) &&
    (dtRequestModel.pro_size_code > 0 ? w.ProductSize.pro_size_code == dtRequestModel.pro_size_code : false)
    );
            }

            if (dtRequestModel.pro_model_code > 0 && dtRequestModel.pro_size_code == 0)
            {
                query = query.Where(w =>
    (dtRequestModel.product_group_code > 0 ? w.ProductGrpCode.product_group_code == dtRequestModel.product_group_code : false) &&
    (dtRequestModel.progroup_code != "" ? w.ProductGrpCode.progroup_code == dtRequestModel.progroup_code : false) &&
    (dtRequestModel.pro_brand_code > 0 ? w.ProductBrand.pro_brand_code == dtRequestModel.pro_brand_code : false) &&
    (dtRequestModel.pro_model_code > 0 ? w.ProductModel.pro_model_code == dtRequestModel.pro_model_code : false)
    );
            }

            if (dtRequestModel.pro_brand_code > 0 && dtRequestModel.pro_model_code == 0 && dtRequestModel.pro_size_code == 0)
            {
                query = query.Where(w =>
    (dtRequestModel.product_group_code > 0 ? w.ProductGrpCode.product_group_code == dtRequestModel.product_group_code : false) &&
    (dtRequestModel.progroup_code != "" ? w.ProductGrpCode.progroup_code == dtRequestModel.progroup_code : false) &&
    (dtRequestModel.pro_brand_code > 0 ? w.ProductBrand.pro_brand_code == dtRequestModel.pro_brand_code : false)
    );
            }

            if (dtRequestModel.progroup_code != "" && dtRequestModel.pro_brand_code == 0 && dtRequestModel.pro_model_code == 0 && dtRequestModel.pro_size_code == 0)
            {
                query = query.Where(w =>
    (dtRequestModel.product_group_code > 0 ? w.ProductGrpCode.product_group_code == dtRequestModel.product_group_code : false) &&
    (dtRequestModel.progroup_code != "" ? w.ProductGrpCode.progroup_code == dtRequestModel.progroup_code : false)
    );
            }

            if (dtRequestModel.product_group_code > 0 && dtRequestModel.progroup_code == "" && dtRequestModel.pro_brand_code == 0 && dtRequestModel.pro_model_code == 0 && dtRequestModel.pro_size_code == 0)
            {
                query = query.Where(w =>
    (dtRequestModel.product_group_code > 0 ? w.ProductGrpCode.product_group_code == dtRequestModel.product_group_code : false)
    );
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Product.pro_code); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Product.Part_No); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Product.pro_tname); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProductGrpCode.progroup_name); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProductBrand.pro_brand); break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProductModel.pro_model); break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProductSize.pro_size); break;
                    case 7:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Product.pro_ohqty); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraMapper((q.Product.pro_stock == "0" ? GetProPrice(q.Product, cus_code, cus_type) : q.Product),
                q.ProductGrpCode, q.ProductBrand, q.ProductModel, q.ProductSize));
            var dtModel = new DTResult<ProductModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public object ProductDetailList(string pro_code, string cus_code, string cus_type)
        {
            var query = _db.SB_Product.Where(w => w.pro_code == pro_code)

                        .GroupJoin(_db.SB_Prolocation,
                        _ => _.pro_code,
                        prolocat => prolocat.pro_code,
                        (product, prolocat) => new { Product = product, Prolocat = prolocat.FirstOrDefault() })
                        .GroupJoin(_db.SB_location,
                        _ => _.Prolocat.locat_code,
                        locat => locat.locat_code,
                        (master, locat) => new { master.Product, master.Prolocat, locat = locat.FirstOrDefault() })

                        .GroupJoin(_db.SB_Prolocation_dot,
                        _ => _.Product.pro_code,
                        prolocatdot => prolocatdot.pro_code,
                        (master, prolocatdot) => new
                        {
                            master.Product,
                            master.Prolocat,
                            master.locat,
                            Prolocatdot = prolocatdot.Join(_db.SB_Location_DOT,
                        _ => _.dot_id,
                        locatdot => locatdot.dot_id,
                        (_prolocatdot, locatdot) => new { _prolocatdot, locatdot })
                        })
                        //.GroupJoin(_db.SB_Location_DOT,
                        //_ => _.Prolocatdot.dot_id,
                        //locatdot => locatdot.dot_id,
                        //(master, locatdot) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot, locatdot = locatdot.FirstOrDefault() })

                        .Join(_db.SB_Progroup,
                        _ => _.Product.progroup_code,
                        pdgroup => pdgroup.progroup_code,
                        (master, grp) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot/*, master.locatdot*/, ProductGrpCode = grp })
                            .GroupJoin(_db.SB_Product_FirstGroup,
                            _ => _.ProductGrpCode.product_group_code,
                            _grp => _grp.product_group_code,
                            (master, fgrp) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot/*, master.locatdot*/, master.ProductGrpCode, ProductGrp = fgrp })
                                .GroupJoin(_db.SB_Probrand,
                                _ => _.Product.pro_brand_code,
                                pdbrand => pdbrand.pro_brand_code,
                                (master, brand) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot/*, master.locatdot*/, master.ProductGrpCode, master.ProductGrp, ProductBrand = brand.FirstOrDefault() })
                                    .GroupJoin(_db.SB_Promodel,
                                    _ => _.Product.pro_model_code,
                                    pdmodel => pdmodel.pro_model_code,
                                    (master, models) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot/*, master.locatdot*/, master.ProductGrpCode, master.ProductGrp, master.ProductBrand, ProductModel = models.FirstOrDefault() })
                                        .GroupJoin(_db.SB_ProSize,
                                        _ => _.Product.pro_size_code,
                                        pdsize => pdsize.pro_size_code,
                                        (master, size) => new { master.Product, master.Prolocat, master.locat, master.Prolocatdot/*, master.locatdot*/, master.ProductGrpCode, master.ProductGrp, master.ProductBrand, master.ProductModel, ProductSize = size.FirstOrDefault() })
                        .ToArray()
                        .Select(s => new
                        {
                            Product = ExtraMapper(GetProPrice(s.Product, cus_code, cus_type), s.ProductGrpCode, s.ProductBrand, s.ProductModel, s.ProductSize, true),
                            Productlocat = MapperProLocation(s.Prolocat, s.locat),
                            ProductlocatDot = s.Prolocatdot != null ? s.Prolocatdot.ToArray().Select(_ => MapperProLocationDot(_._prolocatdot, _.locatdot, s.locat)) : null
                            //ProductlocatDot = s.Prolocatdot != null ? MapperProLocationDot(s.Prolocatdot, s.locatdot, s.locat) : null
                        });
            return query;
        }

        private ProductModel CheckProductSet(ProductModel product)
        {
            /*
              select * from SB_Product_Set_Head 
                where ps_gen_id in (select ps_gen_id from SB_Product_Set_Detail 
                where ps_pro_code = '400581' and ps_startdate_report <= '20200816' and ps_enddate_report >= '20200816')
             */
            var ps_d = _db.SB_Product_Set_Detail.Where(a => a.ps_pro_code == product.pro_code);
            if (ps_d.Any())
            {
                var ps_Head = _db.SB_Product_Set_Head.ToArray().Where(w => w.ps_gen_id == ps_d.FirstOrDefault().ps_gen_id).FirstOrDefault();
                if (ps_Head != null)
                {
                    var ps_startdate = DateTime.ParseExact(ps_Head.ps_startdate, "dd/MM/yyyy", null);
                    var ps_enddate = DateTime.ParseExact(ps_Head.ps_enddate, "dd/MM/yyyy", null);
                    if (ps_startdate <= DateTime.Today && ps_enddate >= DateTime.Today)
                    {
                        product.is_proset = true;
                        product.ps_gen_id = ps_Head.ps_gen_id;
                        product.ps_code = ps_Head.ps_code;
                        product.ps_name = ps_Head.ps_name;

                    }
                    return product;
                }
                else { return product; }
            }
            else
            {
                return product;
            }
        }

        private locationModel MapperProLocation(SB_Prolocation prolocat, SB_location locat)
        {
            var m = _mapper.Map<locationModel>(prolocat);
            m.locat_name = locat.locat_name;
            return m;
        }

        private locationDotModel MapperProLocationDot(SB_Prolocation_dot prolocatD, SB_Location_DOT locatD, SB_location locat)
        {
            var m = _mapper.Map<locationDotModel>(prolocatD);
            m.dot_name = locatD?.dot_name ?? "";
            m.locat_name = locat.locat_name;
            return m;
        }

        public DTResult<ProductSetModel> ProductSetList(ProductSearchModel dtRequestModel)
        {
            var query = _db.SB_Product_Set_Head.Where(w => w.ps_typesale == "Job" || w.ps_typesale == "JobSale")
                        .GroupJoin(_db.SB_Product_Set_Detail,
                        _ => _.ps_gen_id,
                        detail => detail.ps_gen_id,
                        (proset, detail) => new { ProducSet = proset, detail = detail.FirstOrDefault() })
                        .Join(_db.SB_Product,
                        _ => _.detail.ps_pro_code,
                        pd => pd.pro_code,
                        (master, product) => new { master.ProducSet, master.detail, product }
                        );
            if (!string.IsNullOrEmpty(dtRequestModel.prodSetSearch))
            {
                query = query.Where(w =>
                        w.ProducSet.ps_code.Contains(dtRequestModel.prodSetSearch) ||
                            w.ProducSet.ps_name.Contains(dtRequestModel.prodSetSearch) ||
                                w.product.pro_code.Contains(dtRequestModel.prodSetSearch) ||
                                    w.product.pro_tname.Contains(dtRequestModel.prodSetSearch));
            }


            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProducSet.ps_code); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProducSet.ps_name); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProducSet.ps_startdate); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.ProducSet.ps_enddate_report); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => _mapper.Map<ProductSetModel>(q.ProducSet));
            if (dtRequestModel.StartDate != null || dtRequestModel.EndDate != null)
            {
                if (!string.IsNullOrEmpty(dtRequestModel.StartDate) && !string.IsNullOrEmpty(dtRequestModel.EndDate))
                {
                    model = model.Where(q =>
                        DateTime.ParseExact(q.ps_startdate, "dd/MM/yyyy", null) >= DateTime.ParseExact(dtRequestModel.StartDate, "dd/MM/yyyy", null) &&
                        DateTime.ParseExact(q.ps_enddate, "dd/MM/yyyy", null) <= DateTime.ParseExact(dtRequestModel.EndDate, "dd/MM/yyyy", null)
                    );
                }
                else if (!string.IsNullOrEmpty(dtRequestModel.StartDate))
                {
                    model = model.Where(q =>
                        DateTime.ParseExact(q.ps_startdate, "dd/MM/yyyy", null) >= DateTime.ParseExact(dtRequestModel.StartDate, "dd/MM/yyyy", null)
                    );
                }
            }
            var dtModel = new DTResult<ProductSetModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public object ProductSetDetailList(string ps_code, int ps_gen_id)
        {
            var _head = _db.SB_Product_Set_Head.Where(w => w.ps_code == ps_code && w.ps_gen_id == ps_gen_id).FirstOrDefault();
            var ps_startdate = DateTime.ParseExact(_head.ps_startdate, "dd/MM/yyyy", null);
            var ps_enddate = DateTime.ParseExact(_head.ps_enddate, "dd/MM/yyyy", null);

            var query = _db.SB_Product_Set_Head.Where(w => w.ps_code == ps_code && w.ps_gen_id == ps_gen_id &&
                                                    ps_startdate <= DateTime.Today && ps_enddate >= DateTime.Today)
                        .Join(_db.SB_Product_Set_Detail,
                        _ => _.ps_gen_id,
                        detail => detail.ps_gen_id,
                        (proset, ProducSetDetail) => new { ProducSetDetail })
                        .Join(_db.SB_Product,
                        _ => _.ProducSetDetail.ps_pro_code,
                        pd => pd.pro_code,
                        (master, product) => new { master.ProducSetDetail, Product = product })

                        .GroupJoin(_db.SB_Prolocation,
                       _ => _.ProducSetDetail.ps_pro_code,
                       prolocat => prolocat.pro_code,
                       (master, prolocat) => new { master.ProducSetDetail, master.Product, Prolocat = prolocat.FirstOrDefault() })
                           .GroupJoin(_db.SB_location,
                           _ => _.Prolocat.locat_code,
                           locat => locat.locat_code,
                           (master, locat) => new { master.ProducSetDetail, master.Product, master.Prolocat, locat = locat.FirstOrDefault() })

                   .GroupJoin(_db.SB_Prolocation_dot,
                   _ => _.ProducSetDetail.ps_pro_code,
                   prolocatdot => prolocatdot.pro_code,
                   (master, prolocatdot) => new
                   {
                       master.ProducSetDetail,
                       master.Product,
                       master.Prolocat,
                       master.locat,
                       Prolocatdot = prolocatdot
                            .Join(_db.SB_Location_DOT,
                        _ => _.dot_id,
                       locatdot => locatdot.dot_id,
                       (prodot, locatdot) => new { prodot, locatdot }).Select(s => new locationDotModel
                       {
                           dealercode = s.prodot.dealercode,
                           pro_code = s.prodot.pro_code,
                           dot_id = s.prodot.dot_id,
                           locat_code = s.prodot.locat_code,
                           pro_qty = s.prodot.pro_qty,
                           status = s.prodot.status,
                           dot_name = s.locatdot.dot_name,
                           //s.locatdot.dot_id,
                           flag_used = s.locatdot.flag_used
                       })
                   })

                        //.GroupJoin(_db.SB_Location_DOT,
                        //_ => _.JOrder.dot_id,
                        //locatdot => locatdot.dot_id,
                        //(master, locatdot) => new { master.ProducSetDetail, master.Product, master.Prolocat, master.locat, master.Prolocatdot, locatdot = locatdot.FirstOrDefault() })

                        .ToArray()
                        .Select(s => MapperProSetDetail(s.ProducSetDetail, s.Product, s.locat, s.Prolocat, s.Prolocatdot))
                        .OrderBy(o => o.ps_line_no);

            return query;
            #region. bak
            //var query = _db.SB_Product_Set_Head.Where(w => w.ps_code == ps_code && w.ps_gen_id == ps_gen_id)
            //            .Join(_db.SB_Product_Set_Detail,
            //            _ => _.ps_gen_id,
            //            detail => detail.ps_gen_id,
            //            (proset, ProducSetDetail) => new { ProducSetDetail })
            //            .Join(_db.SB_Product,
            //            _ => _.ProducSetDetail.ps_pro_code,
            //            pd => pd.pro_code,
            //            (master, product) => new { master.ProducSetDetail, product })

            //            .Join(_db.SB_location,
            //            _ => _.ProducSetDetail.ps_locat_code,
            //            loca => loca.locat_code,
            //            (master, location) => new { master.ProducSetDetail, master.product, location })
            //            .Join(_db.SB_Prolocation,
            //            _ => _.ProducSetDetail.ps_pro_code,
            //            proloca => proloca.pro_code,
            //            (master, prolocation) => new { master.ProducSetDetail, master.product, master.location, prolocation })

            //            .ToArray().Select(s => MapperProSetDetail(s.ProducSetDetail, s.product, s.location, s.prolocation)).OrderBy(o => o.ps_line_no);
            #endregion
        }
        private ProductSetDetailModel MapperProSetDetail(SB_Product_Set_Detail producSetDetail, SB_Product product, SB_location location, SB_Prolocation prolocation, IEnumerable<locationDotModel> prolocatdot)
        {

            var m = _mapper.Map<ProductSetDetailModel>(producSetDetail);
            m.pro_name = product.pro_tname;
            m.pro_stock = product?.pro_stock ?? "";
            m.locat_name = location?.locat_name;
            m.pro_qoh = prolocation?.pro_qoh ?? 0;
            m.ddlobj = prolocatdot;
            return m;
        }

        private ProductModel ExtraMapper(SB_Product product, SB_Progroup productGrpCode, SB_Probrand productBrand, SB_Promodel productModel, SB_ProSize productSize, bool chkProset = false)
        {
            var m = _mapper.Map<ProductModel>(product);
            m.progroup_name = productGrpCode.progroup_name;
            m.probrand_name = productBrand.pro_brand;
            m.promodel_name = productModel.pro_model;
            m.prosize_name = productSize.pro_size;
            m.product_group_code = productGrpCode.product_group_code ?? 0;

            if (chkProset)
                CheckProductSet(m);

            return m;
        }

        private SB_Product GetProPrice(SB_Product product, string cus_code, string cus_type)
        {
            if (cus_type == "02")
            {
                var pp_crdi = new SB_Grooveprice();
                if (_db.SB_Grooveprice.Any(w => w.cus_code == cus_code))
                    pp_crdi = _db.SB_Grooveprice.Where(w => w.cus_code == cus_code && w.pro_code == product.pro_code).OrderByDescending(o => o.groove_id).FirstOrDefault();
                else
                    pp_crdi = _db.SB_Grooveprice.Where(w => w.cus_code == "CREDIT" && w.pro_code == product.pro_code).OrderByDescending(o => o.groove_id).FirstOrDefault();

                if (pp_crdi != null)
                {
                    var cred_startdate = DateTime.ParseExact(pp_crdi.groove_start_date, "dd/MM/yyyy", null);
                    var cred_enddate = DateTime.ParseExact(pp_crdi.groove_end_date, "dd/MM/yyyy", null);

                    if (cred_startdate <= DateTime.Today && cred_enddate >= DateTime.Today)
                    {
                        product.pro_price_retail = pp_crdi.rate_price;
                    }
                }
                return product;
            }
            if (cus_type == "03")
            {
                var pp_pttor = new SB_Grooveprice();
                if (_db.SB_Grooveprice.Any(w => w.cus_code == cus_code))
                    pp_pttor = _db.SB_Grooveprice.Where(w => w.cus_code == cus_code && w.pro_code == product.pro_code).OrderByDescending(o => o.groove_id).FirstOrDefault();
                else
                    pp_pttor = _db.SB_Grooveprice.Where(w => w.cus_code == "PTTOR" && w.pro_code == product.pro_code).OrderByDescending(o => o.groove_id).FirstOrDefault();

                if (pp_pttor != null)
                {
                    var cred_startdate = DateTime.ParseExact(pp_pttor.groove_start_date, "dd/MM/yyyy", null);
                    var cred_enddate = DateTime.ParseExact(pp_pttor.groove_end_date, "dd/MM/yyyy", null);

                    if (cred_startdate <= DateTime.Today && cred_enddate >= DateTime.Today)
                    {
                        product.pro_price_retail = pp_pttor.rate_price;
                    }
                }
                return product;
            }

            var pp = _db.SB_proprice.Where(w => w.pro_code == product.pro_code).FirstOrDefault();
            if (pp != null)
            {
                var propdate = DateTime.ParseExact(pp.proprice_date, "dd/MM/yyyy", null);
                if (propdate <= DateTime.Today)
                    product.pro_price_retail = pp.pro_price_retail;
            }
            else
            {
                var pp_log = _db.SB_Proprice_Log.ToArray().Where(w => w.pro_code == product.pro_code
                                        && DateTime.ParseExact(w.proprice_date, "dd/MM/yyyy", null) <= DateTime.Today).FirstOrDefault();
                if (pp_log != null)
                {
                    product.pro_price_retail = pp_log.pro_price_retail;
                }
            }
            #region .bak
            /*
SELECT top 1 pro_price_retail 
FROM SB_proprice Where pro_code ='8006040001' and 
substring(proprice_date,7,4)+''+substring(proprice_date,4 ,2)+''+substring(proprice_date,1,2) <= 20200811 and cus_groupcode='01' 
order by substring(proprice_date,7,4) desc, substring(proprice_date,4 ,2) desc, substring(proprice_date,1,2) desc

SELECT * FROM SB_Proprice Where pro_code ='FA-90-1-02-0006'-- and proprice_date = '11/08/2020' order by doc_no_run desc

SELECT top 1 pro_price_retail FROM SB_proprice_log Where pro_code ='8006040001' and 
substring(proprice_date,7,4)+''+substring(proprice_date,4 ,2)+''+substring(proprice_date,1,2) <= 20200811 and cus_groupcode='01' 
order by substring(proprice_date,7,4) desc, substring(proprice_date,4 ,2) desc, substring(proprice_date,1,2) desc, id desc

SELECT top 1 * FROM SB_Proprice_Log Where pro_code ='FA-90-1-02-0006' --and proprice_date = '11/08/2020' order by id desc
 */
            #endregion
            return product;
        }
    }
}
