using CentralService.Injection;
using CentralService.Models;
using CentralService.Services;
using HQPosData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQService.Services
{
    public class CustomerService : ICustomerService
    {
        private HQEntities _db;

        public CustomerService(HQEntities conn)
        {
            _db = conn;
        }

        public void CheckAndCreateCustomer(CustomerVehicleModel model, string dealerCode)
        {
            throw new NotImplementedException();
        }

        public object GetCar(string code, int provinceId, string dealerCode)
        {
            var dbModel = _db.SB_CusCar.FirstOrDefault(c => c.car_reg == code && c.car_provid == provinceId);
            return dbModel;
        }

        public object GetCustomer(string code, string dealerCode)
        {
            var dbModel = _db.SB_Customer.FirstOrDefault(c => c.cus_code == code);
            return dbModel;
        }

        public DTResult<CustomerVehicleModel> GetDTResult(DTParameters dtRequestModel, ISearchModel search)
        {
            //string path = HttpContext.Current.Request.Url.AbsolutePath;
            //string path = HttpContext.Current.Request.Url.AbsolutePath;

            var customerQuery = _db.SB_Customer.Where(x => (x.cancel_date == "" || x.cancel_date == null)).ToList()
                 .Join(_db.SB_CusCar.Where(x => x.cancel_date == "" || x.cancel_date == null).ToList(),
                 cus => cus.cus_code,
                 vehicle => vehicle.cus_code,
                 (cus, vehicle) => new { Customer = cus, Vehicle = vehicle });

            customerQuery = customerQuery.Concat(_db.SB_Customer.Where(x => (x.cancel_date == "" || x.cancel_date == null)).ToList().Select(c => new { Customer = c, Vehicle = (SB_CusCar)null }));


            var query = customerQuery
                .GroupJoin(_db.SB_province,
                master => master?.Vehicle?.car_provid,
                prov => prov.add_provid,
                (master, prov) => new { master.Customer, master.Vehicle, prov = prov.FirstOrDefault() })
                .GroupJoin(_db.SB_Cartype,
                m => m.Vehicle?.cartype_code,
                t => t.cartype_code,
                (master, type) => new { master.Customer, master.Vehicle, master.prov, type = type.FirstOrDefault() })
                .GroupJoin(_db.SB_Carbrand,
                m => m.Vehicle?.car_brand_code,
                b => b.car_brand_code,
                (master, brand) => new { master.Customer, master.Vehicle, master.prov, master.type, brand = brand.FirstOrDefault() })
                .GroupJoin(_db.SB_CarModel,
                m => m.Vehicle?.car_model_code,
                g => g.car_model_code,
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
                        query = query.Where(p => p.Customer.cus_name != null && p.Customer.cus_name.Contains(search.ValueSearch));
                        break;
                    case 3:
                        query = query.Where(p => p.Customer.add_mobile != null && p.Customer.add_mobile.Contains(search.ValueSearch));
                        break;
                    case 4:
                        query = query.Where(p => p.Customer.cus_member != null && p.Customer.cus_member.Contains(search.ValueSearch));
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
                        query = DatatableTools.SortDatetable(query, sort, p => p.brand != null ? p.brand.car_brand : null);
                        break;
                    case 6:
                        query = DatatableTools.SortDatetable(query, sort, p => p.gen != null ? p.gen.car_model : null);
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
                    Brand = q.brand?.car_brand,
                    Generation = q.gen?.car_model,
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

        public DTResult<CustomerVehicleModel> GetDTResultCallHq(DTParameters dtRequestModel, ISearchModel search, string dealerCode)
        {
            throw new NotImplementedException();
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

        public int UpdateIPFromClient(IpV4 req)
        {
            int success = 0;
            if (req != null)
            {
                var sbs = _db.SB_System.FirstOrDefault(w => w.dealercode == req.dealerCode);
                sbs.client_url = "http://" + req.AddsIP + "/PTT_Client_1/WebService/webclient.asmx/";
                //success += _db.SaveChanges();

                var dm = _db.SB_Dealercode_Master.FirstOrDefault(w => w.dealercode == req.dealerCode);
                dm.http_path = "http://" + req.AddsIP + "/PTT_Client_1/WebService/webclient.asmx/";
                dm.ip_address = req.AddsIP;
                dm.ip_address_pub = req.AddsIP;

                success = _db.SaveChanges();
            }
            return success;
        }
    }
}
