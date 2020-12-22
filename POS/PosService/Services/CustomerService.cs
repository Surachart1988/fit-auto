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
    public class CustomerService : ICustomerService
    {
        private Entities _db;
        private Mapper _mapper;
        public CustomerService(Entities conn, Mapper mapper)
        {
            _db = conn;
            _mapper = mapper;
        }

        public void CheckAndCreateCustomer(CustomerVehicleModel model, string dealerCode)
        {
            bool isSave = false;
            var customerModel_0 = _db.SB_Customer.FirstOrDefault(c => c.cus_code == model.CustomerCode);
            if (customerModel_0 != null)
            {

                //_db.Entry(customerModel_0).State = EntityState.Deleted;
                //_db.SaveChanges();
            }
            var posCusModel = _db.SB_Customer.FirstOrDefault(c => c.cus_code == model.CustomerCode);
            //var newCusModel = _db.SB_Customer.FirstOrDefault(c => c.cus_code == dbCustomer.cus_code && c.dealercode == dbCustomer.dealercode);
            var carModel = _db.SB_CusCar.FirstOrDefault(c => c.car_reg == model.License && c.car_provid == model.VehicleProvinceId);
            //if (customerModel != null && carModel != null) return;

            if (posCusModel == null)
            {
                SB_Customer dbCustomer = (SB_Customer)GetCustomer(model.CustomerCode, dealerCode);

                dbCustomer.Cus_code_run = 0;
                dbCustomer.cus_code = CheckCusCodePos(dbCustomer.cus_code);
                _db.SB_Customer.Add(dbCustomer); isSave = true;
            }
            else if (model.CustomerName != posCusModel.cus_name)
            {
                SB_Customer dbCustomer = (SB_Customer)GetCustomer(model.CustomerCode, dealerCode);
                dbCustomer.Cus_code_run = 0;
                dbCustomer.cus_code = CheckCusCodePos(dbCustomer.cus_code);
                _db.SB_Customer.Add(dbCustomer); isSave = true;
            }

            if (carModel == null && model.VehicleProvinceId != null && !string.IsNullOrWhiteSpace(model.License))
            {
                SB_CusCar dbCar = (SB_CusCar)GetCar(model.License, (int)model.VehicleProvinceId, dealerCode);
                dbCar.DOC_NO_RUN = 0;
                _db.SB_CusCar.Add(dbCar);
                isSave = true;
            }

            if (isSave) _db.SaveChanges();
        }

        private string CheckCusCodePos(string cus_code)
        {
            var customerModel = _db.SB_Customer.FirstOrDefault(c => c.cus_code == cus_code);
            if (customerModel == null)
            {
                return cus_code;
            }

            string stext = cus_code.Substring(3, cus_code.Length - 3);
            var newcode = int.Parse(stext) + 1;
            cus_code = cus_code.Substring(0, 3) + newcode;

            return CheckCusCodePos(cus_code);
        }

        public RegisterBlueCardModel GetBranchDetail()
        {
            var data = _db.SB_Branch.FirstOrDefault();
            return new RegisterBlueCardModel()
            {
                MID = data?.MID,
                TID = data?.TID
            };
        }

        public object GetCar(string code, int provinceId, string dealerCode)
        {
            var hqPath = _db.SB_System.First(s => s.dealercode == dealerCode).hq_url.ToUpper().Replace("PTT_HQ/WEBSERVICE/WEBHQ.ASMX/", "FIT_HQ");
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{hqPath}/Home/GetCar?license={code}&provinceId={provinceId}");
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    return (SB_CusCar)Newtonsoft.Json.JsonConvert.DeserializeObject(result.Result, typeof(SB_CusCar));
                }
                else
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    Console.WriteLine(result.Result);
                    return null;
                }
            }
        }

        public object GetCustomer(string code, string dealerCode)
        {
            var hqPath = _db.SB_System.First(s => s.dealercode == dealerCode).hq_url.ToUpper().Replace("PTT_HQ/WEBSERVICE/WEBHQ.ASMX/", "FIT_HQ");
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{hqPath}/Home/GetCustomer?customerCode={code}");
                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    return (SB_Customer)Newtonsoft.Json.JsonConvert.DeserializeObject(result.Result, typeof(SB_Customer));
                }
                else
                {
                    var result = response.Result.Content.ReadAsStringAsync();
                    Console.WriteLine(result.Result);
                    return null;
                }
            }
        }

        public DTResult<CustomerVehicleModel> GetDTResult(DTParameters dtRequestModel, ISearchModel search)
        {

            //var test = _db.SB_CusCar.ToList();
            var customerQuery = _db.SB_Customer.Where(x => x.cancel_date == "" || x.cancel_date == null).ToList()
                 .Join(_db.SB_CusCar.Where(x => x.cancel_date == "" || x.cancel_date == null).ToList(),
                 cus => cus.cus_code,
                 vehicle => vehicle.cus_code,
                 (cus, vehicle) => new { Customer = cus, Vehicle = vehicle });

            customerQuery = customerQuery.Concat(_db.SB_Customer.Where(x => x.cancel_date == "" || x.cancel_date == null).ToList().Select(c => new { Customer = c, Vehicle = (SB_CusCar)null }));

            var query = customerQuery
                .GroupJoin(_db.SB_province,
                master => master?.Vehicle?.car_provid,
                prov => prov?.add_provid,
                (master, prov) => new { master.Customer, master.Vehicle, prov = prov.FirstOrDefault() })
                .GroupJoin(_db.SB_Cartype,
                m => m.Vehicle?.cartype_code,
                t => t?.cartype_code,
                (master, type) => new { master.Customer, master.Vehicle, master.prov, type = type.FirstOrDefault() })
                .GroupJoin(_db.SB_CarBrand,
                m => m.Vehicle?.car_brand_code,
                b => b?.Car_Brand_Code,
                (master, brand) => new { master.Customer, master.Vehicle, master.prov, master.type, brand = brand.FirstOrDefault() })
                .GroupJoin(_db.SB_CarModel,
                m => m?.Vehicle?.car_model_code,
                g => g?.Car_Model_Code,
                 (master, gen) => new { master.Customer, master.Vehicle, master.prov, master.type, master.brand, gen = gen.FirstOrDefault() });



            if (!string.IsNullOrWhiteSpace(search.ValueSearch))
            {
                switch (search.KeySearch)
                {
                    default:
                        query = query.Where(c => (c.Customer != null && c.Customer.cus_name.Contains(search.ValueSearch))
                                                 || (c.Customer.cus_code != null && c.Customer.cus_code.Contains(search.ValueSearch))
                                                 || (c.Customer.add_mobile != null && c.Customer.add_mobile.Contains(search.ValueSearch))
                                                 || (c.Customer.cus_member != null && c.Customer.cus_member.Contains(search.ValueSearch))
                                                 || (c.Vehicle != null && c.Vehicle.car_reg.Contains(search.ValueSearch)));
                        break;
                    case 1:
                        query = query.Where(p => p.Vehicle != null && p.Vehicle.car_reg.Contains(search.ValueSearch));
                        break;
                    case 2:
                        query = query.Where(p => p.Customer.cus_name.Contains(search.ValueSearch));
                        break;
                    case 3:
                        query = query.Where(p => p.Customer.add_mobile.Contains(search.ValueSearch));
                        break;
                    case 4:
                        query = query.Where(p => p.Customer.cus_member.Contains(search.ValueSearch));
                        break;
                }
            }
            else
            {
                var dtModel1 = new DTResult<CustomerVehicleModel>()
                {
                    data = new List<CustomerVehicleModel>(),
                    draw = dtRequestModel.Draw,
                    recordsFiltered = 0,
                    recordsTotal = 0
                };

                return dtModel1;
            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle == null ? "ลูกค้า" : "รถ");
                        break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle != null ? p.Vehicle.car_reg : null);
                        break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.prov != null ? p.prov.add_province : null);
                        break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_code);
                        break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_name);
                        break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.brand != null ? p.brand.Car_Brand : null);
                        break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.gen != null ? p.gen.Car_Model : null);
                        break;
                    case 7:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle != null ? p.Vehicle.car_color : null);
                        break;
                    case 8:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle != null ? p.Vehicle.last_mileage : null);
                        break;
                    case 9:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_member);
                        break;
                    case 10:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.add_mobile);
                        break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);

            var model = query.ToArray().Select(q =>
            {
                return new CustomerVehicleModel
                {
                    CustomerCode = q.Customer?.cus_code,
                    CustomerName = q.Customer?.cus_name,
                    BlueCard = q.Vehicle == null ? q.Customer?.cus_member : null,
                    Tel = q.Customer?.add_mobile,
                    VehicleProvince = q.prov?.add_province,
                    Brand = q.brand?.Car_Brand,
                    Generation = q.gen?.Car_Model,
                    VehicleProvinceId = q.Vehicle?.car_provid,
                    TypeName = q.Vehicle == null ? "ลูกค้า" : "รถ",
                    License = q.Vehicle?.car_reg,
                    Color = q.Vehicle?.car_color,
                    LastMileage = q.Vehicle != null && q.Vehicle.last_mileage <= 0 ? q.Vehicle.first_mileage : q.Vehicle?.last_mileage,
                    LastContdate = q.Vehicle?.last_contdate,
                    Chassis = q.Vehicle?.car_chasis
                };
            });

            var dtModel = new DTResult<CustomerVehicleModel>()
            {
                data = model.ToList(),
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public async Task<DTResult<CustomerVehicleModel>> GetDTResultCallHqAsync(DTParameters dtRequestModel, ISearchModel search, string dealerCode)
        {
            var hqPath = _db.SB_System.First(s => s.dealercode == dealerCode).hq_url.ToUpper().Replace("PTT_HQ/WEBSERVICE/WEBHQ.ASMX/", "FIT_HQ");
            //hqPath = "http://localhost:10000/";
            using (HttpClient client = new HttpClient())
            {
                var model = new { dtRequestModel, search };
                var content = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("Draw", dtRequestModel.Draw.ToString()),
                new KeyValuePair<string, string>("Length", dtRequestModel.Length.ToString()),
                new KeyValuePair<string, string>("Order[0].Column", dtRequestModel.Order[0].Column.ToString()),
                new KeyValuePair<string, string>("Order[0].Dir", dtRequestModel.Order[0].Dir.ToString()),
                new KeyValuePair<string, string>("KeySearch", search.KeySearch.ToString()),
                new KeyValuePair<string, string>("ValueSearch", search.ValueSearch?.ToString())
            });
                var resp = await client.PostAsync($"{hqPath}/Home/GetDTResult", content);
                if (resp != null && resp.Content != null)
                {
                    //var result = response.Result.Content.ReadAsStringAsync();
                    var result = await resp.Content.ReadAsStringAsync();
                    return (DTResult<CustomerVehicleModel>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(DTResult<CustomerVehicleModel>));
                }
                else
                {
                    return null;
                }
            }
        }

        public List<IdNameModel> GetKeySearchList()
        {
            return new List<IdNameModel>
            {
                new IdNameModel
                    {
                        Id = 0,
                        Name = "ทั้งหมด"
                    },
                    new IdNameModel
                    {
                        Id = 1,
                        Name = "ทะเบียนรถ"
                    },
                    new IdNameModel
                    {
                        Id = 2,
                        Name = "ชื่อลูกค้า"
                    },
                    new IdNameModel
                    {
                        Id = 3,
                        Name = "เบอร์โทรศัพท์"
                    },
                    new IdNameModel
                    {
                        Id = 4,
                        Name = "Blue card"
                    }
            };
        }

        public DTResult<CusCarRegModel> CarRegList(DTParameters dtRequestModel)
        {
            var query = _db.SB_CusCar.Where(w => w.cancel_date == "" || w.cancel_date == null)
                .GroupJoin(_db.SB_Customer,
                    _ => _.cus_code,
                    c => c.cus_code,
                    (vehicle, cus) => new { Customer = cus.FirstOrDefault(), Vehicle = vehicle })
                    .GroupJoin(_db.SB_Custype,
                        master => master.Customer.custype_code,
                        type => type.custype_code,
                        (master, type) => new { master.Customer, master.Vehicle, Custype = type.FirstOrDefault() })
                        .GroupJoin(_db.SB_province,
                            master => master.Vehicle.car_provid,
                            prov => prov.add_provid,
                            (master, prov) => new { master.Customer, master.Vehicle, master.Custype, prov = prov.FirstOrDefault() })
                            .GroupJoin(_db.SB_CarBrand,
                                m => m.Vehicle.car_brand_code,
                                b => b.Car_Brand_Code,
                                (master, brand) => new { master.Customer, master.Vehicle, master.Custype, master.prov, brand = brand.FirstOrDefault() })
                                .GroupJoin(_db.SB_CarModel,
                                    m => m.Vehicle.car_model_code,
                                    g => g.Car_Model_Code,
                                     (master, gen) => new { master.Customer, master.Vehicle, master.Custype, master.prov, master.brand, gen = gen.FirstOrDefault() });

            if (!string.IsNullOrWhiteSpace(dtRequestModel.Search.Value))
            {
                query = query.Where(w =>
                w.Vehicle.car_reg.Contains(dtRequestModel.Search.Value) ||
                    w.prov.add_province.Contains(dtRequestModel.Search.Value) ||
                        w.Customer.cus_name.Contains(dtRequestModel.Search.Value) ||
                            w.Customer.add_mobile.Contains(dtRequestModel.Search.Value) ||
                                w.brand.Car_Brand.Contains(dtRequestModel.Search.Value) ||
                                    w.gen.car_brand.Contains(dtRequestModel.Search.Value) ||
                                        w.gen.Car_Model.Contains(dtRequestModel.Search.Value) ||
                                            w.Customer.cus_code.Contains(dtRequestModel.Search.Value) ||
                                                w.Customer.cus_member.Contains(dtRequestModel.Search.Value) ||
                                                    w.Vehicle.car_color.Contains(dtRequestModel.Search.Value));

            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle.car_reg); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.prov.add_province); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_name); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.add_mobile); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.brand.Car_Brand); break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.gen.Car_Model); break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Vehicle.car_color); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraMapper(q.Vehicle, q.Customer, q.prov, q.brand, q.gen, q.Custype));
            var dtModel = new DTResult<CusCarRegModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }

        public DTResult<CusCarRegModel> CustomerList(DTParameters dtRequestModel)
        {
            var query = _db.SB_Customer.Where(w => (w.cancel_date == "" || w.cancel_date == null) && w.custype_code != "03")//LEFT(a.cus_code,1) <> 'E'
                .GroupJoin(_db.SB_Custype_pay,
                    _ => _.cus_paytype,
                    c => c.custype_pay_code,
                    (cus, pay) => new { Customer = cus, CustypePay = pay.FirstOrDefault() })
                    .GroupJoin(_db.SB_Custype,
                        master => master.Customer.custype_code,
                        type => type.custype_code,
                        (master, type) => new { master.Customer, master.CustypePay, Custype = type.FirstOrDefault() });

            if (!string.IsNullOrWhiteSpace(dtRequestModel.Search.Value))
            {
                query = query.Where(w =>
                w.Customer.cus_code.Contains(dtRequestModel.Search.Value) ||
                    w.Customer.pre_name.Contains(dtRequestModel.Search.Value) ||
                        w.Customer.cus_name.Contains(dtRequestModel.Search.Value) ||
                            w.Custype.custype_name.Contains(dtRequestModel.Search.Value));

            }

            foreach (var sort in dtRequestModel.Order ?? (new DTOrder[1]))
            {
                if (sort == null) break;
                switch (sort.Column)
                {
                    default:
                    case 0:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_code); break;
                    case 1:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.pre_name); break;
                    case 2:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.cus_name); break;
                    case 3:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Custype.custype_name); break;
                    case 4:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.credit_limit); break;
                    case 5:
                        query = DatatableTools.SortDatetable(query, sort, p => p.Customer.credit_bal); break;
                }
            }

            var countTotal = query.Count();

            query = query.Skip(dtRequestModel.Start).Take(dtRequestModel.Length);
            var model = query.ToArray().Select(q => ExtraMapper2(q.Customer, q.CustypePay, q.Custype));
            var dtModel = new DTResult<CusCarRegModel>()
            {
                data = model,
                draw = dtRequestModel.Draw,
                recordsFiltered = countTotal,
                recordsTotal = countTotal
            };

            return dtModel;
        }
        private CusCarRegModel ExtraMapper2(SB_Customer customer, SB_Custype_pay custypePay, SB_Custype custype)
        {

            var m = _mapper.Map<CusCarRegModel>(customer);
            m.custype_code = custype?.custype_code ?? "";
            m.custype_pay = custypePay?.custype_pay_name ?? "";
            m.custype_name = custype?.custype_name ?? "";
            return m;
        }
        private CusCarRegModel ExtraMapper(SB_CusCar vehicle, SB_Customer customer, SB_province prov, SB_CarBrand brand, SB_CarModel gen, SB_Custype custype)
        {

            var m = _mapper.Map<CusCarRegModel>(vehicle);
            m.cus_name = customer.cus_name;
            m.add_mobile = customer.add_mobile;
            m.add_tel = customer.add_tel;
            m.custype_code = custype?.custype_code ?? "";
            m.add_province = prov.add_province;
            m.car_brand = brand.Car_Brand;
            m.car_model = gen?.Car_Model ?? "";
            return m;
        }
    }
}
